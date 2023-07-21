namespace EnterComputers.Domain.Exceptions.Products;

public class ProductNotFoundExcaption : NotFoundException
{
    public ProductNotFoundExcaption()
    {
        this.TitleMessage = "Product not found!";
    }
}
