<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdf_generate.aspx.cs" Inherits="online_food_delivery__63_.Pdf_generate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <div>
                <%--Button to Download Invoice in PDF format--%>
                <asp:Button ID="Button1" runat="server" Text="Download Invoice"
                    BackColor="#66ffff" Font-Bold="True" Font-Size="X-Large" Height="49px"
                    OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True"
            Font-Size="X-Large" NavigateUrl="~/Default.aspx">Go to Home Page</asp:HyperLink>
                <%--Redirect to Home Page i.e Default Page--%>


                <%--Content inside the Panel will going to reflect in PDF--%>
                <asp:Panel ID="Panel1" runat="server">

                    <table border="1">
                        <%--Header Text--%>
                        <tr>
                            <td style="text-align: center">
                                <h2 style="text-align: center">Online Food Delivery Invoice</h2>
                            </td>
                        </tr>

                        <tr>
                            <%--Order No. & Order Date--%>
                            <td>Order No:
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <br />
                                <br />
                                Order Date:
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>

                                <table>
                                    <tr>
                                        <%--User Address--%>
                                        <td style="width: 40%">Buyer Address:
                                            <br />
                                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        </td>

                                        <%--Seller Address--%>
                                        <td>Seller Address:
                                            <br />
                                            <br />
                                            GALA NO 10 Abhishek Apt Khopat Thane West 400601
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>

                        <%--GridVeiw for displaying Purchased Product--%>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    Width="1000px">
                                    <Columns>
                                        <asp:BoundField DataField="sno" HeaderText="SNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="productid" HeaderText="Food Id">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="productname" HeaderText="Food Name">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="quantity" HeaderText="Quantity">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="price" HeaderText="Price">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>

                        <%--Display Total payment--%>
                        <tr>
                            <td>Grand Total:
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>

                        <%--PDF Note--%>
                        <tr>
                            <td align="center">This is a computer generated invoice and does not required signature.</td>
                        </tr>
                    </table>

                </asp:Panel>
            </div>
        </center>

        </div>
    </form>
</body>
</html>
