<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsTarea.aspx.cs" Inherits="TaskManagement.Views.ConsTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script src="../js/jquery-1.10.2.js"></script>
    <link href="../js/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />
    <script src="../js/jquery-ui-1.10.4.custom.min.js"></script>


    <script type="text/javascript" lang="javascript">


        $(function () {
            var Id = $("UsuarioId").val();
            $('#<%= tbxBuscarTarea.ClientID %>').autocomplete({
                source: function (request, response) {

                    $.ajax({ //EN EL VIDEO NO LO DICE PERO HAY QUE PONERLE EL  '/' AL clienteservices.asmx SI NO COGE LA REFERENCIA
                        url: "/AutoCompleteServices.asmx/ObtenerDatosTarea",
                        data: "{ 'Titulo': '" + request.term + "'}",
                        //data: "{ 'UsuarioId': '" + Id + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]


                                }
                            }))
                        },
                        error: function (response) {
                            //alert('hubo un problema en el proceso de request')

                            swal('', 'BUSQUEDA NO ENCONTRADA O REGISTRE UNA TAREA NUEVA', 'warning')
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });

                }, select: function (event, i) {
                    $(this).val(i.item.value)
                    $('#<%= tbxTareaId.ClientID %>').val(i.item.val);
                 <%--   $('#<%= tbxNombreCliente.ClientID %>').val(i.item.label);--%>



                },


            });
        });

    </script>

    <div class="container">
        <br />
        <br />

        <h3>Consulta de Tareas</h3>

        <div>
            <br />
            <article class="col-xs-6, col-sm-6, col-md-3, col-lg-3">
                <label style="font-weight: normal; font: bold">Buscar Tarea</label>
                <asp:TextBox ID="tbxBuscarTarea" Font-Bold="true" ForeColor="#1e3873" CssClass="form-control" placeholder="&#128269;" runat="server" />
                <asp:TextBox ID="tbxTareaId" BorderColor="Transparent" ForeColor="Transparent" runat="server" />
            </article>

            <article class="col-xs-6, col-sm-6, col-md-9, col-lg-9">
                <div style="margin-top:3%">
                    <asp:Button Text="Buscar" CssClass="btn btn-success" placeholder="Titulo" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />

                </div>
            </article>
        </div>

        <div style="margin-left: 2%; margin-top: 5%">
            <br />
            <br />
            <asp:GridView ID="gridviewTareaRe" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="gridviewTareaRe_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TareaId" HeaderText="TareaId" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de vencimiento" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />

                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass=" btn btn-primary" HeaderText="" HeaderStyle-Width="70px" SelectImageUrl="~/Imagenes/" ShowSelectButton="True" SelectText="Editar/Eliminar">

                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>

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

        </div>

    </div>
</asp:Content>
