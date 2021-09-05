using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    public static class UpdateDollarLabels
    {

        public static void FindAndGrayOutGameDollarLabel(IList<Border> dollarAmountLabels, int amount)
        {
            foreach (var currDollarAmountLabel in dollarAmountLabels)
            {
                if (grayOutLabelIfMatchesDollarAmount(amount, currDollarAmountLabel))
                {
                    break;
                }
            }
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border currDollarAmountLabel)
        {
            var matched = false;

            if (currDollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                matched = setBackgroundToGrayIfLabelMatchesDollarAmount(amount, currDollarAmountLabel, dollarTextBlock);
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
