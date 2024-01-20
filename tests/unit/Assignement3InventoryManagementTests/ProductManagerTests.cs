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
        [InlineData("12")]
        public void ValidIntProductQuantityInt_IsProductQuantityInt_ReturnsTrueIfInt(string productQuantity)
        {
            var productManager = new ProductManager();
            int productQuantityOutput;

            Assert.True(productManager.IsProductQuantityInt(productQuantity, out productQuantityOutput));
        }
        [Theory]
        [InlineData("Ten")]
        [InlineData("Hundred")]
        public void InValidIntProductQuantityInt_IsProductQuantityInt_ReturnsFalseIfNotInt(string productPrice)
        {
            var productManager = new ProductManager();
            int productPriceOutput;

            Assert.False(productManager.IsProductQuantityInt(productPrice, out productPriceOutput));
        }


        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20)]
        public void InputProductDetails_AddProductToTheList_ProductAddedToTheList(string productName, string productID, double productPrice, int productQuantity)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);

            productManager.AddProductsToTheList(product);

            Xunit.Assert.Contains(product, productManager.GetProducts());

        }
        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "Sony Mouse", "ELE13", 500, 30)]

        public void InputProductDetails_EditProductWithreference_ProductEdittedInTheSameRefrence(string productName, string productID, double productPrice, int productQuantity,
            string newProuctName, string newProductID, double newProductPrice, int newProductQuanity)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            productManager.EditProductsWithReference(product, newProuctName, newProductID, newProductPrice, newProductQuanity);

            Xunit.Assert.Contains(product, productManager.GetProducts());

        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "Mouse")]

        public void AddedProductsToThelist_IsProductNameUnique_ReturnsTrueIftheProductNameIsExisting(string productName, string productID, double productPrice, int productQuantity,
            string newProuctName)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Assert.True(productManager.ISProductNameUnique(newProuctName));

        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "KeyBoard")]
        public void AddedProductsToThelist_IsProductNameUnique_ReturnsFalseIftheProductNameIsNotInTheList(string productName, string productID, double productPrice, int productQuantity,
            string newProuctName)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Assert.False(productManager.ISProductNameUnique(newProuctName));

        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "ELE12")]
        public void AddedProductsToThelist_IsProductIdUnique_ReturnsTrueIftheProductIdIsInTheList(string productName, string productID, double productPrice, int productQuantity,
            string newProuctID)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Assert.True(productManager.IsProductIDUnique(newProuctID));

        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "ELE13")]
        public void AddedProductsToThelist_IsProductIdUnique_ReturnsFalseIftheProductIdIsNotInTheList(string productName, string productID, double productPrice, int productQuantity,
            string newProuctID)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Assert.False(productManager.IsProductIDUnique(newProuctID));

        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "Mouse")]
        public void AddedproductsToTheList_SearchProductsInTheList_ReturnsTheInstanceIfTheNameIsInTheList(string productName, string productID, double productPrice, int productQuantity,
            string searchNameOrID)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Product result = productManager.SearchProductInTheList(searchNameOrID);

            Assert.Equal(product, result);
        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20, "ELE13")]
        public void AddedproductsToTheList_SearchProductsInTheList_ReturnsNulleIfTheNameIsNotInTheList(string productName, string productID, double productPrice, int productQuantity,
            string searchNameOrID)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            Product result = productManager.SearchProductInTheList(searchNameOrID);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("Mouse", "ELE12", 450, 20)]
        public void AddedproductsToTheList_RemoveProductsFromTheList_ReturnsNulleIfTheNameIsNotInTheList(string productName, string productID, double productPrice, int productQuantity)
        {
            var productManager = new ProductManager();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            productManager.AddProductsToTheList(product);

            productManager.DeleteProductFromTheList(product);

            Assert.DoesNotContain(product, productManager.GetProducts());
        }
    }
}
