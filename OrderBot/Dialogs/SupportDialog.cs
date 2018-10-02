using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using OrderBot.Shared.FormModels;

namespace OrderBot.Dialogs
{
    [Serializable]
    public class SupportDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Welcome to the Form!");

            var FormFromModel = FormDialog.FromForm(this.BuildForm, FormOptions.PromptFieldsWithValues);

            context.Call(FormFromModel, MessageReceivedAsync);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            // TODO: Put logic for handling user message here

            await context.PostAsync(activity.Text);
        }

        private IForm<SupportModel> BuildForm()
        {
            OnCompletionAsyncDelegate<SupportModel> processHotelsSearch = async (context, state) =>
            {
                await context.PostAsync($"{ state.Problem }");
            };

            return new FormBuilder<SupportModel>()
                .Message("Please give us a few details.")
                .Field(nameof(SupportModel.OrderNumber))
                .Field(nameof(SupportModel.Email))
                .Field(nameof(SupportModel.Problem))
                .Confirm(prompt: "")
                .Message("Thanks for letting us know, we'll be in touch soon.")
                .AddRemainingFields()
                .OnCompletion(processHotelsSearch)
                .Build();

        }
    }
}