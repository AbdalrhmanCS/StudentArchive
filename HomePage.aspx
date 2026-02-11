<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="StudentArchive1.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();


        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="container">
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
               <br /><br /> <asp:GridView CssClass="table table-dark" ShowHeader="true" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView> <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br />
                 <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /> <br />
            </div>
        </div>
    </div>
</asp:Content>
