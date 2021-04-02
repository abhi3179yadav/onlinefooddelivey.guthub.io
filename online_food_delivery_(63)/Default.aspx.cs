using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_delivery__63_
{
    public partial class Default1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoodDeliveryDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";

            //Login Session
            if (Session["username"] != null)
            {
                Label4.Text = "Logged in as " + Session["username"].ToString();
                HyperLink1.Visible = false;
                Button1.Visible = true;
            }
            else
            {
                Label4.Text = "Hello you can Login here...";
                HyperLink1.Visible = true;
                Button1.Visible = false;
            }

            if (!IsPostBack)
            {
                Drp_ProductCategory();
            }
        }


        //Logout Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            Label4.Text = "You have Logged out successfully..";
        }

        //Searching Products based on Product Name and Category
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where (Pname like '%" + TextBox1.Text + "%') or (Pcategory like '%" + TextBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        //Passing Data of which product item is being selected & quantity by user to Cart page 
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addproduct"] = "true";
            if (e.CommandName == "AddToCart")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("Dropdownlist1"));
                Response.Redirect("AddtoCart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
            }
        }

        //For displaying the quantity of product exists in stock & hiding AddToCart button if product is not in Stock
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label productID = e.Item.FindControl("Label6") as Label;
            Label stock = e.Item.FindControl("Label5") as Label;
            ImageButton btn = e.Item.FindControl("ImageButton1") as ImageButton;
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where ProductId= '" + productID.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String stockdata = "";

            if (dt.Rows.Count > 0)
            {
                stockdata = dt.Rows[0]["Pquantity"].ToString();

            }
            con.Close();

            if (stockdata == "0")
            {
                stock.Text = "Out of Stock";
                btn.Enabled = false;
                btn.ImageUrl = "Images/SoldOut.png";

            }
            else
            {
                stock.Text = stockdata;
            }
        }

        //Displays Product Categories in DropDownList
        public void Drp_ProductCategory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Category", con);
            ProductCategories.DataSource = cmd.ExecuteReader();
            ProductCategories.DataTextField = "CategoryName";
            ProductCategories.DataValueField = "CategoryID";
            ProductCategories.DataBind();
            ProductCategories.Items.Insert(0, "Food Category");
            con.Close();
        }

        //Displaying Products based on selected Category
        protected void ProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strQuery = "";
            string selectedProduct = ProductCategories.SelectedItem.Text;
            if (selectedProduct == "Product Category")
            {
                strQuery = "";
            }
            else
            {
                strQuery = "where Pcategory = '" + selectedProduct + "' ";
            }
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 " + strQuery + " ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (selectedProduct == dt.Rows[0][6].ToString())
                {
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('No product found')</script>");
            }
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}