<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="UAS.contactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <asp:Label ID="Label1" runat="server" Text="Your name">
    </asp:Label><asp:TextBox ID="txtName" runat="server" Required="true"></asp:TextBox>
    </div>

    <div>
    <asp:Label ID="Label3" runat="server" Text="Email Address">
    </asp:Label><asp:TextBox ID="txtEmail" runat="server" Required="true"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="Label2" runat="server" Text="Comment">
        </asp:Label><asp:TextBox ID="txtComment" runat="server" Required="true"></asp:TextBox>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
     
</asp:Content>
