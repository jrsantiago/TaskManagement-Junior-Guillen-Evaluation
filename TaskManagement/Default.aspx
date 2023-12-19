<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">
            <h1 style="color: #161d6d">Iniciar Sesion</h1>

            <label>Correo</label>

            <asp:TextBox ID="tbxCorreo" CssClass="form-control" Width="300px" placeholder="Digite su correo" runat="server" TextMode="Email" />

            <label>Contraseña</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ForeColor="Red" Font-Size="Medium" runat="server" ErrorMessage="Campo contrasena requerido" ControlToValidate="tbxContrasena">*</asp:RequiredFieldValidator>

            <asp:TextBox ID="tbxContrasena" CssClass="form-control" Width="250px" placeholder="Digite su contraseña" runat="server" ValidationGroup="GroupInicio" TextMode="Password" />

            <br />
            <asp:ValidationSummary Font-Bold="true" ForeColor="Red" ValidationGroup="GroupInicio" ID="ValidationSummary2" runat="server" />
            <asp:Button CssClass="btn btn-primary" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" ValidationGroup="GroupInicio" />
        </article>

        <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">
            <h1 style="color: #161d6d">Registrar Usuario</h1>

            <label>Nombre</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Bold="true" ForeColor="Red" Font-Size="Medium" runat="server" ErrorMessage="Campo nombre requerido" 
              ValidationGroup="GroupRegistro"  ControlToValidate="tbxNombre">*</asp:RequiredFieldValidator>
            <asp:TextBox ID="tbxNombre" CssClass="form-control" Width="250px" placeholder="Nombre Completo" ValidationGroup="GroupRegistro" runat="server" />

            <label>Correo</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="GroupRegistro" Font-Bold="true" ForeColor="Red" Font-Size="Medium" runat="server" ErrorMessage="Campo Correo requerido" ControlToValidate="tbxCorreoRegistro">*</asp:RequiredFieldValidator>
            <asp:TextBox ID="tbxCorreoRegistro" CssClass="form-control" Width="250px" placeholder="Digite su contraseña" ValidationGroup="GroupRegistro" runat="server" TextMode="Email" />
           
            <div style="margin-left: -15px">
                <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">
                    <label>Contraseña</label>
                    <asp:TextBox ID="tbxContrasenaRegistro" CssClass="form-control" Width="250px" placeholder="Digite su contraseña" ValidationGroup="GroupRegistro" runat="server" TextMode="Password" />
                </article>

                <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">

                    <label>Repita su Contraseña</label>
                    <asp:CompareValidator ID="CompareValidator1" ValidationGroup="GroupRegistro" ControlToValidate="tbxContrasenaRegistro"
                        ControlToCompare="tbxReContrasenaregistro" Font-Bold="true" ForeColor="Red" Font-Size="Medium" runat="server"
                        ErrorMessage="Las contraseñas deben ser iguales.!">*</asp:CompareValidator>

                    <asp:TextBox ID="tbxReContrasenaregistro" CssClass="form-control" Width="250px" placeholder="Repita la contraseña" ValidationGroup="GroupRegistro" runat="server" TextMode="Password" />

                </article>
            </div>
    <br />
    <asp:ValidationSummary Font-Bold="true" ForeColor="Red" ValidationGroup="GroupRegistro" ID="ValidationSummary1" runat="server" />
    <asp:Button ID="btnGuardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Registrar usuario" ValidationGroup="GroupRegistro" runat="server" />
    </article>

    </div>

</asp:Content>
