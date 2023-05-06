<%@ Page Title="" Language="C#"  AutoEventWireup="true" 
    CodeBehind="Absence.aspx.cs" Inherits="ESPOnline.Administration.Absence"  MasterPageFile="~/Administration/Administration.Master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
      <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>

   <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>

    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
      
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
 <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 200,
         
        });
    });
    </script>--%> 
    <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView2.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>--%> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 
 
             

    <div class="container" style="margin-top:12%">
    <div class="row">

   <div class="col-lg-4">
      
   
    
      
        <br />

    
    <table class="container" style="width: 100%;">

    <%--Etablir Par Défaut:--%>
        <tr>
            <td class="style2">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager> 
                </td>
            <td class="style9">
              <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" 
                                                            DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom d'enseignant "  
                                                            Filter="Contains" Width="200">
                                                        </telerik:RadComboBox>
    
               
      <%--  <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource1" DataTextField="NOM_ENS" 
                    DataValueField="ID_ENS">
        
        </asp:DropDownList>--%>
               
         <%--<asp:ListSearchExtender ID="DropDownList1_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList1">
                                </asp:ListSearchExtender>--%>
                                                        <asp:SqlDataSource ID="SqlDataSource1" 
                    runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                    
                    SelectCommand="select id_ens,nom_ens from esp_enseignant where  (id_ens in 
(select id_ens from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe))or 
id_ens in (select id_ens2 from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe))
or   id_ens in (select id_ens3 from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe))
or id_ens in (select id_ens4 from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe))
or   id_ens in (select id_ens5 from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe)))">
                </asp:SqlDataSource>
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                                            <asp:ListItem Value="1" Selected="True">Semestre 1</asp:ListItem>
                                                            <asp:ListItem Value="2"     >Semestre 2</asp:ListItem>
                                                       
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
                <asp:ControlParameter ControlID="DropDownList1" Name="id" 
                    PropertyName="SelectedValue" Type="String" />
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
        <asp:DropDownList ID="DdlModule" CssClass="form-control" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource2" DataTextField="DESIGNATION" 
            DataValueField="CODE_MODULE" 
                    onselectedindexchanged="DdlModule_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetList" TypeName="ABSEsprit.Modules" 
                    OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="id" 
                    PropertyName="SelectedValue" Type="String" />
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
        <%--Seance--%>
        <tr>
            <td class="style2">
                <strong class="text-primary">Séance:</strong></td>
            <td class="style9">
                <asp:DropDownList ID="DdlNumSeance" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlNumSeance_SelectedIndexChanged" 
                    CssClass="form-control">
                    <asp:ListItem Value="0">Choisir une séance</asp:ListItem>
                    <asp:ListItem Value="1">1: 8h:30 à 9h:40</asp:ListItem>
                    <asp:ListItem Value="2">2: 9h:50 à 11h:00</asp:ListItem>
                    <asp:ListItem Value="3">3: 11h:10 à 12h:20</asp:ListItem>
                    <asp:ListItem Value="4">4: 12h:30 à 13h:40</asp:ListItem>
                    <asp:ListItem Value="5">5: 13h:50 à 15h:00</asp:ListItem>
                    <asp:ListItem Value="6">6: 15h:10 à 16h:20</asp:ListItem>
                    <asp:ListItem Value="7">7: 16h:30 à 17h:40</asp:ListItem>
                    <asp:ListItem Value="8">8: 18h:30 à 20h:30</asp:ListItem>
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
                </asp:CalendarExtender>
                                             </div>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
           <td>
                                                     
                                                    </td>
        <tr>
            <td class="style3" colspan="2">
                <asp:Button  CssClass="btn-lg btn-primary btn-success" ID="BtnCreer" runat="server" 
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
                
            </td>
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
                CssClass="table table-condensed table-hover pull-left" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
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
                
           
            
               
                
            </Columns>
             <Columns>
            
                <asp:TemplateField HeaderText="Justification " HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddltypeabs1">
    <asp:ListItem Text="Non" Value="N" Selected="true" />
    <asp:ListItem Text="Oui" Value="O"/>
</asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtobservation" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <script type="text/javascript" language="javascript">



            function CheckAllA(Checkbox) {
                var GridVwHeaderChckbox = document.getElementById("<%=GridView1.ClientID %>");
                for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                    Checkbox.style.backgroundColor = "red";
                    GridVwHeaderChckbox.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;

                    GridVwHeaderChckbox.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = false;
                }
            }

            function CheckAllP(Checkbox) {
                var GridVwHeaderChckbox = document.getElementById("<%=GridView1.ClientID %>");
                for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
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
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = (select max(annee_deb) from societe)) AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET">
<SelectParameters>
                <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource3" Width="872px" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" 
            CssClass="table table-condensed table-hover">
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
            
                <asp:TemplateField HeaderText="Justification " HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddltypeabs2">
    <asp:ListItem Text="Non" Value="N" Selected="true" />
    <asp:ListItem Text="Oui" Value="O"/>
</asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>


            <Columns>
            
                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtobservation2" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
           
        </asp:GridView>
        </div>
        <br />
         <script type="text/javascript" language="javascript">
             function CheckBoxCheck1(rb) {
                 var gv = document.getElementById("<%=GridView2.ClientID %>");
                 for (i = 1; i < gv.rows.length; i++) {

                     if (gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked) {
                         gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = false;

                     } else { gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = true; }

                 }
             }
             function CheckBoxCheck2(rb) {
                 var gv = document.getElementById("<%=GridView2.ClientID %>");
                 for (i = 1; i < gv.rows.length; i++) {

                     if (gv.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked) {
                         gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = false;

                     } else { gv.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = true; }

                 }
             }
            </Script>
         <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" CancelSelectOnNullParameter="False" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            
            
            
            
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS &quot;Nom Prénom&quot;,case when exists ( select esp_absence_new.id_et from esp_absence_new where   ( to_date(esp_absence_new.DATE_SEANCE,'dd/mm/yyyy') = to_date(:argdateseance,'dd/mm/yyyy') and esp_absence_new.id_et =ESP_ETUDIANT.ID_ET  and ESP_ABSENCE_NEW.NUM_SEANCE=TO_NUMBER(:argnumseance)) )then 'true' else 'false' end as abs 
FROM         ESP_ETUDIANT, ESP_INSCRIPTION
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL =:argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '(select max(annee_deb) from societe)') AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET" onselecting="SqlDataSource3_Selecting">
        
       
             <SelectParameters>
               
               <asp:ControlParameter ControlID="TBdateseance" Name="argdateseance" 
                    PropertyName="Text" DefaultValue="" />
               
                <asp:ControlParameter ControlID="Label1" Name="argnumseance" 
                    PropertyName="Text" DefaultValue="" />
                   
                   
                  
                    <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" DefaultValue="" />
            
                </SelectParameters>


        </asp:SqlDataSource>--%>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" CancelSelectOnNullParameter="False" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            
            
            
            
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS Nom,case when exists ( select esp_absence_new.id_et from esp_absence_new where 
              ( to_char(esp_absence_new.DATE_SEANCE,'dd-MON-YY') = to_char(:argdateseance,'dd-MON-YY') and esp_absence_new.id_et =ESP_ETUDIANT.ID_ET  and ESP_ABSENCE_NEW.NUM_SEANCE=TO_NUMBER(:argnumseance)) )then 'true' else 'false' end as abs  
FROM         ESP_ETUDIANT, ESP_INSCRIPTION
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL =:argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = (select max(annee_deb)  from societe)) AND 
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


        </asp:SqlDataSource>
        <br />
        <br />

    </div>
    </div>
</div>


</asp:Content>