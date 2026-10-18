using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmMarca : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarMarcas();
            }
        }

        private void MostrarMarcas()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, err) => true;
                var marcas = servicio.marcafindAll();
                gvMarca.DataSource = marcas;
                gvMarca.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar marcas: " + ex.Message, "error");
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
            string script = tipo == "exito"
                ? $"alert('✅ Éxito: {mensaje}');"
                : $"alert('❌ Error: {mensaje}');";
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
                var nueva = new MarcaBO
                {
                    nombre = txtNom.Text.Trim(),
                    estado = chkEst.Checked
                };
                bool ok = servicio.marcaadd(nueva);
                if (ok)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Marca registrada correctamente.", "exito");
                    MostrarMarcas();
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
                    MostrarAlerta("Primero seleccione una marca.", "error");
                    return;
                }
                var marca = new MarcaBO
                {
                    codigo = Convert.ToInt32(txtCod.Text),
                    nombre = txtNom.Text.Trim(),
                    estado = chkEst.Checked
                };
                bool ok = servicio.marcaupdate(marca);
                if (ok)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Marca actualizada correctamente.", "exito");
                    MostrarMarcas();
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
                    MostrarAlerta("Primero seleccione una marca.", "error");
                    return;
                }
                var marca = new MarcaBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool ok = servicio.marcadelete(marca);
                if (ok)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Marca eliminada (deshabilitada).", "exito");
                    MostrarMarcas();
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
                    MostrarAlerta("Primero seleccione una marca.", "error");
                    return;
                }
                var marca = new MarcaBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool ok = servicio.marcaenable(marca);
                if (ok)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Marca habilitada correctamente.", "exito");
                    MostrarMarcas();
                    UpdatePanelGrid.Update();
                }
                else MostrarAlerta("No se pudo habilitar.", "error");
            }
            catch (Exception ex) { MostrarAlerta("Error: " + ex.Message, "error"); }
        }

        protected void gvMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvMarca.Rows[rowIndex];
                    txtCod.Text = row.Cells[0].Text;
                    txtNom.Text = row.Cells[1].Text;
                    Label lblEst = (Label)row.Cells[2].FindControl("lblEstado");
                    if (lblEst != null) chkEst.Checked = (lblEst.Text == "Habilitado");
                    UpdatePanelFormulario.Update();
                    MostrarAlerta("Marca seleccionada.", "exito");
                }
                catch (Exception ex) { MostrarAlerta("Error al seleccionar: " + ex.Message, "error"); }
            }
        }
    }
}