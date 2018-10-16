using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace OrderBot.Dialogs.Support
{
    [Serializable]
    public class SupportLuisDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var reply = await result;

            await context.PostAsync($"{ reply.ToString() }");

            context.Wait(MessageReceivedAsync);
        }

    }
}