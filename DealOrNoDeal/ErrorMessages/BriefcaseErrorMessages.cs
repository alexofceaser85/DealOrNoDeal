using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the Briefcase class.
    /// </summary>
    public static class BriefcaseErrorMessages
    {
        /// <summary>
        /// The brief case identifier cannot be zero or less
        /// </summary>
        public const string BriefCaseIdCannotBeZeroOrLess = "The brief case Id cannot be less than zero";
        /// <summary>
        /// The dollar amount cannot be less than zero
        /// </summary>
        public const string DollarAmountCannotBeLessThanZero = "The dollar amount cannot be less than zero";
    }
}
