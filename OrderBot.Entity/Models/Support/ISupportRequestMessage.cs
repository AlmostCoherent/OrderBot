using OrderBot.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    public interface ISupportRequestMessageRepository
    {
        IEnumerable<SupportRequestMessage> GetSupportRequestMessages();
        SupportRequestMessage GetSupportRequestMessageByID(int supportId);
        void InsertSupportRequestMessage(SupportRequestMessage support);
        void DeleteSupportRequestMessage(int messageID);
        void UpdateSupportRequestMessage(SupportRequestMessage support);
        void Save();
    }
}
