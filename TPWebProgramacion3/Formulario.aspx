<%@ Page Title="Formulario" Language="VB" MasterPageFile="~/PromoMaster.master" AutoEventWireup="true" CodeBehind="Formulario.aspx.vb" Inherits="TPWebProgramacion3.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container py-4">
    <h1 class="display-6 fw-semibold mb-4">Ingresá tus datos</h1>

  
    <form class="needs-validation" novalidate>
    
      <div class="mb-3">
        <label for="dni" class="form-label">DNI</label>
        <input type="text" class="form-control" id="dni" placeholder="99888777" required />
        <div class="invalid-feedback">Ingresá tu DNI.</div>
      </div>

      <div class="row g-3">
       
        <div class="col-md-4">
          <label for="nombre" class="form-label">Nombre</label>
          <input type="text" class="form-control" id="nombre" placeholder="Juanito" required />
          <div class="valid-feedback">Ok</div>
          <div class="invalid-feedback">Ingresá tu nombre.</div>
        </div>

       
        <div class="col-md-4">
          <label for="apellido" class="form-label">Apellido</label>
          <input type="text" class="form-control" id="apellido" placeholder="Argento" required />
          <div class="invalid-feedback">Ingresá tu apellido.</div>
        </div>

       
        <div class="col-md-4">
          <label for="email" class="form-label">Email</label>
          <div class="input-group">
            <span class="input-group-text" id="addon-at">@</span>
            <input type="email" class="form-control" id="email" placeholder="email@email.com"
                   aria-describedby="addon-at" required />
            <div class="invalid-feedback">Email inválido.</div>
          </div>
        </div>
      </div>

      <div class="row g-3 mt-1">
       
        <div class="col-md-6">
          <label for="direccion" class="form-label">Dirección</label>
          <input type="text" class="form-control" id="direccion" placeholder="Mi ciudad" required />
          <div class="invalid-feedback">Falta dirección.</div>
        </div>

       
        <div class="col-md-4">
          <label for="ciudad" class="form-label">Ciudad</label>
          <input type="text" class="form-control" id="ciudad" placeholder="Calle 123" required />
          <div class="invalid-feedback">Ingresá tu ciudad.</div>
        </div>

      
        <div class="col-md-2">
          <label for="cp" class="form-label">CP</label>
          <input type="text" class="form-control" id="cp" placeholder="xxxx" required />
          <div class="invalid-feedback">Ingresá el CP.</div>
        </div>
      </div>

    
      <div class="form-check mt-3">
        <input class="form-check-input" type="checkbox" value="" id="terms" required />
        <label class="form-check-label" for="terms">
          Acepto los términos y condiciones.
        </label>
        <div class="invalid-feedback">Debés aceptar los términos.</div>
      </div>

     
      <div class="mt-3">
        <button type="submit" class="btn btn-primary">Participar!</button>
      </div>
    </form>
  </div>

 
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
