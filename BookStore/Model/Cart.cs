﻿namespace BookStore.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public double  TotalPrice { get; set; }
        public ICollection<BookProduct> Product { get; set; }
    }
}
