using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    /// <summary>
    /// Holds the GUI behavior for a briefcase button click
    ///
    /// Author: Alex DeCesare
    /// Version: 05-September-2021
    /// </summary>
    public static class UpdateBriefcaseButtons
    {
        public static void EnableBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.IsEnabled = true;
            }
        }

        public static void DisableBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.IsEnabled = false;
            }
        }

        public static void HideBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
