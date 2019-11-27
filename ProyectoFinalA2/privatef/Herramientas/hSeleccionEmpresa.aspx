<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="hSeleccionEmpresa.aspx.cs" Inherits="ProyectoFinalA2.privatef.Herramientas.hSeleccionEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<!-- COPIAR DESDE AQUI -->
	<div class="container">
		<div class="row">
			<div class="col-lg-10 col-xl-9 mx-auto">
				<div class="card  flex-row my-5">
					<div class="card-img-left d-none d-md-flex">
					</div>
					<div class="card-body">
						<div class="card-header text-white h5" style="background-color: rgb(50, 116, 211)">
							<div class="card-title text-center text-uppercase">
								Seleccion de Empresa
								<asp:Label CssClass="float-right" runat="server" ID="LabelFecha" Text="11/12/2019"></asp:Label>
							</div>
						</div>

						<asp:Panel runat="server">
							<hr />
							<div class="form-group">
								<label for="textboxPasswordConfirm">Correo Electronico</label>
								<asp:DropDownList ID="dropdownlistEmpresas" runat="server"></asp:DropDownList>
								<asp:Button ID="buttonSeleccionrEmpresa" runat="server" Text="INGRESAR" CssClass="btn btn-primary btn-block" OnClick="buttonSeleccionrEmpresa_Click"/>
							</div>

							
							<hr class="my-4" />
							<a class="d-block text-center mt-2 small" href="#">Ver Listado</a>
						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>

	<!-- COPIAR HASTA AQUI -->
</asp:Content>
