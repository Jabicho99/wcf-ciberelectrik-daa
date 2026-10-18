<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="ConsumoWS.frmCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mantenimiento de Cliente</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1 class="mt-4 mb-4">Mantenimiento de Cliente</h1>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />

            <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <div class="row g-3">
                        <div class="col-md-4">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="LabelApPat" runat="server" Text="Apellido Paterno:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="LabelApMat" runat="server" Text="Apellido Materno:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelDoc" runat="server" Text="Documento:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="LabelDirec" runat="server" Text="Dirección:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelFecha" runat="server" Text="Fecha Nacimiento:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelTel" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelCel" runat="server" Text="Celular:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="LabelCorreo" runat="server" Text="Correo:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelDistrito" runat="server" Text="Distrito:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="form-select" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelTipoDoc" runat="server" Text="Tipo Documento:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LabelSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-select" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <div class="form-check mt-4">
                                <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="LabelEst" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
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
                    <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-bordered table-striped" DataKeyNames="codigo"
                        OnRowCommand="gvCliente_RowCommand">
                        <EmptyDataTemplate>No hay clientes registrados.</EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Código" />
                            <asp:TemplateField HeaderText="Apellidos y Nombres">
                                <ItemTemplate><%# Eval("apepaterno") + " " + Eval("apematerno") + ", " + Eval("nombre") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="documento" HeaderText="Documento" />
                            <asp:BoundField DataField="correo" HeaderText="Correo" />
                            <asp:TemplateField HeaderText="Distrito">
                                <ItemTemplate><%# Eval("distrito.nombre") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Convert.ToBoolean(Eval("estado")) ? "Habilitado" : "Deshabilitado" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:Button ID="btnSeleccionar" runat="server" CommandName="Seleccionar"
                                        CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-primary" Text="Seleccionar" />
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