using System.Globalization;
using System.Text.RegularExpressions;

namespace UI.Template.Framework.Helpers;

public static class TextHelper
{
    // Univerzal method for extracting double values from text (e.g., price with currency symbol)
    public static double ExtractDouble(string text)
    {

        string numberOnly = Regex.Match(text, @"\d+(\.\d+)?").Value;

        if (string.IsNullOrEmpty(numberOnly)) return 0;

        return double.Parse(numberOnly, CultureInfo.InvariantCulture);
    }

    // Univerzal method for extracting integer values from text (e.g., quantity in stock)
    public static int ExtractInt(string text)
    {
        string numberOnly = Regex.Match(text, @"\d+").Value;
        if (string.IsNullOrEmpty(numberOnly)) return 0;

        return int.Parse(numberOnly);
    }
}
