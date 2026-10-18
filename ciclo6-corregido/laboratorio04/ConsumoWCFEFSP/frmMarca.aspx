<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMarca.aspx.cs" Inherits="ConsumoWS.frmMarca" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mantenimiento de Marca</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1 class="mt-4 mb-4">Mantenimiento de Marca</h1>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />

            <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <div class="col-5">
                        <asp:Label ID="LabelNombre" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label ID="LabelEstado" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
                        <div class="form-check">
                            <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="LabelEstText" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
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
                    <asp:GridView ID="gvMarca" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-striped table-bordered" DataKeyNames="codigo"
                        OnRowCommand="gvMarca_RowCommand">
                        <EmptyDataTemplate>No hay marcas disponibles.</EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Código" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>