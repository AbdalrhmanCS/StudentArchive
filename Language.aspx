<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="StudentArchive1.WebForm2" %>
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
            <div class="col">
                <div class="card" style="
    background-color:#191b1c;
    padding: 25px;
    border-radius: 15px;
    color: white;
">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <br /> <br /> <br /> <br /><br /> <br /> <br /> <br /> <br /><center><div class="row">
                                    <div class="col-md-6">
                                          <div class="d-grid gap-2">
 
                                   <asp:Button Class="btn btn-outline-light btn-lg"  ID="Button3" runat="server" Text="English" OnClick="Button3_Click"  />
                                   </div> </div>
                                    <div class="col-md-6">
                                               <div class="d-grid gap-2">
 
                                        <asp:Button Class=" btn btn-outline-light btn-lg"  ID="Button1" runat="server" Text="العربية" OnClick="Button1_Click"  />
                                   </div> </div>
                                </div> </center><br /> <br /> <br /> <br /> <br /> <br /> <br /><br /><br />
                            </div></div></div></div></div></div></div>
</asp:Content>
