<%@ Page Title="Elegir Premio" Language="VB" MasterPageFile="~/PromoMaster.master" AutoEventWireup="true" CodeBehind="EleccionPremio.aspx.vb" Inherits="TPWebProgramacion3.EleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Elige tu premio!</h1>
    <br />
    
    <div class="container text-center">
        <div class="row">
            <div class="col">
                <div class="card" style="width: 18rem;">
                    
                    <div class="carousel slide" id="carouselMouse">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://tiva.com.ar/wp-content/uploads/2024/06/1.png" class="card-img-top d-block w-100" alt="Mouse">
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.soscomputacion.com.ar/30334/mouse-gamer-con-cable-kosmo-mo-335-retroiluminado-rgb.jpg" class="card-img-top d-block w-100" alt="Mouse1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.soscomputacion.com.ar/30335-thickbox_default/mouse-gamer-con-cable-kosmo-mo-335-retroiluminado-rgb.jpg" class="card-img-top d-block w-100" alt="Mouse2">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselMouse" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselMouse" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                    <br />
                    
                    <div class="card-body">
                        <h5 class="card-title">Mouse Gamer</h5>
                        <p class="card-text">Mouse Gamer Kosmo-mo335 Negro 1600 Dpi, con luces intermitentes y vibracion interna.</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">

                    <div id="carouselMousePad" class="carousel slide">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://http2.mlstatic.com/D_NQ_NP_672702-MLA91931033751_092025-O.webp" class="card-img-top d-block w-100" alt="MousePad">
                            </div>
                            <div class="carousel-item">
                                <img src="https://http2.mlstatic.com/D_NQ_NP_2X_790542-MLA91532641066_092025-F.webp" class="card-img-top d-block w-100" alt="MousePad1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://http2.mlstatic.com/D_NQ_NP_730023-MLA46770137457_072021-O.webp" class="card-img-top d-block w-100" alt="MousePad2">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselMousePad" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselMousePad" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                    <br />

                    <div class="card-body">
                        <h5 class="card-title">Mouse Pad Gamer</h5>
                        <p class="card-text">Mouse Pad Genius G-wmp 100 Tela 23x25cm Gamer y Oficina, con fijacion antideslizante.</p>
                        <a href="Formulario.aspx" class="btn btn-primary">Quiero este!</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">

                    <div id="carouselDescuento" class="carousel slide">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://dossierweb.com.ar/wp-content/uploads/2017/07/50_descuento1.gif" class="card-img-top d-block w-100" alt="Descuento">
                            </div>
                            <div class="carousel-item">
                                <img src="https://images.fravega.com/f300/4337e6ea7982f605c5a057022ceb1892.jpg.webp" class="card-img-top d-block w-100" alt="Descuento1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://images.fravega.com/f300/1b74205c95379a3e5b539f4f50c7f3a9.jpg.webp" class="card-img-top d-block w-100" alt="Descuento2">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselDescuento" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselDescuento" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>

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

                    <div id="carouselMaxi" class="carousel slide">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://maxiprograma.com/assets/imgs/maxi-transparente.png" class="card-img-top d-block w-100" alt="MaxiPrograma">
                            </div>
                            <div class="carousel-item">
                                <img src="https://maxiprograma.com/Archivos/Img-Curso/curso-img-4.jpg" class="card-img-top d-block w-100" alt="MaxiPrograma1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://maxiprograma.com/Archivos/Img-Curso/curso-img-3.jpg" class="card-img-top d-block w-100" alt="MaxiPrograma2">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselMaxi" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselMaxi" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                    
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