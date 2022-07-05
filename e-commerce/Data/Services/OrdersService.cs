﻿using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ShopDbContext _context;

        public OrdersService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();
            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductID = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.ProductPrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
