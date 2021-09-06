using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.InitializeDealOrNoDealPageGUI
{
    /// <summary>
    /// Sets the versions of the dollar amount labels for the GUI
    ///
    /// Author: Alex DeCesare
    /// Version: 06-September-2021
    /// </summary>
    public static class DollarAmountVersions
    {
        private const int QuickPlayNumberOfVisibleCasesPerSide = 9;

        public static void BuildDollarAmountLabelsForSyndicatedGame(IList<Border> dollarAmountLabels,
            IList<int> dollarAmounts)
        {
            for (int i = 0; i < dollarAmounts.Count; i++)
            {
                TextBlock dollarAmountText = (TextBlock) dollarAmountLabels[i].Child;

                dollarAmountText.Text = $"${dollarAmounts[i]}";
            }
        }

        public static void BuildDollarAmountLabelsForQuickPlayGame(IList<Border> dollarAmountLabels,
            IList<int> dollarAmounts)
        {
            IList<Border> iterableDollarAmountLabels = new List<Border>(dollarAmountLabels);
            int initialDefaultDollarAmountLabelsPerSide = dollarAmountLabels.Count / 2;
            int currentDollarAmountLabelsPerSide = 0;
            int indexOfCurrentDollarAmount = 0;

            foreach (Border dollarLabel in iterableDollarAmountLabels)
            {
                if (currentDollarAmountLabelsPerSide >= initialDefaultDollarAmountLabelsPerSide)
                {
                    currentDollarAmountLabelsPerSide = 0;
                } 
                if (currentDollarAmountLabelsPerSide < QuickPlayNumberOfVisibleCasesPerSide)
                {
                    TextBlock dollarAmountText = (TextBlock)dollarLabel.Child;
                    dollarAmountText.Text = $"${dollarAmounts[indexOfCurrentDollarAmount]}";
                    indexOfCurrentDollarAmount++;
                    currentDollarAmountLabelsPerSide++;
                } else if (currentDollarAmountLabelsPerSide < initialDefaultDollarAmountLabelsPerSide)
                {
                    dollarLabel.Visibility = Visibility.Collapsed;
                    dollarAmountLabels.Remove(dollarLabel);
                    currentDollarAmountLabelsPerSide++;
                }
            }
        }
    }
}
