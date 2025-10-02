<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PromoMaster.master" CodeBehind="Exito.aspx.vb" Inherits="TPWebProgramacion3.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container py-4">
    <div class="alert alert-success shadow-sm" role="alert">
      <h4 class="alert-heading">¡Listo, ya estás participando! 🎉</h4>
      <p>
        <strong><asp:Literal ID="litNombre" runat="server" /></strong>
        registramos tu participación correctamente.
      </p>
    </div>

    <a href="Home.aspx" class="btn btn-outline-primary">Volver al inicio</a>
  </div>
</asp:Content>
