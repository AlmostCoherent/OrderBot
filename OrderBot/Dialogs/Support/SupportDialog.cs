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
        private static readonly ISupportRequestMessageRepository _supportRequestMessageRepository = ServiceResolver.GetService<ISupportRequestMessageRepository>();
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
            var activity = await result as SupportModel;

            SupportRequest supportRequest = CreateSupportRequestEntity(activity);

            _supportRepository.InsertSupportRequest(supportRequest);
            _supportRepository.Save();

            SupportRequestMessage supportRequestMessage = CreateSupportRequestMessageEntity(activity, supportRequest);

            _supportRequestMessageRepository.InsertSupportRequestMessage(supportRequestMessage);
            _supportRequestMessageRepository.Save();

            await context.PostAsync("");
        }

        private static SupportRequestMessage CreateSupportRequestMessageEntity(SupportModel activity, SupportRequest supportRequest)
        {
            var newSupportId = supportRequest.SupportId;

            SupportRequestMessage supportRequestMessage = new SupportRequestMessage();
            supportRequestMessage.MessageDate = DateTime.Now;
            supportRequestMessage.SupportMessage = activity.Message;
            supportRequestMessage.SupportId = newSupportId;
            return supportRequestMessage;
        }

        private static SupportRequest CreateSupportRequestEntity(SupportModel activity)
        {
            var supportRequest = new SupportRequest();

            supportRequest.Email = activity.Email;
            supportRequest.OrderNumber = Int32.Parse(activity.OrderNumber);
            supportRequest.Status = SupportStatus.New;
            return supportRequest;
        }
    }
}