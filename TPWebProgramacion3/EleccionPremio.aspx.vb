Imports Negocio
Imports Dominio

Partial Public Class EleccionPremio
    Inherits System.Web.UI.Page

    Protected RepeaterArticulos As Global.System.Web.UI.WebControls.Repeater

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim negocio As New ArticuloNegocio()
            Dim articulos As List(Of Articulo) = negocio.ObtenerArticulos()

            AddHandler RepeaterArticulos.ItemDataBound, AddressOf RepeaterArticulos_ItemDataBound

            RepeaterArticulos.DataSource = articulos
            RepeaterArticulos.DataBind()
        End If
    End Sub

    Protected Sub RepeaterArticulos_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim art As Dominio.Articulo = CType(e.Item.DataItem, Dominio.Articulo)
            Dim repImagenes As Repeater = CType(e.Item.FindControl("RepeaterImagenes"), Repeater)
            repImagenes.DataSource = art.Imagenes
            repImagenes.DataBind()
        End If
    End Sub
End Class