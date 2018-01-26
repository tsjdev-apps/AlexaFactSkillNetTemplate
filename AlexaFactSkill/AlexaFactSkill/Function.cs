using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaFactSkill.Extensions;
using AlexaFactSkill.Services;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaFactSkill
{
    public class Function
    {
        // necessary intent from amazon
        private const string AmazonStopIntent = "AMAZON.StopIntent";
        private const string AmazonCancelIntent = "AMAZON.CancelIntent";
        private const string AmazonHelpIntent = "AMAZON.HelpIntent";

        // custom intent
        // TODO: Please be sure to have an intent called RandomIntent 
        //       created in the developer console or update name here
        private const string RandomIntent = "RandomIntent";

        /// <summary>
        /// Entry point for an Alexa request.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();

            if (requestType == typeof(LaunchRequest))
                return MakeSkillResponse(MessagesService.GetLaunchMessage(), false);

            if (requestType != typeof(IntentRequest))
                return MakeSkillResponse(MessagesService.GetErrorMessage(), true);

            if (!(input.Request is IntentRequest intentRequest))
                return MakeSkillResponse(MessagesService.GetErrorMessage(), true);

            switch (intentRequest.Intent.Name)
            {
                case AmazonHelpIntent:
                    return MakeSkillResponse(MessagesService.GetHelpMessage(), false);
                case AmazonCancelIntent:
                    return MakeSkillResponse(MessagesService.GetCancelMessage(), true);
                case AmazonStopIntent:
                    return MakeSkillResponse(MessagesService.GetStopMessage(), true);
                default:
                    return HandleFactSkill(intentRequest.Intent.Name);
            }
        }

        /// <summary>
        /// Handles the fact intent and return a fact.
        /// </summary>
        /// <param name="intentName">Name of the intent.</param>
        /// <returns>The SkillResponse.</returns>
        private static SkillResponse HandleFactSkill(string intentName)
        {
            if (intentName == RandomIntent)
            {
                var randomFact = FactService.GetRandomFact();
                return MakeSkillResponse(randomFact.Texts.PickRandom(), true);
            }

            var fact = FactService.GetFact(intentName);
            return MakeSkillResponse(fact == null ? MessagesService.GetErrorMessage() : fact.Texts.PickRandom(), true);
        }

        /// <summary>
        /// Makes the skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <returns></returns>
        private static SkillResponse MakeSkillResponse(string outputSpeech, bool shouldEndSession)
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech },
            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            return skillResponse;
        }
    }
}
