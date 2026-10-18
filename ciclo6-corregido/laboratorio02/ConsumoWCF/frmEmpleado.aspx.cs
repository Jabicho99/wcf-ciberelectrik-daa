using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmEmpleado : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                MostrarEmpleados();
            }
        }

        private void CargarCombos()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, err) => true;
                ddlDistrito.DataSource = servicio.distritofindAll();
                ddlDistrito.DataBind();
                ddlRol.DataSource = servicio.rolfindAll();
                ddlRol.DataBind();
                ddlTipoDocumento.DataSource = servicio.tipodocumentofindAll();
                ddlTipoDocumento.DataBind();
                ddlSexo.DataSource = servicio.sexofindAll();
                ddlSexo.DataBind();
                ddlEstadoCivil.DataSource = servicio.estadocivilfindAll();
                ddlEstadoCivil.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar combos: " + ex.Message, "error");
            }
        }

        private void MostrarEmpleados()
        {
            try
            {
                var data = servicio.empleadofindAll();
                gvEmpleado.DataSource = data;
                gvEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al mostrar: " + ex.Message, "error");
            }
        }

        private EmpleadoBO ObtenerEmpleadoDesdeFormulario()
        {
            return new EmpleadoBO
            {
                codigo = string.IsNullOrEmpty(txtCod.Text) ? 0 : Convert.ToInt32(txtCod.Text),
                nombre = txtNombre.Text.Trim(),
                apepaterno = txtApPaterno.Text.Trim(),
                apematerno = txtApMaterno.Text.Trim(),
                documento = txtDocumento.Text.Trim(),
                direccion = txtDireccion.Text.Trim(),
                fecha = Convert.ToDateTime(txtFecha.Text),
                nacionalidad = txtNacionalidad.Text.Trim(),
                telefono = txtTelefono.Text.Trim(),
                celular = txtCelular.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                usuario = txtUsuario.Text.Trim(),
                clave = txtClave.Text.Trim(),
                estado = chkEst.Checked,
                distrito = new DistritoBO { codigo = Convert.ToInt32(ddlDistrito.SelectedValue) },
                rol = new RolBO { codigo = Convert.ToInt32(ddlRol.SelectedValue) },
                tipoDocumento = new TipoDocumentoBO { codigo = Convert.ToInt32(ddlTipoDocumento.SelectedValue) },
                sexo = new SexoBO { codigo = Convert.ToInt32(ddlSexo.SelectedValue) },
                estadoCivil = new EstadoCivilBO { codigo = Convert.ToInt32(ddlEstadoCivil.SelectedValue) }
            };
        }

        private void LimpiarFormulario()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtDocumento.Text = "";
            txtDireccion.Text = "";
            txtFecha.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            chkEst.Checked = true;
            if (ddlDistrito.Items.Count > 0) ddlDistrito.SelectedIndex = 0;
            if (ddlRol.Items.Count > 0) ddlRol.SelectedIndex = 0;
            if (ddlTipoDocumento.Items.Count > 0) ddlTipoDocumento.SelectedIndex = 0;
            if (ddlSexo.Items.Count > 0) ddlSexo.SelectedIndex = 0;
            if (ddlEstadoCivil.Items.Count > 0) ddlEstadoCivil.SelectedIndex = 0;
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
                var emp = ObtenerEmpleadoDesdeFormulario();
                emp.codigo = 0;
                if (servicio.empleadoadd(emp))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Empleado registrado.", "exito");
                    MostrarEmpleados();
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
                    MostrarAlerta("Seleccione un empleado.", "error");
                    return;
                }
                if (servicio.empleadoupdate(ObtenerEmpleadoDesdeFormulario()))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Actualizado correctamente.", "exito");
                    MostrarEmpleados();
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
                    MostrarAlerta("Seleccione un empleado.", "error");
                    return;
                }
                var emp = new EmpleadoBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.empleadodelete(emp))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Empleado eliminado (deshabilitado).", "exito");
                    MostrarEmpleados();
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
                    MostrarAlerta("Seleccione un empleado.", "error");
                    return;
                }
                var emp = new EmpleadoBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.empleadoenable(emp))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Empleado habilitado.", "exito");
                    MostrarEmpleados();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo habilitar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void gvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int idx = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvEmpleado.Rows[idx];
                    txtCod.Text = row.Cells[0].Text;

                    var emp = servicio.empleadofindById(new EmpleadoBO { codigo = Convert.ToInt32(txtCod.Text) });
                    if (emp != null)
                    {
                        txtNombre.Text = emp.nombre;
                        txtApPaterno.Text = emp.apepaterno;
                        txtApMaterno.Text = emp.apematerno;
                        txtDocumento.Text = emp.documento;
                        txtDireccion.Text = emp.direccion;
                        txtFecha.Text = emp.fecha.ToString("yyyy-MM-dd");
                        txtNacionalidad.Text = emp.nacionalidad;
                        txtTelefono.Text = emp.telefono;
                        txtCelular.Text = emp.celular;
                        txtCorreo.Text = emp.correo;
                        txtUsuario.Text = emp.usuario;
                        txtClave.Text = emp.clave;
                        chkEst.Checked = emp.estado;

                        if (emp.distrito != null)
                        {
                            ddlDistrito.ClearSelection();
                            foreach (ListItem item in ddlDistrito.Items) if (item.Value == emp.distrito.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (emp.rol != null)
                        {
                            ddlRol.ClearSelection();
                            foreach (ListItem item in ddlRol.Items) if (item.Value == emp.rol.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (emp.tipoDocumento != null)
                        {
                            ddlTipoDocumento.ClearSelection();
                            foreach (ListItem item in ddlTipoDocumento.Items) if (item.Value == emp.tipoDocumento.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (emp.sexo != null)
                        {
                            ddlSexo.ClearSelection();
                            foreach (ListItem item in ddlSexo.Items) if (item.Value == emp.sexo.codigo.ToString()) { item.Selected = true; break; }
                        }
                        if (emp.estadoCivil != null)
                        {
                            ddlEstadoCivil.ClearSelection();
                            foreach (ListItem item in ddlEstadoCivil.Items) if (item.Value == emp.estadoCivil.codigo.ToString()) { item.Selected = true; break; }
                        }
                    }
                    UpdatePanelFormulario.Update();
                    MostrarAlerta("Empleado seleccionado.", "exito");
                }
                catch (Exception ex) { MostrarAlerta("Error selección: " + ex.Message, "error"); }
            }
        }
    }
}
