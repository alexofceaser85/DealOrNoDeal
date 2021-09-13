using System.Collections.Generic;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DealOrNoDeal.View.UpdateGUI
{
    /// <summary>
    /// Updates the dollar labels
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public static class UpdateDollarLabels
    {
        /// <summary>
        /// Finds a dollar label and grays it out
        ///
        /// Precondition: None
        /// Postcondition: dollarAmountLabels.get(amount).Background == new SolidColorBrush(Colors.Gray)
        /// </summary>
        /// <param name="dollarAmountLabels">The dollar amount labels from which one can be grayed out</param>
        /// <param name="amount">The dollar amount of the label to gray out</param>
        public static void FindAndGrayOutGameDollarLabel(IList<Border> dollarAmountLabels, int amount)
        {
            foreach (var currentDollarAmountLabel in dollarAmountLabels)
            {
                if (grayOutLabelIfMatchesDollarAmount(amount, currentDollarAmountLabel))
                {
                    break;
                }
            }
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border currentDollarAmountLabel)
        {
            var matched = false;

            if (currentDollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                matched = setBackgroundToGrayIfLabelMatchesDollarAmount(amount, currentDollarAmountLabel, dollarTextBlock);
            }

            return matched;
        }

        private static bool setBackgroundToGrayIfLabelMatchesDollarAmount(int amount, Border currentDollarAmountLabel,
            TextBlock dollarTextBlock)
        {
            var labelAmount = int.Parse(dollarTextBlock.Text, NumberStyles.Currency);

            if (labelAmount != amount)
            {
                return false;
            }

            currentDollarAmountLabel.Background = new SolidColorBrush(Colors.Gray);
            return true;
        }
    }
}
