<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="teacherRegistration.aspx.cs" Inherits="UAS.teacherRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">

        *{
           /* background-color:rgb(168 162 158);*/
        }
                
        .regstrainStyle {
            width: 77%;
            height: 289px;
            margin-bottom: 0px;
        }
        .userInfoStyle {
            width: 97px;
            font-weight: bold;
        }
       
        .userImg {
            width: 326px;
        }
        .userimgblock {
            width: 332px;
        }
      
        .auto-style1 {
            width: 362px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container justify-content-center mt-5 mb-5 border rounded p-5" style="border:1px solid black !important; border-radius:25px !important; color: black; box-shadow: 2px 2px 20px grey; background-color:aliceblue; background-image: radial-gradient(rgba(185, 206, 222, 0.6), rgba(194, 226, 221, 0.4));">

        <br />
       <h2 style="text-align:center;">Register as a Teacher</h2>
        <br /> <br />

       <div class="form-row justify-content-around">
            <div class="form-group col-md-6">
                <asp:Label ID="Label4" runat="server" Text="&nbsp; First Name: "></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>           
        </div>

       <div class="form-row justify-content-around">
            <div class="form-group col-md-6">
                <asp:Label ID="Label1" runat="server" Text="&nbsp; Email: "></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label2" runat="server" Text="&nbsp; Contact No: "></asp:Label>
                <asp:TextBox ID="ContactNo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-row justify-content-around">
            <div class="form-group col-md-12">
                <asp:Label ID="Label5" runat="server" Text="&nbsp; Study Background: "></asp:Label>
                <asp:TextBox ID="sb" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

         <div class="form-row justify-content-around">
            <div class="form-group col-md-6">
                <asp:Label ID="Label6" runat="server" Text="&nbsp; Password: "></asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="form-control"></asp:TextBox>    
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label7" runat="server" Text="&nbsp; Gender: "></asp:Label>
                <asp:DropDownList ID="DropDownGender" runat="server" CssClass="auto-style20 form-control">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Prefer Not to Say</asp:ListItem>
                </asp:DropDownList>    
            </div>
        </div>

        <br /> <br /> 
        <div class="bookflight" style="text-align: center;">
            &nbsp; <b> Upload Profile Image </b> &nbsp; &nbsp;
            <asp:FileUpload ID="ImageUpload" runat="server"/> &nbsp;
        </div>
        <br />  <br />

            <div class="bookflight" style="text-align:center;">
                 <asp:Button ID="UserInfobuttoN" runat="server" cssclass="btn btn-dark" OnClick="UserInfoSubmit" Text="Submit" Width="84px" />
            </div>
            <br />  

     </div>

</asp:Content>
