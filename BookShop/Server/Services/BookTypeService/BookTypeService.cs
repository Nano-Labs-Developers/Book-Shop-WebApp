namespace BookShop.Server.Services.BookTypeService
{
    public class BookTypeService : IBookTypeService
    {
        private readonly DataContext _context;

        public BookTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<BookType>>> GetBookTypes()
        {
            var bookTypes = await _context.BookTypes.ToListAsync();
            return new ServiceResponse<List<BookType>> { Data = bookTypes };
        }

        public async Task<ServiceResponse<List<BookType>>> AddBookType(BookType bookType)
        {
            bookType.Editing = bookType.IsNew = false;
            _context.BookTypes.Add(bookType);
            await _context.SaveChangesAsync();

            return await GetBookTypes();
        }

        public async Task<ServiceResponse<List<BookType>>> UpdateBookType(BookType bookType)
        {
            var dbbookType = await _context.BookTypes.FindAsync(bookType.Id);
            if (dbbookType == null)
            {
                return new ServiceResponse<List<BookType>>
                {
                    Success = false,
                    Message = "Product Type not found."
                };
            }

            dbbookType.Name = bookType.Name;
            await _context.SaveChangesAsync();

            return await GetBookTypes();
        }
    }
}
