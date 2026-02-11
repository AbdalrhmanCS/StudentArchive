<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="StudentArchive1.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container" style="
    background-color:#191b1c;
    padding: 25px;
    border-radius: 15px;
    color: white;
">
    <div class="row">
        <div class="col-md-6 mx-auto">
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
                                <img width="150" src="imgs/user.png" />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col">
                              <center>
                                <h3>Admin Login</h3>
                              </center>
                         </div>
                   </div>
                   <div class="row">
                        <div class="col">
                              <br />
                        </div>
                  </div>
                      <div class="row">
                          <label>Admin Email</label>
                           <div class="form-group">
                               
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="E-mail"></asp:TextBox>
                                
                           </div>
                          <label>Admin Password</label>
                           <div class="form-group">
                              
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                               <br />
                           </div>
                          <br />
                           <div class="form-group">
                               
                                   <div class="d-grid gap-2">
                                     
                                   <input class="btn btn-primary btn-lg" id="Button1" type="button"  value="Login" />
                                      
                              
                           </div>
                               <br />
                           
                               
                      </div>
                </div>
            </div>
        
                </div>
             <br /><br />
            
            <br /><br /><br /><br />
    </div>
</div>
    </div>
</asp:Content>
