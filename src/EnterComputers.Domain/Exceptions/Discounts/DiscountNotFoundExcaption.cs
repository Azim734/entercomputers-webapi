namespace EnterComputers.Domain.Exceptions.Discounts;

public class DiscountNotFoundExcaption : NotFoundException
{
    public DiscountNotFoundExcaption()
    {
        this.TitleMessage = "Discount not found!";
    }
}
