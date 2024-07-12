namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> AddAsync(Author author);
        Author AddBookToAuthor(Author author,BookDetail bookDetail);

        Task<Author> GetByIDAsync(int id);
        Task<Author> GetByNameAsync(string name);

        Author Update(Author author);
        Author DeleteAuthor(Author author);
    }
}
