<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Hilvilla.Dominio.Model.Cliente>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Clientes</h2>
     
       
    
      <% using (Html.BeginForm())
    {%>
        <fieldset>
        <legend>Buscar Cliente</legend>
            
            <div class="editor-label">
                <label for="Nombre">Nombre:</label>
            </div>
            <div class="editor-field">
            <%= Html.TextBox("persona",null, new { @class = "text-box" })%>
            </div>
            <div class="editor-label">
                <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Buscar"/>
            </div>
         </fieldset>
     <%
    }%>
    <fieldset>
        <legend>Clientes</legend>
   
    <table>
    <tr> <th>Nuevo Cliente</th> <th> <a title="Agregar Cliente" href="<%=Url.Action("Create", "Cliente")%>">
     <img src="<%=Url.Content("~/Content/agregar.png")%>" height="25px" width="25px" /></a></th> </tr>
        


        </table>
        <table>
        <tr>
            <th>
                Tipo
            </th>
            <th>
                Rif o Cedula
            </th>
            <th>
                Nombre
            </th>
            <th>
                Direccion
            </th>
            
        </tr>

    <%foreach (var item in Model)
      {
          if (Model != null)
          {%>
     <tr>
                <td>
                    <%:item.Tipo%>
                </td>
                <td>
                    <%:item.RifCedula%>
                </td>
                <td>
                    <%:item.Nombre%>
                </td>
                <td>
                    <%:item.Direccion%>
                </td>

                <td>
                        <a title="Eliminar Cliente" href="<%=Url.Action("Delete", "Cliente", new {id = item.RifCedula}, null)%>">
                        <img src="<%=Url.Content("~/Content/eliminar.png")%>" height="25px" width="25px" /></a>
                </td>
                <td>
                        <a title="Editar Cliente" href="<%=Url.Action("Edit", "Cliente", new {id = item.RifCedula}, null)%>">
                        <img src="<%=Url.Content("~/Content/editar.png")%>" height="25px" width="25px" /></a>
                </td>
                <td>
                        <a title="Ver Cliente" href="<%=Url.Action("Details", "Cliente", new {id = item.RifCedula}, null)%>">
                        <img src="<%=Url.Content("~/Content/amigos.png")%>" height="25px" width="25px" /></a>
                </td>
      </tr>
      
        <%}
          else
          {%> <h2>No Hay Clientes...</h2>
          
      <%
          }
      }%>
      </table>
   </fieldset>
       <script type="text/javascript">

           $(document).ready(function () {
               $("input#persona").autocomplete('<%= Url.Action("Find", "Cliente") %>');
           }); 

</script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
