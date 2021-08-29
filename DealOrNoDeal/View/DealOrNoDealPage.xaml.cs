using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DealOrNoDeal.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DealOrNoDeal.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    ///
    ///     Author: Alex DeCesare
    ///     Version: 
    /// </summary>
    public sealed partial class DealOrNoDealPage
    {
        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        public const int ApplicationHeight = 500;

        /// <summary>
        ///     The application width
        /// </summary>
        public const int ApplicationWidth = 500;

        private const string TellUserToSelectACaseBelowMessage = "Select a case below";
        private const string TellUserThatThisRoundIsTheFinalRoundMessage = "This is the final round";
        private const string AskUserDealOrNoDeal = "Deal or No Deal?";

        private const int FinalRound = 10;
        private const int CasesLeftToEndRound = 0;

        private string formattedBankerCurrentOffer;
        private string formattedBankerMinimumOffer;
        private string formattedBankerMaximumOffer;

        private readonly GameManager theGameManager;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new viewable game page for the Deal or No Deal game
        ///     Precondition: None
        ///     Postcondition:
        ///         this.theGameManager == new GameManager()
        ///         this.dealButton.Visibility == Visibility.Collapsed
        ///         this.noDealButton.Visibility == Visibility.Collapsed
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();
            this.theGameManager = new GameManager();

            this.toggleDealButtonAndNoDealButtonVisibility();
        }

        #endregion

        #region Methods

        private void initializeUiDataAndControls()
        {
            setPageSize();

            this.briefcaseButtons = new List<Button>();
            this.dollarAmountLabels = new List<Border>();
            this.buildBriefcaseButtonCollection();
            this.buildDollarAmountLabelCollection();
        }

        private static void setPageSize()
        {
            ApplicationView.PreferredLaunchViewSize = new Size { Width = ApplicationWidth, Height = ApplicationHeight };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void buildDollarAmountLabelCollection()
        {
            this.dollarAmountLabels.Clear();

            this.dollarAmountLabels.Add(this.label0Border);
            this.dollarAmountLabels.Add(this.label1Border);
            this.dollarAmountLabels.Add(this.label2Border);
            this.dollarAmountLabels.Add(this.label3Border);
            this.dollarAmountLabels.Add(this.label4Border);
            this.dollarAmountLabels.Add(this.label5Border);
            this.dollarAmountLabels.Add(this.label6Border);
            this.dollarAmountLabels.Add(this.label7Border);
            this.dollarAmountLabels.Add(this.label8Border);
            this.dollarAmountLabels.Add(this.label9Border);
            this.dollarAmountLabels.Add(this.label10Border);
            this.dollarAmountLabels.Add(this.label11Border);
            this.dollarAmountLabels.Add(this.label12Border);
            this.dollarAmountLabels.Add(this.label13Border);
            this.dollarAmountLabels.Add(this.label14Border);
            this.dollarAmountLabels.Add(this.label15Border);
            this.dollarAmountLabels.Add(this.label16Border);
            this.dollarAmountLabels.Add(this.label17Border);
            this.dollarAmountLabels.Add(this.label18Border);
            this.dollarAmountLabels.Add(this.label19Border);
            this.dollarAmountLabels.Add(this.label20Border);
            this.dollarAmountLabels.Add(this.label21Border);
            this.dollarAmountLabels.Add(this.label22Border);
            this.dollarAmountLabels.Add(this.label23Border);
            this.dollarAmountLabels.Add(this.label24Border);
            this.dollarAmountLabels.Add(this.label25Border);
        }

        private void buildBriefcaseButtonCollection()
        {
            this.briefcaseButtons.Clear();

            this.briefcaseButtons.Add(this.case0);
            this.briefcaseButtons.Add(this.case1);
            this.briefcaseButtons.Add(this.case2);
            this.briefcaseButtons.Add(this.case3);
            this.briefcaseButtons.Add(this.case4);
            this.briefcaseButtons.Add(this.case5);
            this.briefcaseButtons.Add(this.case6);
            this.briefcaseButtons.Add(this.case7);
            this.briefcaseButtons.Add(this.case8);
            this.briefcaseButtons.Add(this.case9);
            this.briefcaseButtons.Add(this.case10);
            this.briefcaseButtons.Add(this.case11);
            this.briefcaseButtons.Add(this.case12);
            this.briefcaseButtons.Add(this.case13);
            this.briefcaseButtons.Add(this.case14);
            this.briefcaseButtons.Add(this.case15);
            this.briefcaseButtons.Add(this.case16);
            this.briefcaseButtons.Add(this.case17);
            this.briefcaseButtons.Add(this.case18);
            this.briefcaseButtons.Add(this.case19);
            this.briefcaseButtons.Add(this.case20);
            this.briefcaseButtons.Add(this.case21);
            this.briefcaseButtons.Add(this.case22);
            this.briefcaseButtons.Add(this.case23);
            this.briefcaseButtons.Add(this.case24);
            this.briefcaseButtons.Add(this.case25);

            this.storeBriefCaseIndexInControlsTagProperty();
        }

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < this.briefcaseButtons.Count; i++)
            {
                this.briefcaseButtons[i].Tag = i;
            }
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            var briefcaseButton = (Button)sender;
            var briefcaseId = getBriefcaseId(briefcaseButton);
            briefcaseButton.Visibility = Visibility.Collapsed;

            if (this.theGameManager.IsSelectingStartingCase)
            {
                this.updatePlayerSelectedStartingCase(briefcaseId, briefcaseButton);
            }
            else
            {
                this.removeBriefcaseFromPlay(briefcaseId, briefcaseButton);
            }

            this.updateSummaryOutputTextForSelectionOfBriefcase();
            this.updateCurrentRoundInformation();
            this.updateButtonsForEachRound();
            this.theGameManager.IsSelectingStartingCase = false;
        }

        private void updatePlayerSelectedStartingCase(int briefcaseId, Button senderButton)
        {
            this.theGameManager.PlayerSelectedStartingCase = briefcaseId;
            this.briefcaseButtons.Remove(senderButton);
        }

        private void removeBriefcaseFromPlay(int briefcaseId, Button senderButton)
        {
            var removedBriefcaseValue = this.theGameManager.RemoveBriefcaseFromPlay(briefcaseId);
            this.briefcaseButtons.Remove(senderButton);
            this.theGameManager.CasesLeftForCurrentRound--;
            this.findAndGrayOutGameDollarLabel(removedBriefcaseValue);
        }

        private static int getBriefcaseId(Button selectedBriefCase)
        {
            return (int)selectedBriefCase.Tag;
        }

        private void updateSummaryOutputTextForSelectionOfBriefcase()
        {
            if (this.theGameManager.IsSelectingStartingCase)
            {
                this.displaySummaryInformationNeededForSelectionOfStartingCase();
            }
            else if (this.theGameManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                this.displaySummaryInformationNeededForEndOfRound();
            }
        }

        private void displaySummaryInformationNeededForSelectionOfStartingCase()
        {
            var playerSelectedStartingCaseMessage = $"Your case: {this.theGameManager.PlayerSelectedStartingCase + 1}";
            this.summaryOutput.Text = playerSelectedStartingCaseMessage;
        }

        private void displaySummaryInformationNeededForEndOfRound()
        {
            var bankerMinimumOfferAndBankerMaximumOfferMessage =
                $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n";
            var bankerCurrentOfferMessage = $"Current offer: {this.formattedBankerCurrentOffer}\n";
            this.summaryOutput.Text =
                bankerMinimumOfferAndBankerMaximumOfferMessage + bankerCurrentOfferMessage + AskUserDealOrNoDeal;
        }

        private void updateCurrentRoundInformation()
        {
            if (this.theGameManager.CasesLeftForCurrentRound == 1)
            {
                this.updateFormattedBankerOffers();
            }

            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.displayRoundInformationNeededForFinalRound();
            }
            else
            {
                this.displayRoundInformationNeededForGameplayWithinRound();
            }
        }

        private void updateFormattedBankerOffers()
        {
            this.theGameManager.GetOffer();
            this.formattedBankerCurrentOffer = this.theGameManager.BankerCurrentOffer.ToString("C");
            this.formattedBankerMinimumOffer = this.theGameManager.BankerMinimumOffer.ToString("C");
            this.formattedBankerMaximumOffer = this.theGameManager.BankerMaximumOffer.ToString("C");
        }

        private void displayRoundInformationNeededForFinalRound()
        {
            this.casesToOpenLabel.Text = TellUserToSelectACaseBelowMessage;
            this.roundLabel.Text = TellUserThatThisRoundIsTheFinalRoundMessage;
        }

        private void displayRoundInformationNeededForGameplayWithinRound()
        {
            var currentRoundAndCasesAvailableForRoundMessage =
                $"Round {this.theGameManager.CurrentRound.ToString()}: {this.theGameManager.CasesAvailableForCurrentRound} cases to open";
            var numberOfCasesLeftToOpenForRoundMessage =
                $"{this.theGameManager.CasesLeftForCurrentRound.ToString()} more cases to open";

            this.roundLabel.Text = currentRoundAndCasesAvailableForRoundMessage;
            this.casesToOpenLabel.Text = numberOfCasesLeftToOpenForRoundMessage;
        }

        private void updateButtonsForEachRound()
        {
            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.updateButtonsForFinalRound();
            }
            else if (this.theGameManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                this.updateButtonsForEndOfRound();
            }
            else
            {
                this.enableBriefcaseButtons();
            }
        }

        private void updateButtonsForFinalRound()
        {
            this.toggleDealButtonAndNoDealButtonVisibility();
            this.changeDealAndNoDealButtonContent();
            this.changeDealAndNoDealButtonTag();
            this.collapseBriefcaseButtons();
        }

        private void toggleDealButtonAndNoDealButtonVisibility()
        {
            if (this.dealButton.Visibility == Visibility.Collapsed &&
                this.noDealButton.Visibility == Visibility.Collapsed)
            {
                this.dealButton.Visibility = Visibility.Visible;
                this.noDealButton.Visibility = Visibility.Visible;
            }
            else
            {
                this.dealButton.Visibility = Visibility.Collapsed;
                this.noDealButton.Visibility = Visibility.Collapsed;
            }
        }

        private void changeDealAndNoDealButtonContent()
        {
            this.noDealButton.Content = (int)this.briefcaseButtons[0].Tag + 1;
            this.dealButton.Content = this.theGameManager.PlayerSelectedStartingCase + 1;
        }

        private void changeDealAndNoDealButtonTag()
        {
            this.noDealButton.Tag = (int)this.briefcaseButtons[0].Tag;
            this.dealButton.Tag = this.theGameManager.PlayerSelectedStartingCase;
        }

        private void collapseBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void updateButtonsForEndOfRound()
        {
            this.toggleDealButtonAndNoDealButtonVisibility();
            this.disableBriefcaseButtons();
        }

        private void disableBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.IsEnabled = false;
            }
        }

        private void enableBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.IsEnabled = true;
            }
        }

        private void findAndGrayOutGameDollarLabel(int amount)
        {
            foreach (var currDollarAmountLabel in this.dollarAmountLabels)
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

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.toggleDealButtonAndNoDealButtonVisibility();
                this.updateSummaryTextForFinalBriefcaseSelection(this.dealButton);
            }
            else
            {
                this.toggleDealButtonAndNoDealButtonVisibility();
                var playerStartingCase = this.theGameManager.PlayerSelectedStartingCase;
                this.updateSummaryOutputForDealButtonClick(playerStartingCase);
            }
        }

        private void updateSummaryTextForFinalBriefcaseSelection(Button selectedBriefcase)
        {
            this.summaryOutput.Text =
                $"Congrats you win: {this.getFormattedBriefcaseValue((int)selectedBriefcase.Tag)}\n"
                + "\n"
                + "GAME OVER";
        }

        private string getFormattedBriefcaseValue(int indexToGet)
        {
            return this.theGameManager.GetBriefcaseValue(indexToGet).ToString("C");
        }

        private void updateSummaryOutputForDealButtonClick(int playerStartingCase)
        {
            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.displaySummaryInformationForFinalRound();
            }
            else
            {
                this.displaySummaryInformationForAcceptedDeal(playerStartingCase);
            }
        }

        private void displaySummaryInformationForFinalRound()
        {
            var bankerMinimumOfferAndBankerMaximumOfferMessage =
                $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n";
            this.summaryOutput.Text = bankerMinimumOfferAndBankerMaximumOfferMessage;
        }

        private void displaySummaryInformationForAcceptedDeal(int playerStartingCase)
        {
            this.summaryOutput.Text =
                $"Your case contained: {this.getFormattedBriefcaseValue(playerStartingCase)}\n"
                + $"Accepted offer: {this.formattedBankerCurrentOffer}\n"
                + "GAME OVER";
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.toggleDealButtonAndNoDealButtonVisibility();
                this.updateSummaryTextForFinalBriefcaseSelection(this.noDealButton);
            }
            else
            {
                this.theGameManager.MoveToNextRound();
                this.toggleDealButtonAndNoDealButtonVisibility();
                this.updateCurrentRoundInformation();
                this.updateButtonsForEachRound();
                this.updateSummaryTextForNoDealButtonClick();
            }
        }

        private void updateSummaryTextForNoDealButtonClick()
        {
            if (this.theGameManager.CurrentRound == FinalRound)
            {
                this.displaySummaryInformationForFinalRound();
            }
            else
            {
                this.displaySummaryOutputForDeniedDeal();
            }
        }

        private void displaySummaryOutputForDeniedDeal()
        {
            this.summaryOutput.Text =
                $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n"
                + $"Last offer: {this.formattedBankerCurrentOffer}\n";
        }

        #endregion
    }
}