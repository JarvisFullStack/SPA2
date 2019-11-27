<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalA2.Registros.rUsuarios" %>

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
								Registro de Usuarios
								<asp:Label CssClass="float-right" runat="server" ID="LabelFecha" Text="11/12/2019"></asp:Label>
							</div>
						</div>

						<asp:Panel ID="formRegistro" runat="server">							
							<hr />
							<div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxId" class="form-control" placeholder="ID" autofocus />
									<div class="input-group-append">
										<asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" formnovalidate OnClick="buttonBusqueda_Click" type="button" />
									</div>
								</div>

							</div>

							<div class="form-group">
								<label for="textboxEmail">Correo Electronico</label>
								<asp:TextBox runat="server" type="email" ID="textboxEmail" class="form-control" placeholder="Correo Electronico" required />
							</div>

							<div class="form-group">
								<label for="textboxNombre">Nombres</label>
								<asp:TextBox runat="server" type="text" ID="textboxNombre" class="form-control" placeholder="Nombres" required />
							</div>

							<div class="form-group">
								<label for="textboxApellido">Apellidos</label>
								<asp:TextBox runat="server" type="text" ID="textboxApellido" class="form-control" placeholder="Apellidos" required />
							</div>
							
							<div class="row">
								<div class="col-6">
									<div class="form-group">
										<label for="textboxPassword">Password</label>
										<asp:TextBox runat="server" type="password" ID="textboxPassword" class="form-control" placeholder="Password" required />
									</div>
								</div>
								<div class="col-6">
									<div class="form-group">
										<label for="textboxPasswordConfirm">Confirm Password</label>
										<asp:TextBox runat="server" type="password" ID="textboxPasswordConfirm" class="form-control" placeholder="Password" required />
									</div>
								</div>
							</div>
							<hr />

							<asp:Button formnovalidate Text="Nuevo" ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" class="btn btn-lg btn-secondary text-uppercase" />
							<asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" class="btn btn-lg btn-success text-uppercase" type="submit" />
							<asp:Button formnovalidate ID="EliminarButton" runat="server" OnClick="EliminarButton_Click" Text="Eliminar" class="btn btn-lg btn-danger text-uppercase" />							
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
