﻿using CodeChallengeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallengeApp.Resources
{
    public class ProductResource : IProductResource
    {


        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public ProductResource(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IList<Category> CatList()
        {
            return CategoryCollection.List;
        }

        public IList<Subcategory> SubCatList()
        {
            return SubcategoryCollection.List;

        }
        public ProductDetail AddProduct(ProductDetail product)
        {
            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources\\productTable.json");
            var json = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<ProductDetail>>(json);
            int currentId = list.Max(x => x.Id) + 1;
            product.Id = currentId;
            list.Add(product);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, convertedJson);
            return product;
        }

        public ProductCollection List()
        {
            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources\\productTable.json");
            var json = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<ProductDetail>>(json);
            var productCollection = new ProductCollection() { List = list };
            return productCollection;
        }
    }
}
