<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminSignup.aspx.cs" Inherits="StudentArchive1.AdminSignup" %>
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
             <br />
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
                                 <img width="100" src="imgs/user.png" />
                             </center>
                         </div>
                     </div>
                     <div class="row">
                          <div class="col">
                               <center>
                                 <h4 id="hasu" runat="server">Admin Sign Up</h4>
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
                                
                                     <asp:TextBox class="form-control text-bg-secondary" ID="txtfulname" runat="server" placeholder="Full Name"></asp:TextBox>
                                 
                            </div>
                        
                         </div>
                         <div class="col-md-6">
                           <label id="lbldob" runat="server">Date of Birth</label>
                            <div class="form-group">
                               
                                     <asp:TextBox class="form-control text-bg-secondary" ID="txtDob" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                                <br />
                            </div>                              
                         </div>
                   

                  </div>     
                                         <div class="row">
                         <div class="col-md-6">
                       
                           
                           <label id="lblem" runat="server">Email</label>
                            <div class="form-group">
                                
                                     <asp:TextBox class="form-control text-bg-secondary" ID="txtemail" runat="server" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                                 
                            </div>
                        
                         </div>
                         <div class="col-md-6">
                           <label id="lblpass" runat="server">Password</label>
                            <div class="form-group">
                               
                                     <asp:TextBox class="form-control text-bg-secondary" ID="txtpass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <br />
                            </div>                              
                         </div>
                   

                  </div>     

                           <br />
                            <div class="form-group">
                                
                                    <div class="d-grid gap-2">
                                      
                                   <%// <input class="btn btn-primary btn-lg" id="Button1" type="button"  value="Sign Up" />%> 
                                        <asp:Button class="btn btn-primary btn-lg" ID="btnad" runat="server" Text="Sign Up" OnClick="btnad_Click"  />
                               
                            </div>
                                <br />
                           
                                
                       </div>
                 </div>
             </div>
         
                 </div>
              <br /><br />
             
             <br /><br /><br /><br /><br />
     </div>
 </div>
</asp:Content>
