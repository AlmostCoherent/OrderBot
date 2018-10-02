using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using OrderBot.Shared.Enums;
using Microsoft.Bot.Builder.FormFlow;

namespace OrderBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var reply = context.MakeMessage();
            HeroCard heroCard = new HeroCard
            {
                Title = "Hi, what can I help you with?",
                Images = new List<CardImage> { new CardImage("https://www.fillmurray.com/640/360") },
                Buttons = new List<CardAction> {
                                    new CardAction(type: ActionTypes.PostBack, title: "Existing Order", value: WelcomeEnum.ExistingOrder.ToString()),
                                    new CardAction(type: ActionTypes.PostBack, title: "New Order", value: WelcomeEnum.NewOrder.ToString()),
                                    new CardAction(type: ActionTypes.PostBack, title: "Help", value: WelcomeEnum.Support.ToString()) }
            };

            reply.Attachments.Add(heroCard.ToAttachment());

            await context.PostAsync(reply);

            context.Wait(this.OnOptionSelected);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if(message.Text == WelcomeEnum.Support.ToString())
            {
                context.Call(new SupportDialog(), OnCompletetionOfChild);
            }
            else
            {
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task OnCompletetionOfChild(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }
    }
}