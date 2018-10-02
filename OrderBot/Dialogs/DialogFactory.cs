using OrderBot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderBot.Dialogs
{
    public class DialogFactory : IDialogFactory
    {
        public dynamic Create(string typeOfDialogue)
        {
            WelcomeEnum welcomeEnum;
            Enum.TryParse(typeOfDialogue, out welcomeEnum);

            switch (welcomeEnum)
            {
                case WelcomeEnum.Support:
                    return new SupportDialog();
                default:
                    return new RootDialog();
            }
        }
    }
}