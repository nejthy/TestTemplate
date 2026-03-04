using UI.Template.Data;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class OrderTest : BaseTest
{
    [Test]
    public void OrderProductTest()
    {
        //** STEP 1 ***/
        HomePage homePage = new HomePage();
        homePage.Open();

        //** STEP 2 ***/
        Assert.That(homePage.GetCurrentCategory(), Is.EqualTo("All"), "The current category is not 'All'");

        //** STEP 3 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(TestData.OrderTestProduct.ProductCategory, TestData.OrderTestProduct.ProductName);

        //** STEP 4 ***/
        productDetail.ProductInfoForm.AddToCart();

        //** STEP 5 ***/
        productDetail.Header.OpenBasketContainer();
        Assert.That(productDetail.Header.GetBasketCount(), Is.EqualTo(1), "Basket count is not 1. Check Add to Cart functionality.");

        Assert.That(productDetail.Header.GetNthProduct(1, out string productName, out _), Is.True, "The first product in the basket was not found");
        Assert.That(productName, Is.EqualTo(TestData.OrderTestProduct.ProductName), "The name of product in the basket is not same as in test data");
        Assert.That(productDetail.ProductInfoForm.GetParsedQuantity(),
           Is.EqualTo(TestData.OrderTestProduct.ProductStock),
           "The number of items in stock does not match the expected value.");
        Assert.That(productDetail.ProductInfoForm.GetParsedPrice(),
           Is.EqualTo(TestData.OrderTestProduct.ProductPrice),
           "The price of item does not match the expected value.");

        //** STEP 6 ***/
        productDetail.ProductInfoForm.ClickCheckout();

        //** STEP 7 ***/
        CheckoutPage checkoutPage = new CheckoutPage();
        checkoutPage.WaitForReady();

        Assert.That(checkoutPage.CheckOutCardForm.EnterName(TestData.OrderCustomer.FirstName, TestData.OrderCustomer.LastName), Is.True, "Failed to enter customer name");
        Assert.That(checkoutPage.CheckOutCardForm.EnterAddress(TestData.OrderCustomer.Street, TestData.OrderCustomer.City, TestData.OrderCustomer.PostalCode), Is.True, "Failed to enter address");
        Assert.That(checkoutPage.CheckOutCardForm.EnterBirthDate(TestData.OrderCustomer.BirthDate), Is.True, "Failed to enter birth date");
        Assert.That(checkoutPage.CheckOutCardForm.EnterPhoneAndEmail(TestData.OrderCustomer.PhoneNumber, TestData.OrderCustomer.Email), Is.True, "Failed to enter phone and email");

        //** STEP 8 ***/
        Assert.That(checkoutPage.CheckOutCardForm.SelectPaymentMethod("PayPal"), Is.True, "Failed to select payment method");
        decimal totalPrice = checkoutPage.CheckOutCardForm.GetTotalPrice();
        Assert.That(totalPrice, Is.GreaterThan(0), "Total price should be greater than 0");
        Assert.That(totalPrice, Is.EqualTo(TestData.OrderTestProduct.ProductPrice), "Total price does not match the expected value");

        //** STEP 9 ***/
        checkoutPage.CheckOutCardForm.ClickPay();

    }


}
