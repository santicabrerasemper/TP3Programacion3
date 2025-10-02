<%@ Page Title="Voucher" Language="VB" MasterPageFile="~/PromoMaster.master" AutoEventWireup="true" CodeBehind="Voucher.aspx.vb" Inherits="TPWebProgramacion3.Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Voucher</h2>
    <p>Ingrese su código de voucher:</p>
    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
    <asp:Button ID="btnValidar" Text="Validar" runat="server" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" runat="server"></asp:Label>
</asp:Content>