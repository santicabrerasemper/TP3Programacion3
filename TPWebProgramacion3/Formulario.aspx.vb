Imports System.Configuration
Imports System.Text.RegularExpressions
Imports ConexionesBD
Imports Dominio
Imports Negocio

Partial Public Class Formulario
    Inherits System.Web.UI.Page

    Private Function Servicio() As ServicioCliente
        Dim cs = ConfigurationManager.ConnectionStrings("PromoDb").ConnectionString
        Return New ServicioCliente(New ClienteRepository(cs))
    End Function

    ' Regex (mismos que en el .aspx)
    Private ReadOnly RxDni As New Regex("^\d{7,12}$")
    Private ReadOnly RxNombre As New Regex("^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,40}$")
    Private ReadOnly RxApellido As New Regex("^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,40}$")
    Private ReadOnly RxDir As New Regex("^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ0-9°º\.\,#\- ]{5,80}$")
    Private ReadOnly RxCiudad As New Regex("^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,50}$")
    Private ReadOnly RxCp As New Regex("^\d{4,10}$")
    Private ReadOnly RxEmail As New Regex("^(?=.{1,254}$)(?=.{1,64}@)(?!.*\.\.)[A-Za-z0-9!#$%&'*+/=?^_{}|~\-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_{}|~\-]+)*@(?:(?=[A-Za-z0-9\-]{1,63}\.)[A-Za-z0-9](?:[A-Za-z0-9\-]{0,61}[A-Za-z0-9])?\.)+[A-Za-z]{2,24}$")

    Protected Sub txtDni_TextChanged(sender As Object, e As EventArgs)
        litError.Text = ""
        Dim cli = Servicio().BuscarPorDocumento(txtDni.Text.Trim())
        If cli IsNot Nothing Then
            txtNombre.Text = cli.Nombre
            txtApellido.Text = cli.Apellido
            txtEmail.Text = cli.Email
            txtDireccion.Text = cli.Direccion
            txtCiudad.Text = cli.Ciudad
            txtCp.Text = cli.CP.ToString()
        End If
    End Sub

    Protected Sub btnParticipar_Click(sender As Object, e As EventArgs) Handles btnParticipar.Click
        litError.Text = ""
        ' 1) Validadores WebForms del .aspx
        If Not Page.IsValid Then Exit Sub
        ' 2) Defensa extra en servidor (evita “…” u otros bypass)
        If Not CamposValidosServidor() Then Exit Sub

        Dim s = Servicio()
        Dim documento = txtDni.Text.Trim()
        Dim existente = s.BuscarPorDocumento(documento)

        If existente Is Nothing Then
            Dim cpVal As Integer : Integer.TryParse(txtCp.Text.Trim(), cpVal)
            Dim c As New Cliente With {
                .Documento = documento,
                .Nombre = txtNombre.Text.Trim(),
                .Apellido = txtApellido.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .Direccion = txtDireccion.Text.Trim(),
                .Ciudad = txtCiudad.Text.Trim(),
                .CP = cpVal
            }

            Dim id = s.RegistrarNuevo(c)
            If id <= 0 Then
                litError.Text = "<div class='alert alert-danger mt-3'>No pudimos registrar el cliente.</div>"
                Exit Sub
            End If

            Try
                Dim mail = New ServicioEmail()
                Dim html = $"<h2>¡Gracias, {Server.HtmlEncode(c.Nombre)}!</h2><p>Ya estás inscripto a la promo.</p>"
                mail.Enviar(c.Email, "Registro exitoso - TuElectro", html)
            Catch
                ' podés loguear si querés
            End Try
        End If

        Response.Redirect("~/Exito.aspx?nombre=" & Server.UrlEncode(txtNombre.Text.Trim()), False)
    End Sub

    Private Function CamposValidosServidor() As Boolean
        Dim dni = txtDni.Text.Trim()
        Dim nombre = txtNombre.Text.Trim()
        Dim apellido = txtApellido.Text.Trim()
        Dim email = txtEmail.Text.Trim()
        Dim dir = txtDireccion.Text.Trim()
        Dim ciudad = txtCiudad.Text.Trim()
        Dim cp = txtCp.Text.Trim()

        If Not RxDni.IsMatch(dni) Then Return ErrorOut("DNI inválido.")
        If Not RxNombre.IsMatch(nombre) Then Return ErrorOut("Nombre inválido.")
        If Not RxApellido.IsMatch(apellido) Then Return ErrorOut("Apellido inválido.")
        If Not RxDir.IsMatch(dir) Then Return ErrorOut("Dirección inválida.")
        If Not RxCiudad.IsMatch(ciudad) Then Return ErrorOut("Ciudad inválida.")
        If Not RxCp.IsMatch(cp) Then Return ErrorOut("CP inválido.")
        If Not EsEmailValido(email) OrElse Not RxEmail.IsMatch(email) Then Return ErrorOut("Email inválido.")

        Return True
    End Function

    Private Function ErrorOut(msg As String) As Boolean
        litError.Text = $"<div class='alert alert-danger mt-3'>{Server.HtmlEncode(msg)}</div>"
        Return False
    End Function

    Private Function EsEmailValido(correo As String) As Boolean
        If String.IsNullOrWhiteSpace(correo) Then Return False
        correo = correo.Trim()
        If correo.EndsWith("."c) Then Return False
        If correo.Length > 254 Then Return False

        Dim partes = correo.Split("@"c)
        If partes.Length <> 2 Then Return False
        If partes(0).Length = 0 OrElse partes(0).Length > 64 Then Return False
        If Not partes(1).Contains("."c) Then Return False

        Try
            Dim addr = New System.Net.Mail.MailAddress(correo)
            If addr.Address <> correo Then Return False
        Catch
            Return False
        End Try

        If correo.Contains("..") Then Return False
        For Each label In partes(1).Split("."c)
            If label.Length = 0 Then Return False
            If label.StartsWith("-") OrElse label.EndsWith("-") Then Return False
            If label.Length > 63 Then Return False
        Next
        Return True
    End Function
End Class
