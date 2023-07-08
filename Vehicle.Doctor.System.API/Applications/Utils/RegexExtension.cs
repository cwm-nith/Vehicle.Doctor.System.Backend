using System.Text.RegularExpressions;

namespace Vehicle.Doctor.System.API.Applications.Utils;

public static class RegexExtension
{
    public static bool IsNumber(this string num)
    {
        var r = new Regex(@"^[0-9]+$");
        return r.IsMatch(num);
    }
}