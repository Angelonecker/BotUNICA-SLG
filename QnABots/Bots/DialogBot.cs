// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.9.2

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QnABots.Models;
using RestSharp;    

namespace QnABots.Bots
{
    // This IBot implementation can run any type of Dialog. The use of type parameterization is to allows multiple different bots
    // to be run at different endpoints within the same project. This can be achieved by defining distinct Controller types
    // each with dependency on distinct IBot types, this way ASP Dependency Injection can glue everything together without ambiguity.
    // The ConversationState is used by the Dialog system. The UserState isn't, however, it might have been used in a Dialog implementation,
    // and the requirement is that all BotState objects are saved at the end of a turn.
    public class DialogBot<T> : ActivityHandler
        where T : Dialog
    {
        protected readonly Dialog Dialog;
        protected readonly BotState ConversationState;
        protected readonly BotState UserState;
        protected readonly ILogger Logger;

        public DialogBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger)
        {
            ConversationState = conversationState;
            UserState = userState;
            Dialog = dialog;
            Logger = logger;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                string receivedQuestion = string.Format("{{\"question\":\"{0}\"}}", turnContext.Activity.Text);
                var client = new RestClient("https://qnmunica-slg.azurewebsites.net/qnamaker/knowledgebases/94b3a4e3-82e4-4a71-8219-7e26769bf004/generateAnswer");
                
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "EndpointKey b36bea5f-5c4a-4f1e-bd23-7fc00f730409");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", "ARRAffinity=2ab35d85b8ae4a94f2ff2b977e3682bb4e7b7bbb826b44af6c1215b501938a8d");
                request.AddParameter("undefined", receivedQuestion, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var createdAnswer = JsonConvert.DeserializeObject<Answer>(response.Content).answers[0].answer;
                await turnContext.SendActivityAsync(createdAnswer);
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Running dialog with Message Activity.");

            // Run the Dialog with the new message Activity.
            await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
        }
    }
}
