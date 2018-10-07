using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Linq;
using OrderBot.Entity;
using OrderBot.Entity.Models.Support;
using OrderBot.Utilities;
using Microsoft.Bot.Builder.FormFlow;

namespace OrderBot.Dialogs.Support
{
    [Serializable]
    public class SupportDialog : IDialog<object>
    {
        private static readonly ISupportRequestRepository _supportRepository = ServiceResolver.GetService<ISupportRequestRepository>();
        public SupportDialog()
        {
        }

        public async Task StartAsync(IDialogContext context)
        {
            var FormFromModel = FormDialog.FromForm(SupportForm.BuildForm, FormOptions.PromptFieldsWithValues);
            context.Call(FormFromModel, MessageReceivedAsync);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as SupportRequest;

            _supportRepository.InsertSupportRequest(activity);
            _supportRepository.Save();

            var id = activity.SupportId;

            var temp = _supportRepository.GetSupportRequests();

            await context.PostAsync("");
        }

    }
}