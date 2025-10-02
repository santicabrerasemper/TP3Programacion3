Imports Dominio
Imports ConexionBD

Public Class Voucher
    Inherits System.Web.UI.Page

    ' Cadena de conexión
    Private _cs As String = "Data Source=.\SQLEXPRESS;Initial Catalog=PROMOS_DB;Integrated Security=True"
    Private _repo As New VoucherRepository(_cs)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' No hace nada especial al cargar la página
    End Sub

    Protected Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        Dim codigo As String = txtCodigo.Text.Trim()

        If String.IsNullOrEmpty(codigo) Then
            lblMensaje.Text = "Ingrese un código de voucher."
            Return
        End If

        ' Obtener voucher
        Dim miVoucher As Dominio.Voucher = _repo.GetByCodigo(codigo)

        If miVoucher Is Nothing Then
            lblMensaje.Text = "El código ingresado no existe."
        ElseIf Not _repo.EstaDisponible(codigo) Then
            lblMensaje.Text = "El voucher ya fue utilizado."
        Else
            ' Voucher válido, redirigimos a la página de elección de premio
            Response.Redirect("EleccionPremio.aspx?codigo=" & codigo)
        End If
    End Sub
End Class