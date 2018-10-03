using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Collections.Generic;
using OrderBot.Shared.Enums;
using OrderBot.Dialogs;

namespace OrderBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private IDialogFactory _dialogFactory;
        public MessagesController(IDialogFactory dialogFactory)
        {
            _dialogFactory = dialogFactory;
        }
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, () => _dialogFactory.Create(activity.Text));
                await Conversation.SendAsync(activity, () => new RootDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
                IConversationUpdateActivity update = message;
                var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
                if (update.MembersAdded != null && update.MembersAdded.Any())
                {
                    foreach (var newMember in update.MembersAdded)
                    {
                        if (newMember.Id != message.Recipient.Id)
                        {
                            HeroCard heroCard = new HeroCard
                            {
                                Title = "Hi, what can I help you with?",
                                Images = new List<CardImage> { new CardImage("https://www.fillmurray.com/640/360") },
                                Buttons = new List<CardAction> {
                                    new CardAction(type: ActionTypes.PostBack, title: "Existing Order", value: WelcomeEnum.ExistingOrder.ToString()),
                                    new CardAction(type: ActionTypes.PostBack, title: "New Order", value: WelcomeEnum.NewOrder.ToString()),
                                    new CardAction(type: ActionTypes.PostBack, title: "Help", value: WelcomeEnum.Support.ToString()) }
                            };
                            var reply = message.CreateReply();
                            reply.Attachments.Add(heroCard.ToAttachment());
                            client.Conversations.ReplyToActivityAsync(reply);
                        }
                    }
                }
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }

    }
}