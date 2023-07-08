using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Vehicle.Doctor.System.API.Infrastructure.Options;

public class UtcValueConverter : ValueConverter<DateTime, DateTime>
{
    public UtcValueConverter()
        : base(v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}

public class UtcValueConverterOptional : ValueConverter<DateTime?, DateTime?>
{
    public UtcValueConverterOptional()
        : base(v => v.HasValue ? v.Value.ToUniversalTime() : v,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)
    {
    }
}