using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Dialogs
{
    public interface IDialogFactory
    {
        dynamic Create(string typeOfDialogue);
    }
}
