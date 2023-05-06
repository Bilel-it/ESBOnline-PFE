<%@ Page Title="" Language="C#" MasterPageFile="~/Enseignants/Ens.Master" AutoEventWireup="true" CodeBehind="Absence.aspx.cs" Inherits="ESPOnline.Enseignants.Absence" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>

   <%-- <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
    
      <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script> 
    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView2.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>   
    <script type="text/javascript" language="javascript">
        function CheckBoxCheck1(rb) {
            var gv = document.getElementById("<%=GridView2.ClientID %>");
            for (i = 0; i < gv.rows.length; i++) {

                if (gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked) {
                    gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = false;

                } else { gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = true; }

            }
        }
        function CheckBoxCheck2(rb) {
            var gv = document.getElementById("<%=GridView2.ClientID %>");
            for (i = 0; i < gv.rows.length; i++) {

                if (gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked) {
                    gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = false;

                } else { gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = true; }

            }
        }
            </script>
<style type="text/css">
    .style1
    {
        text-align: center;
    }
    .style2
    {
        width: 89px;
    }
    .style3
    {
        text-align: center;
        height: 56px;
    }
    .style4
    {
        height: 56px;
    }
    .style6
    {
        height: 55px;
    }
    .style7
    {
        text-align: center;
        height: 73px;
        direction: ltr;
    }
    .style8
    {
        height: 73px;
    }
    .style9
    {
        max-width: 1170px;
        text-align: center;
        margin-left: auto;
        margin-right: auto;
        padding-left: 15px;
        padding-right: 15px;
    }
    .style10
    {
        color: #999999;
        text-align: center;
        font-size: large;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 
             

    <div class="container" style="margin-top:10%">
    <div class="row">

   <div class="col-lg-4">
      
      
    
      
      

    
    <table class="container" style="width: 100%;">

    <%--Etablir Par Défaut:--%>
        <tr>
            <td class="style2">
                
                </td>
            <td class="style9">
            
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True"  >
                                                            <asp:ListItem Value="1" >Trimestre 1</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">Trimestre 2</asp:ListItem>
                                                            <asp:ListItem Value="3" >Trimestre 3</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <br />
            </td>
            <td class="text-primary">
                &nbsp;</td>
            
            <td>
                &nbsp;</td>
        </tr>
        <%--Classe:--%>
        <tr>
            <td class="style2">
                <strong><span class="text-primary">Classe:</span></strong>
                </td>
            <td class="style9">
        <asp:DropDownList CssClass="form-control" ID="DDClasse" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource1" DataTextField="CODE_CL" 
            DataValueField="CODE_CL">
            <asp:ListItem Value="0">Choisir Une classe</asp:ListItem>
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetList" TypeName="ABSEsprit.Classes" 
                    OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="ID_ENS" Type="String" />
                <asp:ControlParameter ControlID="RadioButtonList3" Name="semestre" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </td>
            <td class="text-primary">
                <span class="style6"><strong class="collapse">Semestre :</strong></span><strong><span 
                    class="text-muted">
               <%-- <input type="radio" name="group2" value="S3" id="tous" class="radio-inline"> S1</input>
                <input type="radio" name="group2" value="S4" class="radio-inline"> S2</input>--%>
               
                </span></strong>
            </td>
            
            <td>
                &nbsp;</td>
        </tr>
        <%--Module--%>
        <tr>
            <td class="style2">
                <strong><span class="text-primary">Module:</span></strong></td>
            <td class="style9">
        <asp:DropDownList ID="DdlModule" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlModule_SelectedIndexChanged"
            DataSourceID="ObjectDataSource2" DataTextField="DESIGNATION" 
            DataValueField="CODE_MODULE" 
                     >
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetList" TypeName="ABSEsprit.Modules" 
                    OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="ID_ENS" Type="String" />
                <asp:ControlParameter ControlID="DDClasse" Name="codcl" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="RadioButtonList3" Name="semestre" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </td>
            <td class="style10" colspan="2">
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style9">
                <asp:DropDownList ID="DdlNumSeance" runat="server" AutoPostBack="True"  onselectedindexchanged="DdlNumSeance_SelectedIndexChanged" 
                   
                    CssClass="form-control">
                 <asp:ListItem Value="0">Choisir une séance</asp:ListItem>
                    <asp:ListItem Value="1">1: 9h:00 à 10h:30</asp:ListItem>
                    <asp:ListItem Value="2">2: 10h:30 à 12h:00</asp:ListItem>
                    <asp:ListItem Value="3">3: 12h:00 à 13h:30</asp:ListItem>
                    <asp:ListItem Value="4">4: 13h:30 à 15h:00</asp:ListItem>
                    <asp:ListItem Value="5">5: 15h:00 à 16h:30</asp:ListItem>
                    <asp:ListItem Value="6">6: 16h:30 à 18h:00</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;&nbsp;
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <%--Date seance--%>
        <tr>
            <td class="style2">
                <strong class="text-primary">Date Séance:</strong></td>
            <td class="style9">
            <div class="form-group">
            
            <%--    <asp:TextBox ID="TBdateseance" runat="server" CssClass="form-inline form-control"></asp:TextBox>
                <asp:CalendarExtender ID="TBdateseance_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MMM-yy" TargetControlID="TBdateseance">
                </asp:CalendarExtender>
              --%>
                <telerik:RadDatePicker runat="server"  ID="TBdateseance" Width="99%"  
                    AutoPostBack="true"  Height="37px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy" 
                        DisplayDateFormat="dd/MMM/yy"  Height="37px">
                  
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TBdateseance"   ValidationGroup="ajouter_date"
                ErrorMessage="Date!!!" CssClass="style11" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:Label ID="Label2" runat="server" Text="" CssClass="style11"></asp:Label>                         </div>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
           
        <tr>
            <td class="style3" colspan="2">
                <asp:Button  CssClass="btn-lg btn-primary  btn btn-success" ID="BtnCreer" runat="server" 
                    Text="Enregistrer" onclick="Button1_Click" Width="180px" />
                <asp:Button ID="BtnModifier" runat="server" Text="Modifier" 
                    onclick="Button2_Click" CssClass="btn-lg btn-primary" Width="180px" />
                <br />
                <asp:Label ID="Label3" runat="server" ></asp:Label>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style1" colspan="2">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7" colspan="2">
                <asp:Button ID="Button5" runat="server" Text="Annuler" onclick="Button5_Click" 
                    CssClass="btn-lg btn-danger"  Width="180px" />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td class="style8">
                </td>
            <td class="style8">
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style2">
                
                </td>
            <td class="style9">
            
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
        <div class="col-lg-8">
        <div class="style9" style="width:100%; margin-left:10%">
            <div class="style1">
              <strong><span class="style10">Etablir Par Défaut: <br />
                <asp:CheckBox ID="CheckBoxAccess" runat="server" AutoPostBack="true" 
                    oncheckedchanged="CheckBoxAccess_CheckedChanged" onclick="CheckAllA(this);" 
                    Text="Absence" />&nbsp;
                <asp:CheckBox ID="CheckBoxAccess0" runat="server" AutoPostBack="true" 
                    oncheckedchanged="CheckBoxAccess0_CheckedChanged" onclick="CheckAllP(this);" 
                    Text="Présence" />
                </span></strong>
                <br />
                <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2"  
             
                    >
                <Columns>
                <asp:TemplateField >
  <ItemTemplate>
    <%# Container.DataItemIndex + 1 %>
  </ItemTemplate>
</asp:TemplateField>
               
                <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
                <asp:BoundField DataField="Nom Prénom" HeaderText="Nom Prénom" ReadOnly="True" 
                    SortExpression="Nom Prénom" />
          
 
                <asp:TemplateField HeaderText="Absence" HeaderStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="ui_absent" onclick="CheckBoxCheck(this);" />Absent(e)
                    </ItemTemplate>
                </asp:TemplateField>
           
                <asp:TemplateField HeaderText="Présence" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="ui_present"  onclick="CheckBoxCheck(this);"  />Présent(e)
                    </ItemTemplate>
                </asp:TemplateField>
                
           
            
                <asp:TemplateField HeaderText="Observation" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtobservation" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
           
        </asp:GridView>

        <script type="text/javascript" language="javascript">



            function CheckAllA(Checkbox) {
                var GridVwHeaderChckbox = document.getElementById("<%=GridView1.ClientID %>");
                for (i = 0; i < GridVwHeaderChckbox.rows.length; i++) {
                    Checkbox.style.backgroundColor = "red";
                    GridVwHeaderChckbox.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;

                    GridVwHeaderChckbox.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = false;
                }
            }

            function CheckAllP(Checkbox) {
                var GridVwHeaderChckbox = document.getElementById("<%=GridView1.ClientID %>");
                for (i = 0; i < GridVwHeaderChckbox.rows.length; i++) {
                    GridVwHeaderChckbox.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
                    GridVwHeaderChckbox.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = false;
                }
            }

       
                 
    </script>
   
            </div>
   
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
           ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                     
                     
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS &quot;Nom Prénom&quot;
FROM         ESP_ETUDIANT, ESP_INSCRIPTION
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2017') AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET">
<SelectParameters>
                <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
          
           
          >
              <Columns>
                <asp:TemplateField>
  <ItemTemplate>
    <%# Container.DataItemIndex + 1 %>
  </ItemTemplate>
</asp:TemplateField>
                </Columns>
            <Columns>
                <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
                <asp:BoundField DataField="Nom" HeaderText="Nom Prénom" ReadOnly="True" 
                    SortExpression="Nom" />
            </Columns>
             <Columns>
 
                <asp:TemplateField HeaderText="Absence " HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="ui_absent1"   Checked='<%# bool.Parse(Eval("ABS").ToString()) %>' Enable='<%# !bool.Parse(Eval("ABS").ToString()) %>' onclick="CheckBoxCheck1(this);"/>Absent(e)
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
            
                <asp:TemplateField HeaderText="Présence" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="ui_present1"   Checked='<%# !bool.Parse(Eval("ABS").ToString()) %>' Enable='<%# !bool.Parse(Eval("ABS").ToString()) %>' onclick="CheckBoxCheck2(this);" />Présent(e)
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
            
                <asp:TemplateField HeaderText="Observation" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtobservation2" Text='<%# DataBinder.Eval( Container, "DataItem.observation") %>'
 
    runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
           
        </asp:GridView>
        </div>
        <br />
         <asp:SqlDataSource ID="SqlDataSource3" runat="server" CancelSelectOnNullParameter="False" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            
            
            
            
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS Nom,case when exists ( select esp_absence_new.id_et from esp_absence_new where 
              ( to_date(esp_absence_new.DATE_SEANCE,'dd/MM/yy') = to_date(:argdateseance,'dd/MM/yy') and esp_absence_new.id_et =ESP_ETUDIANT.ID_ET  and ESP_ABSENCE_NEW.NUM_SEANCE=TO_NUMBER(:argnumseance) ) and esp_absence_new.code_cl=:argcl )then 'true' else 'false' end as abs  
,case when exists ( select t4.observation from esp_absence_new t4 where 
              ( to_date(t4.DATE_SEANCE,'dd/MM/yy') = to_date(:argdateseance,'dd/MM/yy') and t4.id_et =ESP_ETUDIANT.ID_ET and t4.code_cl=:argcl and t4.NUM_SEANCE=TO_NUMBER(:argnumseance)) )then (select t5.observation from esp_absence_new t5 where t5.id_et=esp_etudiant.id_et and ( to_date(t5.DATE_SEANCE,'dd/MM/yy') = to_date(:argdateseance,'dd/MM/yy') and t5.CODE_CL=:argcl  and t5.NUM_SEANCE=TO_NUMBER(:argnumseance))) else null end as observation  
    FROM        ESP_ETUDIANT, ESP_INSCRIPTION
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL =:argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2017') AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET">
        
       
             <SelectParameters>
               
              <%-- <asp:ControlParameter ControlID="TBdateseance" Name="argdateseance" PropertyName="SelectedDate" Type="DateTime"
                 />--%>
               <asp:ControlParameter ControlID="Label4" Name="argdateseance" 
                    PropertyName="Text" DefaultValue="" />
                <asp:ControlParameter ControlID="Label1" Name="argnumseance" 
                    PropertyName="Text" DefaultValue="" />
                    
               
                    <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" DefaultValue="" />
            
                </SelectParameters>


        </asp:SqlDataSource>
         <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" CancelSelectOnNullParameter="False" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            
            
            
            
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS Nom,case when exists ( select esp_absence_new.id_et from esp_absence_new where 
              ( to_char(esp_absence_new.DATE_SEANCE,'dd-MON-YY') = to_char(:argdateseance,'dd-MON-YY') and esp_absence_new.id_et =ESP_ETUDIANT.ID_ET  and ESP_ABSENCE_NEW.NUM_SEANCE=TO_NUMBER(:argnumseance)) )then 'true' else 'false' end as abs  
   ,case when exists ( select esp_absence_new.id_et from esp_absence_new where 
              ( to_char(esp_absence_new.DATE_SEANCE,'dd-MON-YY')  = to_char(:argdateseance,'dd-MON-YY') and esp_absence_new.id_et =ESP_ETUDIANT.ID_ET  and ESP_ABSENCE_NEW.NUM_SEANCE=TO_NUMBER(:argnumseance)) )then  (  select observation from esp_absence_new t1 where t1.id_et=ESP_ETUDIANT.id_et and  to_date(t1.DATE_SEANCE,'dd/MM/yy') = to_date(:argdateseance,'dd/MM/yy')  and t1.NUM_SEANCE=TO_NUMBER(:argnumseance))   else observation end as observation FROM        ESP_ETUDIANT, ESP_INSCRIPTION
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL =:argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2014') AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET">
        
       
             <SelectParameters>
               
               <asp:ControlParameter ControlID="TBdateseance" Name="argdateseance" PropertyName="SelectedDate" Type="DateTime"
                 />
               
                <asp:ControlParameter ControlID="Label1" Name="argnumseance" 
                    PropertyName="Text" DefaultValue="" />
                    
               
                    <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" DefaultValue="" />
            
                </SelectParameters>


        </asp:SqlDataSource>--%>

            <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>

        <br />
        <br />
    </div>
    </div>
</div>


</asp:Content>