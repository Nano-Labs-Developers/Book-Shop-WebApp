namespace BookShop.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }

        Task GetCategories();

        event Action OnChange;

        List<Category> AdminCategories { get; set; }

        string Message { get; set; }

        int CurrentPage { get; set; }

        int PageCount { get; set; }

        Task GetAdminCategories();

        Task AddCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int categoryId);

        Category CreateNewCategory();
    }
}
