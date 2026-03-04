using System.Globalization;
using OpenQA.Selenium;

namespace UI.Template.Components.Basic;

/// <summary>
/// Simple wrapper for date picker inputs. Many UI date fields are actually
/// <input type="date"> or custom widgets that accept text. This component
/// exposes helpers for reading and setting the value conveniently.
/// </summary>
public class DateInput : TextInput
{
    public DateInput(By locator) : base(locator) { }
    public DateInput(By locator, ISearchContext searchContext) : base(locator, searchContext) { }

    /// <summary>
    /// Returns the value of the underlying input as a <see cref="DateTime"/>,
    /// parsing either the DOM value or visible text.
    /// </summary>
    public DateTime GetDate()
    {
        string raw = GetDomProperty("value");
        if (string.IsNullOrEmpty(raw))
        {
            raw = GetText();
        }
        // try a couple common formats, falling back to invariant parse
        if (DateTime.TryParse(raw, out DateTime dt))
            return dt;
        throw new InvalidOperationException($"Unable to parse date from '{raw}'");
    }

    /// <summary>
    /// Sets the input using the provided date. If the input is not directly
    /// editable (e.g. datepicker widget), this method will attempt to use JS
    /// to update the value property.
    /// </summary>
    public void SetDate(DateTime date)
    {
        // format according to locale or expected pattern
        string text = date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
        try
        {
            Clear();
            SendKeys(text);
        }
        catch
        {
            // fallback to JS where SendKeys might not work
            JavaScriptExecutor.ExecuteScript("arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('change'));", Element, text);
        }
    }
}
