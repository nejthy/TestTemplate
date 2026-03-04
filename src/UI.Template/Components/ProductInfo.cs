using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;
using UI.Template.Framework.Helpers;


namespace UI.Template.Components;

public class ProductInfo(By locator) : BaseProductInfo(locator)
{
    public override Simple Name => new(By.XPath($"{Locator.ToSelector()}//h1[@class='product-name']"));
    public override Simple Price => new(By.XPath($"{Locator.ToSelector()}//span[@ko-id='price-value']"));
    public override Simple StockStatus => new(By.XPath($"{Locator.ToSelector()}//span[@ko-id='stock-value']"));

    public Button IncreaseAmountButton => new(By.XPath($"{Locator.ToSelector()}//button[contains(@ko-id,'increment-button')]"));
    public Button DecreaseAmountButton => new(By.XPath($"{Locator.ToSelector()}//button[contains(@ko-id,'decrement-button')]"));
    public Simple Quantity => new(By.XPath($"{Locator.ToSelector()}//span[contains(@ko-id,'quantity-display')]"));
    public Button AddToCartButton => new(By.XPath($"{Locator.ToSelector()}//button[@class='add-to-cart']"));
    private readonly Button _backToShopButton = new(By.XPath("//a[@class='back-to-shop']"));
    private readonly Button _checkoutButton = new(By.XPath("//button[@class='checkout-button']"));

    /// <summary>
    /// Returns the current amount of the product selected in the quantity selector.
    /// </summary>
    /// <returns>The current product quantity.</returns>
    public int GetCurrentAmount() => int.TryParse(Quantity.GetText(), out int value) ?
                                                  value :
                                                  throw new InvalidOperationException("Failed to parse product quantity.");

    /// <inheritdoc/>
    public override bool IsReady()
    {
        return base.IsReady() && IsDisplayed();
    }

    /// <summary>
    /// Change the amount of product to the specified number.
    /// </summary>
    public void ChangeAmount(int amount)
    {
        int currentAmount = GetCurrentAmount();

        Wait.Until(_ =>
        {
            if (currentAmount < amount)
            {
                IncreaseAmountButton.Click();
                currentAmount++;
            }
            else if (currentAmount > amount)
            {
                DecreaseAmountButton.Click();
                currentAmount--;
            }
            return currentAmount == amount;
        });
    }


    /// <summary>
    /// Returns the price of the product, parsed from the price text.
    /// </summary>

    public double GetParsedPrice()
    {
        return TextHelper.ExtractDouble(Price.GetText());
    }

    /// <summary>
    /// Returns the number of items in stock, parsed from the stock status text.
    /// </summary>
    public int GetParsedStock()
    {
        return TextHelper.ExtractInt(StockStatus.GetText());
    }


    /// <summary>
    /// Returns the parsed quantity of the product in the quantity selector.
    /// </summary>
    public int GetParsedQuantity()
    {
        return TextHelper.ExtractInt(Quantity.GetText());
    }

    /// <summary>
    /// Add the product to the basket.
    /// </summary>
    public void AddToCart() => AddToCartButton.Click();

    /// <summary>
    /// Navigate back to the shop page.
    /// </summary>
    public void BackToShop() => _backToShopButton.Click();

    /// <summary>
    /// Clicks on checkout in the basket.
    /// </summary>
    public void ClickCheckout() => _checkoutButton.Click();


}
