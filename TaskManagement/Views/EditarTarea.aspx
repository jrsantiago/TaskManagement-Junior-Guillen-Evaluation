<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarTarea.aspx.cs" Inherits="TaskManagement.Views.EditarTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <br />
        <br />
        <br />


            <div id="divRegistrar" runat="server">
            
                <label>Titulo</label>
                <asp:TextBox ID="tbxTitulo" CssClass="form-control" Width="250px" ValidationGroup="GroupRegistro" runat="server" />

                <br />

                <label>Prioridad</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <label>Fecha de vencimiento</label>
                <br />
                <asp:RadioButton Text="baja" GroupName="prioGroup" Checked="true" Width="70px" Height="20px" ID="radBaja" runat="server" />
                <asp:RadioButton Text="Media" GroupName="prioGroup" Width="70px" Height="20px" ID="RadioMedia" runat="server" />
                <asp:RadioButton Text="Alta" GroupName="prioGroup" Width="70px" Height="20px" ID="RadioAlta" runat="server" />
                <asp:TextBox ID="tbxFecha" runat="server" TextMode="Date" Width="180px" Height="30px" />
                <br />
                <br />

                <label>Detalle</label>
                <br />
                <textarea id="tbxDescripcion" style="width: 300px; height: 100px" cols="20" rows="2" runat="server"></textarea>



                <br />
                <asp:Button Text="Actualizar Tarea" ID="btnActualizar" Width="150px" Height="40px" CssClass="btn btn-success" OnClick="btnActualizar_Click" runat="server" />
              
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              
                <asp:Button Text="Eliminar" ID="btnEliminar" Width="150px" Height="40px" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />


            </div>

    </div>

</asp:Content>
