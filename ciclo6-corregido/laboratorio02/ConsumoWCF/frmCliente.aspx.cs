using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmCliente : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                MostrarClientes();
            }
        }

        private void CargarCombos()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, err) => true;
                ddlDistrito.DataSource = servicio.distritofindAll();
                ddlDistrito.DataBind();
                ddlTipoDocumento.DataSource = servicio.tipodocumentofindAll();
                ddlTipoDocumento.DataBind();
                ddlSexo.DataSource = servicio.sexofindAll();
                ddlSexo.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar combos: " + ex.Message, "error");
            }
        }

        private void MostrarClientes()
        {
            try
            {
                var data = servicio.clientefindAll();
                gvCliente.DataSource = data;
                gvCliente.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al mostrar: " + ex.Message, "error");
            }
        }

        private ClienteBO ObtenerClienteDesdeFormulario()
        {
            return new ClienteBO
            {
                codigo = string.IsNullOrEmpty(txtCod.Text) ? 0 : Convert.ToInt32(txtCod.Text),
                nombre = txtNombre.Text.Trim(),
                apepaterno = txtApPaterno.Text.Trim(),
                apematerno = txtApMaterno.Text.Trim(),
                documento = txtDocumento.Text.Trim(),
                fecha = Convert.ToDateTime(txtFecha.Text),
                nacionalidad = txtNacionalidad.Text.Trim(),
                direccion = txtDireccion.Text.Trim(),
                telefono = txtTelefono.Text.Trim(),
                celular = txtCelular.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                estado = chkEst.Checked,
                distrito = new DistritoBO { codigo = Convert.ToInt32(ddlDistrito.SelectedValue) },
                tipoDocumento = new TipoDocumentoBO { codigo = Convert.ToInt32(ddlTipoDocumento.SelectedValue) },
                sexo = new SexoBO { codigo = Convert.ToInt32(ddlSexo.SelectedValue) }
            };
        }

        private void LimpiarFormulario()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtDocumento.Text = "";
            txtFecha.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            chkEst.Checked = true;
            if (ddlDistrito.Items.Count > 0) ddlDistrito.SelectedIndex = 0;
            if (ddlTipoDocumento.Items.Count > 0) ddlTipoDocumento.SelectedIndex = 0;
            if (ddlSexo.Items.Count > 0) ddlSexo.SelectedIndex = 0;
            UpdatePanelFormulario.Update();
        }

        private void MostrarAlerta(string mensaje, string tipo)
        {
            string script = tipo == "exito" ? $"alert('✅ {mensaje}');" : $"alert('❌ {mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApPaterno.Text))
                {
                    MostrarAlerta("Nombre y apellido paterno son obligatorios.", "error");
                    return;
                }
                var cli = ObtenerClienteDesdeFormulario();
                cli.codigo = 0;
                if (servicio.clienteadd(cli))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Cliente registrado correctamente.", "exito");
                    MostrarClientes();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo registrar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Seleccione un cliente.", "error");
                    return;
                }
                if (servicio.clienteupdate(ObtenerClienteDesdeFormulario()))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Cliente actualizado correctamente.", "exito");
                    MostrarClientes();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo actualizar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Seleccione un cliente.", "error");
                    return;
                }
                var cli = new ClienteBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.clientedelete(cli))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Cliente eliminado (deshabilitado).", "exito");
                    MostrarClientes();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo eliminar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Seleccione un cliente.", "error");
                    return;
                }
                var cli = new ClienteBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.clienteenable(cli))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Cliente habilitado correctamente.", "exito");
                    MostrarClientes();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo habilitar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int idx = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvCliente.Rows[idx];
                    txtCod.Text = row.Cells[0].Text;

                    var cli = servicio.clientefindById(new ClienteBO { codigo = Convert.ToInt32(txtCod.Text) });
                    if (cli != null)
                    {
                        txtNombre.Text = cli.nombre;
                        txtApPaterno.Text = cli.apepaterno;
                        txtApMaterno.Text = cli.apematerno;
                        txtDocumento.Text = cli.documento;
                        txtFecha.Text = cli.fecha.ToString("yyyy-MM-dd");
                        txtNacionalidad.Text = cli.nacionalidad;
                        txtDireccion.Text = cli.direccion;
                        txtTelefono.Text = cli.telefono;
                        txtCelular.Text = cli.celular;
                        txtCorreo.Text = cli.correo;
                        chkEst.Checked = cli.estado;

                        if (cli.distrito != null)
                        {
                            ddlDistrito.ClearSelection();
                            foreach (ListItem item in ddlDistrito.Items) if (item.Value == cli.distrito.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (cli.tipoDocumento != null)
                        {
                            ddlTipoDocumento.ClearSelection();
                            foreach (ListItem item in ddlTipoDocumento.Items)
                                if (item.Value == cli.tipoDocumento.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (cli.sexo != null)
                        {
                            ddlSexo.ClearSelection();
                            foreach (ListItem item in ddlSexo.Items)
                                if (item.Value == cli.sexo.codigo.ToString()) { item.Selected = true; break; }
                        }
                    }
                    UpdatePanelFormulario.Update();
                    MostrarAlerta("Cliente seleccionado.", "exito");
                }
                catch (Exception ex) { MostrarAlerta("Error selección: " + ex.Message, "error"); }
            }
        }
    }
}
