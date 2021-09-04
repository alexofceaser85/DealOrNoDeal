using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Handles the management of the briefcases
    ///
    /// Author: Alex DeCesare
    /// Version: 04-September-2021
    /// </summary>
    public class BriefcaseManager
    {
        /// <summary>
        /// The amount of briefcases in the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public IList<Briefcase> Briefcases { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BriefcaseManager" /> class.
        ///
        /// Precondition: briefcaseValues != null
        /// Postcondiiton: this.Briefcases.Count > 0
        /// </summary>
        /// <param name="briefCaseDollarAmounts">The dollar amounts that each briefcase can contain</param>
        public BriefcaseManager(IList<int> briefCaseDollarAmounts)
        {
            if (briefCaseDollarAmounts == null)
            {
                throw new ArgumentException(BriefcaseManagerErrorMessages
                    .ShouldNotCreateNeWBriefcaseManagerIfTheBriefcaseDollarAmountsAreNull);
            }

            var numberOfDollarAmounts = briefCaseDollarAmounts.Count;
            var randomBriefcaseDollarAmountIndexes = this.createPopulatedIndexes(numberOfDollarAmounts, 0,
                numberOfDollarAmounts);

            this.PopulateBriefcases(randomBriefcaseDollarAmountIndexes, briefCaseDollarAmounts);
        }

        private IList<int> createPopulatedIndexes(int numberOfIndexesToGenerate,
            int minimumValueToGenerate, int maximumValueToGenerate)
        {
            var randomNumberGenerator = new Random();
            IList<int> randomIndexes = new List<int>();
            IList<int> previousIndexes = new List<int>();

            for (var counter = 0; counter < numberOfIndexesToGenerate; counter++)
            {
                var currentIndex = this.findCurrentUnusedRandomIndex(minimumValueToGenerate, maximumValueToGenerate, randomNumberGenerator, previousIndexes);

                randomIndexes.Add(currentIndex);
                previousIndexes.Add(currentIndex);
            }

            return randomIndexes;
        }

        private int findCurrentUnusedRandomIndex(int minimumValueToGenerate, int maximumValueToGenerate,
            Random randomNumberGenerator, IList<int> previousIndexes)
        {
            int currentIndex;
            do
            {
                currentIndex = randomNumberGenerator.Next(minimumValueToGenerate, maximumValueToGenerate);
            } while (previousIndexes.Contains(currentIndex));

            return currentIndex;
        }

        /// <summary>
        ///     Populates the briefcases
        ///     Precondition:
        ///     indexesOfDollarValuesToPopulate != null
        ///     AND dollarValuesToPopulate != null
        ///     Postcondition:
        ///     this.Briefcases == thePopulatedBriefcases
        /// </summary>
        /// <param name="indexesOfDollarValuesToPopulate">
        ///     The index of the array element which is used to get a value from the
        ///     dollar values
        /// </param>
        /// <param name="dollarValuesToPopulate">The dollar values which are to be accessed</param>
        /// <return>The populated briefcases</return>
        public void PopulateBriefcases(IList<int> indexesOfDollarValuesToPopulate, IList<int> dollarValuesToPopulate)
        {
            if (indexesOfDollarValuesToPopulate == null)
            {
                throw new ArgumentException(BriefcaseManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull);
            }

            if (dollarValuesToPopulate == null)
            {
                throw new ArgumentException(BriefcaseManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfDollarValuesAreNull);
            }

            this.Briefcases = this.createPopulatedBriefcases(indexesOfDollarValuesToPopulate, dollarValuesToPopulate);
        }

        private IList<Briefcase> createPopulatedBriefcases(IList<int> indexesOfDollarValuesToPopulate, IList<int> dollarValuesToPopulate)
        {
            IList<Briefcase> populatedBriefcases = new List<Briefcase>();

            for (var counter = 0; counter < indexesOfDollarValuesToPopulate.Count; counter++)
            {
                var currentDollarAmountIndex = indexesOfDollarValuesToPopulate[counter];
                var newBriefcase = new Briefcase(counter, dollarValuesToPopulate[currentDollarAmountIndex]);
                populatedBriefcases.Add(newBriefcase);
            }

            return populatedBriefcases;
        }

        /// <summary>
        ///     Gets the briefcase value.
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        /// <param name="briefcaseIdToGet">The briefcase identifier to get.</param>
        /// <returns>
        ///     the dollar amount of the briefcase that has been selected, -1 if the briefcase Id is not present in the briefcases
        /// </returns>
        public int GetBriefcaseValue(int briefcaseIdToGet)
        {
            var theSelectedBriefcase = this.getBriefcaseById(briefcaseIdToGet);

            if (theSelectedBriefcase == null)
            {
                return -1;
            }

            return theSelectedBriefcase.DollarAmount;
        }

        private Briefcase getBriefcaseById(int briefcaseIdToGet)
        {
            return this.Briefcases.SingleOrDefault(p => p.BriefcaseId == briefcaseIdToGet);
        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: None
        ///     Postcondition: this.Briefcases.Count@prev == this.Briefcases.Count - 1
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcase(int id)
        {
            var briefcaseToRemove = this.getBriefcaseById(id);
            if (briefcaseToRemove == null)
            {
                return -1;
            }

            this.Briefcases.Remove(this.getBriefcaseById(id));
            return briefcaseToRemove.DollarAmount;
        }

    }
}
