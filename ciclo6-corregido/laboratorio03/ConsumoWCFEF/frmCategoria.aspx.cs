using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmCategoria : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCategoria();
            }
        }

        private void MostrarCategoria()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                var categorias = servicio.categoriafindAll();
                gvCategoria.DataSource = categorias;
                gvCategoria.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar datos: " + ex.Message, "error");
            }
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

                var nuevaCategoria = new CategoriaBO
                {
                    nombre = txtNom.Text.Trim(),
                    estado = chkEst.Checked
                };

                bool resultado = servicio.categoriaadd(nuevaCategoria);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Categoría registrada correctamente.", "exito");
                    MostrarCategoria(); // Refrescar GridView
                    UpdatePanelGrid.Update(); // Forzar actualización del GridView
                }
                else
                {
                    MostrarAlerta("No se pudo registrar la categoría.", "error");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message, "error");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Primero seleccione una categoría para actualizar.", "error");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MostrarAlerta("El nombre es obligatorio.", "error");
                    return;
                }

                var categoria = new CategoriaBO
                {
                    codigo = Convert.ToInt32(txtCod.Text),
                    nombre = txtNom.Text.Trim(),
                    estado = chkEst.Checked
                };

                bool resultado = servicio.categoriaupdate(categoria);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Categoría actualizada correctamente.", "exito");
                    MostrarCategoria();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se pudo actualizar la categoría.", "error");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message, "error");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Primero seleccione una categoría para eliminar.", "error");
                    return;
                }

                var categoria = new CategoriaBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool resultado = servicio.categoriadelete(categoria);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Categoría eliminada (deshabilitada) correctamente.", "exito");
                    MostrarCategoria();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se pudo eliminar la categoría.", "error");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message, "error");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCod.Text))
                {
                    MostrarAlerta("Primero seleccione una categoría para habilitar.", "error");
                    return;
                }

                var categoria = new CategoriaBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool resultado = servicio.categoriaenable(categoria);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Se habilitó la categoría correctamente.", "exito");
                    MostrarCategoria();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se habilitó la categoría.", "error");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message, "error");
            }
        }

        protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCategoria.Rows[rowIndex];

                string codigo = row.Cells[0].Text;
                string nombre = row.Cells[1].Text;
                string estadoTexto = ((Label)row.Cells[2].FindControl("lblEstado")).Text;

                txtCod.Text = codigo;
                txtNom.Text = nombre;
                chkEst.Checked = (estadoTexto == "Habilitado");

                // Actualizar el UpdatePanel del formulario para mostrar los datos seleccionados
                UpdatePanelFormulario.Update();
            }
        }

        private void LimpiarFormulario()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            chkEst.Checked = false;
            UpdatePanelFormulario.Update();
        }

        private void MostrarAlerta(string mensaje, string tipo)
        {
            string script = "";
            if (tipo == "exito")
                script = $"alert('✅ Éxito: {mensaje}');";
            else
                script = $"alert('❌ Error: {mensaje}');";

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
        }
    }
}