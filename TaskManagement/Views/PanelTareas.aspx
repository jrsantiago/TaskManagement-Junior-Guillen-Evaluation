<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegTareas.aspx.cs" Inherits="TaskManagement.Views.PanelTareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <br />

    <div class="container">
     
        <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">
            <div id="divRegistrar" runat="server">
                <label>Titulo</label>
                <asp:TextBox ID="tbxTitulo" CssClass="form-control" Width="350%" ValidationGroup="GroupRegistro" runat="server" />

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
                <asp:Button Text="Guardar Tarea" ID="btnGuardarTarea" Width="150px" Height="40px" CssClass="btn btn-success" OnClick="btnGuardarTarea_Click" runat="server" />



            </div>
        </article>

        <article class="col-xs-6, col-sm-6, col-md-6, col-lg-6">
           <h2>Tareas - Cambiar Estados</h2>
            <h4 id="h4GridviewTarea" runat="server" >No tiene registros de tareas.!</h4>
            <br />
            <asp:GridView ID="gridviewTareaRe" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="gridviewTareaRe_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TareaId" HeaderText="TareaId" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de vencimiento" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />

                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass=" btn btn-info" HeaderText="" HeaderStyle-Width="70px" SelectImageUrl="~/Imagenes/" ShowSelectButton="True" SelectText="C/Estado">

                        <ControlStyle CssClass="btn btn-info"></ControlStyle>

                        <HeaderStyle Width="70px"></HeaderStyle>
                    </asp:CommandField>


                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </article>









    </div>

</asp:Content>
