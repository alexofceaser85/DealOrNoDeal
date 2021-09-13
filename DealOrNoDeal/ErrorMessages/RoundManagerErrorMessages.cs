namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    ///     Holds the error messages for the round manager
    ///     Author: Alex DeCesare
    ///     Version: 03-September-2021
    /// </summary>
    public static class RoundManagerErrorMessages
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
        /// The error message that tells the user that they should not have a null cases available for each round
        /// </summary>
        public const string ShouldNotAllowNullCasesAvailableForEachRound =
            "Cannot allow a round manager with null cases available for each round";

        /// <summary>
        /// The error messages that tells the user that they should not have an empty cases available for each round
        /// </summary>
        public const string ShouldNotAllowEmptyCasesAvailableForEachRound =
            "Cannot allow a round manager with an empty cases available for each round";

    }
}
