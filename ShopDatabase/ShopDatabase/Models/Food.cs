﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase.Models
{
    public class Food
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public OleDbCommand InsertCommand { get; internal set; }

        public Food(string name, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}
