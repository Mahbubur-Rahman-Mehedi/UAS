<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="adminStudentControl.aspx.cs" Inherits="UAS.adminStudentControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <center>  <h3>Admin Panel</h3> </center>
    &nbsp;  &nbsp;  <asp:Button ID="back" CssClass="back btn btn-primary" runat="server" Text="Back" onclick="back_Click" Visible="true" /> 
   <br />  <br />
    <div style="display: flex; justify-content: flex-end"> 
        
    </div>


    <div class="container-fluid" id="studentEdit" runat="server">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Student Details</h4>
                                </center>
                            </div>
                            <asp:Label ID="message" runat="server" Text=''></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <!--           <img src="images/admin.png" width ="100px">  -->

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Student ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="empid" runat="server" placeHolder="Fill"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary pr-4 ml-1" ID="btnEventDetails" runat="server" Style="width: 6px" OnClick="btnEventDetails_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Student Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <label>Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-2" ID="status" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-success pr-4 mr-1" ID="btnActive" runat="server" title="active" OnClick="btnActive_Click" Style="width: 6px"><i id="iActive" runat="server" class="fas fa-check-circle"></i></asp:LinkButton>
                                    <%--  <asp:LinkButton class="btn btn-warning pr-4 mr-1" ID="btnPending" runat="server" title="deactive" OnClick="btnPending_Click" style="width: 6px"><i class="far fa-pause-circle"></i></asp:LinkButton>--%>
                                    <asp:LinkButton class="btn btn-danger pr-4 mr-1" ID="btnDelete" runat="server" title="delete" OnClick="btnDelete_Click" Style="width: 6px"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-primary pr-4 mr-1" ID="btnEdit" runat="server" title="Edit" OnClick="btnEdit_Click" Visible="false" >Edit</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-primary pr-4 mr-1" ID="btnCancel" runat="server" title="Cancel" OnClick="btnCancel_Click" Visible="false" >Cancel</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-primary pr-4 mr-1" ID="btnOk" runat="server" title="Ok" OnClick="btnOk_Click" Visible="false" >Ok</asp:LinkButton>
                                    <asp:LinkButton class="btn btn-primary pr-4 mr-1" ID="btnInsert" runat="server" title="Insert" OnClick="btnInsert_Click" Visible="true" >Insert</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        </div>

                    <div class="row">
                          <div class="col-md-5">
                              <label>Father Name</label>
                              <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="txtFathers" runat="server" ReadOnly="True"></asp:TextBox>
                              </div>
                          </div>
                          <div class="col-md-7">
                              <label>Mother Name</label>
                              <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="txtMother" runat="server" ReadOnly="True"></asp:TextBox>
                              </div>
                          </div>
                      </div>

                      <div class="row">
                          <div class="col-md-5">
                              <label>Contact No</label>
                              <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="phone" runat="server" ReadOnly="True"></asp:TextBox>
                              </div>
                          </div>
                          <div class="col-md-7">
                              <label>Email</label>
                              <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="email" runat="server" ReadOnly="True"></asp:TextBox>
                              </div>
                          </div>
                      </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Present Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="address" runat="server" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    <div class="row">
                            <div class="col-12">
                                <label>Permanent Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPaddress" runat="server" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            
        

            <%-- Student List --%>

            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Student List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table border-0 table-striped  table-responsive" ID="eventGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                                    <Columns>

                                        <asp:BoundField DataField="s_id" HeaderText="ID" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnSelect" runat="server" CommandArgument='<%#Eval("s_id") %>' OnClick="btnSelect_Click"> <%#Eval("s_name")  %> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                       <asp:BoundField DataField="status" HeaderText="Status" />
                                        <%--<asp:BoundField DataField="isExpired" HeaderText="Status" />--%>
                                       <%-- <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <p><%# Convert.ToString(Eval("isExpired")) == "False"? "Active" : "Deactive"%></p>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:BoundField DataField="s_phone" HeaderText="Phone" />
                                        <asp:BoundField DataField="s_mail" HeaderText="Email" />

                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" NextPageText="Next " />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
      
 </div>
   
</asp:Content>
