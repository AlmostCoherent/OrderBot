using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using OrderBot.Dialogs.Support;
using OrderBot.Shared.Enums;
using System;
using System.Threading.Tasks;

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