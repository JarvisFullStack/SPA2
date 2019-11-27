<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rCobros.aspx.cs" Inherits="ProyectoFinalA2.privatef.Registros.rCobros" %>

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
								Registro de Cobros
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
								<label for="dropdownlistClientes">Cliente</label>
								<asp:DropDownList ID="dropdownlistClientes" OnSelectedIndexChanged="dropdownlistClientes_SelectedIndexChanged" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
							</div>

							<div class="form-group">
								<label for="dropdownlistPrestamos">Prestamos</label>
								<asp:DropDownList ID="dropdownlistPrestamos" OnSelectedIndexChanged="dropdownlistPrestamos_SelectedIndexChanged" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
							</div>

							<div class="form-group">
								<label for="buttonverCobrosAnteriores">Cliente</label>
								<a ID="buttonverCobrosAnteriores" data-toggle="modal" data-target="#exampleModalCentered" formnovalidate class="btn btn-primary btn-block">Ver Cobros</a>
							</div>

							<!-- Modal -->
							<div class="modal" id="exampleModalCentered" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenteredLabel" aria-hidden="true">
								<div class="modal-dialog modal-dialog-centered" role="document">
									<div class="modal-content">
										<div class="modal-header">
											<h5 class="modal-title" id="exampleModalCenteredLabel">Cobros Realizados</h5>
											<button type="button" class="close" data-dismiss="modal" aria-label="Close">
												<span aria-hidden="true">&times;</span>
											</button>
										</div>
										<div class="modal-body">
											<div class="collapse" id="collapseExample">
												<div class="card card-body">
													<asp:GridView ID="GridViewCobrosRealizados" runat="server"></asp:GridView>
												</div>
											</div>
										</div>
										<div class="modal-footer">
											<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
										</div>
									</div>
								</div>
							</div>

							<div class="form-group">
								<label for="textboxMontoCobro">Monto Cobrado</label>
								<asp:TextBox runat="server" type="number" value="0" ReadOnly="true" ID="textboxMontoCobro" class="form-control" placeholder="% Interes" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxCobroCapital">Cobro Capital</label>
								<asp:TextBox runat="server" type="number" value="0" ReadOnly="true" ID="textboxCobroCapital" class="form-control" placeholder="% Interes" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxInteres">Cobro Interes</label>
								<asp:TextBox runat="server" type="number" value="0" ReadOnly="true" ID="textboxInteres" class="form-control" placeholder="% Interes" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxMora">Cobro Mora</label>
								<asp:TextBox runat="server" type="number" value="0" ReadOnly="true" ID="textboxMora" class="form-control" placeholder="% Mora" required autofocus />
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
