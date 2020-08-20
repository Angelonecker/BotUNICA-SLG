// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var replyText = $"BotUNICA-SLG: {turnContext.Activity.Text}";
=======
            var replyText = $"Echo: {turnContext.Activity.Text}";
>>>>>>> parent of 2e3fe8b... Revert "Create BotUNICA-SLG-src.zip"
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var welcomeText = "Hola Innovador!";
=======
            var welcomeText = "Hello and welcome!";
>>>>>>> parent of 2e3fe8b... Revert "Create BotUNICA-SLG-src.zip"
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
<<<<<<< HEAD
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hola Innovador!"), cancellationToken);
=======
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
>>>>>>> parent of 2e3fe8b... Revert "Create BotUNICA-SLG-src.zip"
                }
            }
        }
    }
}
