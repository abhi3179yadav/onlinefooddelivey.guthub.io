using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;


namespace online_food_delivery__63_
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                MailMessage Msg = new MailMessage();
                //Sender e-mail address.
                Msg.From = new MailAddress("abhiyadav3179@gmail.com");
                //Recipient e-mail address.
                Msg.To.Add("abhiyadav3179@gmail.com");
                //Meaages Subject
                Msg.Subject = "Contact Us Abhishek";
                StringBuilder sb = new StringBuilder();
                sb.Append("Name :" + txtname.Text + "\r\n");
                sb.Append("Contact:" + txtcontact.Text + "\r\n");
                sb.Append("Email:" + txtemail.Text + "\r\n");
                sb.Append("Message:" + txtmessage.Text + "\r\n");

                Msg.Body = sb.ToString();
                // SMTP server IP.
                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                smtp.Credentials = new System.Net.NetworkCredential("abhiyadav3179@gmail.com", "Abhishek@123");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                //Mail Message
                Response.Write("<Script>alert('Thanks for contact us,our team will be contact you as soon as possible')</Script>");
                // Clear the textbox values
                txtname.Text = "";
                txtcontact.Text = "";
                txtemail.Text = "";
                txtmessage.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
    }
}




