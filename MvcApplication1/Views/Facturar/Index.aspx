<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Hilvilla.Dominio.Model.Cotizacion>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cotizaciones
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cotizaciones</h2>

     <p>
        <%: Html.ActionLink("Crear Nueva", "Create") %>
    </p>

    <table>
        <tr>
         
            <th>
                Fecha
            </th>
            <th>
                Cliente
            </th>
            <th>
                Nro Control
            </th>
            <th>
                Tipo
            </th>
            <th>
                Operar
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: String.Format("{0:g}", item.Fecha) %>
            </td>
            <td>
                <%: item.Cliente.Nombre %>
            </td>
            <td>
                <%: item.Control %>
            </td>
            <td>
                <%: item.Tipo %>
            </td>
             <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.IdCotizacion }) %> |
                <%: Html.ActionLink("Ver Detalles", "Details", new {  id=item.IdCotizacion })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new {  id=item.IdCotizacion })%>
            </td>
             
        </tr>
    
    <% } %>

    </table>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

