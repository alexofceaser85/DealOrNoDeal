using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    public static class UpdateDealAndNoDealButton
    {
        public static void ToggleDealButtonAndNoDealButtonVisibility(Button dealButton, Button noDealButton)
        {
            if (dealButton.Visibility == Visibility.Collapsed &&
                noDealButton.Visibility == Visibility.Collapsed)
            {
                dealButton.Visibility = Visibility.Visible;
                noDealButton.Visibility = Visibility.Visible;
            }
            else
            {
                dealButton.Visibility = Visibility.Collapsed;
                noDealButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
