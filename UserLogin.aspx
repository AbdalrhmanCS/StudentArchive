<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="StudentArchive1.UserLogin" %>
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
                                    <img width="150" src="imgs/user%20(1).png"  />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col">
                                  <center>
                                    <h3 id="hlogin" runat="server">Login</h3>
                                  </center>
                             </div>
                       </div>
                       <div class="row">
                            <div class="col">
                                  <hr />
                            </div>
                      </div>
                          <div class="row">
                              <label id="lblem" runat="server">Email</label>
                               <div class="form-group">
                                   
                                        <asp:TextBox class="form-control text-bg-secondary" ID="txtemail" runat="server" placeholder="E-mail"></asp:TextBox>
                                    
                               </div>
                              <label id="lblpass" runat="server">Password</label>
                               <div class="form-group">
                                  
                                        <asp:TextBox class="form-control text-bg-secondary" ID="txtpass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                   <br />
                               </div>
                              <br />
                               <div class="form-group">
                                   
                                       <div class="d-grid gap-2">
                                         
                                      
                                           <asp:Button  class="btn btn-primary btn-lg" ID="Button4" runat="server" Text="Login" OnClick="Button4_Click" />
                                  
                               </div>
                                   <br />
                               <div class="form-group">
                                   <div class="col">
                                       <a href="SignUp.aspx">
                                       <div class="d-grid gap-2">
                                      
                                           <asp:Button Class="btn btn-info btn-lg"  ID="Button3" runat="server" Text="Sign Up" OnClick="Button3_Click" />
                                           </div></a>
                                   </div>
                               </div>
                                   
                          </div>
                    </div>
                </div>
            
                    </div>
                 <br /><br />
                
                <br /><br />
        </div>
    </div>
        </div>
</asp:Content>
