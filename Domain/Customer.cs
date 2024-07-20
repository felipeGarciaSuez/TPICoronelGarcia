﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public void CreateOrder(Order order)
        {
            Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
        }

        public void CreateAccount()
        {
            // Lógica para crear una cuenta
        }
    }
}