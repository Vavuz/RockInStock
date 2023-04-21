﻿namespace RockInStock.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int GuitarId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guitar Guitar { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
