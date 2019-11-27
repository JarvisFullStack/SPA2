<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="ProyectoFinalA2.privatef.Registros.rPrestamos" %>

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
								Registro de Prestamos
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
								<asp:DropDownList ID="dropdownlistClientes" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
							</div>

							<div class="form-group">
								<label for="textboxMontoPrestado">Monto a Prestar</label>
								<asp:TextBox runat="server" type="number" ReadOnly="false" ID="textboxMontoPrestado" class="form-control" placeholder="Capital a Prestar" required autofocus />
							</div>

							<div class="form-group">
								<label for="textboxInteres">% Interes</label>
								<asp:TextBox runat="server" type="number" value="30" ID="textboxInteres" class="form-control" placeholder="% Interes" required />
							</div>

							<div class="form-group">
								<label for="textboxMora">% Mora</label>
								<asp:TextBox runat="server" type="number" value="0" ReadOnly="true" ID="textboxMora" class="form-control" placeholder="% Mora" required />
							</div>

							<div class="form-group">
								<label for="textboxSemanasAtraso">Semanas de Atraso</label>
								<asp:TextBox runat="server" value="10" type="number" ReadOnly="false" ID="textboxSemanasAtraso" class="form-control" placeholder="Semanas de Atraso" required autofocus />
								<small>Semana desde la que se empezara a cobrar mora a los prestamos.</small>
							</div>

							<div class="form-group">
								<label for="textboxBalance">Balance</label>
								<asp:TextBox runat="server" value="0" ReadOnly="true" type="number" ID="textboxBalance" class="form-control" placeholder="Balance" required />
							</div>

							<hr />
							<h5>Distribucion de Cuotas</h5>
							<asp:Button runat="server" ID="buttonCalcularCuotas" Text="Calcular Cuotas" OnClick="buttonCalcularCuotas_Click" CssClass="btn btn-primary btn-block" />

							<hr />
							<button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
								Mostrar Distribucion
							</button>

							<div class="collapse" id="collapseExample">
								<div class="card card-body">
									<asp:GridView ID="GridViewDistribucionCuotas" runat="server"></asp:GridView>
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
