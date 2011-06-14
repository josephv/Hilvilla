<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TwoColumn.Master" Inherits="System.Web.Mvc.ViewPage<Hilvilla.Dominio.Model.Cotizacion>" %>
<%@ Import Namespace="Hilvilla.Dominio.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
     <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery.cascade.js") %>"></script>
     <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery.cascade.ext.js") %>"></script>
     <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery.templating.js") %>"></script>


    <fieldset>
        <legend>Presupuesto</legend>

       <% using (Html.BeginForm("Create", "Facturar", FormMethod.Post, new { name = "presupuesto", id = "presupuesto" }))
       { %>
        <table>
        <tr><td><label for="Nombre" ><b>Nombre Cliente</b></label></td> <td><%=Html.TextBox("persona", "", new { style = "width:200px" })%></td></tr>
        <tr><td><%:Html.DropDownList("marcas")%></td><td> <%:Html.DropDownList("motores")%></td><td><%:Html.DropDownList("tipos")%></td></tr>
        <!-- <tr><td><label for="Control"><b>Nro. de Control</b></label></td><td><%=Html.TextBox("control", "", new { style = "width:200px" })%></td></tr>-->
        <tr><td style=" text-align:right"><label><b>Total:</b></label>&nbsp;</td><td style=" text-align:left"><input id ="total" type ="text" value="0,00" disabled="disabled" style=" width:auto; text-align:right" /><label>Bs.</label></td></tr>
         <tr><td><label for="Detalles"><b>Detalles:</b></label></td></tr>
         <tr><td></td><td id="detalles"></td></tr>
        
        <div class="editor-label">
            <%:Html.LabelFor(model => model.Control)%>
        </div>
        <div class="editor-field">
            <%:Html.TextBoxFor(model => model.Control)%>
            <%:Html.ValidationMessageFor(model => model.Control)%>
        </div>
         
         
         </table>
         <table>
         <tr><td><input type="submit"  name="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover" value="Guardar"/></td></tr>
         </table>
         
         <%}%>
           
          
           

      <script type="text/javascript">
          jQuery(document).ready(function () {
              jQuery("#motores").cascade("#marcas", {
                  ajax: { url: 'GetMotores' },
                  template: commonTemplate,
                  match: commonMatch
              });
              jQuery("#tipos").cascade("#motores", {
                  ajax: { url: 'GetTipos' },
                  template: commonTemplate,
                  match: commonMatch
              });
              jQuery("#detalles").cascade("#tipos", {
                  ajax: { url: 'tipoMotor' },
                  template: commonTemplate2,
                  match: commonMatch
              });
          });
          function commonTemplate(item) {
              return "<option value='" + item.Value + "'>" + item.Text + "</option>";
          };
          function commonTemplate2(item) {
              return item.Value;
          };

          function commonMatch(selectedValue) {
              return this.When == selectedValue;
          };
	</script>

         
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
   
     <script type="text/javascript">
         function producto(a, b, c, d,e) {
             if (d.checked) {
                 c.value = a * b;
                 f = this.document.presupuesto.total.value;
                 operando1 = eval(c.value);
                 operando2 = eval(this.document.presupuesto.total.value);
                 this.document.presupuesto.total.value = operando1 + operando2;
                 //e.disabled = true;
             }
             else {
                 this.document.presupuesto.total.value = eval(this.document.presupuesto.total.value) - eval(c.value);
                 c.value = "";
                 e.value = "";
                // e.disabled = false;

             }
         }

         function mouse1(a) {
            if(!a.value!="")
             a.disabled = false;
         }
         function mouse2(a) {
             if (!a.value != "")
             a.disabled = true;
         }
         function cargarDatos() {
             var motor = this.document.presupuesto.motor.value
             var tipo = $.ajax({
                 url: "tipoMotor?motor="+motor,
                 async: false
             }).responseText;
             if (tipo.value=="no") {
                 Alert("El Motor No Existe o no Ha Seleccionado un Motor!");
             } else {
                 var previousInnerHTML = new String();

                 previousInnerHTML = document.getElementById('presupuesto').innerHTML;
                 previousInnerHTML = previousInnerHTML.concat(tipo);

                 document.getElementById('presupuesto').innerHTML = previousInnerHTML;
             }
                        
         }
     </script>
   
   
</asp:Content>

  
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
