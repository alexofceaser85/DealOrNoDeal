using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.InitializeDealOrNoDealPageGUI
{
    /// <summary>
    /// Sets the versions of the briefcases for the GUI
    ///
    /// Author: Alex DeCesare
    /// Version: 06-September-2021
    /// </summary>
    public static class BriefcaseVersions
    {
        private static readonly List<int> BriefcaseFormatForFiveRoundGame = new List<int>(){
            5, 9, 12
        };

        /// <summary>
        /// Builds the briefcases for the five round version of the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="briefcaseButtons">The briefcase buttons for the default game</param>
        /// <param name="gameManager">The game manager for the game</param>

        public static void BuildBriefcasesForFiveRoundGame(IList<Button> briefcaseButtons, GameManager gameManager)
        {
            int tagToSet = 0;
            int contentToSet = 1;

            foreach (Button briefcase in briefcaseButtons)
            {

                if (gameManager.GetBriefcaseValue(tagToSet) == -1)
                {
                    briefcase.Visibility = Visibility.Collapsed;
                } else if (BriefcaseFormatForFiveRoundGame.Contains((int)briefcase.Tag))
                {
                    briefcase.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    briefcase.Tag = tagToSet.ToString();
                    briefcase.Content = contentToSet.ToString();
                    tagToSet++; 
                    contentToSet++;
                }
            }
        }
    }
}
