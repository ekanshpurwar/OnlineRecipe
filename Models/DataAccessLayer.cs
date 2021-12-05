using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OnlineRecipes.Models
{
    public class DataAccessLayer
    {
        SqlConnection con;

        public DataAccessLayer()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Integrated Security=True; Initial Catalog = DemoDB";
        }
        public List<Recipe> GetAllRecipe()
        {
            List<Recipe> lstRecipe = new List<Recipe>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from recipe";

            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                lstRecipe.Add(
                    new Recipe
                    {
                        CategoryId = (int)sdr[0],
                        RecipeName = sdr[1].ToString(),
                        Picture = sdr[2].ToString(),
                        Description = sdr[3].ToString()
                    }
                    ); ;
            }
            sdr.Close();
            con.Close();

            return lstRecipe;
        }
        public List<Category> GetAllCategory()
        {
            List<Category> lstCategory = new List<Category>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from category";

            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                lstCategory.Add(
                    new Category
                    {
                        CategoryId = (int)sdr[0],
                        CategoryName = sdr[1].ToString()
                    }
                    ) ;
            }
            sdr.Close();
            con.Close();

            return lstCategory;
        }
        public void AddRecipe(Recipe rec)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into recipe values(@cId,@Rname,@pic,@desc)";
            cmd.Parameters.AddWithValue("@cId", rec.CategoryId);
            cmd.Parameters.AddWithValue("@Rname", rec.RecipeName);
            cmd.Parameters.AddWithValue("@pic", rec.Picture);
            cmd.Parameters.AddWithValue("@desc", rec.Description);

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void DeleteRecipe(int catId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from recipe where categoryid = @cId";
            cmd.Parameters.AddWithValue("@cId", catId);


            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateRecipe(Recipe rec)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update tbl_employee set recipename=@Rname,picture=@pic,description=@desc where categoryid=@cId";
            cmd.Parameters.AddWithValue("@cId", rec.CategoryId);
            cmd.Parameters.AddWithValue("@Rname", rec.RecipeName);
            cmd.Parameters.AddWithValue("@pic", rec.Picture);
            cmd.Parameters.AddWithValue("@desc", rec.Description);


            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Recipe GetRecipeById(int catId)
        {
            Recipe r = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from recipe where categoryid=@cId";

            cmd.Parameters.AddWithValue("@cId", catId);
            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                r = new Recipe
                {
                    CategoryId = (int)sdr[0],
                    RecipeName = sdr[1].ToString(),
                    Picture = sdr[2].ToString(),
                    Description = sdr[3].ToString()
                };

            }
            sdr.Close();
            con.Close();

            return r;

        }
    }
}