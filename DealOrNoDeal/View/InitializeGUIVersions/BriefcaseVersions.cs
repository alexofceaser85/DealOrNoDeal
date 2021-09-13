using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.InitializeGUIVersions
{
    /// <summary>
    /// Sets the versions of the briefcases for the GUI
    ///
    /// Author: Alex DeCesare
    /// Version: 06-September-2021
    /// </summary>
    public class BriefcaseVersions
    {
        private int tagToSet;
        private int contentToSet;

        private readonly IList<Button> briefcaseButtons;
        private readonly GameManager gameManager;
        private readonly List<int> briefcaseFormatForFiveRoundGame = new List<int>{
            5, 9, 12
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BriefcaseVersions"/> class.
        ///
        /// Precondition: None
        /// Postcondition:
        /// this.briefcaseButtons == briefcaseButtons
        /// this.gameManager == gameManager
        /// this.tagToSet == 0
        /// this.contentToSet == 1
        /// </summary>
        /// <param name="briefcaseButtons">The briefcase buttons.</param>
        /// <param name="gameManager">The game manager.</param>
        public BriefcaseVersions(IList<Button> briefcaseButtons, GameManager gameManager)
        {
            this.briefcaseButtons = briefcaseButtons;
            this.gameManager = gameManager;
            this.tagToSet = 0;
            this.contentToSet = 1;
        }

        /// <summary>
        /// Builds the briefcases for the five round version of the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>

        public void BuildBriefcasesForFiveRoundGame()
        {
            IList<Button> iterableBriefcaseButtons = new List<Button>(this.briefcaseButtons);

            foreach (var briefcase in iterableBriefcaseButtons)
            {
                if (int.TryParse(briefcase.Tag.ToString(), out var briefcaseTag))
                {
                    this.buildBriefcaseForGame(briefcase, briefcaseTag);
                }
            }
        }

        private void buildBriefcaseForGame(Button briefcase, int briefcaseTag)
        {
            if (this.gameManager.BriefcaseManager.GetBriefcaseValue(this.tagToSet) == -1)
            {
                this.briefcaseButtons.Remove(briefcase);
                briefcase.Visibility = Visibility.Collapsed;
            }
            else if (this.briefcaseFormatForFiveRoundGame.Contains(briefcaseTag))
            {
                this.briefcaseButtons.Remove(briefcase);
                briefcase.Visibility = Visibility.Collapsed;
            }
            else
            {
                briefcase.Tag = this.tagToSet.ToString();
                briefcase.Content = this.contentToSet.ToString();
                this.tagToSet++;
                this.contentToSet++;
            }
        }
    }
}
