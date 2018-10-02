using System;
using Microsoft.Bot.Builder.FormFlow;

namespace OrderBot.Shared.FormModels
{
    [Serializable]
    public class SupportModel
    {
        [Prompt("Please enter your {&}")]
        public string OrderNumber { get; set; }

        [Prompt("Please enter a short description of your {&}")]
        public string Problem { get; set; }

        [Prompt("Please enter your {&}")]
        public string Email { get; set; }
    }
}
