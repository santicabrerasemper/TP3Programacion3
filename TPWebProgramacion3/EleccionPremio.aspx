<%@ Page Title="Elegir Premio" Language="VB" MasterPageFile="~/PromoMaster.master" AutoEventWireup="true" CodeBehind="EleccionPremio.aspx.vb" Inherits="TPWebProgramacion3.EleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Elige tu premio!</h1>
    <br />
    
    <div class="container text-center">
        <div class="row">
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="https://http2.mlstatic.com/D_NQ_NP_807278-MLA92785118520_092025-O.webp" class="card-img-top" alt="Mouse"/>
                    <div class="card-body">
                        <h5 class="card-title">Mouse Gamer</h5>
                        <p class="card-text">Mouse Gamer Kosmo-mo335 Negro 1600 Dpi, con luces intermitentes y vibracion interna.</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="https://http2.mlstatic.com/D_NQ_NP_672702-MLA91931033751_092025-O.webp" class="card-img-top" alt="MousePad"/>
                    <div class="card-body">
                        <h5 class="card-title">Mouse Pad Gamer</h5>
                        <p class="card-text">Mouse Pad Genius G-wmp 100 Tela 23x25cm Gamer y Oficina, con fijacion antideslizante.</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="https://dossierweb.com.ar/wp-content/uploads/2017/07/50_descuento1.gif" class="card-img-top" alt="Descuento"/>
                    <br />
                    <div class="card-body">
                        <h5 class="card-title">50% OFF</h5>
                        <p class="card-text">50% de descuento en tu proxima compra para que te lleves lo que tanto queres!</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="https://maxiprograma.com/assets/imgs/maxi-transparente.png" class="card-img-top" alt="MaxiPrograma"/>
                    <br />
                    <div class="card-body">
                        <h5 class="card-title">Curso MaxiPrograma</h5>
                        <p class="card-text">100% de descuento en cualquier curso de MaxiPrograma que desees realizar.</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>