using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    public class UpdateSummaryOutput
    {
        private readonly FormattedOffers formattedOffers;
        private readonly TextBlock summaryOutput;

        private const int CasesLeftToEndRound = 0;
        private const string AskUserDealOrNoDeal = "Deal or No Deal?";

        public UpdateSummaryOutput(FormattedOffers formattedOffers, TextBlock summaryOutput)
        {
            this.formattedOffers = formattedOffers;
            this.summaryOutput = summaryOutput;
        }

        public void UpdateSummaryOutputTextForSelectionOfBriefcase(GameManager gameManager)
        {
            if (gameManager.IsSelectingStartingCase)
            {
                displayStartingCaseSelectionSummaryInformation(gameManager);
            }
            else if (gameManager.RoundManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                this.formattedOffers.UpdateFormattedOffers(gameManager);
                displaySummaryInformationNeededForEndOfRound();
            }
        }

        private void displayStartingCaseSelectionSummaryInformation(GameManager gameManager)
        {
            var playerSelectedStartingCaseMessage = $"Your case: {gameManager.PlayerSelectedStartingCase + 1}";
            this.summaryOutput.Text = playerSelectedStartingCaseMessage;
        }

        private void displaySummaryInformationNeededForEndOfRound()
        {
            var bankerMinimumOfferAndBankerMaximumOfferMessage =
                $"Offers : Min: {this.formattedOffers.FormattedMinimumOffer} Max: {this.formattedOffers.FormattedMaximumOffer}\n";
            var bankerCurrentOfferMessage = $"Current offer: {this.formattedOffers.FormattedCurrentOffer}\n";
            this.summaryOutput.Text =
                bankerMinimumOfferAndBankerMaximumOfferMessage + bankerCurrentOfferMessage + AskUserDealOrNoDeal;
        }

        public void DisplaySummaryOutputForDeniedDeal()
        {
            this.summaryOutput.Text =
                $"Offers : Min: {this.formattedOffers.FormattedMinimumOffer} Max: {this.formattedOffers.FormattedMaximumOffer}\n"
                + $"Last offer: {this.formattedOffers.FormattedCurrentOffer}\n";
        }

        public void UpdateSummaryOutputForDealButtonClick(GameManager gameManager, int playerStartingCase, int finalRound)
        {
            this.displaySummaryInformationForAcceptedDeal(gameManager, playerStartingCase);
        }

        private void displaySummaryInformationForFinalRound()
        {
            var bankerMinimumOfferAndBankerMaximumOfferMessage =
                $"Offers : Min: {this.formattedOffers.FormattedMinimumOffer} Max: {this.formattedOffers.FormattedMaximumOffer}\n"
                + $"Average: {this.formattedOffers.FormattedAverageOffer}";
            this.summaryOutput.Text = bankerMinimumOfferAndBankerMaximumOfferMessage;
        }

        private void displaySummaryInformationForAcceptedDeal(GameManager gameManager, int playerStartingCase)
        {
            this.summaryOutput.Text =
                $"Your case contained: {FormattedBriefcaseValue.GetFormattedBriefcaseValue(gameManager, playerStartingCase)}\n"
                + $"Accepted offer: {this.formattedOffers.FormattedCurrentOffer}\n"
                + "GAME OVER";
        }

        public void UpdateSummaryTextForFinalBriefcaseSelection(GameManager gameManager, Button selectedBriefcase)
        {
            this.summaryOutput.Text =
                $"Congrats you win: {FormattedBriefcaseValue.GetFormattedBriefcaseValue(gameManager, int.Parse(selectedBriefcase.Tag.ToString()))}\n"
                + "\n"
                + "GAME OVER";
        }

    }
}
