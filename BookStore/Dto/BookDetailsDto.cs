﻿using BookStore.Model;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto
{
    public class BookDetailsDto
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        public double Rate { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [MaxLength(50)]
        public String? Genre { get; set; }
        public IFormFile? BookImage { get; set; }
        public int AuthorId { get; set; }
    }
}
