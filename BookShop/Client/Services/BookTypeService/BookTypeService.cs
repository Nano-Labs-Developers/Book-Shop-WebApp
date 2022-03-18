namespace BookShop.Client.Services.BookTypeService
{
    public class BookTypeService : IBookTypeService
    {
        private readonly HttpClient _http;

        public BookTypeService(HttpClient http)
        {
            _http = http;
        }

        public List<BookType> BookTypes { get; set; } = new List<BookType>();

        public event Action OnChange;

        public async Task AddBookType(BookType productType)
        {
            var response = await _http.PostAsJsonAsync("api/booktype", productType);
            BookTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BookType>>>()).Data;
            OnChange.Invoke();
        }

        public BookType CreateNewBookType()
        {
            var newBookType = new BookType { IsNew = true, Editing = true };

            BookTypes.Add(newBookType);
            OnChange.Invoke();
            return newBookType;
        }

        public async Task GetBookTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<BookType>>>("api/booktype");
            BookTypes = result.Data;
        }

        public async Task UpdateBookType(BookType productType)
        {
            var response = await _http.PutAsJsonAsync("api/booktype", productType);
            BookTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BookType>>>()).Data;
            OnChange.Invoke();
        }
    }
}
