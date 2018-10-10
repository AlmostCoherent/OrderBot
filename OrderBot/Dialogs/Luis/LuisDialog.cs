//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Builder.Luis;
//using Microsoft.Bot.Builder.Luis.Models;
//using System;
//using System.Threading.Tasks;

//namespace OrderBot.Dialogs.Luis
//{
//    [Serializable]
////    [LuisModel("6ae38cfe-3084-4c18-8a8d-dd75a60cf624", "e8ed78ec10214dbaa87d3721e6017e28")]
//    public class RootLuisDialog : LuisDialog<object>
//    {
//        [LuisIntent(LuisConstants.Intent_Support)]
//        public async Task SupportIntentDialog(IDialogContext context, LuisResult result)
//        {
//            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

//            await context.PostAsync(message);

//            context.Wait(MessageReceived);

//        }

//    }
//}