﻿namespace EnterComputers.Service.Validators;

public class PasswordValidator
{
    public static string Symbols { get; } = "~`! @#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
    public static (bool IsValid, string Message) IsStrongPassword(string password)
    {
        if (password.Length < 8) return (IsValid: false, Message: "Password can not be less than 8 characters!");

        bool IsUpperCaseExists = false;
        bool IsLowerCaseExists = false;
        bool IsNumberExists = false;
        bool IsCharacterExists = false;

        foreach(var item in password)
        {
            if (char.IsUpper(item))  IsUpperCaseExists = true;
            if (char.IsLower(item))  IsLowerCaseExists = true;
            if (char.IsDigit(item))  IsNumberExists = true;
            if (Symbols.Contains(item)) IsCharacterExists = true;   
        }

        if (IsNumberExists == false) return (IsValid: false, Message: "Password should contain at least one digit!");
        if (IsUpperCaseExists == false) return (IsValid: false, Message: "Password should contain at least one Upper case!");
        if (IsLowerCaseExists == false) return (IsValid: false, Message: "Password should contain at least one Lover case!");
        if (IsCharacterExists == false) return (IsValid: false, Message: "Password should contain at least one Symbol like (@#(*&$%^)!");

        return (IsValid: true, "");




    }
}
