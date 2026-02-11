<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="StudentArchive1.ProfilePage" %>
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
        <div class="col-md-8 mx-auto">
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
                                <img width="100" src="imgs/user%20(1).png"  />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col">
                              <center>
                                <h4 id="hyp" runat="server">Your Profile</h4>
                                  <span id="accst" runat="server">Account Status - </span>
                                  <asp:Label CssClass="badge text-bg-success" ID="lblact" runat="server" Text="Active"></asp:Label>
                              </center>
                         </div>
                   </div>
                   <div class="row">
                        <div class="col">
                              <hr />
                        </div>
                  </div>
                   <div class="row">
                        <div class="col-md-6">
                      
                          
                          <label id="lblfn" runat="server">Full Name</label>
                           <div class="form-group">
                               
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtfull" runat="server" placeholder="Full Name"></asp:TextBox>
                                
                           </div>
                       
                        </div>
                        <div class="col-md-6">
                          <label id="lbldob" runat="server">Date of Birth</label>
                           <div class="form-group">
                              
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtdate" runat="server"  TextMode="Date" ReadOnly="False"></asp:TextBox>
                               <br />
                           </div>                              
                        </div>
                  

                 </div>     
                                        <div class="row">
                        <div class="col-md-4">
                      
                          
                          <label id="lblem" runat="server">Email</label>
                           <div class="form-group">
                               
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtemail" runat="server" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                                
                           </div>
                       
                        </div>
                        <div class="col-md-4">
                          <label id="lbloldpass" runat="server">Old Password</label>
                           <div class="form-group">
                              
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtold" runat="server" placeholder="Password"  ReadOnly="True"></asp:TextBox>
                               <br />

                           </div>     

                  

                 </div>     
                       <div class="col-md-4">
                          <label id="lblnewpass" runat="server">New Password</label>
                           <div class="form-group">
                              
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtnew" runat="server" placeholder="Password" ></asp:TextBox>
                               <br />
                           </div>     
                        </div>

                          <br />
                           <div class="form-group">
                               
                                   <div class="d-grid gap-2">
                                     
                                       <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                      
                              
                           </div>
                               <br />
                          
                               
                      </div>
                </div>
            </div>
        
                </div>
             <br /><br />
            <a href="HomePage.aspx">Back To Home</a>
            <br /><br /><br /><br />
    </div>
</div>
           </div>
</asp:Content>
