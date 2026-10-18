<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProducto.aspx.cs" Inherits="ConsumoWS.frmProducto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mantenimiento de Producto</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1 class="mt-4 mb-4">Mantenimiento de Producto</h1>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />

            <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <div class="row g-3">
                        <div class="col-md-6">
                            <asp:Label ID="LabelNom" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="LabelDesc" runat="server" Text="Descripción:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelPrec" runat="server" Text="Precio (S/):" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelCant" runat="server" Text="Cantidad:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelFecha" runat="server" Text="Fecha Ingreso:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelCat" runat="server" Text="Categoría:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelMar" runat="server" Text="Marca:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelEst" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
                            <div class="form-check">
                                <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="LabelEstText" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3"></div>

            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-striped table-hover table-bordered"
                            OnRowCommand="gvProducto_RowCommand" DataKeyNames="codigo">
                            <EmptyDataTemplate>No hay productos disponibles.</EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="Código" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:C2}" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                <asp:TemplateField HeaderText="Fecha Ingreso">
                                    <ItemTemplate>
                                        <asp:Literal ID="litFecha" runat="server" Text='<%# Eval("fechaingreso", "{0:d}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate>
                                        <asp:Literal ID="litCategoria" runat="server" Text='<%# Eval("categoria.nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemTemplate>
                                        <asp:Literal ID="litMarca" runat="server" Text='<%# Eval("marca.nombre") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server"
                                            Text='<%# Convert.ToBoolean(Eval("estado")) ? "Habilitado" : "Deshabilitado" %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSeleccionar" runat="server"
                                            CommandName="Seleccionar"
                                            CommandArgument='<%# Container.DataItemIndex %>'
                                            CssClass="btn btn-sm btn-primary"
                                            Text="Seleccionar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>