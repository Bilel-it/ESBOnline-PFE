<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="absaffich2022.aspx.cs" Inherits="ESPOnline.Enseignants.absaffich2022" 
    MasterPageFile="~/Enseignants/Ens.Master" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>
     <center>
           Consulter les absences par:

         
          <asp:RadioButtonList ID="rb01" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                AppendDataBoundItems="true"
                ForeColor="Blue" OnSelectedIndexChanged="rb01_SelectedIndexChanged">

                  <asp:ListItem Text="Par formation" Value="1"></asp:ListItem>

                <asp:ListItem Text="Par groupe" Value="2"></asp:ListItem>
                <asp:ListItem Text="Par période" Value="3"></asp:ListItem>
                <asp:ListItem Text="Par Semestre" Value="4"></asp:ListItem>
                <asp:ListItem Text="Par étudiant" Value="5"></asp:ListItem>
            </asp:RadioButtonList>
      </center>

    <center>

    <div runat="server" id="Div5" visible="false">
        Liste des absences par étudiant
        <telerik:RadComboBox ID="DropDownList1" runat="server"
                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="cc"
                        DataValueField="ID_ET" DropDownWidth="500"
                        EmptyMessage="Tappez le Nom d'etudiant " EnableLoadOnDemand="True"
                        Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400"
                        ShowMoreResultsBox="False" Width="300" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </telerik:RadComboBox>

       </div>
    <div runat="server" id="Div2" visible="false">
        Liste des absences par groupe
        </div>
    <div runat="server" id="Div1" visible="false">
         Liste des absences par formation
        <telerik:RadComboBox ID="DropDownList2" runat="server"
                        AutoPostBack="True" DataSourceID="SqlDataSource11" DataTextField="code_cl"
                        DataValueField="code_cl" DropDownWidth="500"
                        EmptyMessage="Tappez la classe " EnableLoadOnDemand="True"
                        Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400"
                        ShowMoreResultsBox="False" Width="300" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged">
                    </telerik:RadComboBox>
        </div>
    <div runat="server" id="Div4" visible="false">
         Liste des absences par semestre
                 <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="RadioButtonList3_SelectedIndexChanged"  >
                                                            <asp:ListItem Value="1" Selected="True"  >Semestre 1</asp:ListItem>
                                                            <asp:ListItem Value="2"  >Semestre 2</asp:ListItem>
                                                       
                                                        </asp:RadioButtonList>
        </div>
    <div runat="server" id="Div3" visible="false">
          Liste des absences par période
        <br />
        Date début:
       
           
                <telerik:RadDatePicker runat="server"  ID="TBdateseance" Width="99%"  
                    AutoPostBack="true"  Height="37px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy" 
                        DisplayDateFormat="dd/MMM/yy"  Height="37px">
                  
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                       
            &nbsp;<asp:Label ID="Label2" runat="server" Text="" CssClass="style11"></asp:Label> 
        
                      Date fin:
       
           
                <telerik:RadDatePicker runat="server"  ID="TBdateseance2" Width="99%"  
                    AutoPostBack="true"  Height="37px" OnSelectedDateChanged="RadDatePicker1_SelectedDateChanged">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy" 
                        DisplayDateFormat="dd/MMM/yy"  Height="37px">
                  
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                       
            &nbsp;<asp:Label ID="Label1" runat="server" Text="" CssClass="style11"></asp:Label> 
        
                                 


    </div>

        </center>

    <div>

      <%--  ici different gridviews--%>
        <br />
        <center>
            <asp:Label runat="server" Visible="false" ID="lbltitle" ForeColor="Green"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  Visible="false"
                    DataKeyNames="ID_ET"   Style="border-bottom: white 2px ridge;
                    border-left: white 2px ridge; background-color: white; border-top: white 2px ridge;
                    border-right: white 2px ridge;" BorderWidth="0px" BorderColor="White" CellSpacing="1"
                    CellPadding="3" CssClass="grid" GridLines="Both" RowStyle-CssClass="ItemStyle"
                    HeaderStyle-CssClass="FixedHeaderStyle" EmptyDataRowStyle-CssClass="ItemStyle"
                   >
                    <EmptyDataTemplate>
                        Pas d'enregistrement.
                    </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="#CC0000"
                        ForeColor="White" />
                    <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                    <FooterStyle CssClass="ItemStyle" />
                    <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                    <RowStyle CssClass="GridItemStyle" />
                    <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <Columns>
                       
                        <asp:BoundField DataField="ID_ET" HeaderText="Matricule" SortExpression="ID_ET"
                          />
                        <asp:BoundField DataField="NOM_et" HeaderText="Nom" SortExpression="NOM_et" />
                      
                         <asp:BoundField DataField="pNOM_et" HeaderText="Prénom" SortExpression="pNOM_et" />

                         <asp:BoundField DataField="code_cl" HeaderText="Formation" SortExpression="code_cl" />

                         <asp:BoundField DataField="Date_seance" HeaderText="Date séance" SortExpression="Date_seance" />
                      
                       <asp:BoundField DataField="Heure" HeaderText="Heure" SortExpression="Heure" />
                       <asp:BoundField DataField="Module" HeaderText="Module" SortExpression="Module" />
                      


                    </Columns>
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <AlternatingRowStyle BackColor="#d2c1bf" />
                </asp:GridView>
            </center>
    </div>

    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="SELECT trim(t1.id_et)||'    '|| trim(t1.NOM_ET)||'        '||trim(t1.PNOM_ET)
||'       '||trim(t1.NUM_CIN_PASSEPORT)||'       '||trim(t2.code_cl)  cc,
trim(t1.ADRESSE_MAIL_ESP) 
,t1.ID_ET FROM ESP_ETUDIANT t1,esp_inscription t2,SOCIETE t3  
where t2.annee_deb=t3.ANNEE_DEB and t2.id_et=t1.id_et  and ETAT='A'  
and code_cl in (select code_cl from ESP_MODULE_PANIER_CLASSE_SAISO 
where annee_deb =(select max(annee_deb) from societe) and id_ens =:arget1)
      ">

          <SelectParameters>
               
          
               
                <asp:ControlParameter ControlID="Label2" Name="argidet" 
                    PropertyName="Text" DefaultValue="" />
                    
               
                 
            
                </SelectParameters>

    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource11" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                        SelectCommand="select distinct code_cl from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb) from societe)  and id_ens =:argidet
      ">



                           <SelectParameters>
               
          
               
                <asp:ControlParameter ControlID="Label1" Name="argidet" 
                    PropertyName="Text" DefaultValue="" />
                    
               
                 
            
                </SelectParameters>

                    </asp:SqlDataSource> 

 </asp:Content>