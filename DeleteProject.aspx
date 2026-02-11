<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteProject.aspx.cs" Inherits="StudentArchive1.DeleteProject" %>
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
                               <h4 id="hdel" runat="server">Delete Project</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <img  width="100" src="imgs/delete.png" /><br /><br />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <dive class="col-md-5">
                            <label id="lblpid" runat="server">Project ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control text-bg-secondary" ID="txtpid" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>

                            </div>
                        </dive>
                        <dive class="col-md-7">
                            <label id="lbltit" runat="server">Title</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control text-bg-secondary" ID="txttitle" runat="server" placeholder="Title" ReadOnly="True"></asp:TextBox>
                                

                            </div>
                        </dive>
                    </div>
                    <br /><br /><br /><br /><br /><br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="d-grid gap-2">
                            <asp:Button CssClass="btn btn-danger btn-lg btn-block" ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
                                </div>
                        </div>
                        
                    </div><br /> <a href="HomePage.aspx">Back To Home</a><br /><br /><br />
                </div><br /><br /><br /><br />
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
                                <h4 id="hptaple" runat="server">Projects Table</h4>
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
                                    <asp:GridView CssClass="table table-dark" ID="GridView1" runat="server" OnLoad="GridView1_Load"  ></asp:GridView>
                             </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
