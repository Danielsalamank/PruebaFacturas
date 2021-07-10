<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FacturacionWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <div>  
        <h2>Bind GridView From JSON Object (Converted In to Dynamic Object [dynamic keyword])</h2>  
        <asp:GridView ID="grdJSON2Grid" runat="server" BackColor="White" BorderColor="#3399ff"  
            BorderStyle="Dotted" BorderWidth="1px" CellPadding="3" GridLines="Both"></asp:GridView>  
  
        <br />  
        <br />  
         <h2>Bind GridView From JSON Object (Converted In to DataTable Object [DataTable])</h2>  
        <asp:GridView ID="grdJSON2Grid2" runat="server" BackColor="White" BorderColor="#3399ff"  
            BorderStyle="Dotted" BorderWidth="1px" CellPadding="3" GridLines="Both"></asp:GridView>  
    </div>  


</asp:Content>
