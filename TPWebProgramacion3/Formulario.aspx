<%@ Page Title="Formulario" Language="VB" MasterPageFile="~/PromoMaster.master"
    AutoEventWireup="true" CodeBehind="Formulario.aspx.vb"
    Inherits="TPWebProgramacion3.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container py-4">
    <h1 class="display-6 fw-semibold mb-4">Ingresá tus datos</h1>

    <!-- Mensajes -->
    <asp:Literal ID="litError" runat="server" EnableViewState="false" />

    <!-- DNI -->
    <div class="row g-3">
      <div class="col-lg-6 col-md-8">
        <label for="txtDni" class="form-label">DNI</label>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" MaxLength="12" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDni"
            CssClass="text-danger small" ErrorMessage="Ingresá tu DNI" Display="Dynamic" />
      </div>
    </div>

    <!-- Nombre / Apellido / Email -->
    <div class="row g-3 mt-1">
      <div class="col-md-4">
        <label for="txtNombre" class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
            CssClass="text-danger small" ErrorMessage="Ingresá tu nombre" Display="Dynamic" />
      </div>

      <div class="col-md-4">
        <label for="txtApellido" class="form-label">Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido"
            CssClass="text-danger small" ErrorMessage="Ingresá tu apellido" Display="Dynamic" />
      </div>

      <div class="col-md-4">
        <label for="txtEmail" class="form-label">Email</label>
        <div class="input-group">
          <span class="input-group-text" id="addon-at">@</span>
          <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
            CssClass="text-danger small" ErrorMessage="Ingresá tu email" Display="Dynamic" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
            CssClass="text-danger small" Display="Dynamic"
            ErrorMessage="Formato de email inválido"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
      </div>
    </div>

    <!-- Dirección / Ciudad / CP -->
    <div class="row g-3 mt-1">
      <div class="col-md-6">
        <label for="txtDireccion" class="form-label">Dirección</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion"
            CssClass="text-danger small" ErrorMessage="Ingresá la dirección" Display="Dynamic" />
      </div>

      <div class="col-md-4">
        <label for="txtCiudad" class="form-label">Ciudad</label>
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCiudad"
            CssClass="text-danger small" ErrorMessage="Ingresá la ciudad" Display="Dynamic" />
      </div>

      <div class="col-md-2">
        <label for="txtCp" class="form-label">CP</label>
        <asp:TextBox ID="txtCp" runat="server" CssClass="form-control" MaxLength="10" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCp"
            CssClass="text-danger small" ErrorMessage="Ingresá el CP" Display="Dynamic" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCp"
            CssClass="text-danger small" Display="Dynamic"
            ErrorMessage="Sólo números en el CP"
            ValidationExpression="^\d{1,10}$" />
      </div>
    </div>

    <!-- Botones -->
    <div class="mt-3 d-flex gap-2">
      <asp:Button ID="btnBuscarDni" runat="server" CssClass="btn btn-outline-secondary"
                  Text="Buscar DNI" />
      <asp:Button ID="btnParticipar" runat="server" CssClass="btn btn-primary"
                  Text="¡Participar!" />
    </div>
  </div>

  <!-- Script Bootstrap validation -->
  <script>
      (function () {
          'use strict';
          var forms = document.querySelectorAll('.needs-validation');
          Array.prototype.slice.call(forms).forEach(function (form) {
              form.addEventListener('submit', function (event) {
                  if (!form.checkValidity()) {
                      event.preventDefault();
                      event.stopPropagation();
                  }
                  form.classList.add('was-validated');
              }, false);
          });
      })();
  </script>
</asp:Content>
