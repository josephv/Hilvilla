<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Hilvilla.Dominio.Model.Marca>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            
            <th>
                Nombre
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
          
            
            <td>
                <%: item.Nombre %>
            </td>
              <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.IdMarca }) %> |
                <%: Html.ActionLink("Detalles", "Details", new { id = item.IdMarca })%> |
                <%: Html.ActionLink("Borrar", "Delete", new { id = item.IdMarca })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

