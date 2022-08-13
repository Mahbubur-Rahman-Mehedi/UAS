<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="sCourses.aspx.cs" Inherits="UAS.sCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />

     <%-- Course List --%>

          <div class="col-md-6">
              <div class="card">
                  <div class="card-body">
                      <div class="row">
                          <div class="col">
                              <center>
                                  <h4>Course List</h4>
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

                                      <asp:BoundField DataField="c_id" HeaderText="ID" />
                                      <asp:BoundField DataField="subject" HeaderText="Course Name" />

                                      <asp:TemplateField>
                                          <HeaderTemplate>
                                              Teacher
                                          </HeaderTemplate>
                                          <ItemTemplate>
                                              <p><%# Convert.ToString(Eval("t_name")) == string.Empty ? "Not assigned" : Eval("t_name") %></p>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:BoundField DataField="amount" HeaderText="Amount" />

                                      <asp:TemplateField>
                                          <HeaderTemplate>
                                              Action
                                          </HeaderTemplate>
                                          <ItemTemplate>
                                              <asp:LinkButton ID="btnCancel" runat="server" CommandArgument='<%#Eval("c_id") %>' OnClick="btnCancel_Click">Cancel</asp:LinkButton>
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
