using e_commerce.Models.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models.asbstractClasses
{

    public abstract class AbstractProduct : IProduct
    {


        private string? _id;
        private string? _name;
  
        private int _yearOfRelease;
        public AbstractProduct()
        {
           this.Price= 0;
        }

        public string? Category { get; set; }

        public string? Id { get => _id; set => _id = value; }

        public string? Name { get => _name; set => _name = value; }

        public string? Manufacter { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
        public int YearOfRelease { get => _yearOfRelease; set => _yearOfRelease = value; }

        public void AddCategory(string newcategory)
        {
            this.Category = this.Category + " ," + newcategory;
        }

        public void RemoveCategory(string categoryToRemove)
        {
            Category?.Replace(categoryToRemove + ",", "");
        }
    }
 }