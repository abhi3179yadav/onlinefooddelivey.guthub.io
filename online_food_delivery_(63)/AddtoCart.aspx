<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddtoCart.aspx.cs" Inherits="online_food_delivery__63_.AddtoCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align="center" style=" margin: 0 auto;">

        <h2 style=" text-decoration: underline overline blink; color:#5f98f3">You Have Following Food In Your order</h2>
        <br />

        <%--Redirect you to Default page--%>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
            Font-Names="Colonna MT" Font-Size="X-Large" NavigateUrl="~/Default.aspx">Order More</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <%--Clear All products present in your Cart--%>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Clear Order List</asp:LinkButton>
            <br /><br />

        <%--Displays Product present in your Cart--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="#ffffff" BorderColor="#333333" BorderWidth="5px" 
            EmptyDataText="No Product Available in Shopping Cart" Font-Bold="True" 
            Height="257px" ShowFooter="True" Width="1100px" 
            onrowdeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="Sr No">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pid" HeaderText="Food ID">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="pimage" HeaderText="Food Image">
                    <ControlStyle Height="300px" Width="340px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="pname" HeaderText="Food Name">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pdesc" HeaderText="Description">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pprice" HeaderText="Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pquantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ptotalprice" HeaderText="Total Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#6666FF" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="DarkOrchid" ForeColor="White" />
        </asp:GridView>

        <br />

        <%--Buttton to place an Order which redirects you to Payment page--%>
        <asp:Button CssClass="btnPlaceOrder" ID="Button1" runat="server" Text="Place Order" BackColor="#FF6699" 
            BorderColor="#0A2C2A" BorderStyle="Ridge" Font-Bold="True" Font-Size="Large" 
            Height="46px" Width="135px" onclick="Button1_Click" />
    </div>

        </div>
    </form>
</body>
</html>
