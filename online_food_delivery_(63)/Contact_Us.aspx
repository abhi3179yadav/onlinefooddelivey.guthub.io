<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact_Us.aspx.cs" Inherits="online_food_delivery__63_.Contact_Us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-image:url("Images/back.jpg");
            background-size:cover;
        }
      
    </style>
</head>
<body>
                
    <form id="form1" runat="server">
    <div>
        <fieldset style="width: 300px;">
            <legend>Contact Us Form</legend>
            <table align="centre" style="width: 641px; height: 360px">
                <tr>
                    <td align="centre">
                        Name
                    </td>
                    <td align="centre">
                        <asp:TextBox ID="txtname" runat="server" Height="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="centre">
                        Conatct Number
                    </td>
                    <td align="centre">
                        <asp:TextBox ID="txtcontact" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcontact" ErrorMessage="Enter Contact Number" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="centre">
                        Email
                    </td>
                    <td align="centre">
                        <asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter E-mail" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="centre">
                        Message
                    </td>
                    <td align="centre">
                        <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmessage" ErrorMessage="Enter Meassage" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" Height="39px" Width="98px" />
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" ForeColor="Black" NavigateUrl="~/Default.aspx">Goto Home Page</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>


