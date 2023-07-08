using System.Text.RegularExpressions;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;

namespace Vehicle.Doctor.System.API.Applications.Utils;

public static class RegexExtension
{
    public static bool IsNumber(this string num)
    {
        var r = new Regex(@"^[0-9]+$");
        return r.IsMatch(num);
    }

    public static string ValidatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 8)
        {
            throw new InvalidPhoneNumberException(phoneNumber);
        }

        phoneNumber = phoneNumber.Trim().Replace("+", "").Replace(" ", "");

        if (!phoneNumber.IsNumber()) throw new InvalidPhoneNumberException(phoneNumber);
        return phoneNumber;
    }
}