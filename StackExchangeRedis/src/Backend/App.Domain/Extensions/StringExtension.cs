using System.Diagnostics.CodeAnalysis;

namespace App.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool NoEmpty([NotNullWhen(true)] this string? value) => string.IsNullOrWhiteSpace(value).IsFalse(); 
    }
}
