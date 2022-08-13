<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UAS.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
      <%-- Course List --%>

          <div class="col-md-12" style="place-content:center">
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
                              <a href="sCourses.aspx">my courses</a>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col">
                              <hr>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col">
                              <asp:GridView class="table border-0 table-striped table-responsive" ID="eventGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
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
                                              <asp:LinkButton ID="btnApply" runat="server" CommandArgument='<%#Eval("c_id") %>' OnClick="btnApply_Click1">Join</asp:LinkButton>
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
                              <a href="sAddmission.aspx">my applied list</a>
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
                                              <asp:LinkButton ID="btnApply1" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="btnApply1_Click">apply</asp:LinkButton>
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
