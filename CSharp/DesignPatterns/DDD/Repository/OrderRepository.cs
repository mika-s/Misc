using System;
using System.Collections.Generic;

namespace DesignPatterns.DDD.Repository
{
    public sealed class OrderRepository : IRepository<Order>
    {
        public Order Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
