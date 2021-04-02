using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_delivery__63_
{
    public partial class Add_Product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoodDeliveryDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether Admin is logged in or not
                if (Session["admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        // Will Add all Product Details in Table
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (imageUpload.HasFile)
            {
                string filename = imageUpload.PostedFile.FileName;
                string filepath = "Images/Upload/" + imageUpload.FileName;
                imageUpload.PostedFile.SaveAs(Server.MapPath("~/Images/Upload/") + filename);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Product1 values('" + txtName.Text + "', '" + txtDesc.Text + "',  '" + filepath + "', '" + txtPrice.Text + "', '" + txtQuantity.Text + "', '" + DropDownList1.SelectedItem.Text + "' )", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Default.aspx");
            }
        }

    }
}