<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="Evaluationpardept.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.Evaluationpardept" %>
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
    .auto-style1 {
        max-width: 1170px;
        text-align: center;
        margin-left: auto;
        margin-right: auto;
        padding-left: 15px;
        padding-right: 15px;
        width: 60px;
    }
    .auto-style2 {
        width: 299px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><asp:Label ID="Label3" runat="server" Text="Label" BorderColor="Silver" 
            Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" 
            style="font-weight: 700; font-size: x-large" Width="361px"  ></asp:Label> <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager> <br /><telerik:RadComboBox ID="RadComboBox2" AutoPostBack="True" EnableLoadOnDemand="True" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="test"
                                                            
        DataTextField="NOM_ENS" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom du l'enseignant "
                                                            Filter="Contains" 
        Width="279px" Height="120px">  </telerik:RadComboBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                            SelectCommand="
select  distinct e3.id_ens,nom_ens from esp_module e1,esp_module_panier_classe_saiso e2,esp_enseignant e3,esp_up e4 where  e4.up=e3.up and e2.annee_deb=2016 and e1.code_module=e2.code_module and ((e3.id_ens=e2.id_ens) or (e3.id_ens=e2.id_ens2) or (e3.id_ens=e2.id_ens3) or (e3.id_ens=e2.id_ens4) or (e3.id_ens=e2.id_ens5)) and upper(nom_ens) not like '%AFFECTER' order by nom_ens">
                                                     <SelectParameters>
                            
                             <asp:SessionParameter Name="CODE_DEPT" SessionField="CODE_DEPT" Type="String" />
                        </SelectParameters>
                                                        </asp:SqlDataSource><br />
        
<br /><table border="1" align="center" style="align-content:center; border:groove"><tr><td>
<table style="height: 27px; width: 856px">
    <tr><td class="auto-style2">
        <table class="container" align="center">

    <%--Etablir Par Défaut:--%>
            <tr>
                <td class="style2"></td>
                <td class="auto-style1">
                    
                </td>
                <td>&nbsp;</td>
                
               
            </tr>
            <%--Classe:--%>
            <tr>
                <td class="style2"><strong><span class="text-primary">Année:</span></strong> </td>
                <td class="auto-style1"> 
            <asp:DropDownList ID="DDLAnnee" runat="server" CssClass="form-control" Height="36px" Width="350px"   OnSelectedIndexChanged="DDLAnnee_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="False">
            <%-- <asp:ListItem Selected="True" Text="Veuillez choisir une annee" Value="">
                                                </asp:ListItem>--%>
                                                 <asp:ListItem Value="0">Veuillez choisir une annee</asp:ListItem>
            <asp:ListItem>2016</asp:ListItem>
            
    </asp:DropDownList> 
       
                </td>
                <td></td>
                
                
            </tr>
            <%--Module--%>
            <tr>
                <td class="style2"><strong><span class="text-primary">Classe:</span></strong></td>
                <td class="auto-style1">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="36px" Width="350px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="false">
  <asp:ListItem Selected="True" Text="Veuillez choisir une classe" Value="">
                                                </asp:ListItem>
                                               <%--   <asp:ListItem Value="0">Veuillez choisir une classe</asp:ListItem>--%>
    </asp:DropDownList> 
       
                </td>
                <td class="style1" colspan="2">
         
                </td>
                
            </tr>
            <%--Seance--%>
            <tr>
                <td class="style2"><strong class="text-primary">Module:</strong></td>
                <td class="auto-style1">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Height="36px" Width="350px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True"  >
  
    </asp:DropDownList> 
       
        
       

                </td>
                <td></td>
              <td>   <asp:Button ID="Button1" runat="server" CssClass="btn-lg btn-primary"  OnClick="Button1_Click" Text="Valider" /></td>
            </tr>
            <%--Date seance--%>
           
         
          
            </table>
        <br />
        </td></tr></table>
<table style="height: 129px; width: 857px"><tr>

    <td><asp:GridView ID="GridView2" BorderStyle="Solid" runat="server"  BorderColor="#999999" BorderWidth="3px" CellPadding="4" CellSpacing="2" BackColor="#CCCCCC" ForeColor="Black" >
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView></td>
    <td class="auto-style2"><asp:GridView ID="GridView3" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </td>
    <td><asp:GridView ID="GridView4" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView></td>
    
          </tr></table>
    


<table align="center" style="align-items:center"><tr><td>
<p>
    <asp:Chart ID="Chart3" runat="server" Height="100px" Width="850px"  OnCustomize="SummaryChart_Customize3">
       <Series>
            <asp:Series Name="Très  insuffisant" XValueMember="crit" YValueMembers="TI"  ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#ff0000">
            </asp:Series>
            <asp:Series Name="Insuffisant" XValueMember="crit" YValueMembers="I"  ChartType="StackedBar100"  LegendToolTip="#LEGENDTEXT" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#ffccff">
            </asp:Series>
            <asp:Series Name="Suffisant" XValueMember="crit" YValueMembers="S"  ChartType="StackedBar100"  IsValueShownAsLabel="True" LabelFormat="0\%" Color="#99ccff">
            </asp:Series>
            <asp:Series Name="Bon" XValueMember="crit" YValueMembers="B"  ChartType="StackedBar100"  IsValueShownAsLabel="True" LabelFormat="0\%" Color="#0033cc">
            </asp:Series>
            <asp:Series Name="Excellent" XValueMember="crit" YValueMembers="TB"  ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#000066">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IsLabelAutoFit="False" MaximumAutoSize="60">
                </AxisX>
            </asp:ChartArea>
            
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>

</p>

<p>
    <asp:Chart ID="Chart1" runat="server" Height="288px" Width="850px" OnCustomize="SummaryChart_Customize" >
        <Series>
            <asp:Series Name="Total désaccord" XValueMember="LIB_CRITERE" YValueMembers="p1" ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#ff0000" >
               
            </asp:Series>
            <asp:Series Name="Plutôt désaccord" XValueMember="LIB_CRITERE" YValueMembers="p2" ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%"  Color="#ffccff" >
            
            </asp:Series>
            <asp:Series Name="Plutôt d'accord" XValueMember="LIB_CRITERE" YValueMembers="p3" ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#99ccff">
           
                 </asp:Series>
            <asp:Series Name="Total accord" XValueMember="LIB_CRITERE" YValueMembers="p4" ChartType="StackedBar100" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#0033cc">
            
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IsLabelAutoFit="False" MaximumAutoSize="60">
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Name="Test">
            </asp:Title>
        </Titles>
    </asp:Chart>
    </p>
<p>
    <asp:Chart ID="Chart2" runat="server"  Height="100px" Width="850px" OnCustomize="SummaryChart_Customize2">
       <Series>
            <asp:Series Name="0H" XValueMember="crit" YValueMembers="heure_0"  ChartType="StackedBar100" IsValueShownAsLabel="True"  LabelFormat="0\%" Color="#ff0000">
            </asp:Series>
            <asp:Series Name="1H" XValueMember="crit" YValueMembers="heure_1"  ChartType="StackedBar100"  LegendToolTip="#LEGENDTEXT" IsValueShownAsLabel="True" LabelFormat="0\%" Color="#ffccff">
            </asp:Series>
            <asp:Series Name="2H" XValueMember="crit" YValueMembers="heure_2"  ChartType="StackedBar100"  IsValueShownAsLabel="True" LabelFormat="0\%" Color="#99ccff">
            </asp:Series>
            <asp:Series Name="3H" XValueMember="crit" YValueMembers="heure_3"  ChartType="StackedBar100"  IsValueShownAsLabel="True" LabelFormat="0\%" Color="#0033cc">
            </asp:Series>
            <asp:Series Name="4H" XValueMember="crit" YValueMembers="heure_4"  ChartType="StackedBar100"  IsValueShownAsLabel="True" LabelFormat="0\%" Color="#000066">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IsLabelAutoFit="False" MaximumAutoSize="60">
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>
    </p>

    </td></tr></table>

<p>





    <asp:GridView  ID="GridView5" runat="server" OnRowDataBound="YourGridView_RowDataBound" Width="815px" CellPadding="4" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle HorizontalAlign="Center" BackColor="#6B696B" Font-Bold="True" ForeColor="White"  />
         <AlternatingRowStyle BackColor="White" />
         <Columns>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="PT_FORT" HeaderText="POINTS FORTS" 
                         >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
             <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  DataField="PT_FAIBLE" HeaderText="POINTS FAIBLES" 
                         >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
             <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  DataField="PROPOSITION" HeaderText="PROPOSITIONS" 
                         >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
             </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
</p>
    </td></tr></table>

                                                        <center> 
</asp:Content>
