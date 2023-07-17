﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
             //Oracle,Sql Server,Postgres,MongoDB
            _products = new List<Product> {
            new Product{ProductID=1,CategoryID=1,ProductName="Sapka",UnitInPrice=22,UnitsInStock=15},
            new Product{ProductID=2,CategoryID=1,ProductName="Kamera",UnitInPrice=25,UnitsInStock=18},
            new Product{ProductID=3,CategoryID=2,ProductName="Tablet",UnitInPrice=21,UnitsInStock=13},
            new Product{ProductID=4,CategoryID=3,ProductName="Bumerang",UnitInPrice=26,UnitsInStock=10},
            new Product{ProductID=5,CategoryID=4,ProductName="Halat",UnitInPrice=24,UnitsInStock=11}, 
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            //LINQ -Language Integrated Query
            //Lambda
            //SingleOrDefault== Foreach

         /*   Product productToDelete= null;
           foreach ( var p  in _products)
            {if(product.ProductID== p.ProductID)
                {productToDelete= p;}}*/
           Product productToDelete = _products.SingleOrDefault(p=>p.ProductID== product.ProductID);


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryID)
        {  //where içindeki bütün şartlara uyanları yeni bir liste haline getirip onu döndürür
           return _products.Where(p=> p.CategoryID==categoryID).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan ürün listedeki ürünü  bul

            Product productToUpdate= _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID= product.CategoryID;
            productToUpdate.UnitInPrice= product.UnitInPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;
           


        }
    }
}
