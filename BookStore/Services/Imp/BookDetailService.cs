
using System.Runtime.InteropServices;

namespace BookStore.Services.Imp
{
    public class BookDetailService : IBookDetailService
    {
        private readonly ApplicationDbContext _context;

        public BookDetailService(ApplicationDbContext context,IAuthorService author)
        {
            _context = context;
        }

        public async Task<BookDetail> AddAsync(BookDetail bookDetails)
        {
            await _context.AddAsync(bookDetails);
            _context.SaveChanges();
            return bookDetails;
        }

        public BookDetail DeleteBook(BookDetail bookDetails)
        {
            _context.Remove(bookDetails);
            _context.SaveChanges();
            return bookDetails;
        }

        public async Task<IEnumerable<BookDetail>> GetAllAsync()
        {
            return await _context.BookDetails.Include(b => b.Author).ToListAsync();
        }

        public async Task<BookDetail> GetByIDAsync(int id)
        {
            return await _context.BookDetails.SingleOrDefaultAsync(b => b.Id == id);
        }

        public  BookDetail Update(BookDetail bookDetails)
        {
            _context.Update(bookDetails);   
            _context.SaveChanges();
            return bookDetails;
        }
    }
}
