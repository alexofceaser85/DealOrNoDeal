using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using DealOrNoDeal.Data;
using DealOrNoDeal.Data.Settings;
using DealOrNoDeal.Model;
using DealOrNoDeal.View.DealOrNoDealPageGUIUtilities;
using DealOrNoDeal.View.InitializeDealOrNoDealPageGUI;
using DealOrNoDeal.View.UserSettings;

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
        private Boolean isOnFinalSelection = false;

        private GameManager gameManager;
        private GameSettings gameSettings;

        private FormattedOffers formattedOffers;
        private UpdateSummaryOutput updateSummaryOutput;

        private int FinalRound;
        private Button playerSelectedStartingCaseButton;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new viewable game page for the Deal or No Deal game
        ///     Precondition: None
        ///     Postcondition:
        ///     this.gameSettings = new GameSettings()
        ///     this.gameManager == new GameManager()
        ///     this.dealButton.Visibility == Visibility.Collapsed
        ///     this.noDealButton.Visibility == Visibility.Collapsed
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();

            this.gameSettings = new GameSettings(UsersGameSettings.CasesToOpenSetting, UsersGameSettings.DollarValuesSetting);
            this.gameManager = new GameManager(this.gameSettings.CasesToOpen, this.gameSettings.DollarValues);

            this.formattedOffers = new FormattedOffers();
            this.updateSummaryOutput = new UpdateSummaryOutput(this.formattedOffers, this.summaryOutput);

            if (this.gameSettings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Syndicated))
            {
                DollarAmountVersions.BuildDollarAmountLabelsForSyndicatedGame(this.dollarAmountLabels, this.gameSettings.DollarValues);
            } else if (this.gameSettings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.QuickPlay))
            {
                DollarAmountVersions.BuildDollarAmountLabelsForQuickPlayGame(this.dollarAmountLabels, this.gameSettings.DollarValues);
                BriefcaseVersions.BuildBriefcasesForFiveRoundGame(this.briefcaseButtons, this.gameManager);
            }

            this.FinalRound = this.gameSettings.CasesToOpen.Count + 1;

            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
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
            var briefcaseId = this.getBriefcaseId(briefcaseButton);

            briefcaseButton.Visibility = Visibility.Collapsed;

            if (this.gameManager.IsSelectingStartingCase)
            {
                this.updatePlayerSelectedStartingCase(briefcaseId, briefcaseButton);
            }
            else
            {
                if (!this.isOnFinalSelection)
                {
                    this.removeBriefcaseFromPlay(briefcaseId, briefcaseButton);
                }
            }

            if (gameManager.RoundManager.CasesLeftForCurrentRound == 0)
            {
                this.formattedOffers.UpdateFormattedOffers(this.gameManager);
            }

            UpdateRoundOutput.UpdateCurrentRoundInformation(this.gameManager, this.FinalRound, this.casesToOpenLabel, this.roundLabel);
            this.updateSummaryOutput.UpdateSummaryOutputTextForSelectionOfBriefcase(this.gameManager);
            this.updateButtonsForEachRound(briefcaseButton);
            this.gameManager.IsSelectingStartingCase = false;
        }

        private void updatePlayerSelectedStartingCase(int briefcaseId, Button senderButton)
        {
            this.gameManager.PlayerSelectedStartingCase = briefcaseId;
            this.playerSelectedStartingCaseButton = senderButton;
            this.gameManager.PlayerSelectedStartingCaseDollarAmount = this.gameManager.GetBriefcaseValue(briefcaseId);
            this.briefcaseButtons.Remove(senderButton);
        }

        private void removeBriefcaseFromPlay(int briefcaseId, Button senderButton)
        {
            var removedBriefcaseValue = this.gameManager.RemoveBriefcaseFromPlay(briefcaseId);
            this.briefcaseButtons.Remove(senderButton);  
            UpdateDollarLabels.FindAndGrayOutGameDollarLabel(this.dollarAmountLabels, removedBriefcaseValue);
        }

        private int getBriefcaseId(Button selectedBriefCase)
        {
            return int.Parse(selectedBriefCase.Tag.ToString());
        }

        private void updateButtonsForEachRound(Button briefcaseButton)
        {
            if (this.gameManager.RoundManager.CurrentRound == this.FinalRound && isOnFinalSelection == false)
            {
                this.UpdateBriefcasesForBeforeFinalRound();
                isOnFinalSelection = true;
            }
            else if (this.gameManager.RoundManager.CurrentRound == this.FinalRound && isOnFinalSelection == true)
            {
                this.updateSummaryOutput.UpdateSummaryTextForFinalBriefcaseSelection(this.gameManager, briefcaseButton);
                UpdateBriefcaseButtons.HideBriefcaseButtons(this.briefcaseButtons);
                this.playerSelectedStartingCaseButton.Visibility = Visibility.Collapsed;
                this.askUserToPlayAgain();
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

        private async void askUserToPlayAgain()
        {
            ContentDialog userPrompt = new ContentDialog() {
                Title = "Play Again?",
                Content = "Would You Like To Play Again?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",

                PrimaryButtonCommand = new StandardUICommand(StandardUICommandKind.Close),
                CloseButtonCommand = new StandardUICommand(StandardUICommandKind.Close),
            };
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameManager.RoundManager.CurrentRound == FinalRound)
            {
                UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
                this.updateSummaryOutput.UpdateSummaryTextForFinalBriefcaseSelection(this.gameManager, this.dealButton);
            }
            else
            {
                UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
                var playerStartingCase = this.gameManager.PlayerSelectedStartingCase;
                this.updateSummaryOutput.UpdateSummaryOutputForDealButtonClick(this.gameManager, playerStartingCase, this.FinalRound);
            }
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            this.gameManager.MoveToNextRound();
            UpdateDealAndNoDealButton.ToggleDealButtonAndNoDealButtonVisibility(this.dealButton, this.noDealButton);
            UpdateRoundOutput.UpdateCurrentRoundInformation(this.gameManager, this.FinalRound, this.casesToOpenLabel, this.roundLabel);
            this.updateButtonsForEachRound((Button) sender);
            this.updateSummaryOutput.DisplaySummaryOutputForDeniedDeal();
        }

        public void UpdateBriefcasesForBeforeFinalRound()
        {
            var firstBriefcaseButton = briefcaseButtons[0];
            var secondBriefcaseButton = this.playerSelectedStartingCaseButton;
            secondBriefcaseButton.Visibility = Visibility.Visible;

            var primaryButtonGrid = this.getPrimaryButtonGrid(firstBriefcaseButton);
            this.clearBriefcaseButtons(primaryButtonGrid);
            var panelToAddTo = this.getMiddleButtonPanel(primaryButtonGrid);

            panelToAddTo.Children.Clear();
            this.addButtonsToMiddlePanel(panelToAddTo, firstBriefcaseButton, secondBriefcaseButton);
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.IsEnabled = true;
            }
        }

        private Grid getPrimaryButtonGrid(Button firstBriefcaseButton)
        {
            StackPanel firstButtonPanel = (StackPanel)firstBriefcaseButton.Parent;
            Grid firstButtonGrid = (Grid)firstButtonPanel.Parent;
            Grid primaryButtonGrid = (Grid)firstButtonGrid.Parent;
            return primaryButtonGrid;
        }

        private void clearBriefcaseButtons(Grid primaryButtonGrid)
        {
            int currentGridRow = 0;
            while (currentGridRow <= 4)
            {
                Grid buttonGrid = (Grid) primaryButtonGrid.Children[currentGridRow];
                StackPanel gridButtonPanel = (StackPanel)buttonGrid.Children[0];
                gridButtonPanel.Children.Clear();
                currentGridRow++;
            }
        }

        private StackPanel getMiddleButtonPanel(Grid primaryButtonGrid)
        {
            UIElementCollection primaryButtonGridChildren = primaryButtonGrid.Children;
            Grid buttonGridToAddTo = (Grid)primaryButtonGridChildren[2];
            StackPanel panelToAddTo = (StackPanel)buttonGridToAddTo.Children[0];
            return panelToAddTo;
        }

        private void addButtonsToMiddlePanel(StackPanel panelToAddTo, Button firstBriefcaseButton,
            Button secondBriefcaseButton)
        {

            if (int.Parse(firstBriefcaseButton.Tag.ToString()) > int.Parse(secondBriefcaseButton.Tag.ToString()))
            {
                panelToAddTo.Children.Add(secondBriefcaseButton);
                panelToAddTo.Children.Add(firstBriefcaseButton);
            }
            else
            {
                panelToAddTo.Children.Add(firstBriefcaseButton);
                panelToAddTo.Children.Add(secondBriefcaseButton);
            }
        }
        #endregion
    }
}