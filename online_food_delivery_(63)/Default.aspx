<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="online_food_delivery__63_.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<table style=" width:1150px; height:30px">
        <tr style=" background-color:#5f98f3">
            <%--Login & Logout Button--%>
            <td colspan="2" style=" text-align: right">
                <asp:Label ID="Label4" runat="server" style=" text-align:left" Font-Bold="True" 
                    Font-Italic="True" Font-Names="Bahnschrift SemiBold"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                    Font-Names="Arial Rounded MT Bold" NavigateUrl="~/Login.aspx">Click To Login</asp:HyperLink>
                <asp:Button ID="Button1" runat="server" Text="Log Out" BackColor="#FF5050" 
                    BorderColor="White" Font-Bold="True" Font-Names="Comic Sans MS" 
                    ForeColor="Aqua" Height="27px" Width="105px" onclick="Button1_Click" />
            </td>
            <%--Product Category DropDownList & TextBox for Searching Products by name as well as by Category of product--%>
            <td style=" text-align:right">
                <asp:DropDownList ID="ProductCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductCategories_SelectedIndexChanged" BackColor="#5F98F3" Font-Bold="True" Font-Size="Medium" ForeColor="White">
                </asp:DropDownList>&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="174px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="23px" 
                    ImageUrl="~/Images/SearchingIcon.jpg" Width="25px" 
                    onclick="ImageButton2_Click" />
            </td>
            
        </tr>
    </table>


    <%--Displaying Products Starts Here--%>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductId" 
        DataSourceID="SqlDataSource1" Height="293px" Width="310px" 
        RepeatColumns="4" RepeatDirection="Horizontal" 
        onitemcommand="DataList1_ItemCommand" 
        onitemdatabound="DataList1_ItemDataBound">
    <ItemTemplate>
            <table>
                <%--Product Name--%>
                <tr>
                    <td style="text-align: center; background-color: #5f98f3">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pname") %>' Font-Bold="True"
                            Font-Names="Open Sans Extrabold" ForeColor="White"></asp:Label>
                    </td>
                </tr>

                <%--Product Image & Stock of product--%>
                <tr>
                    <td style="text-align: center">
                        <asp:Image CssClass="All" ID="Image1" runat="server" BorderColor="#5F98F3" BorderWidth="1px"
                            Height="279px" Width="278px" ImageUrl='<%# Eval("Pimage") %>' />
                        <div class="all">
                            &nbsp;Stock:&nbsp;
                            <asp:Label CssClass="txtStock" ID="Label5" runat="server" Text='<%# Eval("Pquantity") %>'
                                BackColor='<%# (int)Eval("Pquantity") <= 10 ? System.Drawing.Color.Red : System.Drawing.Color.Green %>' >
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductId") %>' 
                            Visible="False"></asp:Label>
                    </td>
                </tr>

                <%--Product Price--%>
                <tr>
                    <td style="text-align: center; background-color: #5f98f3">
                        <asp:Label ID="Label2" runat="server" Text="Price: ₹" Font-Bold="True" Font-Names="Arial"
                            ForeColor="White" Style="text-align: center"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Pprice") %>' Font-Bold="True"
                            Font-Names="Arial" ForeColor="White" Style="text-align: center"></asp:Label>
                    </td>
                </tr>

                <%--Product Quantity to Buy--%>
                <tr>
                    <td align="center">
                        Qauntity
                    <asp:DropDownList ID="Dropdownlist1" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>    
                    </td>
                </tr>

                <%--Button to add Product into Cart--%>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/Images/AddCart.jpg"
                            Width="160px" CommandArgument='<%# Eval("ProductId") %>' CommandName="AddToCart" />
                    </td>
                </tr>
            </table>
        <br />
        <br />
    </ItemTemplate>
    </asp:DataList>
    <%--Displaying Products Ends Here--%>


    <%--Data to Display Products--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:FoodDeliveryDBConnectionString %>" 
        
        SelectCommand="SELECT [ProductId], [Pname], [Pimage], [Pprice], [Pquantity] FROM [Product1]">

    </asp:SqlDataSource>

</asp:Content>
