using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRecipes.Models;

namespace OnlineRecipes.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        [HttpGet]
        public ActionResult Index()
        {
            BusinessLayer bal = new BusinessLayer();
            List<Category> lstCategory = bal.GetAllCategory();
            return View(lstCategory);
        }
        [HttpGet]
        public ActionResult GetRecipes(int id)
        {
            BusinessLayer bal = new BusinessLayer();
            var cat = bal.GetAllCategory().Where(item => item.CategoryId == id).SingleOrDefault();
            List<Recipe> lstRecipe = bal.GetAllRecipe().Where(item=>item.CategoryId==id).ToList();
            ViewData.Add("catName", cat.CategoryName);
            return View(lstRecipe);
        }
    }
}