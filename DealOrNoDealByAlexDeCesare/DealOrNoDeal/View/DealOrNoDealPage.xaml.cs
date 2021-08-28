using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Windows.Storage.Streams;
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
    /// </summary>
    public sealed partial class DealOrNoDealPage
    {
        private string formattedBankerCurrentOffer;
        private string formattedBankerMinimumOffer;
        private string formattedBankerMaximumOffer;

        #region Constructors

        private readonly GameManager theGameManager;

        public DealOrNoDealPage()
        {
            InitializeComponent();
            initializeUiDataAndControls();
            theGameManager = new GameManager();

            this.dealButton.Visibility = Visibility.Collapsed;
            this.noDealButton.Visibility = Visibility.Collapsed;
        }

        private void updateFormattedBankerOffers()
        {
            this.theGameManager.GetOffer();
            this.formattedBankerCurrentOffer = this.theGameManager.BankerCurrentOffer.ToString("C");
            this.formattedBankerMinimumOffer = this.theGameManager.BankerMinimumOffer.ToString("C");
            this.formattedBankerMaximumOffer = this.theGameManager.BankerMaximumOffer.ToString("C");
        }

        private string getFormattedBriefcaseValue(int indexToGet)
        {
            return this.theGameManager.GetBriefcaseValue(indexToGet).ToString("C");
        }

        #endregion

        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        public const int ApplicationHeight = 500;

        /// <summary>
        ///     The application width
        /// </summary>
        public const int ApplicationWidth = 500;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;

        #endregion

        #region Methods

        private void initializeUiDataAndControls()
        {
            setPageSize();

            briefcaseButtons = new List<Button>();
            dollarAmountLabels = new List<Border>();
            buildBriefcaseButtonCollection();
            buildDollarAmountLabelCollection();
        }

        private void setPageSize()
        {
            ApplicationView.PreferredLaunchViewSize = new Size { Width = ApplicationWidth, Height = ApplicationHeight };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void buildDollarAmountLabelCollection()
        {
            dollarAmountLabels.Clear();

            dollarAmountLabels.Add(label0Border);
            dollarAmountLabels.Add(label1Border);
            dollarAmountLabels.Add(label2Border);
            dollarAmountLabels.Add(label3Border);
            dollarAmountLabels.Add(label4Border);
            dollarAmountLabels.Add(label5Border);
            dollarAmountLabels.Add(label6Border);
            dollarAmountLabels.Add(label7Border);
            dollarAmountLabels.Add(label8Border);
            dollarAmountLabels.Add(label9Border);
            dollarAmountLabels.Add(label10Border);
            dollarAmountLabels.Add(label11Border);
            dollarAmountLabels.Add(label12Border);
            dollarAmountLabels.Add(label13Border);
            dollarAmountLabels.Add(label14Border);
            dollarAmountLabels.Add(label15Border);
            dollarAmountLabels.Add(label16Border);
            dollarAmountLabels.Add(label17Border);
            dollarAmountLabels.Add(label18Border);
            dollarAmountLabels.Add(label19Border);
            dollarAmountLabels.Add(label20Border);
            dollarAmountLabels.Add(label21Border);
            dollarAmountLabels.Add(label22Border);
            dollarAmountLabels.Add(label23Border);
            dollarAmountLabels.Add(label24Border);
            dollarAmountLabels.Add(label25Border);
        }

        private void buildBriefcaseButtonCollection()
        {
            briefcaseButtons.Clear();

            briefcaseButtons.Add(case0);
            briefcaseButtons.Add(case1);
            briefcaseButtons.Add(case2);
            briefcaseButtons.Add(case3);
            briefcaseButtons.Add(case4);
            briefcaseButtons.Add(case5);
            briefcaseButtons.Add(case6);
            briefcaseButtons.Add(case7);
            briefcaseButtons.Add(case8);
            briefcaseButtons.Add(case9);
            briefcaseButtons.Add(case10);
            briefcaseButtons.Add(case11);
            briefcaseButtons.Add(case12);
            briefcaseButtons.Add(case13);
            briefcaseButtons.Add(case14);
            briefcaseButtons.Add(case15);
            briefcaseButtons.Add(case16);
            briefcaseButtons.Add(case17);
            briefcaseButtons.Add(case18);
            briefcaseButtons.Add(case19);
            briefcaseButtons.Add(case20);
            briefcaseButtons.Add(case21);
            briefcaseButtons.Add(case22);
            briefcaseButtons.Add(case23);
            briefcaseButtons.Add(case24);
            briefcaseButtons.Add(case25);

            storeBriefCaseIndexInControlsTagProperty();
        }

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < briefcaseButtons.Count; i++) briefcaseButtons[i].Tag = i;
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = (Button)sender;
            var briefcaseId = getBriefcaseID(senderButton);
            senderButton.Visibility = Visibility.Collapsed;

            if (this.theGameManager.PlayerSelectedStartingCase == -1)
            {
                this.theGameManager.PlayerSelectedStartingCase = briefcaseId;
                this.briefcaseButtons.Remove(senderButton);
                this.summaryOutput.Text = $"Your case: {this.theGameManager.PlayerSelectedStartingCase + 1}";

                this.roundLabel.Text = $"Round {this.theGameManager.CurrentRound.ToString()}: {this.theGameManager.CasesAvailableForRound} cases to open";
                this.casesToOpenLabel.Text = $"{this.theGameManager.CasesLeftForCurrentRound.ToString()} more cases to open";
            } 
            else
            {
                var removedBriefcaseValue = theGameManager.RemoveBriefcaseFromPlay(briefcaseId);
                this.briefcaseButtons.Remove(senderButton);
                this.theGameManager.CasesLeftForCurrentRound--;
                this.updateCurrentRoundInformation();
                findAndGrayOutGameDollarLabel(removedBriefcaseValue);
            }
        }

        private void findAndGrayOutGameDollarLabel(int amount)
        {
            foreach (var currDollarAmountLabel in dollarAmountLabels)
                if (grayOutLabelIfMatchesDollarAmount(amount, currDollarAmountLabel))
                    break;
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border currDollarAmountLabel)
        {
            var matched = false;

            if (currDollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                var labelAmount = int.Parse(dollarTextBlock.Text, NumberStyles.Currency);
                if (labelAmount == amount)
                {
                    currDollarAmountLabel.Background = new SolidColorBrush(Colors.Gray);
                    matched = true;
                }
            }

            return matched;
        }

        private int getBriefcaseID(Button selectedBriefCase)
        {
            return (int)selectedBriefCase.Tag;
            // TODO return the integer value (ID) stored in the Button's Tag property.
            // HINT A type cast will be needed
        }

        private void updateCurrentRoundInformation()
        {
            this.roundLabel.Text = $"Round {this.theGameManager.CurrentRound.ToString()}: {this.theGameManager.CasesAvailableForRound} cases to open";
            this.casesToOpenLabel.Text = $"{this.theGameManager.CasesLeftForCurrentRound.ToString()} more cases to open";

            if (this.theGameManager.CasesLeftForCurrentRound == 0)
            {
                this.updateFormattedBankerOffers();
            }

            if (this.theGameManager.CurrentRound == 10)
            {
                this.casesToOpenLabel.Text = "Select a case below";
                this.roundLabel.Text = "This is the final round";
                this.summaryOutput.Text =
                    $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n";

                this.dealButton.Visibility = Visibility.Visible;
                this.noDealButton.Visibility = Visibility.Visible;

                this.dealButton.Content = (int) this.briefcaseButtons[0].Tag + 1;
                this.noDealButton.Content = (int) this.theGameManager.PlayerSelectedStartingCase + 1;

                this.dealButton.Tag = (int)this.briefcaseButtons[0].Tag;
                this.noDealButton.Tag = (int)this.theGameManager.PlayerSelectedStartingCase;

                this.collapseBriefcaseButtons();
            } 
            else if (this.theGameManager.CasesLeftForCurrentRound == 0)
            {
                this.summaryOutput.Text =
                    $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n"
                    + $"Current offer: {this.formattedBankerCurrentOffer}\n"
                    + "Deal or No Deal?";

                this.dealButton.Visibility = Visibility.Visible;
                this.noDealButton.Visibility = Visibility.Visible;

                foreach (Button briefcaseButton in briefcaseButtons)
                {
                    briefcaseButton.IsEnabled = false;
                }
            }
            else
            {
                foreach (Button briefcaseButton in briefcaseButtons)
                {
                    briefcaseButton.IsEnabled = true;
                }
            }

            // TODO This method will need to update the text for the information labels
            //       to display the current round and cases to open, as well as, the number of cases
            //       left to open for this round

            // TODO If a round is complete, then collaborate with the GameManager to get the banker's offer and display the appropriate text in the summaryOutput
        }

        private void collapseBriefcaseButtons()
        {
            foreach (Button briefcaseButton in briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.theGameManager.CurrentRound == 10)
            {
                this.dealButton.Visibility = Visibility.Collapsed;
                this.noDealButton.Visibility = Visibility.Collapsed;

                int playerStartingCase = this.theGameManager.PlayerSelectedStartingCase;
                this.summaryOutput.Text =
                    $"Congrats you win: {this.getFormattedBriefcaseValue((int) this.dealButton.Tag)}\n"
                    + "\n"
                    + "GAME OVER";
            }
            else
            {
                this.dealButton.Visibility = Visibility.Collapsed;
                this.noDealButton.Visibility = Visibility.Collapsed;

                int playerStartingCase = this.theGameManager.PlayerSelectedStartingCase;
                this.summaryOutput.Text =
                    $"Your case contained: {this.getFormattedBriefcaseValue(playerStartingCase)}\n"
                    + $"Accepted offer: {this.formattedBankerCurrentOffer}\n"
                    + "GAME OVER";
            }
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {

            if (this.theGameManager.CurrentRound == 10)
            {
                this.dealButton.Visibility = Visibility.Collapsed;
                this.noDealButton.Visibility = Visibility.Collapsed;

                int playerStartingCase = this.theGameManager.PlayerSelectedStartingCase;
                this.summaryOutput.Text =
                    $"Congrats you win: {this.getFormattedBriefcaseValue((int) this.dealButton.Tag)}\n"

                    + "\n"
                    + "GAME OVER";
            }
            else
            {
                this.theGameManager.MoveToNextRound();
                this.dealButton.Visibility = Visibility.Collapsed;
                this.noDealButton.Visibility = Visibility.Collapsed;

                this.updateCurrentRoundInformation();

                if (this.theGameManager.CurrentRound != 10)
                {
                    foreach (Button briefcaseButton in briefcaseButtons)
                    {
                        briefcaseButton.Visibility = Visibility.Visible;
                    }

                    this.summaryOutput.Text =
                        $"Offers : Min: {this.formattedBankerMinimumOffer} Max: {this.formattedBankerMaximumOffer}\n"
                        + $"Last offer: {this.formattedBankerCurrentOffer}\n";
                }
            }

        }

        #endregion
    }
}