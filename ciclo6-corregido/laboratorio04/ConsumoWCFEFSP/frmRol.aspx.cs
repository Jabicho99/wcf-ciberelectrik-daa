using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmRol : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarRoles();
            }
        }

        private void MostrarRoles()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, err) => true;
                var data = servicio.rolfindAll();
                gvRol.DataSource = data;
                gvRol.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar: " + ex.Message, "error");
            }
        }

        private void LimpiarFormulario()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            chkEst.Checked = true;
            UpdatePanelFormulario.Update();
        }

        private void MostrarAlerta(string mensaje, string tipo)
        {
            string script = tipo == "exito" ? $"alert('✅ Éxito: {mensaje}');" : $"alert('❌ Error: {mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MostrarAlerta("El nombre es obligatorio.", "error");
                    return;
                }
                var obj = new RolBO { nombre = txtNom.Text.Trim(), estado = chkEst.Checked };
                if (servicio.roladd(obj))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Rol registrado correctamente.", "exito");
                    MostrarRoles();
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
                    MostrarAlerta("Seleccione un rol.", "error");
                    return;
                }
                var obj = new RolBO
                {
                    codigo = Convert.ToInt32(txtCod.Text),
                    nombre = txtNom.Text.Trim(),
                    estado = chkEst.Checked
                };
                if (servicio.rolupdate(obj))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Rol actualizado correctamente.", "exito");
                    MostrarRoles();
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
                    MostrarAlerta("Seleccione un rol.", "error");
                    return;
                }
                var obj = new RolBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.roldelete(obj))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Rol eliminado (deshabilitado).", "exito");
                    MostrarRoles();
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
                    MostrarAlerta("Seleccione un rol.", "error");
                    return;
                }
                var obj = new RolBO { codigo = Convert.ToInt32(txtCod.Text) };
                if (servicio.rolenable(obj))
                {
                    LimpiarFormulario();
                    MostrarAlerta("Rol habilitado correctamente.", "exito");
                    MostrarRoles();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo habilitar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void gvRol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvRol.Rows[rowIndex];
                    txtCod.Text = row.Cells[0].Text;
                    txtNom.Text = row.Cells[1].Text;
                    Label lblEst = (Label)row.Cells[2].FindControl("lblEstado");
                    if (lblEst != null) chkEst.Checked = (lblEst.Text == "Habilitado");
                    UpdatePanelFormulario.Update();
                    MostrarAlerta("Rol seleccionado.", "exito");
                }
                catch (Exception ex) { MostrarAlerta("Error selección: " + ex.Message, "error"); }
            }
        }
    }
}