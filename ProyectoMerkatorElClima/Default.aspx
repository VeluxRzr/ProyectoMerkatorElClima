<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoMerkatorElClima._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Consultar Clima Actual</h2>
    <asp:TextBox ID="txtCiudad" runat="server" Placeholder="Ingrese una ciudad"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <br /><br />
    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label><br />
    <asp:Image ID="imgIcono" runat="server" Visible="false" />
</asp:Content>
