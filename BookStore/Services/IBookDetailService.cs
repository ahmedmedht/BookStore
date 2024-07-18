using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services
{
    public interface IBookDetailService
    {
        Task<IEnumerable<BookDetail>> GetAllAsync();
        Task<BookDetail> AddAsync(BookDetail bookDetails);
        Task<BookDetail> GetByIDAsync(int id);
        BookDetail Update(BookDetail bookDetails);
        BookDetail DeleteBook(BookDetail bookDetails);
                
    }
}
