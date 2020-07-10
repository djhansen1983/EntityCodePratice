using CodeFirstExercise.Controllers;
using CodeFirstExercise.Models;
using System;
using System.Threading.Tasks;

namespace CodeFirstExercise
{
    public class Program
    {
        private static object lineCtrl;

        static async Task Main(string[] args)
        {
            //await TestProduct();
            await TestOrderlines();
            



        }
        static async Task TestOrderlines()
        {
            var lineCrtl = new OrderLinesController();
            var orderline = new OrderLine()
            {
                Id = 0,
                OrderId = 1,
                ProductId = 4,
                Quantity = 1
            };
            await lineCrtl.Create(orderline);
        }
        static async Task TestOrders()
        {
            var ordCtrl = new OrdersController();
            var orders = await ordCtrl.GetAll();
        }
        static async Task TestCustomer()
        {
            var custCtrl = new CustomersController();

            //var cust = new Customer()
            //{
            //    Id = 0, Name = "Max Tech Training", 
            //    State = "OH", 
            //    IsNationalAccount = false, 
            //    TotalSales = 1000
            //};
            //cust = await custCtrl.Create(cust);
            //
            //var customers = await custCtrl.GetAll();

            //var cust2 = await custCtrl.Get(1);

            await custCtrl.Remove(1);
        }

        static async Task TestProduct()
        {
            var prodCtrl = new ProductsController();
            var prod = new Product()
            {
                Id = 0,
                Name = "Echo Show 5",
                Price = 129.99m,
                InStock = true
            };
            prod = await prodCtrl.Create(prod);

            var products = await prodCtrl.GetAll();

            var prod2 = await prodCtrl.Get(1);
        }
    }
}
