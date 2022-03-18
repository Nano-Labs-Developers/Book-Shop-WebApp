namespace BookShop.Server.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetBookAsync();

        Task<ServiceResponse<Book>> GetBookAsync(int bookId);

        Task<ServiceResponse<List<Book>>> GetBooksbyCategory(string categoryURL);

        Task<ServiceResponse<BookSearchResult>> SearchBooks(string searchText, int page);
        
        Task<ServiceResponse<List<string>>> GetBookSearchSuggestions(string searchText);
        
        Task<ServiceResponse<List<Book>>> GetFeaturedBooks();
        
        Task<ServiceResponse<List<Book>>> GetAdminBooks();
        
        Task<ServiceResponse<Book>> CreateBook(Book product);
        
        Task<ServiceResponse<Book>> UpdateBook(Book product);
        
        Task<ServiceResponse<bool>> DeleteBook(int productId);
    }
}
