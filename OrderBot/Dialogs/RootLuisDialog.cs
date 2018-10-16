using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using OrderBot.Dialogs.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OrderBot.Dialogs
{
    [LuisModel("6ae38cfe-3084-4c18-8a8d-dd75a60cf624", "e8ed78ec10214dbaa87d3721e6017e28")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Support.NewRequest")]
        public async Task Support(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            string message = $"Sorry to hear you're having problems. What can we help you with toay?";

            await context.PostAsync(message);

            var supprtDialog = new SupportLuisDialog();
            context.Call(supprtDialog, this.ResumeAfter);
        }

        public async Task ResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }
    }
}