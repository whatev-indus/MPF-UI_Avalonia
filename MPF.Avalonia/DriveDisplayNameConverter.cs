using System;
using System.Globalization;
using Avalonia.Data.Converters;
using MPF.Frontend;

namespace MPF.Avalonia
{
    internal sealed class DriveDisplayNameConverter : IValueConverter
    {
        private const string MacVolumesPrefix = "/Volumes/";

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Drive drive)
                return string.Empty;

            if (OperatingSystem.IsMacOS() && drive.Name?.StartsWith(MacVolumesPrefix, StringComparison.Ordinal) == true)
                return drive.Name[MacVolumesPrefix.Length..].TrimEnd('/');

            return drive.DisplayName;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
