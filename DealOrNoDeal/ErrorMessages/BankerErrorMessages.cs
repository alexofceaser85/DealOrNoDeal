using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the banker
    ///
    /// Author: Alex DeCesare
    /// Version: 03-September-2021
    /// </summary>
    public static class BankerErrorMessages
    {
        /// <summary>
        /// The error messages for calculating a banker offer from a null briefcases still in play
        /// </summary>
        public static string CannotCalculateBankerOfferIfBriefcasesStillInPlayAreNull = "Cannot calculate the banker offer if the briefcases still in play are null";

        public static string CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero =
            "Cannot calculate the banker offer if the briefcases still in play are less than or equal to zero";
    }
}
