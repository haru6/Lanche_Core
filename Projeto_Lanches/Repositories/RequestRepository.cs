using Projeto_Lanches.Database;
using Projeto_Lanches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly SnacksContext _context;
        private readonly CartBuy _cartBuy;

        public RequestRepository(SnacksContext context, CartBuy cartBuy)
        {
            _context = context;
            _cartBuy = cartBuy;
        }
        public void CreateRequest(Request request)
        {
            request.RequestSend = DateTime.Now;
            _context.Requests.Add(request);

            var cartBuy = _cartBuy.CartBuyItems;

            foreach (var item in cartBuy)
            {
                var requestDetail = new RequestDetail()
                {
                    Ammount = item.Amount,
                    SnackId = item.snack.Id,
                    RequestId = request.Id,
                    Price = item.snack.Price
                };
                _context.RequestDetails.Add(requestDetail);
            }
            _context.SaveChanges();
        }
    }
}
