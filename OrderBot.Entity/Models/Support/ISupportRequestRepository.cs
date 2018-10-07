using OrderBot.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    public interface ISupportRequestRepository
    {
        IEnumerable<SupportRequest> GetSupportRequests();
        SupportRequest GetSupportRequestByID(int supportId);
        void InsertSupportRequest(SupportRequest support);
        void DeleteSupportRequest(int supportID);
        void UpdateSupportRequest(SupportRequest support);
        void Save();
    }
}
