<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="absenceetudiant.aspx.cs" Inherits="ESPOnline.Direction.absenceetudiant" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Contents/jquery.notifyBar.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Contents/Scripts/jquery.notifyBar.js" type="text/javascript"></script>
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #F78181;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .Grid th
        {
            background-color: #FE2E2E;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .GridViewEditRow input[type=text]
        {
            width: 50px;
        }
        /* size textboxes */
        .GridViewEditRow select
        {
            width: 90px;
        }
    </style>
    <style type="text/css">
        .footer td
        {
            border: none;
        }
        .table td
        {
            border: none;
        }
        .footer tr
        {
            border: none;
        }
        .footer th
        {
            border: none;
        }
    </style>
    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=gvue.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script> 
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script> 
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Contents/Img/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Contents/Img/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <center>
         
        <asp:Label ID="Label18" runat="server" Text="SUIVI DES ABSENCES PAR ETUDIANT"
            Font-Bold="True" Font-Italic="True" Font-Names="Bookman Old Style" Font-Size="X-Large"
            Width="634px" ForeColor="#CC0000"></asp:Label>
       <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadComboBox ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
            AutoPostBack="True" DataTextField="NOM" DataValueField="ID_ET" EmptyMessage="Tappez le Nom d'etudiant "
         onselectedindexchanged="RadComboBox1_SelectedIndexChanged"   Filter="Contains" Width="400px" Height="100px">
        </telerik:RadComboBox> <br />
        <asp:Label ID="Label19" runat="server" style="color: #33CC33" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label1" runat="server" style="color: #33CC33" Text=""  ></asp:Label>
         <asp:Label ID="Label2" runat="server" style="color: #33CC33" Text="" Visible="false"></asp:Label>
          <asp:Label ID="Label3" runat="server" style="color: #33CC33" Text="" Visible="false">Nombre:</asp:Label>
        <asp:Label ID="Label22" runat="server" style="color: #33CC33" Text="" 
            Visible="false"></asp:Label>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="SELECT NOM_ET||' '||PNOM_ET || ' '||ESP_ETUDIANT.ID_ET ||'  '|| esp_inscription.code_cl as NOM, ESP_ETUDIANT.ID_ET as ID_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE (ESP_INSCRIPTION.ID_ET=ESP_ETUDIANT.ID_ET )AND (ESP_INSCRIPTION.ANNEE_deb=2018) and upper(code_cl)not like 'MP%' and upper(code_cl) not like 'PS%'  order by NOM ,code_cl">
        </asp:SqlDataSource>
        <span style='font-size: 15pt'> 
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            
            SelectCommand="select t1.*,t3.nom_ens ,t4.DESIGNATION,(select t5.LIB_NOME from CODE_NOMENCLATURE t5 where t5.CODE_NOME=t1.NUM_SEANCE and t5.CODE_STR='60' ) seance from ESP_ABSENCE_NEW t1,societe t2,ESP_ENSEIGNANT t3,esp_module t4 where t1.annee_deb=t2.annee_deb and t3.id_ens=t1.id_ens AND T1.id_et=:idet and t4.CODE_MODULE=t1.CODE_MODULE ">
            <SelectParameters><asp:ControlParameter ControlID="DropDownList1" Name="idet" PropertyName="SelectedValue"
                    Type="String" /></SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            
            SelectCommand="select nbb,nom_et,pnom_et,code_cl from (select count (*)nbb,id_et from (select count(*),DATE_SEANCE,id_et from ESP_ABSENCE_NEW where to_char(DATE_SEANCE,'dd-MON-YY')>= to_char(:datee,'dd-MON-YY')   and   annee_deb=2018 group by DATE_SEANCE,id_et)group by id_et) t1,esp_etudiant t2,esp_inscription t3  where t1.id_et=t2.id_et and t3.annee_deb=2018 and t3.id_et=t2.id_et and t2.etat='A' and  nbb&gt; :nb order by nom_et ">
            <SelectParameters>
             <asp:ControlParameter ControlID="TBdateseance" Name="datee"   DefaultValue='01/09/16'
                   PropertyName="SelectedDate" Type="DateTime" />
            <asp:ControlParameter ControlID="Label2" Name="nb" PropertyName="Text"
                    Type="String" />
                   
                    
                    </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            
            SelectCommand="select count(*) from (select count (*)nbb,id_et from (select count(*),DATE_SEANCE,id_et from ESP_ABSENCE_NEW where   annee_deb=2018 group by DATE_SEANCE,id_et)group by id_et) t1,esp_etudiant t2  where t1.id_et=t2.id_et and  nbb&gt;=:nb ">
            <SelectParameters><asp:ControlParameter ControlID="Label2" Name="nb" PropertyName="Text"
                    Type="String" /></SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            
            
            SelectCommand="select count(distinct DATE_SEANCE) from ESP_ABSENCE_NEW where annee_deb=2018 and id_et=:idet ">
<SelectParameters><asp:ControlParameter ControlID="DropDownList1" Name="idet" PropertyName="SelectedValue" DefaultValue=''
                    Type="String" /></SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" BackColor="#CCCCCC" 
            CssClass="text-info" ForeColor="Black" Height="27px" onclick="BuTT2_Click" 
            Text="Exporter en excel" />
        <br />
        <asp:GridView ID="gvue" runat="server" AutoGenerateColumns="false"  DataSourceID="SqlDataSource2"
            CssClass="Grid"    
          >
            <Columns>
             <asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE"
                    SortExpression="DATE_SEANCE" DataFormatString="{0:d}"/>
                     <asp:BoundField DataField="seance" HeaderText="séance"
                    SortExpression="seance" />
                    
                    <asp:BoundField DataField="DESIGNATION" HeaderText="Module"
                    SortExpression="DESIGNATION" />
                 
                     <asp:BoundField DataField="NOM_eNS" HeaderText="Enseignant"
                    SortExpression="NOM_ens" />
                   
                          <asp:BoundField DataField="Justification" HeaderText="Justification"
                    SortExpression="Justification" />
                         
            </Columns>
            
        </asp:GridView>
         
        <asp:Label ID="Label21" runat="server" Text="SUIVI DES ABSENCES CUMULÉES"
            Font-Bold="True" Font-Italic="True" Font-Names="Bookman Old Style" Font-Size="X-Large"
            Width="634px" ForeColor="#CC0000"></asp:Label>
         
        <br />
        <telerik:RadNumericTextBox RenderMode="Lightweight" runat="server" 
            ID="RadNumericTextBox1" Width="88px" Value="1"   MinValue="0"  
            ShowSpinButtons="true" NumberFormat-DecimalDigits="0" Height="36px"></telerik:RadNumericTextBox>
       <telerik:RadDatePicker runat="server"  ID="TBdateseance" Width="20%"  
                    AutoPostBack="true"  Height="37px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput ToolTip="Date input" DateFormat="dd/MM/yy" 
                        DisplayDateFormat="dd/MMM/yy"  Height="37px">
                  
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
        <asp:Button ID="Button1" runat="server" Text="Rechercher" OnClick="test" />
        <asp:Button ID="Button3" runat="server" BackColor="#CCCCCC" 
            CssClass="text-info" ForeColor="Black" Height="27px" onclick="BuTT_Click" 
            Text="Exporter en excel" Width="88px" />
        <br />
        </nb>Nombre:
        <asp:Label ID="Label20" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  DataSourceID="SqlDataSource3"
            CssClass="Grid"    
          >
            <Columns>
             <asp:BoundField DataField="nom_et" HeaderText="nom"
                    SortExpression="nom_et" />
                    <asp:BoundField DataField="pnom_et" HeaderText="prenom"
                    SortExpression="pnom_et" />
                     <asp:BoundField DataField="nbb" HeaderText="Nombre absence"
                    SortExpression="nbb" />
                      <asp:BoundField DataField="code_cl" HeaderText="Classe"
                    SortExpression="code_cl" />
            </Columns></asp:GridView>
        </center></asp:Content>