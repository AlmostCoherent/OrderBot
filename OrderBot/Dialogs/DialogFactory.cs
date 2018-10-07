using OrderBot.Dialogs.Support;
using OrderBot.Shared.Enums;
using System;

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