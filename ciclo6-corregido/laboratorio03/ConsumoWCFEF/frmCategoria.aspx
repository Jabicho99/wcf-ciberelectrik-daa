<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCategoria.aspx.cs" Inherits="ConsumoWS.frmCategoria" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mantenimiento de Categoria</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1 class="mt-4 mb-4">Mantenimiento de Categoria</h1>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />

            <!-- UpdatePanel para el formulario (TextBox, CheckBox, Botones) -->
            <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <div class="col-5">
                        <asp:Label ID="Label2" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label>
                        <div class="mb-3 form-check">
                            <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="Label1" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
                        </div>
                    </div>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3"></div>

            <!-- UpdatePanel para el GridView -->
            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="false" 
                            CssClass="table table-striped table-hover table-bordered"
                            OnRowCommand="gvCategoria_RowCommand" DataKeyNames="codigo">
                            <EmptyDataTemplate>No hay categorías disponibles.</EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="Código" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" 
                                            Text='<%# Convert.ToBoolean(Eval("estado")) ? "Habilitado" : "Deshabilitado" %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                       
                                <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" HeaderText="Acción" HeaderStyle-CssClass="table-dark" />
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