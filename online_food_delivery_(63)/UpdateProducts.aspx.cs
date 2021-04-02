using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_delivery__63_
{
    public partial class UpdateProducts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoodDeliveryDBConnectionString"].ConnectionString);
        int Productid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether Admin is logged in or not
                if (Session["admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                ShowProduct();
            }
        }

        // Function to display Products in GridView
        public void ShowProduct()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // Will Display Details of selected Product While Updating data
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label productID = (Label)row.FindControl("Label1");
            Productid = int.Parse(productID.Text.ToString());
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where ProductId='" + Productid + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // Will Cancel the Row Editing
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DropDownList2.SelectedValue = "Select Category";
            ShowProduct();
        }

        // Will be Call when GridView Page Changes
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();
        }

        // Will Update Product details
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = Productid;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            FileUpload fu = (FileUpload)row.FindControl("FileUpload1");
            if (fu.HasFile)
            {
                Label productID = (Label)row.FindControl("Label1");
                TextBox pName = (TextBox)row.FindControl("TextBox1");
                TextBox pDesc = (TextBox)row.FindControl("TextBox2");
                TextBox pPrice = (TextBox)row.FindControl("TextBox3");
                TextBox pQuantity = (TextBox)row.FindControl("TextBox4");
                string pCategory = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[6].FindControl("DropDownList1")).Text;

                fu.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(fu.FileName));
                String pImage = "Images/" + Path.GetFileName(fu.FileName);

                con.Open();
                SqlCommand cmd = new SqlCommand("Update Product1 set Pname=@1, Pdesc=@2, Pimage=@3, Pprice=@4, Pquantity=@5, Pcategory=@6 where ProductId=@7 ", con);
                cmd.Parameters.AddWithValue("@1", pName.Text);
                cmd.Parameters.AddWithValue("@2", pDesc.Text);
                cmd.Parameters.AddWithValue("@3", pImage);
                cmd.Parameters.AddWithValue("@4", pPrice.Text);
                cmd.Parameters.AddWithValue("@5", pQuantity.Text);
                cmd.Parameters.AddWithValue("@6", pCategory);
                cmd.Parameters.AddWithValue("@7", productID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                Response.Write("<script>alert('Product Updated Successfully');</script>");
                ShowProduct();
                DropDownList2.SelectedValue = "Select Category";
            }
            else
            {
                Response.Write("<script>alert('Please Select Product Image');</script>");
            }
        }

        // Display Products based on Category Selected
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cname = DropDownList2.SelectedValue.ToString();
            if (Cname == "Select Category")
            {
                ShowProduct();
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where Pcategory='" + Cname + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}