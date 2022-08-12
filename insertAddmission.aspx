<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="insertAddmission.aspx.cs" Inherits="UAS.insertAddmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="registration">
        <div class="jumbotron-fluid pt-5 pb-5" style="min-height: 550px;">
            <div class="container">
                <div id="registerDiv" runat="server" class="container">
                    <br />
                    <h2 style="font-weight: 400;">Insert Addmission Details for 
                        <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                    </h2>
                    <br />
                    <br />



                    <asp:Label ID="lbl" runat="server" Style="color: red" Text=""></asp:Label>

                    <div id="theRestDiv" runat="server" visible="true">

                        <br />
                       
                        <!--
                    <div class="form-group row">
                        <label for="employerId" class="col-sm-2 col-form-label">Employer ID</label>
                        <div class="col-sm-10"> 
                            <asp:TextBox ID="employerId" runat="server" required="required" class="form-control"    ></asp:TextBox>
                        </div>
                    </div>
                    -->
                       
                       
                        <div class="form-group row">
                            <label for="txtaddss" class="col-sm-2 col-form-label">Addmission Season</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtaddss" runat="server" required="required" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="phone" class="col-sm-2 col-form-label">Phone</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="phone" runat="server" required="required" class="form-control" placeholder="5555551234"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">                                           
                            <label for="applicationDeadline" class="col-sm-2 col-form-label">Application Deadline</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="applicationDeadline" runat="server" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
                              
                            </div>
                        </div><br />
                         <div class="form-group row">                                           
                            <label for="applicationDeadline" class="col-sm-2 col-form-label">Exam Date</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtExamDate" runat="server" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox>
                              
                            </div>
                        </div><br />
                        <div class="form-group row">
                            <label for="designation" class="col-sm-2 col-form-label">Departement </label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="departement" runat="server" name="designation" required="required">
                                    <asp:ListItem Text="CSE" Value="CSE"></asp:ListItem>
                                    <asp:ListItem Text="BBA" Value="BBA"></asp:ListItem>
                                    <asp:ListItem Text="LAW" Value="LAW"></asp:ListItem>
                                    <asp:ListItem Text="ENGLISH" Value="ENGLISH"></asp:ListItem>
                                    <asp:ListItem Text="EEE" Value="EEE"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>



                        <br />


                        <div class="form-group row">
                            <div class="col-sm-7">
                                <asp:Button ID="btnsignup" runat="server" class="btn btn-primary" Text="Sign up" OnClick="btnsignup_Click" />
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>


    </section>
</asp:Content>
