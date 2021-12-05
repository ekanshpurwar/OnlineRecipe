using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRecipes.Models
{
    public class BusinessLayer
    {
        public List<Recipe> GetAllRecipe()
        {
            DataAccessLayer dal = new DataAccessLayer();
            return dal.GetAllRecipe();
        }
        public List<Category> GetAllCategory()
        {
            DataAccessLayer dal = new DataAccessLayer();
            return dal.GetAllCategory();
        }
        public void AddRecipe(Recipe rec)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.AddRecipe(rec);
        }
        public void DeleteRecipe(int catId)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.DeleteRecipe(catId);
        }
        public void UpdateRecipe(Recipe rec)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.UpdateRecipe(rec);
        }
        public Recipe GetRecipeById(int catId)
        {
            DataAccessLayer dal = new DataAccessLayer();
            return dal.GetRecipeById(catId);
        }
    }
}