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
        /// The error message that tells the user that they should not allow null dollar amounts for each round
        /// </summary>
        public const string ShouldNotAllowNullDollarAmountsForEachRound =
            "Cannot allow a null value for the dollar amounts for each round";

        /// <summary>
        /// The error message that tells the user that they should not allow null cases to open for each round
        /// </summary>
        public const string ShouldNotAllowNullCasesToOpenForEachRound =
            "Cannot allow a null value for the cases to open for each round";

        /// <summary>
        /// The error message that tells the user that they should not set play selected starting case to less than zero
        /// </summary>
        public const string ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne =
            "Cannot set the selected starting case to a value less than zero";
    }
}
