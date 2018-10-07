using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using OrderBot.Entity.Models.Support;
using OrderBot.Utilities;
using System;

namespace OrderBot.Dialogs.Support
{
    public static class SupportForm
    {
        private static readonly ISupportRequestRepository _supportRepository = ServiceResolver.GetService<ISupportRequestRepository>();

        public static IForm<SupportModel> BuildForm()
        {
            OnCompletionAsyncDelegate<SupportModel> processHotelsSearch = async (context, state) =>
            {
                await context.PostAsync($"XXX");
            };

            return new FormBuilder<SupportModel>()
                .Message("Please give us a few details.")
                .Field(nameof(SupportModel.OrderNumber),
                    validate: async (state, value) => {
                        var result = new ValidateResult { IsValid = true, Value = value };
                        var order = _supportRepository.GetSupportRequestByID(Convert.ToInt32(value));
                        if (order != null)
                        {
                            return result;
                        }
                        else
                        {
                            result.Feedback = "Sorry, that order number isn't recognised. Can you check it's correct?";
                            result.IsValid = false;
                            return result;
                        }
                    })
                .Field(nameof(SupportModel.Email))
                .Field(nameof(SupportModel.Message))
                .Confirm(prompt: "Are the following detail correct?")
                .Message("Thanks for letting us know, we'll be in touch soon.")
                .OnCompletion(processHotelsSearch)
                .Build();

        }
    }
}