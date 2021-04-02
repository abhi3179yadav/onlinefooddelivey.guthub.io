using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

namespace online_food_delivery__63_
{
    public partial class Pdf_generate : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoodDeliveryDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether user is logged in or not 
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            string Orderid = Session["Orderid"].ToString();
            Label1.Text = Orderid;
            findorderdate(Label2.Text);
            string Address = Session["address"].ToString();
            Label3.Text = Address;
            showgrid(Label1.Text);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        // Will generate PDF
        protected void Button1_Click(object sender, EventArgs e)
        {
            exportpdf();
        }

        // Function for exporting PDF
        private void exportpdf()
        {
            // Document Type i.e PDF
            Response.ContentType = "application/pdf";
            // Generate PDF with following Name
            Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
            // Cache is not saved 
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Class for Writing the Content
            StringWriter sw = new StringWriter();
            // Class for Writing HTML 
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            // Function to Render all Content which is inside of Panel Control 
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            // Defines Document Page Size
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            // Class for getting it into PDF Format
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            // Open connection
            pdfDoc.Open();
            // Parse all HTML's Panel Data
            htmlparser.Parse(sr);
            // Close connection
            pdfDoc.Close();
            // Will give PDF as a Response
            Response.Write(pdfDoc);
            Response.End();
            // After this it will get downloaded into your local drive
        }



        // Function to find What is the Order Date
        private void findorderdate(String Orderid)
        {
            SqlCommand cmd = new SqlCommand("Select * from OrderDetails where orderid='" + Label1.Text + "'");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds.Tables[0].Rows[0]["Orderdate"].ToString();
            }
            con.Close();
        }



        // Displays Purchased Items in GridView
        private void showgrid(String orderid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("productid");
            dt.Columns.Add("productname");
            dt.Columns.Add("quantity");
            dt.Columns.Add("price");
            dt.Columns.Add("totalprice");
            SqlCommand cmd = new SqlCommand("select * from OrderDetails where orderid='" + Label1.Text + "'");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;
            while (i < totalrows)
            {
                dr = dt.NewRow();
                dr["sno"] = ds.Tables[0].Rows[i]["sno"].ToString();
                dr["productid"] = ds.Tables[0].Rows[i]["productid"].ToString();
                dr["productname"] = ds.Tables[0].Rows[i]["productname"].ToString();
                dr["quantity"] = ds.Tables[0].Rows[i]["quantity"].ToString();
                dr["price"] = ds.Tables[0].Rows[i]["price"].ToString();
                int price = Convert.ToInt32(ds.Tables[0].Rows[i]["price"].ToString());
                int quantity = Convert.ToInt16(ds.Tables[0].Rows[i]["quantity"].ToString());
                int totalprice = price * quantity;
                dr["totalprice"] = totalprice;
                grandtotal = grandtotal + totalprice;
                dt.Rows.Add(dr);
                i = i + 1;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label4.Text = grandtotal.ToString();
        }
    }
}