using System;
using System.Collections.Generic;

namespace refactorytryout.Models
{
    public enum Order_status{
        accepted = 1,
        sending = 2,
        done = 3,
        failure = 0
    }

    public class Order
    {
        public List<Order_item> Order_items { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Order_status Status {get; set;}
        public int DriverId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
    public class Customer{
        public List<Order> Orders { get; set;  }
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
    public class Product{
        public List<Order_item> Order_items { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

    }
    public class Driver{
        public List<Order> Orders { get; set; }
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

    }
    public class Order_item{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}