namespace EnterComputers.Domain.Exceptions.Users;

public class UserAlreadyExistsException : AlreadyExixtsExcaption
{
    public UserAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }

    public UserAlreadyExistsException(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
