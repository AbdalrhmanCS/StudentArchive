<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminApprove.aspx.cs" Inherits="StudentArchive1.AdminApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="
    background-color:#191b1c;
    padding: 25px;
    border-radius: 15px;
    color: white;
">
        <div class="row">
            <div class="col-md-5">
                <div class="card" style="
    background-color:#191b1c;
    padding: 25px;
    border-radius: 15px;
    color: white;
">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4 id="haa" runat="server">Admin Approval</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img  width="100" src="imgs/project-management.png" /><br /><br />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <dive class="col-md-5">
                                <label id="lblre" runat="server">Request ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control text-bg-secondary" ID="txtreq" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button CssClass="btn btn-primary" ID="btngo" runat="server" Text="Go" OnClick="btngo_Click" />
                                    </div>

                                </div>
                            </dive>
                            <dive class="col-md-7">
                                <label id="lblapt" runat="server">Approval Type</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control text-bg-secondary" ID="txttype" runat="server" placeholder="Type" ReadOnly="True"></asp:TextBox>
                                    

                                </div>
                            </dive>
                        </div>
                        <div class="row">
                             <dive class="col-md-4">
                                <label id="lblpro" runat="server">Project ID</label>
                                     <div class="form-group">
           
                                      <asp:TextBox CssClass="form-control text-bg-secondary" ID="txtpid" runat="server" placeholder="ID" ReadOnly="True"></asp:TextBox>
         
                                       </div>

                              
                       </dive>
                       </div>
                        <br /><br /><br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-lg btn-block" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                             <div class="col-4">
                                  <asp:Button CssClass="btn btn-warning btn-lg btn-block" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                             <div class="col-4">
                                  <asp:Button CssClass="btn btn-danger btn-lg btn-block" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div><br />
                          <div class="row">
                            <div class="col-md-12">
                                 <div class="d-grid gap-2">
                                        <asp:Button CssClass="btn btn-danger btn-lg btn-block" ID="Button1" runat="server" Text="Delete From Requests Table" OnClick="btnDFR_Click" />
                                </div>
                           </div><br />
                              
      
                      </div><br />
                          <div class="row">
                            <div class="col-md-12">
                                 <div class="d-grid gap-2">
                                        <asp:Button CssClass="btn btn-success btn-lg btn-block" ID="Button5" runat="server" Text="Download from requestrs" OnClick="btndoan_Click" />
                                </div>
                           </div><br />
                              
      
                      </div>
                        <br /> <a href="HomePage.aspx">Back To Home</a><br /><br /><br />
                    </div><br /><br />
                </div>
            </div>
            <div class="col-md-7">
                <div class="card" style="
    background-color:#191b1c;
    padding: 25px;
    border-radius: 15px;
    color: white;
">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 id="lblreqtable" runat="server">Requests Table</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row" style="max-width: 100%; overflow-x: auto; width: 100%; background-color:#191b1c">
                            <div class="col">
                                <asp:GridView CssClass="table table-dark" ID="GridView1" runat="server" OnLoad="GridView1_Load" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
