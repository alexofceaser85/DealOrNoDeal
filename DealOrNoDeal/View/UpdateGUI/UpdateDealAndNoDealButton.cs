using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.UpdateGUI
{
    /// <summary>
    /// Updates the deal and no deal buttons
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public static class UpdateDealAndNoDealButton
    {
        /// <summary>
        /// Toggles the visibility of the deal and no deal buttons
        ///
        /// Precondition: None
        /// Postcondition: IF dealButton.Visibility == Visibility.Collapsed AND noDealButton.Visibility == Visibility.Collapsed
        ///                THEN dealButton.Visibility = Visibility.Visible AND noDealButton.Visibility = Visibility.Visible
        ///                ELSE
        ///                dealButton.Visibility = Visibility.Collapsed AND noDealButton.Visibility = Visibility.Collapsed
        /// </summary>
        /// <param name="dealButton">The deal button to toggle the visibility</param>
        /// <param name="noDealButton">The no deal button to toggle the visibility</param>
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
