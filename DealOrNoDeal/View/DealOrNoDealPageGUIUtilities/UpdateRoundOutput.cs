using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    public class UpdateRoundOutput
    {
        private const string TellUserToSelectACaseBelowMessage = "Select a case below";
        private const string TellUserThatThisRoundIsTheFinalRoundMessage = "This is the final round";

        public static void UpdateCurrentRoundInformation(GameManager gameManager, int finalRound, TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            if (gameManager.RoundManager.CurrentRound == finalRound)
            {
                displayRoundInformationNeededForFinalRound(casesToOpenLabel, roundLabel);
            }
            else
            {
                displayRoundInformationNeededForGameplayWithinRound(gameManager, casesToOpenLabel, roundLabel);
            }
        }

        private static void displayRoundInformationNeededForFinalRound(TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            casesToOpenLabel.Text = TellUserToSelectACaseBelowMessage;
            roundLabel.Text = TellUserThatThisRoundIsTheFinalRoundMessage;
        }

        private static void displayRoundInformationNeededForGameplayWithinRound(GameManager gameManager, TextBlock casesToOpenLabel, TextBlock roundLabel)
        {
            var currentRoundAndCasesAvailableForRoundMessage =
                $"Round {gameManager.RoundManager.CurrentRound.ToString()}: {gameManager.RoundManager.CasesAvailableForCurrentRound} cases to open";
            var numberOfCasesLeftToOpenForRoundMessage =
                $"{gameManager.RoundManager.CasesLeftForCurrentRound.ToString()} more cases to open";

            roundLabel.Text = currentRoundAndCasesAvailableForRoundMessage;
            casesToOpenLabel.Text = numberOfCasesLeftToOpenForRoundMessage;
        }
    }
}
