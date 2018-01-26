using System;
using System.Collections.Generic;
using System.Linq;
using AlexaFactSkill.Extensions;
using AlexaFactSkill.Models;

namespace AlexaFactSkill.Services
{
    public static class FactService
    {
        /// <summary>
        /// Gets the fact accosiated with the intent.
        /// </summary>
        /// <param name="intentName">Name of the intent.</param>
        /// <returns>Fact</returns>
        public static Fact GetFact(string intentName)
        {
            var facts = GetFacts();
            var filteredFact = facts.FirstOrDefault(fact => fact.Intent.Equals(intentName, StringComparison.CurrentCultureIgnoreCase));

            return filteredFact;
        }

        /// <summary>
        /// Gets a random fact.
        /// </summary>
        /// <returns></returns>
        public static Fact GetRandomFact()
        {
            var facts = GetFacts();

            return facts.PickRandom();
        }

        /// <summary>
        /// Gets the facts from the local stored json file.
        /// </summary>
        /// <returns>List of facts.</returns>
        private static IEnumerable<Fact> GetFacts()
        {
            // TODO: Please insert here the correct link to the json file.
            return EmbeddedResourceService.GetData<IEnumerable<Fact>>("AlexaFactSkill.Data.facts.json");
        }
    }
}
