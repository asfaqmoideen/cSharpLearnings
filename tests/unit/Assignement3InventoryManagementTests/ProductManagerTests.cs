using Assignments;

namespace Assignement3InventoryManagementTests
{
    public class ProductManagerTests
    {

        [Theory]
        [InlineData("1223")]
        [InlineData("12.1")]
        public void ValidDoubleProductPrice_IsProductPriceDouble_ReturnsTrueIfDouble(string productPrice)
        {
            var productManager = new ProductManager();
            double productPriceOutput;
            Assert.True(productManager.IsProductPriceDouble(productPrice, out productPriceOutput));
        }
        [Theory]
        [InlineData("Ten")]
        [InlineData("Hundred")]
        public void InvalidDoubleProductPrice_IsProductPriceDouble_ReturnsFalseIfNotDouble(string productQuantity)
        {
            var productManager = new ProductManager();
            double productQuantityOutput;
            Assert.False(productManager.IsProductPriceDouble(productQuantity, out productQuantityOutput));
        }

        [Theory]
        [InlineData("1223")]
        [InlineData("12.1")]
        public void ValidDoubleProductPrice_IsProductQuantityInt_ReturnsTrueIfInt(string productQuantity)
        {
            var productManager = new ProductManager();
            int productQuantityOutput;
            Assert.True(productManager.IsProductQuantityInt(productQuantity, out productQuantityOutput));
        }
        [Theory]
        [InlineData("Ten")]
        [InlineData("Hundred")]
        public void InvalidDoubleProductPrice_IsProductQuantityInt_ReturnsFalseIfNotInt(string productPrice)
        {
            var productManager = new ProductManager();
            int productPriceOutput;
            Assert.False(productManager.IsProductQuantityInt(productPrice, out productPriceOutput));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]

        public void ExistingProductName_IsProductNameUnique_ReturnTrueifProductNameisNotUnique(string productName)
        {
            var productManager = new ProductManager();

            Assert.True(productManager.ISProductNameUnique(productName));
        }


    }
}