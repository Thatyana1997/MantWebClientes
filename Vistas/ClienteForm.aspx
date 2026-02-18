<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="MantWebClientes.Vistas.ClienteForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mantenimiento de Clientes</title>
    <link href="../Estilos/ClienteStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 id="titulo">Mantenimiento de Clientes</h2>
            <asp:Label ID="lblMensajeError" runat="server" CssClass="texto-error"></asp:Label> <br />  <br />
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="gridview-cliente"
                OnRowCommand="gvClientes_RowCommand" OnRowDeleting="gvClientes_RowDeleting"
                DataKeyNames="Id" OnRowDataBound="gvClientes_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" />
                    <asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Creación" />
                    <asp:BoundField DataField="FechaModificacion" HeaderText="Fecha Modificación" />
                    <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario Modificación" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" CommandName="Select" 
                                CommandArgument='<%# Eval("Id") %>' Text="Editar" CssClass="btn-editar" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" 
                                CommandArgument='<%# Eval("Id") %>' Text="Eliminar" CssClass="btn-eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <h3>Agregar/Editar Cliente</h3>
            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-field"></asp:TextBox><br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field"></asp:TextBox><br />
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="input-field"></asp:TextBox><br />
            <asp:Label ID="lblMensajeExito" runat="server" CssClass="texto-exito"></asp:Label><br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn-agregar" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btn-limpiar" />
        </div>
    </form>
</body>
</html>
