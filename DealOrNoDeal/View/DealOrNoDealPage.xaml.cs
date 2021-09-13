using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Data;
using DealOrNoDeal.Data.SettingVariables;
using DealOrNoDeal.Model;
using DealOrNoDeal.View.UpdateGUI;
using DealOrNoDeal.View.Dialogs;
using DealOrNoDeal.View.InitializeGUIVersions;
using System.Threading.Tasks;
using DealOrNoDeal.View.FormattedValues;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DealOrNoDeal.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    ///
    /// Author: Alex DeCesare
    /// Version: 31-August-2021
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

        private const int CasesLeftToEndRound = 0;

        private bool isOnFinalSelection;
        private Button playerSelectedStartingCaseButton;

        private readonly GameSettingsManager gameSettings;
        private GameManager gameManager;
        private FormattedOffers formattedOffers;
        private UpdateSummaryOutput updateSummaryOutput;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new viewable game page for the Deal or No Deal game
        /// 
        ///     Precondition: None
        ///     Postcondition:
        ///     this.gameManager == new GameManager()
        ///     this.formattedOffers == new FormattedOffers()
        ///     this.updateSummaryOutput == new UpdateSummaryOutput(this.formattedOffers, this.summaryOutput)
        /// 
        ///     this.roundLabel.Text == UsersGameSettings.DollarValueSetting
        ///     this.finalRound == this.gameSettings.CasesToOpen.Count + 1
        /// 
        ///     this.dealButton.Visibility == Visibility.Collapsed
        ///     this.noDealButton.Visibility == Visibility.Collapsed
        /// </summary>
        public DealOrNoDealPage()
        {
            this.gameSettings = new GameSettingsManager();

            if (this.gameSettings.ValidateGameSettings())
            {
                this.initializeGame();
            }
            else
            {
                informUserOfInvalidGameSettings();
            }
        }

        private static async void informUserOfInvalidGameSettings()
        {
            var userPrompt = new ContentDialog
            {
                Title = "Invalid Game Settings",
                Content = "Cannot Play a Game With the Current Game Settings, Please Change the Game Settings",
                PrimaryButtonText = "Okay"
            };

            var result = await userPrompt.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                CoreApplication.Exit();
            }
        }

        #endregion

        #region Methods

        private void initializeGame()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();

            this.gameManager = new GameManager(this.gameSettings.CasesToOpen, this.gameSettings.DollarValues);
            this.formattedOffers = new FormattedOffers();
            this.updateSummaryOutput = new UpdateSummaryOutput(this.summaryOutput);
            this.roundLabel.Text += $" {UsersGameSettings.DollarValuesSetting}";

            this.setGameGuiVersion();
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
        }

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

        private void setGameGuiVersion()
        {
            var dollarAmountVersions =
                new DollarAmountVersions(this.dollarAmountLabels, this.gameSettings.DollarValues);
            var briefcaseVersions = new BriefcaseVersions(this.briefcaseButtons, this.gameManager);

            if (UsersGameSettings.DollarValuesSetting.Equals(DollarValueSettings.Syndicated))
            {
                dollarAmountVersions.BuildDollarAmountLabelsForSyndicatedGame();
            }
            else if (UsersGameSettings.DollarValuesSetting.Equals(DollarValueSettings.QuickPlay))
            {
                dollarAmountVersions.BuildDollarAmountLabelsForQuickPlayGame();
                briefcaseVersions.BuildBriefcasesForFiveRoundGame();
            }
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

            this.updateIfBriefcaseButtonClickIsBetweenRounds(briefcaseId, briefcaseButton);
            this.updateIfBriefcaseButtonClickIsAtEndOfRound(briefcaseButton);
            UpdateRoundOutput.UpdateCurrentRoundInformation(this.gameManager, this.casesToOpenLabel, this.roundLabel);
            this.updateSummaryOutput.UpdateSummaryOutputTextForSelectionOfBriefcase(this.gameManager, this.formattedOffers);
            this.gameManager.IsSelectingStartingCase = false;
        }

        private static int getBriefcaseId(FrameworkElement selectedBriefCase)
        {
            return int.Parse(selectedBriefCase.Tag.ToString());
        }

        private void updateIfBriefcaseButtonClickIsBetweenRounds(int briefcaseId, Button briefcaseButton)
        {
            if (this.gameManager.IsSelectingStartingCase)
            {
                this.updatePlayerSelectedStartingCase(briefcaseId, briefcaseButton);
            }
            else if (!this.isOnFinalSelection)
            {
                this.removeBriefcaseFromPlay(briefcaseId, briefcaseButton);
            }
        }

        private void updatePlayerSelectedStartingCase(int briefcaseId, Button senderButton)
        {
            this.gameManager.PlayerSelectedStartingCase = briefcaseId;
            this.playerSelectedStartingCaseButton = senderButton;
            this.gameManager.PlayerSelectedStartingCaseDollarAmount = this.gameManager.BriefcaseManager.GetBriefcaseValue(briefcaseId);
            this.briefcaseButtons.Remove(senderButton);
        }

        private void removeBriefcaseFromPlay(int briefcaseId, Button senderButton)
        {
            var removedBriefcaseValue = this.gameManager.RemoveBriefcaseFromPlay(briefcaseId);
            this.briefcaseButtons.Remove(senderButton);
            UpdateDollarLabels.FindAndGrayOutGameDollarLabel(this.dollarAmountLabels, removedBriefcaseValue);
        }

        private async void updateIfBriefcaseButtonClickIsAtEndOfRound(Button briefcaseButton)
        {
            if (this.gameManager.RoundManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                this.updateGameForEndOfRound();
            }
            else if (this.gameManager.RoundManager.IsOnFinalRound())
            {
                await this.updateGameForFinalRoundBriefcaseSelectionAsync(briefcaseButton);
            }
        }

        private void updateGameForEndOfRound()
        {
            this.formattedOffers.UpdateFormattedOffers(this.gameManager);
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
            UpdateBriefcaseButtons.DisableBriefcaseButtons(this.briefcaseButtons);
        }

        private async Task updateGameForFinalRoundBriefcaseSelectionAsync(Button briefcaseButton)
        {
            this.updateSummaryOutput.UpdateSummaryTextForFinalBriefcaseSelection(this.gameManager, briefcaseButton);
            UpdateBriefcaseButtons.HideBriefcaseButtons(this.briefcaseButtons);
            this.playerSelectedStartingCaseButton.Visibility = Visibility.Collapsed;
            var playAgainDialog = new AskUserToPlayAgain();
            await playAgainDialog.ShowAsync();
        }

        private async void dealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameManager.RoundManager.IsOnFinalRound())
            {
                this.updateDealButtonClickForFinalRound();
            }
            else
            {
                await this.updateDealButtonForNormalRoundAsync();
            }
        }

        private void updateDealButtonClickForFinalRound()
        {
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
            this.updateSummaryOutput.UpdateSummaryTextForFinalBriefcaseSelection(this.gameManager, this.dealButton);
        }

        private async Task updateDealButtonForNormalRoundAsync()
        {
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
            var playerStartingCase = this.gameManager.PlayerSelectedStartingCase;
            this.updateSummaryOutput.UpdateSummaryOutputForAcceptedOffer(this.gameManager, playerStartingCase,
                this.formattedOffers);
            var playAgainDialog = new AskUserToPlayAgain();
            await playAgainDialog.ShowAsync();
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            this.gameManager.RoundManager.MoveToNextRound();
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
            UpdateRoundOutput.UpdateCurrentRoundInformation(this.gameManager, this.casesToOpenLabel, this.roundLabel);
            this.updateButtonsForEachRound();
            this.updateSummaryOutput.UpdateSummaryOutputForDeniedOffer(this.formattedOffers);
        }

        private void updateButtonsForEachRound()
        {
            if (this.gameManager.RoundManager.IsOnFinalRound() && this.isOnFinalSelection == false)
            {
                UpdateBriefcaseButtons.UpdateBriefcasesForBeforeFinalRound(this.briefcaseButtons, this.playerSelectedStartingCaseButton);
                this.isOnFinalSelection = true; 
            }
            else if (this.gameManager.RoundManager.CasesLeftForCurrentRound == CasesLeftToEndRound)
            {
                UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
                UpdateBriefcaseButtons.DisableBriefcaseButtons(this.briefcaseButtons);
            }
            else
            {
                UpdateBriefcaseButtons.EnableBriefcaseButtons(this.briefcaseButtons);
            }
        }
        #endregion
    }
}