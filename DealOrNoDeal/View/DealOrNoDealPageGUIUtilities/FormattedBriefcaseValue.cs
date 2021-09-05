using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{
    /// <summary>
    /// Formats the briefcase value
    ///
    /// Author: Alex DeCesare
    /// Version: 05-September-2021
    /// </summary>
    public static class FormattedBriefcaseValue
    {
        /// <summary>
        /// Returns the formatted version of the briefcase value
        /// </summary>
        /// <param name="gameManager">The manager where the briefcase index exists</param>
        /// <param name="idToGet">The Id of the briefcase value to formatted</param>
        /// <returns></returns>
        public static string GetFormattedBriefcaseValue(GameManager gameManager, int idToGet)
        {
            if (idToGet == gameManager.PlayerSelectedStartingCase)
            {
                return gameManager.PlayerSelectedStartingCaseDollarAmount.ToString("C");
            }

            return gameManager.GetBriefcaseValue(idToGet).ToString("C");
        }
    }
}
