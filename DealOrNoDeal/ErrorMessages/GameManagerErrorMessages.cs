namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the game manager
    ///
    /// Author: Alex DeCesare
    /// Version: 31-August-2021
    /// </summary>
    public class GameManagerErrorMessages
    {
        /// <summary>
        /// The error message that tells the user that they should not set current round to less than one
        /// </summary>
        public const string ShouldNotSetCurrentRoundToLessThanOne =
            "Cannot set the current round to a value less than one";

        /// <summary>
        /// The error message that tells the user that they should not set cases left for current round to less than zero
        /// </summary>
        public const string ShouldNotSetCasesLeftForCurrentRoundToLessThanZero =
            "Cannot set the cases left for the current round to a value less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set play selected starting case to less than zero
        /// </summary>
        public const string ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne =
            "Cannot set the selected starting case to a value less than zero";

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
