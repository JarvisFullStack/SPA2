<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rEmpresas.aspx.cs" Inherits="ProyectoFinalA2.Registros.rEmpresas" %>
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
								Registro de Empresas
								<asp:Label CssClass="float-right" runat="server" ID="LabelFecha" Text="11/12/2019"></asp:Label>
							</div>
						</div>

						<asp:Panel ID="formRegistro" runat="server">							
							<hr />
							<div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxId" class="form-control" placeholder="ID" autofocus />
									<div class="input-group-append">
										<asp:Button ID="buttonBusqueda" Text="Buscar" runat="server" CausesValidation="false" formnovalidate OnClick="buttonBusqueda_Click" CssClass="btn btn-primary" type="button" />
									</div>
								</div>

							</div>

							<div class="form-group">
								<label for="textboxNombre">Nombre Comercial</label>
								<asp:TextBox runat="server" type="text" ID="textboxNombre" MaxLength="60" class="form-control" placeholder="Nombre Comercial" required />
							</div>

							<div class="form-group">
								<label for="textboxEslogan">Email address</label>
								<asp:TextBox TextMode="MultiLine" Rows="5" runat="server" type="text" MaxLength="100" ID="textboxEslogan" class="form-control" placeholder="Eslogan" required />
							</div>

							<div class="form-group">
								<label for="textboxInteres">% Interes</label>
								<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxInteres" class="form-control" placeholder="% Interes" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxMora">% Mora</label>
								<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxMora" class="form-control" placeholder="% Mora" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxSemanasAtraso">Semanas de Atraso</label>
								<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxSemanasAtraso" class="form-control" placeholder="Semanas de Atraso" required autofocus />
								<small>Semana desde la que se empezara a cobrar mora a los prestamos.</small>
							</div>
							<hr />

							<asp:Button Text="Nuevo" formnovalidate ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" class="btn btn-lg btn-secondary text-uppercase" type="submit" />
							<asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" class="btn btn-lg btn-success text-uppercase" type="submit" />
							<asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" class="btn btn-lg btn-danger text-uppercase" type="submit" />
							
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
