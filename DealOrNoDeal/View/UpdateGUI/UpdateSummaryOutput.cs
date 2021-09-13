using System;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;
using DealOrNoDeal.View.FormattedValues;

namespace DealOrNoDeal.View.UpdateGUI
{
    /// <summary>
    /// This class updates the summary output
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public class UpdateSummaryOutput
    {
        private readonly TextBlock summaryOutput;

        private const int CasesLeftToEndRound = 0;
        private const int SpacesForAverageMargin = 13;
        private const string AskUserDealOrNoDeal = "Deal or No Deal?";

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSummaryOutput" /> class.
        ///
        /// Precondition:
        /// summaryOutput != null
        ///
        /// Postcondition:
        /// this.summaryOutput == summaryOutput
        /// </summary>
        /// <param name="summaryOutput">The summary output to update</param>
        public UpdateSummaryOutput(TextBlock summaryOutput)
        {
            this.summaryOutput = summaryOutput;
        }

        /// <summary>
        /// Updates the summary output text when a briefcase is selected
        ///
        /// Precondition: None
        /// Postcondition: this.summaryOutput.Text != this.summaryOutput.Text@prev
        /// </summary>
        /// <param name="gameManager">The game manager for the summary text</param>
        /// <param name="formattedOffers">The formatted offers for the summary text</param>
        public void UpdateSummaryOutputTextForSelectionOfBriefcase(GameManager gameManager, FormattedOffers formattedOffers)
        {
            if (gameManager.IsSelectingStartingCase)
            {
                this.updateStartingCaseSelectionSummaryInformation(gameManager);
            }
            else if (gameManager.RoundManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                formattedOffers.UpdateFormattedOffers(gameManager);
                this.updateSummaryInformationNeededForEndOfRound(formattedOffers);
            }
        }

        private void updateStartingCaseSelectionSummaryInformation(GameManager gameManager)
        {
            var playerSelectedStartingCaseMessage = $"Your case: {gameManager.PlayerSelectedStartingCase + 1}";
            this.summaryOutput.Text = playerSelectedStartingCaseMessage;
        }

        private void updateSummaryInformationNeededForEndOfRound(FormattedOffers formattedOffers)
        {
            var bankerMinimumOfferAndBankerMaximumOfferMessage =
                $"Offers : Min: {formattedOffers.MinimumOffer} Max: {formattedOffers.MaximumOffer}" + Environment.NewLine;
            var bankerCurrentOfferMessage = $"Current offer: {formattedOffers.CurrentOffer}" + Environment.NewLine;
            this.summaryOutput.Text =
                bankerMinimumOfferAndBankerMaximumOfferMessage + bankerCurrentOfferMessage + AskUserDealOrNoDeal;
        }

        /// <summary>
        /// Updates the summary output when a banker offer is denied
        ///
        /// Precondition: None
        /// Postcondition: this.summaryOutput.Text != this.summaryOutput.Text@prev
        /// </summary>
        /// <param name="formattedOffers">The formatted offer data to display</param>
        public void UpdateSummaryOutputForDeniedOffer(FormattedOffers formattedOffers)
        {
            this.summaryOutput.Text =
                $"Offers : Min: {formattedOffers.MinimumOffer} Max: {formattedOffers.MaximumOffer}" + Environment.NewLine
                + addMarginForAverageOffer(SpacesForAverageMargin) +  $"Average offer: {formattedOffers.AverageOffer}" + Environment.NewLine;
        }

        /// <summary>
        /// Updates the summary output when a banker offer is accepted
        ///
        /// Precondition: None
        /// Postcondition: this.summaryOutput.Text != this.summaryOutput.Text@prev
        /// </summary>
        /// <param name="gameManager">The game manager to calculate the formatted offer for the summary text</param>
        /// <param name="playerStartingCase">The player starting case to calculated the formatted offer for the summary text</param>
        /// <param name="formattedOffers">The formatted offers to display for the summary text</param>
        public void UpdateSummaryOutputForAcceptedOffer(GameManager gameManager, int playerStartingCase, FormattedOffers formattedOffers)
        {
            this.summaryOutput.Text =
                $"Your case contained: {FormattedBriefcaseValue.GetFormattedBriefcaseValue(gameManager, playerStartingCase)}" + Environment.NewLine
                + $"Accepted offer: {formattedOffers.CurrentOffer}" + Environment.NewLine
                + "GAME OVER";
        }

        /// <summary>
        /// Updates the summary text for the final briefcase selection
        ///
        /// Precondition: None
        /// Postcondition: this.summaryOutput.Text != this.summaryOutput.Text@prev
        /// </summary>
        /// <param name="gameManager">The game manager to calculate the formatted offer for the summary text</param>
        /// <param name="selectedBriefcase">The selected briefcase to display on the summary text</param>
        public void UpdateSummaryTextForFinalBriefcaseSelection(GameManager gameManager, Button selectedBriefcase) {
            
            this.summaryOutput.Text =
                $"Congrats you win: {FormattedBriefcaseValue.GetFormattedBriefcaseValue(gameManager, int.Parse(selectedBriefcase.Tag.ToString()))}" + Environment.NewLine
                + Environment.NewLine
                + "GAME OVER";
        }

        private static string addMarginForAverageOffer(int numberOfSpaces)
        {
            var margin = string.Empty;
            while (numberOfSpaces > 0)
            {
                margin += " ";
                numberOfSpaces--;
            }

            return margin;
        }

    }
}
