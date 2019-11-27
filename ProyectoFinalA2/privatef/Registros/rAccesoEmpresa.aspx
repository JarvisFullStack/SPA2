<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rAccesoEmpresa.aspx.cs" Inherits="ProyectoFinalA2.private.Registros.rAccesoEmpresa" %>
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
								Registro de Accesos
								<asp:Label CssClass="float-right" runat="server" ID="LabelFecha" Text="11/12/2019"></asp:Label>
							</div>
						</div>

						<asp:Panel runat="server">							
							<hr />							
							<asp:GridView ID="GridViewAccesos" runat="server"></asp:GridView>
							<hr />

							<asp:Button Text="Nuevo" ID="NuevoButton" runat="server" class="btn btn-lg btn-secondary text-uppercase" type="submit" />
							<asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-lg btn-success text-uppercase" type="submit" />
							<asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-lg btn-danger text-uppercase" type="submit" />
							<a class="d-block text-center mt-2 small" href="#">Ver Listado</a>
							<hr class="my-4" />

						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>

	<!-- COPIAR HASTA AQUI -->
</asp:Content>
