<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="adminQuestion.aspx.cs" Inherits="UAS.adminQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>  <h5>Admin Panel</h5> </center>
    <asp:Button ID="back" CssClass="back" runat="server" Text="back" onclick="back_Click" Visible="true" /> 
   
    <div style="display: flex; justify-content: flex-end"> 
        
    </div>


   <div class="container-fluid" id="QueEdit" runat="server">
      <div class="row">
         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Question Details</h4>
                        </center>
                     </div>
                      <asp:Label ID="message" runat="server" Text=''></asp:Label>
                      <asp:LinkButton class="btn btn-primary pr-4 ml-1" ID="lnkbtnInsertA" runat="server"  OnClick="lnkbtnInsertA_Click">Insert</asp:LinkButton>
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
                        <label>ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="empid" runat="server" placeHolder="Fill" ></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary pr-4 ml-1" ID="btnEventDetails" runat="server" style="width: 6px"   OnClick="btnEventDetails_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>University Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="name" runat="server"   ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Status</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control mr-2" ID="status" runat="server"   ReadOnly="True"></asp:TextBox>
                              <asp:LinkButton class="btn btn-success pr-4 mr-1" ID="btnInsert" runat="server" title="insert" OnClick="btnInsert_Click" Visible="false"  style="width: 6px"><i class="fas fa-check-circle"></i></asp:LinkButton>
                              <asp:LinkButton class="btn btn-warning pr-4 mr-1" ID="btnActive" runat="server" title="active" OnClick="btnActive_Click"  style="width: 6px"><i id="iActive" runat="server" class="fas fa-pause-circle"></i></asp:LinkButton>
                           <%--   <asp:LinkButton class="btn btn-warning pr-4 mr-1" ID="btnPending" runat="server" title="deactive" OnClick="btnPending_Click" style="width: 6px"><i id="iDeactive" runat="server" class="far fa-pause-circle"></i></asp:LinkButton>--%>
                              <asp:LinkButton class="btn btn-danger pr-4 mr-1" ID="btnDelete" runat="server" title="delete" OnClick="btnDelete_Click" style="width: 6px"><i class="fas fa-times-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                  </div>
                   <div class="col-md-10">
                        <label>Document</label>
                       <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txDocument" runat="server" ReadOnly="True"></asp:TextBox>
                           <asp:LinkButton ID="LinkDownload" runat="server" class="download" OnClick="LinkDownload_Click" Text="Download" ></asp:LinkButton>
                           <asp:FileUpload ID="skillFile" runat="server" />
                           <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                           <br />
                           <asp:Label ID="lblUploadMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="Filesize should be less than 2MB"></asp:Label>
                       </div>
                     </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Year</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="year" runat="server"   TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
               </div>
               
            </div> 
              
         </div>


          <%-- Question List --%>

         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Question List</h4>
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
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                       University Name
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnSelect" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="btnSelect_Click"> <%#Eval("university_name")  %> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="year" HeaderText="Year" />
                                <%--<asp:BoundField DataField="isExpired" HeaderText="Status" />--%>
                                <asp:TemplateField HeaderText="Document">
                                    <ItemTemplate>
                                        <p><%# Convert.ToString(Eval("DocName")) == string.Empty ? "No" : Eval("DocName") %></p>
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
              
   </div>
</asp:Content>
