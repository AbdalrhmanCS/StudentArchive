<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProjects.aspx.cs" Inherits="StudentArchive1.AddProjects" %>
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
                                <img  width="100" src="imgs/office.png" /><br /><br />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col">
                              <center>
                                <h4 id="hadd" runat="server">Add Projects</h4>
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
                      
                          
                          <label id="ptit" runat="server">Project Title</label>
                           <div class="form-group">
                               
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txttitle" runat="server" placeholder="Title"></asp:TextBox>
                                
                           </div>
                       
                        </div>
                        <div class="col-md-6">
                          <label id="lblsup" runat="server">Supervisor Name</label>
                           <div class="form-group">
                              
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtsupname" runat="server" placeholder="Supervisor Name" ></asp:TextBox>
                               <br />
                           </div>                              
                        </div>
                  

                 </div>     
                      <div class="row">
                            <div class="col-md-6">
     
         
                               <label id="lblsn1" runat="server">Student Name 1</label>
                                  <div class="form-group">
              
                                       <asp:TextBox class="form-control text-bg-secondary" ID="txtsn1" runat="server" placeholder="Name"></asp:TextBox>
               
                                  </div>
      
                             </div>
                                    <div class="col-md-6">
                                        <label id="lblsn2" runat="server">Student Name 2</label>
                                               <div class="form-group">
             
                                              <asp:TextBox class="form-control text-bg-secondary" ID="txtsn2" runat="server" placeholder="Name" ></asp:TextBox>
            
                                                 </div>                              
                                       </div>
 

                                   </div>     
                      <div class="row">
                            <div class="col-md-6">
     
         
                               <label id="lblsn3" runat="server">Student Name 3</label>
                                  <div class="form-group">
              
                                       <asp:TextBox class="form-control text-bg-secondary" ID="txtsn3" runat="server" placeholder="Name"></asp:TextBox>
               
                                  </div>
      
                             </div>
                                    <div class="col-md-6">
                                        <label id="lblsn4" runat="server">Student Name 4(ان وجد)</label>
                                               <div class="form-group">
             
                                              <asp:TextBox class="form-control text-bg-secondary" ID="txtsn4" runat="server" placeholder="Name" ></asp:TextBox>
            
                                                 </div>                              
                                       </div>
 

                                   </div>   


                      <div class="row">
                        <div class="col-md-12">
                      
                          
                          <label id="lblGY" runat="server">Graduation Year</label>
                           <div class="form-group">
                               
                                    <asp:TextBox class="form-control text-bg-secondary" ID="txtGY" runat="server" placeholder="Year" ></asp:TextBox>
                                
                           </div>
                       
                        </div>
                       

                 </div> 
                    <div class="row">
                     <div class="col-md-12">
                         <label id="lblpd" runat="server">Project Description</label>
                             <div class="form-group">
       
                                 <asp:TextBox class="form-control text-bg-secondary" ID="txtpd" runat="server" placeholder="Short Decription" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                         <br />
                             </div>                              
                      </div>
                      </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:FileUpload CssClass="btn btn-secondary " ID="FileUpload1" runat="server" />
                        </div>
                    </div>
                  

                          <br />
                           <div class="form-group">
                               
                                   <div class="d-grid gap-2">
                                     
                                    <asp:Button class="btn btn-success btn-lg" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                                      
                              
                           </div>
                               <br />
                          
                               
                      </div>
                </div>
            </div>
        
                </div>
             <br /><br />
            <a id="hp" href="HomePage.aspx">Back To Home</a>
            <br /><br /><br /><br />
    </div>
</div>
</asp:Content>
