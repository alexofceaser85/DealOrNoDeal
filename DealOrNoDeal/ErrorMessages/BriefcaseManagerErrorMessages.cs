using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the briefcase manager
    ///
    /// Author: Alex DeCesare
    /// Version: 01-September-2021
    /// </summary>
    public class BriefcaseManagerErrorMessages
    {
        public const string ShouldNotCreateNeWBriefcaseManagerIfTheBriefcaseDollarAmountsAreNull =
            "Cannot create a new briefcase manager is the briefcase dollar amounts are null";
        /// <summary>
        /// The error message that tells the user that they should not populate briefcases if indexes of dollar values are null
        /// </summary>
        public const string ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull =
            "Cannot populate the briefcase dollar values because the indexes to access the briefcase dollar values are null";

        /// <summary>
        /// The error message that tells the user that they should not populate briefcases if dollar values are null
        /// </summary>
        public const string ShouldNotPopulateBriefcasesIfDollarValuesAreNull =
            "Cannot populate the briefcase dollar values because the briefcase dollar values are null";
    }
}
