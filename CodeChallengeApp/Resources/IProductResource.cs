using CodeChallengeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeApp.Resources
{
    public interface IProductResource
    {
        ProductDetail AddProduct(ProductDetail product);
        ProductCollection List();
        IList<Subcategory> SubCatList();
        IList<Category> CatList();
    }
}
