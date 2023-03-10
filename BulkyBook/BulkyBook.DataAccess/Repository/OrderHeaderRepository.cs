using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault( u => u.Id== id);
            if(orderfromDb != null)
            {
                orderfromDb.OrderStatus = orderStatus;
                if(paymentStatus != null)
                {
                    orderfromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessonId, string paymentItentId)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderfromDb.SessionId = sessonId;
            orderfromDb.PaymentIntentId = paymentItentId;
        }
    }
}
