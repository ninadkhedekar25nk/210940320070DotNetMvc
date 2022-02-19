using _210940320070.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _210940320070.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Home()
        {
            return View();

        }
        public ActionResult Welcome()
        {
            return View();
        }

        // GET: Product
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Security=True;";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Products";
            List<Product> mydata = new List<Product>();
            SqlDataReader dr = cmdInsert.ExecuteReader();

            while (dr.Read())
            {
                mydata.Add(new Product
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                });
            }
            dr.Close();
            cn.Close();

            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            try
            {

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ProductDB; Integrated Security=True;";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "AddData";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

                cmdInsert.ExecuteNonQuery();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ProductDB; Integrated Security=True;";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateDetails";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product obj)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ProductDB; Integrated Security=True;";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "DeleteDetails";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
