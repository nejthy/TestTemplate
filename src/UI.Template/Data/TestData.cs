using UI.Template.Models;

namespace UI.Template.Data;

public static class TestData
{
    public static TestProduct ParametersTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Wireless Mouse",
        ProductUrl = "/product/2"
    };

    public static TestProduct CardTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Gaming Keyboard RGB"
    };
    public static TestProduct AddAndVerifyNewProductTests { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "Camera M25",
        ProductPrice = 50.5,
        ProductStock = 5,
        ProductImageName = "Camera 2",
        ProductDescription = "Camera"

    };
    public static TestProduct OrderTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "DSLR Camera X200",
        ProductPrice = 700,
        ProductStock = 1,
        ProductImageName = "Camera 2",
        ProductDescription = "Camera"
    };

    public static PersonallyInformation OrderCustomer { get; } = new PersonallyInformation
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        PhoneNumber = "777123456",
        Street = "123 Main Street",
        City = "Prague",
        PostalCode = "11000",
        BirthDate = new DateTime(1990, 5, 15)
    };
}
