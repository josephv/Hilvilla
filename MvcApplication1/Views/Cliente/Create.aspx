<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<Hilvilla.Dominio.Model.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true,"Ha ocurrido un error. Por favor corrijalos e intente de nuevo.") %>

        <fieldset>
            <legend>Registro de Cliente:</legend>
            
               <div class="editor-label">
                <label for="Tipo"> Tipo Cliente:</label>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Tipo") %>
                <%= Html.ValidationMessage("Tipo", "*") %>
            </div>

              <div class="editor-label">
                <%: Html.LabelFor(model => model.RifCedula) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.RifCedula) %>
                <%: Html.ValidationMessageFor(model => model.RifCedula) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>

          
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Direccion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Direccion) %>
                <%: Html.ValidationMessageFor(model => model.Direccion) %>
            </div>

                               
            <div class="editor-label">
                <input type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Registrar" />
            </div>
        </fieldset>

    <% } %>

    <div>
       
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
