<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="UAS.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container mt-5 mb-5 mx-auto justify-content-center" >
		  <div class="bookflight row justify-content-center">
            <div class="col-md-6 justify-content-center border rounded p-5" style="border:2px solid black !important; border-radius:25px !important; color: black; box-shadow: 2px 2px 20px grey; background-color:aliceblue; background-image: radial-gradient(rgba(185, 206, 222, 0.6), rgba(194, 226, 221, 0.4));">


            <h2 style="text-align:center;">Admin Login</h2>
            <br /> <br />

            <asp:Label ID="usernameLabel" runat="server" Text="&nbsp; Username: "></asp:Label>
            <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>  <br /> 

            <asp:Label ID="passwordLabel" runat="server" Text="&nbsp; Password: "></asp:Label>
            <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox> <br /> <br /> 
            
            <div style="text-align:center;">
                 <asp:Button ID="AdminLoginbtn" runat="server" OnClick="AdminLogin" Text="Login" CssClass="btn btn-dark"/>
            </div> 

         </div>
        </div>
       </div>
</asp:Content>
