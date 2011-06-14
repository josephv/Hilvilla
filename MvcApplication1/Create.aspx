<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<Hilvilla.Dominio.Model.Cotizacion>" %>
<%@ Import Namespace="Hilvilla.Dominio.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    <fieldset>
        <legend>Presupuesto</legend>
        <form name="presupuesto">
        <div class="editor-label">
        <label for="Nombre">Nombre Cliente</label>
        </div>

        <div> 
            <div style = "float: left; height: 40px; width: 210px;"> <%=Html.TextBox("persona", "", new { style = "width:200px" })%></div>
           <!-- <div style = "float: left; height: 40px; width: 100px;"> <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Seleccionar"/></div>--> 
        </div>

        <div class="editor-label">
        <label for="Nombre">Motor</label>
        </div>

        <div> 
            <div style = "float: left; height: 40px; width: 210px;"> <%=Html.TextBox("motor", "", new { style = "width:200px" })%></div>
            <!-- <div style = "float: left; height: 40px; width: 100px;"> <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Seleccionar"/></div>-->
        </div>

       <!--  <div class="editor-label">
            <%:Html.LabelFor(model => model.Control)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Control)%>
            <%:Html.ValidationMessageFor(model => model.Control)%>
        </div>-->

        <div class="editor-label">
        <label for="Nombre">Detalles:</label>
        </div>

        <div class="editor-label">
         <table border=1>
         <tr>
            <th>
                Descripcion
            </th>
            <th>
                Precio
            </th>
            <th>
                Cantidad
            </th>
            <th>
                Check
            </th>
            <th>
                Total
            </th>
            
        </tr>
         <%
             foreach (var item in (IList<Detalle>) ViewData["Tipo"])
             {%>
              <tr>
                <td>
                    <%:Html.Label(item.Descripcion)%>
                  
                </td>
                 <td>
                    <%:Html.Label(Convert.ToString(item.Costo))%>
                </td>
                <td>
                    <%:Html.TextBox(Convert.ToString(item.IdDetalle), "",new { style = "width:50px" })%>
                </td>
                 <td>
                  <%:Html.CheckBox(Convert.ToString(item.IdDetalle))%>
                  </td>
                  <td>
                    <%:Html.Label(Convert.ToString(item.Costo))%>
                </td>
                </tr>
                 <%
          }%>
          </table>

        </div>
        
         
        </form>
     
        

    <script type="text/javascript">
        $(document).ready(function () {
            $("input#persona").autocomplete('<%= Url.Action("Find", "Cliente") %>');
        }); 
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("input#motor").autocomplete('<%= Url.Action("Find", "Motor") %>');
        }); 

    </script>

  
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
