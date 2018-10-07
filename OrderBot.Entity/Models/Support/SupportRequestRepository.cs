using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    [Serializable]
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private OrderBotContext _context;

        public SupportRequestRepository(OrderBotContext context)
        {
            _context = context;
        }
        public IEnumerable<SupportRequest> GetSupportRequests()
        {
            return _context.SupportRecords.ToList();
        }

        public SupportRequest GetSupportRequestByID(int supportId)
        {
            return _context.SupportRecords.Find(supportId);
        }

        public void DeleteSupportRequest(int supportID)
        {
            SupportRequest supportModel = _context.SupportRecords.Find(supportID);
            _context.SupportRecords.Remove(supportModel);
        }

        public void InsertSupportRequest(SupportRequest support)
        {
            _context.SupportRecords.Add(support);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSupportRequest(SupportRequest support)
        {
            _context.Entry(support).State = System.Data.Entity.EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
