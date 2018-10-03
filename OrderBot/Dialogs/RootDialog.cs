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
            var reply = await result;

            context.PostAsync($"{ reply.ToString() }");

            context.Wait(MessageReceivedAsync);
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