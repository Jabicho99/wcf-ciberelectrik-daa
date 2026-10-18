using ConsumoWCF.WCFCiberElectrik;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmProducto : System.Web.UI.Page
    {
        WCFCiberElectrikClient servicio = new WCFCiberElectrikClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                MostrarProductos();
            }
        }

        private void CargarCombos()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, err) => true;

                var categorias = servicio.categoriafindAll();
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "nombre";
                ddlCategoria.DataValueField = "codigo";
                ddlCategoria.DataBind();

                var marcas = servicio.marcafindAll();
                ddlMarca.DataSource = marcas;
                ddlMarca.DataTextField = "nombre";
                ddlMarca.DataValueField = "codigo";
                ddlMarca.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al cargar combos: " + ex.Message, "error");
            }
        }

        private void MostrarProductos()
        {
            try
            {
                var productos = servicio.productofindAll();
                gvProducto.DataSource = productos;
                gvProducto.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al mostrar productos: " + ex.Message, "error");
            }
        }

        private ProductoBO ObtenerProductoDesdeFormulario()
        {
            return new ProductoBO
            {
                codigo = string.IsNullOrEmpty(txtCod.Text) ? 0 : Convert.ToInt32(txtCod.Text),
                nombre = txtNom.Text.Trim(),
                descripcion = txtDesc.Text.Trim(),
                precio = Convert.ToDecimal(txtPrecio.Text),
                cantidad = Convert.ToInt32(txtCantidad.Text),
                fechaingreso = DateTime.Parse(txtFecha.Text),
                estado = chkEst.Checked,
                categoria = new CategoriaBO { codigo = Convert.ToInt32(ddlCategoria.SelectedValue) },
                marca = new MarcaBO { codigo = Convert.ToInt32(ddlMarca.SelectedValue) }
            };
        }

        private void LimpiarFormulario()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            txtDesc.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            chkEst.Checked = true;
            if (ddlCategoria.Items.Count > 0) ddlCategoria.SelectedIndex = 0;
            if (ddlMarca.Items.Count > 0) ddlMarca.SelectedIndex = 0;
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

                var nuevo = ObtenerProductoDesdeFormulario();
                nuevo.codigo = 0;
                bool resultado = servicio.productoadd(nuevo);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Producto registrado correctamente.", "exito");
                    MostrarProductos();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se pudo registrar el producto.", "error");
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
                    MostrarAlerta("Primero seleccione un producto para actualizar.", "error");
                    return;
                }

                var producto = ObtenerProductoDesdeFormulario();
                bool resultado = servicio.productoupdate(producto);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Producto actualizado correctamente.", "exito");
                    MostrarProductos();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se pudo actualizar el producto.", "error");
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
                    MostrarAlerta("Primero seleccione un producto para eliminar.", "error");
                    return;
                }

                var producto = new ProductoBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool resultado = servicio.productodelete(producto);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Producto eliminado (deshabilitado) correctamente.", "exito");
                    MostrarProductos();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se pudo eliminar el producto.", "error");
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
                    MostrarAlerta("Primero seleccione un producto para habilitar.", "error");
                    return;
                }

                var producto = new ProductoBO { codigo = Convert.ToInt32(txtCod.Text) };
                bool resultado = servicio.productoenable(producto);
                if (resultado)
                {
                    LimpiarFormulario();
                    MostrarAlerta("Se habilitó el producto correctamente.", "exito");
                    MostrarProductos();
                    UpdatePanelGrid.Update();
                }
                else
                {
                    MostrarAlerta("No se habilitó el producto.", "error");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message, "error");
            }
        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvProducto.Rows[rowIndex];

                    // Extraer datos básicos
                    txtCod.Text = row.Cells[0].Text;
                    txtNom.Text = row.Cells[1].Text;
                    txtDesc.Text = row.Cells[2].Text;

                    string precioTexto = row.Cells[3].Text.Replace("S/", "").Replace("$", "").Trim();
                    txtPrecio.Text = precioTexto;

                    txtCantidad.Text = row.Cells[4].Text;

                    // Fecha
                    Literal litFecha = (Literal)row.Cells[5].FindControl("litFecha");
                    if (litFecha != null && DateTime.TryParse(litFecha.Text, out DateTime fecha))
                        txtFecha.Text = fecha.ToString("yyyy-MM-dd");

                    // Categoría y Marca (por nombre, con limpieza previa)
                    Literal litCategoria = (Literal)row.Cells[6].FindControl("litCategoria");
                    Literal litMarca = (Literal)row.Cells[7].FindControl("litMarca");

                    // Limpiar selecciones anteriores
                    ddlCategoria.ClearSelection();
                    ddlMarca.ClearSelection();

                    // Seleccionar por texto (nombre)
                    if (litCategoria != null)
                    {
                        ListItem itemCat = ddlCategoria.Items.FindByText(litCategoria.Text);
                        if (itemCat != null) itemCat.Selected = true;
                    }
                    if (litMarca != null)
                    {
                        ListItem itemMar = ddlMarca.Items.FindByText(litMarca.Text);
                        if (itemMar != null) itemMar.Selected = true;
                    }

                    // Estado
                    Label lblEstado = (Label)row.Cells[8].FindControl("lblEstado");
                    if (lblEstado != null)
                        chkEst.Checked = (lblEstado.Text == "Habilitado");

                    UpdatePanelFormulario.Update();
                    MostrarAlerta("Producto seleccionado correctamente.", "exito");
                }
                catch (Exception ex)
                {
                    MostrarAlerta("Error al seleccionar: " + ex.Message, "error");
                }
            }
        }
    }
}
