<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoMerkatorElClima._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg p-4">
                    <h2 class="text-center mb-4">Consultar Clima Actual</h2>

                    <!-- Input de ciudad -->
                    <div class="mb-3">
                        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" Placeholder="Ingrese una ciudad" />
                    </div>

                    <!-- Botón de búsqueda -->
                    <div class="d-grid mb-3">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>

                    <!-- Resultados -->
                    <div class="text-center">
                        <asp:Label ID="lblResultado" runat="server" CssClass="form-text text-dark" />
                        <br />
                        <asp:Image ID="imgIcono" runat="server" Visible="false" CssClass="mt-3" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
