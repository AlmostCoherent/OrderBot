using Microsoft.Bot.Builder.FormFlow;
using System;

namespace OrderBot.Dialogs.Support
{
    [Serializable]
    public class SupportModel
    {
        [Prompt("Can you give us the {&} that you have an issue with?")]
        public string OrderNumber { get; set; }

        [Prompt("Please enter a short description of your {&}")]
        public string Message { get; set; }

        [Prompt("Please enter your {&}")]
        public string Email { get; set; }
    }
}