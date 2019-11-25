<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="ProyectoFinalA2.Mantenimientos.RegistroUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .modal-lg {
        max-width: 80% !important;
    }
</style>
<script>
   
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="panel panel-primary">
<div class="panel-heading">Registro de Categorias</div>


<div class="panel-body">
<div class="form-horizontal col-md-12" role="form">
<%--UserId--%>
<div class="form-group">
<div class="row">
<label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
<div class="col-md-1 col-sm-2 col-xs-4">
<asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
</div>
<div class="col-md-1 col-sm-2 col-xs-4">
<asp:LinkButton ID="BusquedaButton" CssClass="btn btn-info btn-block btn-md" data-toggle="modal" data-target="#myModal" CausesValidation="False" runat="server" ClientIDMode="Static" OnClientClick="return  false" Text="<i class='fa fa-search'></i>" />
</div>
</div>
</div>
<%--
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  <i class="fa fa-search"></i>
</button> --%>
<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
<div class="modal-dialog modal-lg" role="document">
<div class="modal-content">
<div class="modal-header">
<h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
<button type="button" class="close" data-dismiss="modal" aria-label="Close">
<span aria-hidden="true">&times;</span>
</button>
</div>
<div class="modal-body">
<TWebControl:ConsultaUsuariosUserControl ID="Header" runat="server" />
</div>
<%--  <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
</div>
</div>
</div>

</div>
<%--Names--%>
<div class="form-group">
<label for="NamesTextBox" class="col-md-3 control-label input-sm">Nombres</label>
<div class="col-md-8">
<asp:TextBox ID="NombresTextBox" runat="server"
Class="form-control input-sm"></asp:TextBox>
<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RFVNames" runat="server" MaxLength="200"
ControlToValidate="NamesTextBox"
ErrorMessage="Campo Nombres obligatorio" ForeColor="Red"
Display="Dynamic" SetFocusOnError="True"
ToolTip="Campo Nombres obligatorio">Por favor llenar el campo Nombres
</asp:RequiredFieldValidator>
</div>
</div>
<%--Apellidos--%>
<div class="form-group">
<label for="ApellidosTextBox" class="col-md-3 control-label input-sm">Apellidos</label>
<div class="col-md-8">
<asp:TextBox ID="ApellidosTextBox" runat="server"
Class="form-control input-sm"></asp:TextBox>
<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RequiredFieldValidator1" runat="server" MaxLength="200"
ControlToValidate="ApellidosTextBox"
ErrorMessage="Campo Apellidos obligatorio" ForeColor="Red"
Display="Dynamic" SetFocusOnError="True"
ToolTip="Campo Apellidos obligatorio">Por favor llenar el campo Apellidos
</asp:RequiredFieldValidator>
</div>
</div>
<%--UserName--%>
<div class="form-group">
<label for="UsernameTextBox" class="col-md-3 control-label input-sm">Correo del Usuario</label>
<div class="col-md-8">
<asp:TextBox ID="CorreoTextBox" runat="server"
Class="form-control input-sm"></asp:TextBox>
<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RequiredFieldValidator2" runat="server" MaxLength="200"
ControlToValidate="CorreoTextBox"
ErrorMessage="Campo Username obligatorio" ForeColor="Red"
Display="Dynamic" SetFocusOnError="True"
ToolTip="Campo Correo obligatorio">Por favor llenar el campo correo
</asp:RequiredFieldValidator>
</div>
</div>
<%--Pass--%>
<div class="form-group">
<asp:Label ID="PasswordLabel"
Text="Password"
AssociatedControlID="PasswordTextBox"
runat="server" Visible="true" CssClass="col-md-3 control-label input-sm">
</asp:Label>
<div class="col-md-8">
<asp:TextBox TextMode="Password" ID="PasswordTextBox" runat="server"
Class="form-control input-sm" Visible="true"></asp:TextBox>
<asp:RequiredFieldValidator ValidationGroup="grupoValidar" ID="RequiredFieldValidator3" runat="server" MaxLength="200"
ControlToValidate="PasswordTextBox"
ErrorMessage="Campo Password obligatorio" ForeColor="Red"
Display="Dynamic" SetFocusOnError="True"
ToolTip="Campo Password obligatorio" Enabled="true">Por favor llenar el campo Password
</asp:RequiredFieldValidator>
</div>

</div>
<%--Tipo--%>
<div class="form-group">
<label for="TipoUsuarioDropDownList" class="col-md-3 control-label input-sm">Tipo de Usuario</label>
<div class="col-md-8">
<asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" Class="form-control input-sm">
<asp:ListItem Selected="True">Normal</asp:ListItem>
<asp:ListItem>Administrador</asp:ListItem>
</asp:DropDownList>
</div>
</div>
</div>

<div class="col-md-12">
<asp:ValidationSummary runat="server" ID="SumaryValidation"
ForeColor="red"
DisplayMode="BulletList"
ShowSummary="true"
EnableClientScript="True"
Font-Bold="False"
CssClass=" alert alert-danger" />
</div>

<asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
</div>

<div class="panel-footer">
<div class="text-center">
<div class="form-group" style="display: inline-block">

<asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
<asp:Button Text="Guardar" ValidationGroup="grupoValidar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
<asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

</div>
</div>

</div>
</div>

</asp:Content>
