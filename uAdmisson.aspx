<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="uAdmisson.aspx.cs" Inherits="UAS.uAdmisson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="insertAddmission.aspx">Insert new Addmission details</a>
      <%-- Admisson details --%>

         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Admisson Details</h4>
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
                        <asp:GridView class="table border-0 table-striped  table-responsive" ID="eventGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" >
                            <Columns>

                                <asp:BoundField DataField="id" HeaderText="ID" />
                                <asp:BoundField DataField="addmisson_season" HeaderText="addmisson season" />
                                <asp:BoundField DataField="deadline" HeaderText="addmisson deadline" />
                                <asp:BoundField DataField="course" HeaderText="Course" />
                                <asp:BoundField DataField="exam_date" HeaderText="Exam Date" />
                               
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                        Action
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="btnDelete_Click">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
              <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" NextPageText="Next "/>  

                        </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div> 
              
</asp:Content>
