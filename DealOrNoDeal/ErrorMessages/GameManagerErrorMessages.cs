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
        /// The error message that tells the user that they should not set initial banker current offer to less than zero
        /// </summary>
        public const string ShouldNotSetBankerCurrentOfferToLessThanZero =
            "Cannot set the current banker offer to a value less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker minimum offer to less than zero
        /// </summary>
        public const string ShouldNotSetBankerMinimumOfferToLessThanZero =
            "Cannot set the minimum banker offer to less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker minimum offer to more than maximum offer
        /// </summary>
        public const string ShouldNotSetBankerMinimumOfferToMoreThanMaximumOffer =
            "Cannot set the minimum banker offer to more than the maximum banker offer";

        /// <summary>
        /// The error message that tells the user that they should not set banker maximum offer to less than zero
        /// </summary>
        public const string ShouldNotSetBankerMaximumOfferToLessThanZero =
            "Cannot set the maximum banker offer to less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker maximum offer to less than minimum offer
        /// </summary>
        public const string ShouldNotSetBankerMaximumOfferToLessThanMinimumOffer =
            "Cannot set the maximum banker offer to less than the minimum banker offer";

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
