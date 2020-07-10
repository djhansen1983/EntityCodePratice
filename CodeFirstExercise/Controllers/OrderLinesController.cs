using CodeFirstExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExercise.Controllers
{
    public class OrderLinesController
    {
        private AppDbContext _context = null;

        private async Task CalculateOrderTotal(int orderId)
        {
            _context = new AppDbContext();
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception("Order not found for calc");
            var orderlines = await _context.Orderline.Where(ol => ol.OrderId == orderId).ToListAsync();

            decimal total = 0m;

            foreach(var line in orderlines)
            {
                total += line.Quantity * line.Product.Price;
            }
            order.Total = total;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderLine> Get(int id)
        {
            return await _context.Orderline.FindAsync(id);
        }
        
        public async Task<OrderLine> Create(OrderLine orderline)
        {
            if (orderline == null) throw new Exception();
            await _context.Orderline.AddAsync(orderline);
            await CalculateOrderTotal(orderline.OrderId);
            await _context.SaveChangesAsync();
            return orderline;
        }

        public async Task Remove(OrderLine orderline)
        {

        }


        public OrderLinesController()
        {

        }


    }
}
