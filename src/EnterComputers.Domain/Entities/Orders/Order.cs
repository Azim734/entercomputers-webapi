using EnterComputers.Domain.Enums;

namespace EnterComputers.Domain.Entities.Orders;

public class Order : Auditable 
{
    public long UserId { get; set; }

    public OrderStatus Status { get; set; }

    // the summ of order details result prices
    // the money which that user must pay for product
    public double ProductsPrice { get; set; }


    // the payment that user must pay for sale
    //product price
    public double ResultPrice { get; set; }

    public double latitude { get; set; }

    public double longitude { get; set; }

    public PaymentType Payment {  get; set; }

    public bool IsPaid { get; set; }

    public bool IsContracted { get; set; }

    public string Description { get; set; } = string.Empty;
}
