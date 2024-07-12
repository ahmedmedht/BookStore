﻿using BookStore.Model;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public double Rate { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [MaxLength(50)]
        public String? Genre { get; set; }
        public IFormFile? BookImage { get; set; }
        [MaxLength(100)]
        public String AuthorName { get; set; }
    }
}
