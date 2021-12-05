using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRecipes.Models
{
    public class Recipe
    {
        public int CategoryId { get; set; }
        public string RecipeName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}