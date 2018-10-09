using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    public class SupportRequestMessageRepository : ISupportRequestMessageRepository
    {
        private OrderBotContext _context;

        public SupportRequestMessageRepository(OrderBotContext context)
        {
            _context = context;
        }
        public IEnumerable<SupportRequestMessage> GetSupportRequestMessages()
        {
            return _context.SupportMessages.ToList();
        }

        public SupportRequestMessage GetSupportRequestMessageByID(int supportMessageId)
        {
            return _context.SupportMessages.Find(supportMessageId);
        }

        public void DeleteSupportRequestMessage(int supportMessageID)
        {
            SupportRequestMessage supportMessageModel = _context.SupportMessages.Find(supportMessageID);
            _context.SupportMessages.Remove(supportMessageModel);
        }

        public void InsertSupportRequestMessage(SupportRequestMessage supportMessage)
        {
            _context.SupportMessages.Add(supportMessage);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSupportRequestMessage(SupportRequestMessage supportMessage)
        {
            _context.Entry(supportMessage).State = System.Data.Entity.EntityState.Modified;
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
