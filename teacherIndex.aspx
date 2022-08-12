<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="teacherIndex.aspx.cs" Inherits="UAS.teacherIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                              <p><%# Convert.ToString(Eval("t_id")) == string.Empty ? "Not assigned" : Eval("t_id") %></p>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:BoundField DataField="amount" HeaderText="Amount" />
                                  </Columns>
                                  <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" NextPageText="Next " />

                              </asp:GridView>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
</asp:Content>
