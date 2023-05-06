<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Suivi_devaluation.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Suivi_devaluation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        width: 135px;
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>


             

    <div class="container" style="margin-top:12%"> <asp:Panel ID="Panel2" runat="server">
        <h3 class="text-center text-info">
            <strong>Suivi des evaluations des enseignements</strong></h3>
    </asp:Panel>
    <div class="row">

   <div class="col-lg-3">
      
      
    
      
        <br />

    
    <table class="container" style="width: 100%;">

    <%--Etablir Par Défaut:--%>
        <tr>
            <td class="style2">
                
                <strong><span class="text-primary">Semestre:</span></strong>
                                
                </td>
            <td class="style9">
            <br />
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" 
                                                            OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" Height="16px" 
                                                            Width="117px">
                                                            <asp:ListItem Value="1" Selected="True">Sem 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Sem 2</asp:ListItem>
                                                       
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
        <asp:DropDownList ID="DdlModule" CssClass="form-control" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource2" DataTextField="DESIGNATION" 
            DataValueField="CODE_MODULE" 
                    onselectedindexchanged="DdlModule_SelectedIndexChanged">
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
        <%--Seance--%>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
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
                &nbsp;</td>
            <td class="style9">
            <div class="form-group">
            
                                             </div>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
           <td class="style2">
                                                     
                                                    </td>
        <tr>
            <td class="style3" colspan="2">
                <br />
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
                <asp:Button ID="Button5" runat="server" Text="refresh" onclick="Button5_Click" 
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
        <div class="col-lg-9">
        <div class="style9" style="width:100%; margin-left:2%">
            <div class="style1">
                
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="400px" Width="850px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2" Width="872px" 
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
          
 
               
                
                
           
            
                <asp:TemplateField HeaderText="Evaluer" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="txtobservation" runat="server" Text="Non" ForeColor="#E33532" ></asp:Label>
                       <%-- <asp:TextBox ID="txtobservation" runat="server" Enabled="false" Text="Non"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
           
        </asp:GridView>
        </asp:Panel>
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
WHERE     ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2014') AND 
                      (ESP_ETUDIANT.ETAT = 'A')
ORDER BY ESP_ETUDIANT.NOM_ET">
<SelectParameters>
                <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>

        </div>
        <br />
       <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource1" 
                AutoGenerateColumns="False" Visible="false">
           <Columns>
               <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
           </Columns>
            </asp:GridView>
        

        <br />
        <br />
            
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
            
            
            
            
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT  ESP_ETUDIANT.ID_ET
FROM         ESP_ETUDIANT,ESP_EVALUATION
WHERE     ESP_ETUDIANT.ID_ET =ESP_EVALUATION.ID_ET   AND ESP_EVALUATION.ANNEE_DEB = '2014'
                    and ESP_EVALUATION.CODE_CL = :argcl and ESP_EVALUATION.code_module=:arg and (ESP_ETUDIANT.ETAT = 'A')
">
<SelectParameters>
                <asp:ControlParameter ControlID="DDClasse" Name="argcl" 
                    PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DdlModule" Name="arg" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </div>
</div>


</asp:Content>