using Microsoft.Bot.Builder.FormFlow;
using System;

namespace OrderBot.Dialogs.Support
{
    [Serializable]
    public class SupportModel
    {
        [Prompt("Can you give us the {&} that you have an issue with?")]
        public string OrderNumber { get; set; }
        [Prompt("Please enter your {&}")]
        [Pattern(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }
        [Prompt("Please enter a short description of your issue")]
        public string Message { get; set; }

    }
}