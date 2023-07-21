namespace EnterComputers.Domain.Exceptions.Companies
{
    public class CompaniesNotFoundExcaption : NotFoundException
    {
        public CompaniesNotFoundExcaption()
        {
            this.TitleMessage = "Company not found!";
        }
    }
}
