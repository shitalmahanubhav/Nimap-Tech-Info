using NimapInfotechMachineTest.Models;
using NimapInfotechMachineTest.SqlDbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotechMachineTest.Controllers
{
    public class ProductController : Controller
    {
        #region
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        #endregion
        public ActionResult Index()
        {
            ViewBag.Category = Category_List();
            return View();
        }
        public ActionResult Prtial_View()
        {
            return View();
        }
        public List<SelectListItem> Category_List()
        {
            DataTable Dt = new DataTable();
            var select_List = new List<SelectListItem>();
            select_List.Add(new SelectListItem { Value = "0", Text = "--Select--" });
            try
            {
                _connection = new Connection();
                Dt = _connection.FillCombo("Select * From MCategory Where IsActiv='True'");
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    select_List.Add(new SelectListItem { Value = Dt.Rows[i]["CategoryId"].ToString(), Text = Dt.Rows[i]["CategoryName"].ToString() });

                }

            }
            catch (Exception ex)
            {

            }
            return select_List;

        }
        public ActionResult SaveOrUpdate(ProductModel model)
        {
            int res = 0;
            int r= 0;
            string Flag = "";
            try
            {
                if (model.ProductId == 0)
                {
                    Flag = "I";
                    r = 1;
                    res = 1;
                }
                else
                {
                    Flag = "U";
                    r = 2;
                    res = 2;
                }
                _connection = new Connection();
                _sqlCon = _connection.Connect();
                _sqlCmd = new SqlCommand();
                _sqlCmd.CommandText = "SpProduct";
                _sqlCmd.CommandType = CommandType.StoredProcedure;
                _sqlCmd.Connection = _sqlCon;
                _sqlCmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                _sqlCmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                _sqlCmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);               
                _sqlCmd.Parameters.AddWithValue("@Flag", Flag);
                _sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = 3;
            }
            finally
            {
                _sqlCmd.Dispose();
                _sqlCon.Close();
            }
            if (res == 1)
            {
                TempData["message"] = "Your Data Save Successfuly..";
            }
            else if (res == 2)
            {
                TempData["message"] = "Your Data Update Successfuly";
            }
            else
            {
                TempData["Error"] = "Opps Somthing Wrong !!!";
            }
            return RedirectToAction("index");
        }
        public ActionResult ProductReport()
        {
            List<ProductReportModel> list = new List<ProductReportModel>();
            DataTable Dt = new DataTable();
            _connection = new Connection();
            Dt = _connection.FillCombo("Select ProductId,ProductName,C.CategoryId,CategoryName From MProduct P inner join MCategory C on C.CategoryId=P.CategoryId");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                ProductReportModel model = new ProductReportModel();

                model.ProductId = Convert.ToInt32(Dt.Rows[i]["ProductId"]);
                model.ProductName = Dt.Rows[i]["ProductName"].ToString();
                model.CategoryId = Convert.ToInt32(Dt.Rows[i]["CategoryId"]);
                model.CategoryName = Dt.Rows[i]["CategoryName"].ToString();
                list.Add(model);
            }
            return View(list);


        }
        public ActionResult EditData(int id)
        {
            ViewBag.Category = Category_List();

            DataTable Dt = new DataTable();
            _connection = new Connection();
            Dt = _connection.FillCombo("Select * From MProduct Where ProductId=" + id);

            {
                ProductModel model = new ProductModel();
                {

                    model.ProductId = Convert.ToInt32(Dt.Rows[0]["ProductId"]);
                    model.ProductName = Dt.Rows[0]["ProductName"].ToString();                  
                    model.CategoryId = Convert.ToInt32(Dt.Rows[0]["CategoryId"]);
                }
                return PartialView("index", model);

            }
        }
        public ActionResult ReportDelete(int id)
        {
            ViewBag.Category = Category_List();

            try
            {
                List<ProductReportModel> _list = new List<ProductReportModel>();
                Connection Con = new Connection();
                DataTable Dt = new DataTable();
                _connection = new Connection();
                ProductModel model = new ProductModel();
                model.ProductId = id;
                Dt = _connection.FillCombo("Delete From MProduct Where ProductId =" + id);
                TempData["Delete"] = "Data Delete Sucessfully!";
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            return View("Index");

        }
    }
}