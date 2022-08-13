<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="studentList.aspx.cs" Inherits="UAS.studentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnBack" runat="server" OnClick="back_Click" Text="Back" />

     <%-- Student List --%>

            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblC" runat="server" Text=""></asp:Label> <h4>Student List</h4>
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
                                        <asp:BoundField DataField="s_name" HeaderText="Name" />
                                       <%-- <asp:TemplateField>
                                            <HeaderTemplate>
                                                Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnSelect" runat="server" CommandArgument='<%#Eval("s_id") %>' OnClick="btnSelect_Click"> <%#Eval("s_name")  %> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

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
</asp:Content>
