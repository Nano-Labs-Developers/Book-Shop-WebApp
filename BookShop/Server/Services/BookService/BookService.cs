namespace BookShop.Server.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Book>> CreateBook(Book book)
        {
            foreach (var variant in book.Variants)
            {
                variant.BookType = null;
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Book> { Data = book };
        }

        public async Task<ServiceResponse<bool>> DeleteBook(int bookId)
        {
            var dbBook = await _context.Books.FindAsync(bookId);
            if (dbBook == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Book not found."
                };
            }

            dbBook.Deleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Book>>> GetAdminBooks()
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                    .Where(b => !b.Deleted)
                    .Include(b => b.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.BookType)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Book>>> GetBookAsync()
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                    .Where(b => b.Visible && !b.Deleted)
                    .Include(b => b.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Book>> GetBookAsync(int bookId)
        {
            var response = new ServiceResponse<Book>();
            Book book = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                book = await _context.Books
                    .Include(b => b.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.BookType)
                    .FirstOrDefaultAsync(b => b.Id == bookId && !b.Deleted);
            }
            else
            {
                book = await _context.Books
                    .Include(b => b.Variants.Where(v => v.Visible && !v.Deleted))
                    .ThenInclude(v => v.BookType)
                    .FirstOrDefaultAsync(b => b.Id == bookId && !b.Deleted && b.Visible);
            }

            if (book == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this book does not exist.";
            }
            else
            {
                response.Data = book;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksbyCategory(string categoryURL)
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                    .Where(b => b.Category.URL.ToLower().Equals(categoryURL.ToLower()) &&
                        b.Visible && !b.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Book>>> GetFeaturedBooks()
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                    .Where(b => b.Featured && b.Visible && !b.Deleted)
                    .Include(b => b.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetBookSearchSuggestions(string searchText)
        {
            var books = await FindBooksBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var book in books)
            {
                if (book.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book.Title);
                }

                if (book.Description != null)
                {
                    var punctuation = book.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = book.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<BookSearchResult>> SearchBooks(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindBooksBySearchText(searchText)).Count / pageResults);
            var books = await _context.Books
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                    p.Description.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Include(p => p.Variants)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<BookSearchResult>
            {
                Data = new BookSearchResult
                {
                    Books = books,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<Book>> UpdateBook(Book book)
        {
            var dbBook = await _context.Books.FindAsync(book.Id);
            if (dbBook == null)
            {
                return new ServiceResponse<Book>
                {
                    Success = false,
                    Message = "Book not found."
                };
            }

            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.ImageURL = book.ImageURL;
            dbBook.CategoryId = book.CategoryId;
            dbBook.Visible = book.Visible;
            dbBook.Featured = book.Featured;

            foreach (var variant in book.Variants)
            {
                var dbVariant = await _context.BookVariants
                    .SingleOrDefaultAsync(v => v.BookId == variant.BookId &&
                        v.BookTypeId == variant.BookTypeId);
                if (dbVariant == null)
                {
                    variant.BookType = null;
                    _context.BookVariants.Add(variant);
                }
                else
                {
                    dbVariant.BookTypeId = variant.BookTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;
                }
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<Book> { Data = book };
        }
        private async Task<List<Book>> FindBooksBySearchText(string searchText)
        {
            return await _context.Books
                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                    p.Description.ToLower().Contains(searchText.ToLower()) &&
                    p.Visible && !p.Deleted)
                .Include(p => p.Variants)
                .ToListAsync();
        }

    }
}
