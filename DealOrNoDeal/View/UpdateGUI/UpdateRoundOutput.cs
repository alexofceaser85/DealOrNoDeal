using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.UpdateGUI
{
    /// <summary>
    /// Updates the round output
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public class UpdateRoundOutput
    {
        private const string TellUserToSelectACaseBelowMessage = "Select a case below";
        private const string TellUserThatThisRoundIsTheFinalRoundMessage = "This is the final round";

        /// <summary>
        /// Updates the current round information
        ///
        /// Precondition: None
        /// Postcondition:
        /// casesToOpenLabel.Text != casesToOpenLabel.Text@prev
        /// roundLabel.Text != roundLabel.Text@prev
        /// </summary>
        /// <param name="gameManager">The game manager to use to update the round information</param>
        /// <param name="casesToOpenLabel">The label that displays the cases to open</param>
        /// <param name="roundLabel">The label that displays the round</param>
        public static void UpdateCurrentRoundInformation(GameManager gameManager, TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            if (gameManager.RoundManager.IsOnFinalRound())
            {
                updateRoundInformationNeededForFinalRound(casesToOpenLabel, roundLabel);
            }
            else
            {
                updateRoundInformationNeededForGamePlayWithinRound(gameManager, casesToOpenLabel, roundLabel);
            }
        }

        private static void updateRoundInformationNeededForFinalRound(TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            casesToOpenLabel.Text = TellUserToSelectACaseBelowMessage;
            roundLabel.Text = TellUserThatThisRoundIsTheFinalRoundMessage;
        }

        private static void updateRoundInformationNeededForGamePlayWithinRound(GameManager gameManager, TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            var currentRoundAndCasesAvailableForRoundMessage =
                $"Round {gameManager.RoundManager.CurrentRound}: {gameManager.RoundManager.CasesAvailableForCurrentRound} cases to open";
            var numberOfCasesLeftToOpenForRoundMessage =
                $"{gameManager.RoundManager.CasesLeftForCurrentRound} more cases to open";

            roundLabel.Text = currentRoundAndCasesAvailableForRoundMessage;
            casesToOpenLabel.Text = numberOfCasesLeftToOpenForRoundMessage;
        }
    }
}
