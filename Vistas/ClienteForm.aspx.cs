using MantWebClientes.Controladores;
using MantWebClientes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantWebClientes.Vistas
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        private ClienteController clienteController = new ClienteController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            List<ClienteClass> clientes = clienteController.ObtenerClientes(); // Obtiene la lista actualizada de clientes
            gvClientes.DataSource = clientes; // Asigna la lista al GridView
            gvClientes.DataBind(); // Vuelve a enlazar el GridView
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            lblId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioActual = "kbrenesc"; // Cambia esto por el usuario actual
                if (string.IsNullOrEmpty(lblId.Text))
                {
                    clienteController.AgregarCliente(txtNombre.Text.Trim(), txtEmail.Text.Trim(),
                                                     txtTelefono.Text.Trim(), usuarioActual);
                    lblMensajeExito.Text = "Guardado exitosamente!";
                }
                else
                {
                    clienteController.ActualizarCliente(int.Parse(lblId.Text), txtNombre.Text.Trim(), txtEmail.Text.Trim(),
                                                        txtTelefono.Text.Trim(), usuarioActual);
                    lblMensajeExito.Text = "Actualizado exitosamente!";
                }

                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error: " + ex.Message;
            }
        } 
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument); // Aquí se obtiene el ID
                    ClienteClass cliente = clienteController.ObtenerClientePorId(id);
                    if (cliente != null)
                    {
                        lblId.Text = cliente.Id.ToString();
                        txtNombre.Text = cliente.Nombre;
                        txtEmail.Text = cliente.Email;
                        txtTelefono.Text = cliente.Telefono;
                    }
                }
                catch (FormatException ex)
                {
                    lblMensajeError.Text = "Error: " + ex.Message; // Manejo de excepciones
                }
            }
        }
        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Si la fila está seleccionada, aplicar el estilo
                if (e.Row.RowState.HasFlag(DataControlRowState.Selected))
                {
                    e.Row.Attributes["class"] = "selected-row"; // Clase CSS para fila seleccionada
                }
            }
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Obtener el ID del cliente a eliminar usando DataKeys
                int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value); // el DataKeyNames debe estar configurado

                // Llamar al método para eliminar el cliente
                clienteController.EliminarCliente(id);
                lblMensajeExito.Text = "Eliminado exitosamente!";

                // Recargar la lista de clientes
                CargarClientes(); // Esto debería actualizar el GridView con los datos restantes
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al eliminar el cliente: " + ex.Message; // Manejo de errores
            }
        }
    }
}




