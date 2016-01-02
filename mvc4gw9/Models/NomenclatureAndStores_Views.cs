using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace mvc4gw9.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int NomenclatureId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string currentParameters { get; set; }
        public List<string> Gallery { get; set; }
    }

    public class ProductInStore
    {
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public int ProductAmount { get; set; }
    }

    public class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SelectedValue { get; set; }
        public List<string> Values { get; set; }
    }

    public class Branch
    {
        public Group Group { get; set; }
        public List<Group> Subgroups { get; set; }
    }

    public class Navigation
    {
        public List<Group> Path { get; set; }
        public List<Branch> Branches { get; set; }
    }

    public class ProductPageContent
    {
        public Product Product { get; set; }
        public Navigation Navigation { get; set; }
    }

    public class ProductsListPageContent
    {
        public List<Product> Products { get; set; }
        public Navigation Navigation { get; set; }
    }

    public class ShoppingBasketAddPageContent
    {
        public string ProductName { get; set; }
        public string ProductFeaturesSet { get; set; }
        public string ProductImage { get; set; }
        public List<ProductInStore> ProductInStores { get; set; }
    }


}
