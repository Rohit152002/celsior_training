﻿namespace WebAPIWithDatabase.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageUrl { get; set; }=string.Empty;
    }
}
