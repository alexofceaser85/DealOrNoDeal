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
    /// </summary>
    public sealed partial class DealOrNoDealPage
    {
        #region Constructors

        private readonly GameManager theGameManager;

        public DealOrNoDealPage()
        {
            InitializeComponent();
            initializeUiDataAndControls();
            theGameManager = new GameManager();
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
            senderButton.Visibility = Visibility.Collapsed;
            var briefcaseId = getBriefcaseID(senderButton);
            var removedBriefcaseValue = theGameManager.RemoveBriefcaseFromPlay(briefcaseId);
            findAndGrayOutGameDollarLabel(removedBriefcaseValue);
            this.updateCurrentRoundInformation();
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
            this.casesToOpenLabel.Text = this.theGameManager.CasesLeftForCurrentRound.ToString();
            this.roundLabel.Text = this.theGameManager.CurrentRound.ToString();

            if (this.theGameManager.CasesLeftForCurrentRound == 1)
            {
                this.theGameManager.MoveToNextRound();
                this.summaryOutput.Text = this.theGameManager.GetOffer().ToString();
            }
            else
            {
                this.theGameManager.CasesLeftForCurrentRound--;
            }

            // TODO This method will need to update the text for the information labels
            //       to display the current round and cases to open, as well as, the number of cases
            //       left to open for this round

            // TODO If a round is complete, then collaborate with the GameManager to get the banker's offer and display the appropriate text in the summaryOutput
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO Complete this method to output the information when the player accepts the Banker's deal
            // Check for instance of last round, as in the last round the deal button
            // displays the player's case value
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO Handle the the selection of a case in the final round
            // You may not want to worry about the final round code until this
            // code can successfully move onto the next round

            // TODO Otherwise, move to the next round (hint: method in GameManager class)
            // and update summaryOutput information and the label information appropriately
            // You will also need to handle the situation when advancing to the next round and the
            // next round is the final round, so the text on the Deal and No Deal buttons will 
            // need to change as detailed in the specifications
        }

        #endregion
    }
}