namespace BookShop.Client.Services.BookServices
{
    public interface IBookService
    {
        event Action OnBookChanged;

        List<Book> Books { get; set; }

        List<Book> AdminBooks { get; set; }

        string Message { get; set; }

        int CurrentPage { get; set; }

        int PageCount { get; set; }

        string LastSearchText { get; set; }

        Task GetBooks(string? categoryURL = null);

        Task<ServiceResponse<Book>> GetBook(int bookId);

        Task SearchBooks(string searchText, int page);

        Task<List<string>> GetBookSearchSuggestions(string searchText);

        Task GetAdminBooks();

        Task<Book> CreateBook(Book product);

        Task<Book> UpdateBook(Book product);

        Task DeleteBook(Book product);
    }
}
