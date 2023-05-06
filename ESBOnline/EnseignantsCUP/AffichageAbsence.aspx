<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="AffichageAbsence.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.AffichageAbsence" %>
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
    .style11
    {
        max-width: 1170px;
        text-align: center;
        margin-left: auto;
        margin-right: auto;
        padding-left: 15px;
        padding-right: 15px;
        width: 98px;
    }
    .style12
    {
        color: #428bca;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 
 
             

    <div class="container" style="margin-top:12%">
    <div class="row">

   <div class="col-lg-4">
      
       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>

    
      
        <br />

    
    <table class="container" style="width: 100%;">

    <%--Etablir Par Défaut:--%>
        <tr>
            <td class="style2">
                
                </td>
            <td class="style9"  >
           
                <strong class="text-primary">Trier Par:</strong><br />
                <br />
&nbsp;<strong class="radio-inline" ><asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem >Tous</asp:ListItem>
                    <asp:ListItem >Par Classe</asp:ListItem>
                    <asp:ListItem >Par Module</asp:ListItem>
                    <asp:ListItem >Par Etudiant</asp:ListItem>

                </asp:RadioButtonList>

               
                <br />

               
                <asp:Button  CssClass="btn-lg btn-primary" ID="BtnCreer" runat="server" 
                    Text="Rechercher" onclick="Button1_Click" Width="180px" />

               
                <br />
                <br />
                <br />
                <br />
                <br />

               
                </strong>
            </td>
            <td class="style12">
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
            DataValueField="CODE_CL" onselectedindexchanged="DDClasse_SelectedIndexChanged" 
                    Width="201px" Visible="False">
            <asp:ListItem Text="All Countries" Value="" />
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetListN" TypeName="ABSEsprit.Classes" 
                    OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="ID_ENS" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </td>
            <td class="style12">
                <strong><span 
                    class="text-muted">
               &nbsp;<%-- <input type="radio" name="group2" value="S3" id="tous" class="radio-inline"> S1</input>
                <input type="radio" name="group2" value="S4" class="radio-inline"> S2</input>--%></span></strong><span class="style6"><strong class="collapse">Semestre :</strong></span></td>
            
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
                    onselectedindexchanged="DdlModule_SelectedIndexChanged" Width="199px" 
                    Visible="False">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetListN" TypeName="ABSEsprit.Modules" 
                    OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="ID_ENS" Type="String" />
                <asp:ControlParameter ControlID="DDClasse" Name="codcl" 
                    PropertyName="SelectedValue" Type="String" />
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
                <strong class="text-primary">Etudiant:</strong></td>
            <td class="style9">
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataTextField="NOM_ET"
                                    DataValueField="ID_ET" AutoPostBack="True" 
                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="200px" 
                                    Visible="False">
                                </asp:DropDownList>
                                <asp:ListSearchExtender ID="DropDownList3_ListSearchExtender" runat="server" 
                                    Enabled="True" TargetControlID="DropDownList3">
                                </asp:ListSearchExtender>
            </td>
            <td>
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
               </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <span __designer:mapid="10a">Nombre d&#39;absence :
                <asp:Label ID="Label7" runat="server" style="font-weight: 700"></asp:Label>
                </span>
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
            <td>
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="2">
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style2">
                
                </td>
            <td class="style9">
                &nbsp;</td>
            <td>
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
        
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged1">
                    <Columns>
                        <asp:BoundField DataField="ID_ET" HeaderText="Nom et Prénom" SortExpression="ID_ET" />
                        <asp:BoundField DataField="CODE_CL" HeaderText="Classe" 
                            SortExpression="CODE_CL" />
                        <asp:BoundField DataField="CODE_MODULE" HeaderText="Nom Module" 
                            SortExpression="CODE_MODULE" ReadOnly="True" />
                        <asp:BoundField DataField="DATE_SEANCE" HeaderText="Date Séance" 
                            SortExpression="DATE_SEANCE"  dataformatstring="{0:d MMMM yyyy}" />
                        <asp:BoundField DataField="NUM_SEANCE" HeaderText="Heure Séance" 
                            SortExpression="NUM_SEANCE" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT (select NOM_ET || ' ' || PNOM_ET from ESP_ETUDIANT where ID_ET=ESP_ABSENCE_NEW.ID_ET)as ID_ET, CODE_CL, (select DESIGNATION from ESP_MODULE where code_module=ESP_ABSENCE_NEW.CODE_MODULE)AS CODE_MODULE, DATE_SEANCE, NUM_SEANCE FROM ESP_ABSENCE_NEW WHERE ((ID_ENS = :argidens ) ) and annee_deb='2015'  order by to_date(date_seance,'dd/MM/yy') DESC  " FilterExpression="CODE_CL = '{0}' ">
                  <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="argidens"/>
                   
                    </SelectParameters>
           <FilterParameters>
            <asp:ControlParameter ControlID="DDClasse" Name="CODE_CL" 
                    PropertyName="SelectedValue"  />
                 
           </FilterParameters>
                </asp:SqlDataSource>
                </div>
                
               </div>
        
        <br />

        <br />
        <br />

    </div>
    </div>
</div>


</asp:Content>