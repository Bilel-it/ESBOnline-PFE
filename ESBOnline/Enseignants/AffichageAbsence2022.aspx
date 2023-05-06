<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="AffichageAbsence2022.aspx.cs" 
    Inherits="ESPOnline.Enseignants.AffichageAbsence" MasterPageFile="~/Enseignants/Ens.Master" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
     

      <center>
           Consulter les absences par:

          <asp:RadioButtonList runat="server" ID="rb02" AutoPostBack="True" RepeatDirection="Horizontal" AppendDataBoundItems="true"></asp:RadioButtonList>
          <asp:RadioButtonList ID="rb01" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                AppendDataBoundItems="true"
                ForeColor="Blue">

                  <asp:ListItem Text="Par formation" Value="1"></asp:ListItem>

                <asp:ListItem Text="Par groupe" Value="2"></asp:ListItem>
                <asp:ListItem Text="Par période" Value="3"></asp:ListItem>
                <asp:ListItem Text="Par Semestre" Value="4"></asp:ListItem>
                <asp:ListItem Text="Par étudiant" Value="5"></asp:ListItem>
            </asp:RadioButtonList>
      </center>
    <table>
        <tr>

              <td class="style4" align="center">Etudiant
                    <telerik:RadComboBox ID="DropDownList1" runat="server"
                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="cc"
                        DataValueField="ID_ET" DropDownWidth="500"
                        EmptyMessage="Tappez le Nom d'etudiant " EnableLoadOnDemand="True"
                        Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400"
                        ShowMoreResultsBox="False" Width="300" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </telerik:RadComboBox>


                    
                </td>

                <td class="style4" align="center">Classe
                    <telerik:RadComboBox ID="DropDownList2" runat="server"
                        AutoPostBack="True" DataSourceID="SqlDataSource11" DataTextField="code_cl"
                        DataValueField="code_cl" DropDownWidth="500"
                        EmptyMessage="Tappez la classe " EnableLoadOnDemand="True"
                        Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400"
                        ShowMoreResultsBox="False" Width="300" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>

            <td>
                Semestre
                 <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="RadioButtonList3_SelectedIndexChanged"  >
                                                            <asp:ListItem Value="1" Selected="True"  >Semestre 1</asp:ListItem>
                                                            <asp:ListItem Value="2"  >Semestre 2</asp:ListItem>
                                                       
                                                        </asp:RadioButtonList>

            </td>
            
            <td class="style2">
                <strong class="text-primary">Date début:</strong></td>
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
                       
            &nbsp;<asp:Label ID="Label2" runat="server" Text="" CssClass="style11"></asp:Label>                         </div>
            </td>
           
         <td class="style2">
                <strong class="text-primary">Date fin:</strong></td>
            <td class="style9">
            <div class="form-group">
            
           
                <telerik:RadDatePicker runat="server"  ID="RadDatePicker1" Width="99%"  
                    AutoPostBack="true"  Height="37px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy" 
                        DisplayDateFormat="dd/MMM/yy"  Height="37px">
                  
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                      
            &nbsp;<asp:Label ID="Label1" runat="server" Text="" CssClass="style11"></asp:Label>                         </div>
            </td>
           
        </tr>

    </table>
             <strong>
             <asp:Button  CssClass="btn-lg btn-primary" ID="BtnCreer" runat="server" 
                    Text="Rechercher" onclick="Button1_Click" Width="197px" Height="54px" style="color: #FFFFFF; background-color: #800000" />
        
                    </strong>
        
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="SELECT trim(t1.id_et)||'    '|| trim(t1.NOM_ET)||'        '||trim(t1.PNOM_ET)||'       '||trim(t1.NUM_CIN_PASSEPORT)||'       '||trim(t2.code_cl)  cc,trim(t1.ADRESSE_MAIL_ESP) ,t1.ID_ET FROM ESP_ETUDIANT t1,esp_inscription t2,SOCIETE t3  
where t2.annee_deb=t3.ANNEE_DEB and t2.id_et=t1.id_et  and ETAT='A'
      "></asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource11" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="SELECT distinct code_cl from esp_inscription where annee_deb=(select max(annee_deb) from societe) ORDER BY CODE_CL
      "></asp:SqlDataSource> 
</div>


</asp:Content>