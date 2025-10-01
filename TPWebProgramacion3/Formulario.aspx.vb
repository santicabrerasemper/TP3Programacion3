Imports System.Configuration
Imports ConexionesBD
Imports Dominio
Imports Negocio
Imports WebGrease.Activities


Partial Public Class Formulario
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Asegura Bootstrap validation en el <form runat="server"> de la master
            Dim cls = (Page.Form.Attributes("class") & " needs-validation").Trim()
            Page.Form.Attributes("class") = String.Join(" ",
                cls.Split({" "c}, StringSplitOptions.RemoveEmptyEntries).Distinct())
            Page.Form.Attributes("novalidate") = "novalidate"
        End Sub

        Private Function Servicio() As ServicioCliente
            Dim cs = ConfigurationManager.ConnectionStrings("PromoDb").ConnectionString
            Return New ServicioCliente(New ClienteRepository(cs))
        End Function

        Protected Sub btnBuscarDni_Click(sender As Object, e As EventArgs) Handles btnBuscarDni.Click
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
            If Not Page.IsValid Then Exit Sub

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
            End If

            Response.Redirect("~/Exito.aspx?nombre=" & Server.UrlEncode(txtNombre.Text.Trim()), False)
        End Sub

    End Class

