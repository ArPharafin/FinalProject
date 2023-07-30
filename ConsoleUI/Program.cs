using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLID
        //OPEN Closed Princible
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(100,1000))
            {
                Console.WriteLine(product.UnitPrice);
            }
            foreach (var product in productManager.GetAllByCategoryId(1))
            {

                Console.WriteLine(product.CategoryID);
            }
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            {

            }
        
        }   
    }
}
