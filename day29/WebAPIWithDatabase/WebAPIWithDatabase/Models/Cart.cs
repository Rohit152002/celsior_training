﻿namespace WebAPIWithDatabase.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? WishList { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
