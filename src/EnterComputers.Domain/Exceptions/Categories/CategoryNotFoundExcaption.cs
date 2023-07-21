namespace EnterComputers.Domain.Exceptions.Categories
{
    public class CategoryNotFoundExcaption : NotFoundException
    {
        public CategoryNotFoundExcaption() 
        {
            this.TitleMessage = "Category not found!";
        }
    }
}
