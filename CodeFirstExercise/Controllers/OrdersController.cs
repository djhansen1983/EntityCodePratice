using Castle.Components.DictionaryAdapter;
using CodeFirstExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExercise.Controllers
{
    public class OrdersController
    {
        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }


        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FindAsync();
        }

        public async Task<Order> Create(Order order)
        {
            if (order == null) throw new Exception("Order cannot be null");
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Change(int id, Order order)
        {
            if (order == null) throw new Exception("Order cannot be null");
            if (id != order.Id) throw new Exception("Oder Id does not match");
        }

        public async Task Remove(Order order)
        {
            if (order == null) throw new Exception("Order cannot be null");
            _context.Orders.Remove(order);

        }

        public async Task Remove(int id)
        {
            var ord = Get(id);
            if (ord == null) throw new Exception("Order does nto exist");
            await Remove(ord.Result);
        }


        public OrdersController()
        {
            _context = new AppDbContext();
        }

    }
}
