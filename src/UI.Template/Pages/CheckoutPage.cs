using OpenQA.Selenium;
using UI.Template.Components;

namespace UI.Template.Pages;

public class CheckoutPage(string url = "/checkout/") : BaseEshopPage(url)
{
    public CheckOutCard CheckOutCardForm { get; private set; } = new(By.XPath("//div[@class='checkout-form']"));

    /// <inheritdoc/>
    public override bool IsReady()
    {
        return base.IsReady() && CheckOutCardForm.IsDisplayed();
    }
}
