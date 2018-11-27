﻿using System;
using System.Linq;
using hw10ClassLib;

namespace hw10Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var call = new Homework10();
            var amount = 0.00;
            var input = "";
            var getAllProduct = call.GetAllProducts().ToList();
            var statusSave = false;
            var massage = "Current state had been saved!";

            while (true)
            {
                var productsInCart = call.GetProductsInCart().ToList();

                Console.WriteLine("Products in your cart are");

                if (productsInCart.Capacity == 0)
                {
                    Console.WriteLine("none");
                }
                else
                {
                    var no = 1;

                    foreach (var item in productsInCart)
                    {
                        Console.WriteLine($"{no}.{item.SKU},{item.Name},{item.Price,2:N}");
                        no++;
                    }
                }

                Console.WriteLine("---");
                Console.WriteLine($"Total amount: {amount,2:N} baht");
                Console.Write("Please input a product key:");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                if (input == "save")
                {
                    call.SaveCurrentState();
                    statusSave = true;
                }

                var addToCart = getAllProduct.Find(it => it.SKU == input);

                call.AddProductToCart(addToCart);
                amount += addToCart.Price;
                
                if (statusSave)
                {
                    Console.WriteLine(massage);
                }
                else Console.WriteLine();

            }
        }
    }
}
