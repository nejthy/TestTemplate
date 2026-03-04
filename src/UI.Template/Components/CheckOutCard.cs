using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;
using UI.Template.Framework.Helpers;


namespace UI.Template.Components;

public class CheckOutCard(By locator) : BaseComponent(locator)
{
    protected TextInput FirstName => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='firstName-input']"));
    protected TextInput LastName => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='lastName-input']"));

    protected TextInput AddressInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='street-input']"));
    protected TextInput CityInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='city-input']"));
    protected TextInput PostalCodeInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='zipCode-input']"));
    protected DateInput BirthDateInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='dateOfBirth-input']"));
    protected TextInput EmailInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='email-input']"));
    protected TextInput PhoneNumberInput => new(By.XPath($"{Locator.ToSelector()}//input[@ko-id='phoneNumber-input']"));

    protected DropDownList ShippingMethodSelect => new(By.XPath($"{Locator.ToSelector()}//select[@ko-id='deliveryMethod-select']"));
    protected DropDownList PaymentMethodSelect => new(By.XPath($"{Locator.ToSelector()}//select[@ko-id='paymentMethod-select']"));

    protected Simple ShippingPrice => new(By.XPath($"{Locator.ToSelector()}//span[@ko-id='shipping-price']"));
    protected Simple TotalPrice => new(By.XPath($"{Locator.ToSelector()}//div[@ko-id='summary-row-total']//span[@ko-id='total-value']"));
    protected Button PayButton => new(By.XPath($"{Locator.ToSelector()}//button[@ko-id='pay-button']"));
    protected Button BackToShopButton => new(By.XPath($"{Locator.ToSelector()}//a[@ko-id='back-to-shop-form']"));


    /// <summary>
    /// Waits for the checkout card to be ready.
    /// </summary>
    public override void WaitForReady()
    {
        Wait.SetTimeoutMessage($"'{GetType().Name}' with locator '{Locator}' wasn't ready during the timeout.")
            .Until(_ => IsDisplayed());
    }


    /// <summary>
    /// Enters the customer's address into the respective input fields.
    /// </summary>
    public bool EnterAddress(string address, string city, string postal)
    {
        AddressInput.Clear();
        AddressInput.SendKeys(address);
        CityInput.Clear();
        CityInput.SendKeys(city);
        PostalCodeInput.Clear();
        PostalCodeInput.SendKeys(postal);
        return AddressInput.GetValue() == address &&
               CityInput.GetValue() == city &&
               PostalCodeInput.GetValue() == postal;
    }

    /// <summary>
    /// Enters the customer's name into the respective input fields.
    /// </summary>

    public bool EnterName(string firstName, string lastName)
    {
        FirstName.Clear();
        FirstName.SendKeys(firstName);
        LastName.Clear();
        LastName.SendKeys(lastName);
        return FirstName.GetValue() == firstName && LastName.GetValue() == lastName;
    }

    /// <summary>
    /// Enters the customer's phone number and email into the respective input fields.
    /// </summary>
    public bool EnterPhoneAndEmail(string phone, string email)
    {
        PhoneNumberInput.Clear();
        PhoneNumberInput.SendKeys(phone);
        EmailInput.Clear();
        EmailInput.SendKeys(email);
        return PhoneNumberInput.GetValue() == phone && EmailInput.GetValue() == email;
    }

    /// <summary>
    /// Enters the customer's birth date into the respective input field.
    /// </summary>
    public bool EnterBirthDate(DateTime date)
    {
        BirthDateInput.SetDate(date);
        return BirthDateInput.GetDate() == date;
    }

    /// <summary>
    /// Selects the specified shipping method from the dropdown and verifies the selection.
    /// </summary>
    public bool SelectShippingMethod(string method)
    {
        ShippingMethodSelect.SelectByText(method);
        return ShippingMethodSelect.GetSelectedOptionText() == method;
    }

    /// <summary>
    /// Selects the specified payment method from the dropdown and verifies the selection.
    /// </summary>

    public bool SelectPaymentMethod(string method)
    {
        PaymentMethodSelect.SelectByText(method);
        return PaymentMethodSelect.GetSelectedOptionText() == method;
    }

    public decimal GetShippingPrice() => (decimal)TextHelper.ExtractDouble(ShippingPrice.GetText());

    public decimal GetTotalPrice() => (decimal)TextHelper.ExtractDouble(TotalPrice.GetText());

    public void ClickPay() => PayButton.Click();

    public void BackToShop() => BackToShopButton.Click();
}
