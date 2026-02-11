<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewPr.aspx.cs" Inherits="StudentArchive1.ViewPr" %>
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
                               <div class="col-md-6 ">
                                      <img width="150" src="imgs/شعار-جامعة-الموصل-zzzz-150x150.png" />
                               </div>
                                   <div class="col-md-auto me-auto">
                                        <img width="150" src="imgs/شعار-الكلية-شفاف.png" />
                                   </div>
                               </div>
                   
                    <div class="row">
                         <div class="col">
                              <center>
                                <h4 id="hviewp" runat="server">View Projects</h4>
                              </center>
                         </div>
                   </div>
                   <div class="row">
                        <div class="col">
                              <hr />
                        </div>
                  </div>
                    <div class="row">
                        <div class="col"><center>
                            <asp:Label Font-Size="Large" ID="lbltitle" runat="server"></asp:Label>
                            </center><br /><br />
                        </div>
                    </div>
                   <div class="row">
                        <div class="col">
                      
                          
                          <label id="lblpid" runat="server">Project ID</label>
                           <div class="form-group">
                               <center>
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtid" runat="server" placeholder="ID"></asp:TextBox>
                                </center>
                           </div>
                       
                        </div>
                      
                  

                 </div>   
                    <br /><br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="lbln" runat="server" Text="Name:"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:Label ID="lblnm1" runat="server"></asp:Label>
                        </div>
                    </div>
                    <hr /><br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="lbln2" runat="server" Text="Name:"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:Label ID="lblnm2" runat="server"></asp:Label>
                        </div>
                    </div>
                    <hr /><br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="lbln3" runat="server" Text="Name:"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:Label ID="lblnm3" runat="server"></asp:Label>
                        </div>
                    </div>
                    <hr /><br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="lbln4" runat="server" Text="Name:"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:Label ID="lblnm4" runat="server"></asp:Label>
                        </div>
                    </div>
                       <hr /><br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblsu" runat="server" Text="Supervisor Name:"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:Label ID="lblsupn" runat="server"></asp:Label>
                        </div>
                    </div>
                       <hr /><br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblg" runat="server" Text="Graduation Year:"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:Label ID="lblGY" runat="server"></asp:Label>
                        </div>
                    </div>
                    <br /><br />
                  
                           <div class="form-group">
       
                            <div class="d-grid gap-2">
             
                                <asp:Button class="btn btn-info btn-lg" ID="Button2" runat="server" Text="View" OnClick="Button2_Click" />
              
      
                                         </div>
                       
                   

            
                </div><br /><br />
                          <div class="form-group">
      
                           <div class="d-grid gap-2">
            
                               <asp:Button class="btn  btn-success btn-lg" ID="Button1" runat="server" Text="Download Project" OnClick="Button1_Click" />
             
     
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
