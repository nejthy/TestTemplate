using UI.Template.Data;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class AddAndVerifyNewProductTests : BaseTest
{
    [Test]
    public void AddNewProductTest()
    {
        //** STEP 1 ***/
        AdminPage adminPage = new AdminPage();
        adminPage.Open();

        Assert.That(adminPage.IsReady(), Is.True, "Admin page is not ready.");

        //** STEP 2 ***/
        var newProductForm = adminPage.OpenAddNewProductContainer();

        Assert.That(newProductForm.SetName(TestData.AddAndVerifyNewProductTests.ProductName), Is.True, "Failed to set product name.");
        Assert.That(newProductForm.SelectCategory(TestData.AddAndVerifyNewProductTests.ProductCategory), Is.True, "Category selection failed.");

        Assert.That(newProductForm.SetPrice(TestData.AddAndVerifyNewProductTests.ProductPrice), Is.True, "Failed to set product price.");

        Assert.That(newProductForm.SetStock(TestData.AddAndVerifyNewProductTests.ProductStock), Is.True, "Failed to set product stock.");
        Assert.That(newProductForm.SelectImage(TestData.AddAndVerifyNewProductTests.ProductImageName), Is.True, "Failed to select product image.");
        Assert.That(newProductForm.SetDescription(TestData.AddAndVerifyNewProductTests.ProductDescription), Is.True, "Failed to set product description.");

        //** STEP 3 ***/
        newProductForm.SaveChanges();


        //** STEP 4 ***/
        HomePage homePage = adminPage.GoToEshopHome();
        Assert.That(homePage.GetCurrentCategory(), Is.EqualTo("All"), "Failed to return to the e-shop's home page, category 'All' was not found.");

        //** STEP 5 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(TestData.AddAndVerifyNewProductTests.ProductCategory, TestData.AddAndVerifyNewProductTests.ProductName);

        //** STEP 6 ***/
        Assert.That(productDetail.ProductInfoForm.Name.GetText(),
            Is.EqualTo(TestData.AddAndVerifyNewProductTests.ProductName),
            "The name of the product on the detail page does not match the name from test data.");

        Assert.That(productDetail.ProductInfoForm.GetParsedPrice(),
            Is.EqualTo(TestData.AddAndVerifyNewProductTests.ProductPrice),
            "The price of the product on the detail page does not match the price from test data.");

        Assert.That(productDetail.ProductInfoForm.GetParsedStock(),
            Is.EqualTo(TestData.AddAndVerifyNewProductTests.ProductStock),
            "The number of items in stock does not match the expected value.");
    }
}
