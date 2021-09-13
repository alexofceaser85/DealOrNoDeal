using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace DealOrNoDeal.View.InitializeGUIVersions
{
    /// <summary>
    /// Sets the versions of the dollar amount labels for the GUI
    ///
    /// Author: Alex DeCesare
    /// Version: 06-September-2021
    /// </summary>
    public class DollarAmountVersions
    {
        private const int QuickPlayNumberOfVisibleCasesPerSide = 9;
        private const int BriefcasesToHidePerSide = 2;
        private const int InvisibleOpacity = 0;

        private readonly IList<Border> dollarAmountLabels;
        private readonly IList<int> dollarAmounts;

        private readonly int initialDefaultDollarAmountLabelsPerSide;
        private int currentDollarAmountIndexPerSide;
        private int indexOfCurrentDollarAmount;

        /// <summary>
        /// Initializes the dollar amounts for the different dollar amount versions in the game
        ///
        /// Precondition: dollarAmountLabels != null
        /// Postcondition:
        /// this.dollarAmountLabels = dollarAmountLabels;
        /// this.dollarAmounts = dollarAmounts;
        ///
        /// this.initialDefaultDollarAmountLabelsPerSide = this.dollarAmountLabels.Count / 2 - 1;
        /// this.currentDollarAmountIndexPerSide = 0;
        /// this.indexOfCurrentDollarAmount = 0;
        /// </summary>
        /// <param name="dollarAmountLabels">The labels displaying the dollar amounts for the version</param>
        /// <param name="dollarAmounts">The dollar amounts for the version</param>
        public DollarAmountVersions(IList<Border> dollarAmountLabels, IList<int> dollarAmounts)
        {
            this.dollarAmountLabels = dollarAmountLabels;
            this.dollarAmounts = dollarAmounts;

            this.initialDefaultDollarAmountLabelsPerSide = this.dollarAmountLabels.Count / 2 - 1;
            this.currentDollarAmountIndexPerSide = 0;
            this.indexOfCurrentDollarAmount = 0;
        }

        /// <summary>
        /// Builds the dollar amount labels for a syndicated game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void BuildDollarAmountLabelsForSyndicatedGame()
        {
            for (var i = 0; i < this.dollarAmounts.Count; i++)
            {
                if (this.dollarAmountLabels[i].Child is TextBlock dollarAmountText)
                {
                    dollarAmountText.Text = $"${this.dollarAmounts[i]}";
                }
            }
        }

        /// <summary>
        /// Builds the dollar amount labels for a quick play game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void BuildDollarAmountLabelsForQuickPlayGame()
        {
            var iterableDollarAmountLabels = new List<Border>(this.dollarAmountLabels);

            foreach (var dollarLabel in iterableDollarAmountLabels)
            {
                if (this.canSwitchBriefcaseSides())
                {
                    this.currentDollarAmountIndexPerSide = 0;
                    this.removeDollarAmountFromPlay(dollarLabel);
                } else if (this.canRemoveBriefcaseIfBriefcasesAreOnSameSide())
                {
                    this.removeDollarAmountFromPlay(dollarLabel);
                } 
                else
                {
                    this.changeDollarAmountForQuickPlayGame(dollarLabel);
                }
            }
        }

        private bool canSwitchBriefcaseSides()
        {
            return this.currentDollarAmountIndexPerSide > this.initialDefaultDollarAmountLabelsPerSide;
        }

        private void removeDollarAmountFromPlay(Border dollarLabel)
        {
            this.dollarAmountLabels.Remove(dollarLabel);
            dollarLabel.Opacity = InvisibleOpacity;
            this.currentDollarAmountIndexPerSide++;
        }

        private bool canRemoveBriefcaseIfBriefcasesAreOnSameSide()
        {
            return this.currentDollarAmountIndexPerSide < BriefcasesToHidePerSide || this.currentDollarAmountIndexPerSide >=
                BriefcasesToHidePerSide + QuickPlayNumberOfVisibleCasesPerSide;
        }

        private void changeDollarAmountForQuickPlayGame(Border dollarLabel)
        {
            if (! (dollarLabel.Child is TextBlock dollarAmountText))
            {
                return;
            }

            dollarAmountText.Text = $"${this.dollarAmounts[this.indexOfCurrentDollarAmount]}";
            this.indexOfCurrentDollarAmount++;
            this.currentDollarAmountIndexPerSide++;
        }
    }
}
