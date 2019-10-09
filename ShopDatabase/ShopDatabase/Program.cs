using ShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.Data.OleDb;

namespace ShopDatabase
{
    class Program
    {

        static void Main(string[] args)
        {
            
    
            List<Food> groceries = new List<Food>
            {
                new Food("apple",1.7),
                new Food("bread", 1.2),
                new Food("cheese",2)

            };
            ShoppingCart newCart = new ShoppingCart();
            foreach (var food in groceries)
            {
                newCart.Items.Add(food);
            }

            using(var db = new ShopDbContext())
            {
                db.ShoppingCarts.Add(newCart);
                db.SaveChanges();

                var carts = db.ShoppingCarts;
                foreach(var cart in carts)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                    foreach(var food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name} Price: {food:Price}");

                    }
                }
            }

            Console.WriteLine("Choose food to select...");
            string itemFood = Console.ReadLine();

            Food chosenFood = groceries.FirstOrDefault(x => x.Name == itemFood);
            if (chosenFood == null)
            {
                Console.WriteLine("Sorry, no food " + itemFood + " in our shop");
            }
            else
            {
                Console.WriteLine("How much do you want? ");
                string amount = Console.ReadLine();
                int a;
                bool success = int.TryParse(amount, out a); // 
                while (!success)
                {
                    Console.WriteLine("Sorry, amount should be integer value: ");
                    amount = Console.ReadLine();
                    success = int.TryParse(amount, out a);

                }
                chosenFood.InsertCommand = new OleDbCommand("Insert into");
                chosenFood.InsertCommand.Parameters.Add("@FIO", OleDbType.VarChar, 255).Value = itemFood;
                
                //Console.WriteLine("Anything else? Y/N");
            }




            //////////////////////////////////




        }
        
        
    }
}
