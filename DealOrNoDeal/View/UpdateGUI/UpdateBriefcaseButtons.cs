using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.UpdateGUI
{
    /// <summary>
    /// Holds the GUI behavior for a briefcase button click
    ///
    /// Author: Alex DeCesare
    /// Version: 05-September-2021
    /// </summary>
    public static class UpdateBriefcaseButtons
    {
        /// <summary>
        /// Enables all of the briefcase buttons
        ///
        /// Precondition: None
        /// Postcondition: EACH briefcaseButton in briefcaseButtons briefcaseButton.IsEnabled == true
        /// </summary>
        /// <param name="briefcaseButtons">The briefcase buttons to enable</param>
        public static void EnableBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Disables all of the briefcase buttons
        ///
        /// Precondition: None
        /// Postcondition: EACH briefcaseButton in briefcaseButtons briefcaseButton.IsEnabled == false
        /// </summary>
        /// <param name="briefcaseButtons">The briefcase buttons to disable</param>
        public static void DisableBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Hides all of the briefcase buttons
        ///
        /// Precondition: None
        /// Postcondition: EACH briefcaseButton in briefcaseButtons briefcaseButton.Visibility == Visibility.Collapsed
        /// </summary>
        /// <param name="briefcaseButtons">The briefcase buttons to hide</param>
        public static void HideBriefcaseButtons(IList<Button> briefcaseButtons)
        {
            foreach (var briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Updates the briefcase buttons for the round before the final round
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="remainingButtons">The  button that was selected</param>
        /// <param name="playerSelectedStartingCaseButton"></param>
        public static void UpdateBriefcasesForBeforeFinalRound(IList<Button> remainingButtons, Button playerSelectedStartingCaseButton)
        {
            var remainingButton = remainingButtons[0];
            playerSelectedStartingCaseButton.Visibility = Visibility.Visible;
            remainingButton.Visibility = Visibility.Visible;
            remainingButton.IsEnabled = true;

            var remainingButtonGrid = getPrimaryButtonGrid(remainingButton);
            clearBriefcaseButtons(remainingButtonGrid);
            var panelToAddTo = getMiddleButtonPanel(remainingButtonGrid);

            addButtonsToMiddlePanel(panelToAddTo, remainingButton, playerSelectedStartingCaseButton);
        }

        private static Grid getPrimaryButtonGrid(FrameworkElement remainingButton)
        {

            var remainingButtons = remainingButton.Parent as StackPanel;
            if (remainingButtons is StackPanel remainingButtonPanel)
            {
                return getRemainingButtonGrid(remainingButtonPanel);
            }

            return null;
        }

        private static Grid getRemainingButtonGrid(FrameworkElement remainingButtonPanel)
        {
            var remainingButtonPanelParent = remainingButtonPanel.Parent;

            if (remainingButtonPanelParent is Grid remainingButtonGrid)
            {
                return remainingButtonGrid.Parent as Grid;
            }

            return null;
        }

        private static void clearBriefcaseButtons(Panel remainingButton)
        {
            var currentGridRow = 0;
            while (currentGridRow <= 4)
            {
                var buttonGrid = remainingButton.Children[currentGridRow] as Grid;
                currentGridRow = clearPanelsInCurrentButtonGrid(buttonGrid, currentGridRow);
            }
        }

        private static int clearPanelsInCurrentButtonGrid(Panel buttonGrid, int currentGridRow)
        {
            if (buttonGrid != null)
            {
                currentGridRow = clearButtonsInCurrentPanel(buttonGrid, currentGridRow);
            }

            return currentGridRow;
        }

        private static int clearButtonsInCurrentPanel(Panel buttonGrid, int currentGridRow)
        {
            if (buttonGrid.Children[0] is StackPanel gridButtonPanel)
            {
                gridButtonPanel.Children.Clear();
            }

            currentGridRow++;
            return currentGridRow;
        }

        private static StackPanel getMiddleButtonPanel(Grid buttonGrid)
        {
            var buttonGridChildren = buttonGrid.Children;

            if (!(buttonGridChildren[2] is Grid buttonGridToAddTo))
            {
                return null;
            }

            return buttonGridToAddTo.Children[0] as StackPanel;
        }

        private static void addButtonsToMiddlePanel(Panel panelToAddTo, FrameworkElement remainingButton,
            FrameworkElement startingBriefcaseButton)
        {

            if (int.Parse(remainingButton.Tag.ToString()) > int.Parse(startingBriefcaseButton.Tag.ToString()))
            {
                panelToAddTo.Children.Add(startingBriefcaseButton);
                panelToAddTo.Children.Add(remainingButton);
            }
            else
            {
                panelToAddTo.Children.Add(remainingButton);
                panelToAddTo.Children.Add(startingBriefcaseButton);
            }
        }
    }
}
