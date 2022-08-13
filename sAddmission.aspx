<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="sAddmission.aspx.cs" Inherits="UAS.sAddmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />

      <%-- Admisson post List --%>

          <div class="col-md-12">
              <div class="card">
                  <div class="card-body">
                      <div class="row">
                          <div class="col">
                              <center>
                                  <h4>Admisson Posts</h4>
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
                              <asp:GridView class="table border-0 table-striped  table-responsive" ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging1" PageSize="10">
                                  <Columns>

                                      <asp:BoundField DataField="id" HeaderText="ID" Visible="false"/>
                                      <asp:BoundField DataField="u_name" HeaderText="Name"/>
                                      <asp:BoundField DataField="u_details" HeaderText="University Details"/>
                                      <asp:BoundField DataField="addmisson_season" HeaderText="addmisson season" />
                                      <asp:BoundField DataField="deadline" HeaderText="deadline" />
                                      <asp:BoundField DataField="exam_date" HeaderText="exam date" />
                                      <asp:BoundField DataField="course" HeaderText="Department" />
                                      <asp:BoundField DataField="phone" HeaderText="phone" />
                                      

                                      <asp:TemplateField>
                                          <HeaderTemplate>
                                              Action
                                          </HeaderTemplate>
                                          <ItemTemplate>
                                              <asp:LinkButton ID="btnCancel" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                  </Columns>
                                  <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" NextPageText="Next " />

                              </asp:GridView>
                          </div>
                      </div>
                  </div>
              </div>
          </div>

</asp:Content>
