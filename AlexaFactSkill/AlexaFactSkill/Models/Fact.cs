namespace AlexaFactSkill.Models
{
    public class Fact
    {
        /// <summary>
        /// Name of the Intent
        /// </summary>
        public string Intent { get; set; }

        /// <summary>
        /// Possible texts as string which are related to the Intent
        /// </summary>
        public string[] Texts { get; set; }
    }
}