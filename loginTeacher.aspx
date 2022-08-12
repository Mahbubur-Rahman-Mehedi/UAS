<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="loginTeacher.aspx.cs" Inherits="UAS.loginTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="login">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4">Login as Teacher</h1>
                <br />
                <form>
                    <div class="form-group row">
                        <label for="inputEmail3" class="col-sm-2 col-form-label">Email</label>
                        <div class="col-sm-6"> 
                                <asp:TextBox ID="loginemail" runat="server" required="required" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Password</label>
                        <div class="col-sm-6"> 
                             <asp:TextBox ID="loginpassword" runat="server" required="required" TextMode="Password" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6"> 
                            <asp:Button ID="btnlogin" runat="server" class="btn btn-primary" Text="Log in" OnClick="btnlogin_Click"  />
                        </div>
                    </div>
                </form>
                <p class="lead">Don't have an account? <a href="teacherRegistration.aspx"><b>Register</b></a></p>
                 <p class="lead"><a href="resetPassword.aspx">Forgot Password?</a></p>
                 <asp:Label ID="messageLable1"  runat="server" Text=""></asp:Label>
                <asp:Label ID="messageLable2"  runat="server" Text="" Visible="false"> Sorry, we experiencing some technical difficulties, please visit us again</asp:Label>
            </div>
        </div>

    </section>
</asp:Content>
