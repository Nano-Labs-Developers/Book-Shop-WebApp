namespace BookShop.Server.Services.BookTypeService
{
    public interface IBookTypeService
    {
        Task<ServiceResponse<List<BookType>>> GetBookTypes();

        Task<ServiceResponse<List<BookType>>> AddBookType(BookType bookType);

        Task<ServiceResponse<List<BookType>>> UpdateBookType(BookType bookType);
    }
}
