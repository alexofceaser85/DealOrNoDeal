namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GameManager"/> class.
        /// </summary>
        public GameManager()
        {

        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: None
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            // TODO Complete method according to the specifications above
            return -1;
        }

        /// <summary>
        ///     TODO Complete method specification
        /// </summary>
        /// <returns></returns>
        public int GetOffer()
        {
            // TODO Collaborates with the banker class to get and return the amount of the offer after the round has completed.
            //      Note: You will need to figure out the number of cases to open in the next round and once you have
            //
            return -1;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: Round == Round@prev + 1 AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            // TODO Complete this method according to its specification
        }

    }
}