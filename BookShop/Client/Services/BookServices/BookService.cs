namespace BookShop.Client.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public List<Book> AdminBooks { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public string Message { get; set; } = "Loading books...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action OnBookChanged;

        public async Task<ServiceResponse<Book>> GetBook(int bookId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Book>>($"api/Book/{bookId}");
            return result;
        }

        public async Task GetBooks(string? categoryURL = null)
        {
            var result = categoryURL == null ?
                 await _http.GetFromJsonAsync<ServiceResponse<List<Book>>>("api/Book") :
                 await _http.GetFromJsonAsync<ServiceResponse<List<Book>>>($"api/Book/category/{categoryURL}");

            if (result != null && result.Data != null)
                Books = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Books.Count == 0)
                Message = "No books found";

            OnBookChanged.Invoke();
        }

        public async Task<Book> CreateBook(Book book)
        {
            var result = await _http.PostAsJsonAsync("api/Book", book);
            var newBook = (await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>()).Data;
            return newBook;
        }

        public async Task DeleteBook(Book book)
        {
            var result = await _http.DeleteAsync($"api/Book/{book.Id}");
        }

        public async Task GetAdminBooks()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Book>>>("api/Book/admin");
            AdminBooks = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminBooks.Count == 0)
                Message = "No books found.";
        }

        public async Task<List<string>> GetBookSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Book/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchBooks(string searchText, int page)
        {
            LastSearchText = searchText;
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<BookSearchResult>>($"api/Book/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Books = result.Data.Books;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Books.Count == 0) Message = "No books found.";
            OnBookChanged?.Invoke();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var result = await _http.PutAsJsonAsync($"api/Book", book);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
            return content.Data;
        }
    }
}
