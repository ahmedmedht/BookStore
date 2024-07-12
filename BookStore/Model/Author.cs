using System.ComponentModel.DataAnnotations;

namespace BookStore.Model
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public byte Age { get; set; }
        public byte[]  ImageAuthor { get; set; }
        public ICollection<BookDetail> BookDetail { get; set; }
    }
}