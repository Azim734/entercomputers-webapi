using EnterComputers.DataAcces.Common.Interfaces;
using EnterComputers.DataAcces.Utils;
using EnterComputers.Domain.Entities.Discounts;

namespace EnterComputers.DataAcces.Interfaces.Discounts;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{}
