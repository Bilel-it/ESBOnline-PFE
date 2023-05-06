<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="stat.aspx.cs" Inherits="ESPOnline.Direction.stat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <style type="text/css"> 
         .style101
        {
            width: 273px;
            border-color:black;
        }
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 44px;
        }
        .style5
        {
            width: 44px;
            height: 222px;
        }
        .style7
        {
            width: 266px;
            height: 222px;
        }
        .style8
        {
            height: 222px;
        }
        .style13
        {
            width: 44px;
            height: 188px;
        }
        .style14
        {
            width: 273px;
            height: 188px;
        }
        .style15
        {
            width: 266px;
            height: 188px;
        }
        .style16
        {
            height: 188px;
        }
        .style17
        {
            width: 89px;
        }
        .style19
        {
            height: 188px;
            width: 89px;
        }
        .style20
        {
            height: 222px;
            width: 89px;
        }
        .style102
        {
            width: 273px;
        }
        .style103
        {
            width: 266px;
        }
        tr.rowhighlight td, tr.rowhighlight th{
    background-color:#f0f8ff;
}
        .style104
        {
            width: 44px;
            height: 5px;
        }
        .style105
        {
            width: 273px;
            height: 5px;
        }
        .style106
        {
            width: 266px;
            height: 5px;
        }
        .style107
        {
            width: 89px;
            height: 5px;
        }
        .style108
        {
            height: 5px;
        }
        .style109
        {
            width: 88px;
        }
        .style110
        {
            width: 88px;
            height: 5px;
        }
        .style111
        {
            height: 188px;
            width: 88px;
        }
        .style112
        {
            height: 222px;
            width: 88px;
        }
        .style113
        {
            width: 20px;
        }
        .style114
        {
            height: 5px;
            width: 20px;
        }
        .style115
        {
            height: 188px;
            width: 20px;
        }
        .style116
        {
            height: 222px;
            width: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <table class="style1">
        <tr >
            <td class="style4">
                &nbsp;</td>
             
            <td class="style102">
                &nbsp;</td>
            <td class="style103">
                <table class="style1">
                    <tr>
                        <td rowspan="2" 
                            
                            style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            &nbsp;</td>
                        <td colspan="3" 
                            
                            style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;" 
                            valign="middle">
                            EM</td>
                        <td colspan="3" 
                            
                            style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            GC</td>
                        <td colspan="3" 
                            
                            style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            TIC</td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            1</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            2</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            3</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            1</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            2</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            3</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            1</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            2</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            3</td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            Candidats</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label15" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label16" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label17" runat="server"  BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label18" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label19" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label20" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label21" runat="server"  BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label22" runat="server" BackColor="White" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label23" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            Testés</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label24" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label25" runat="server" BackColor="White" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label26" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label27" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label28" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label29" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label30" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label31" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label32" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            Admis</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label33" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label34" BackColor="White"  runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label35" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label36" BackColor="White"  runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label37" BackColor="White"  runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label38" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label39" runat="server"  BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label40" runat="server"  BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label41" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            LA</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label42" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label43" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label44" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label45" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label46" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label47" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label48" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label49" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label50" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            Rejets</td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label51" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label52" BackColor="White"  runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label53" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label54" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label55" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label56" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label57" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label58" runat="server" BackColor="White"  Text="Label"></asp:Label>
                        </td>
                        <td style="border-style: solid; background-color: #FFFFFF; border-collapse: collapse;">
                            <asp:Label ID="Label59" runat="server"  BackColor="White"  Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style103">
                &nbsp;</td>
        </tr>
        <tr BGCOLOR="#A9A9F5">
            <td >
                &nbsp;</td>
            <td class="style101">
                Répartition par specialite,niveau&nbsp; CJ 2017</td>
            <td class="style103">
                Répartition par specialite,niveau CS 2017</td>
            <td class="style103">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style17" BGCOLOR="#F5A9F2">
                Redoublement en licence</td>
            <td class="style109">
                Candidats liscence CJ</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                Candidats Prépa CJ</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td gcolor="#5882FA">
                Non licence ou Non Prepa</td>
            <td gcolor="#5882FA" class="style113">
                &nbsp;</td>
            <td BGCOLOR="#00BFFF">
                BAC SC. ECO</td>
        </tr>
        <tr BGCOLOR="#5882FA">
            <td >
                &nbsp;</td>
            <td class="style101">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                             <asp:BoundField DataField="NB" HeaderText="NB"    
                                  ReadOnly="True" SortExpression="NB"
                        />
                         <asp:BoundField DataField="SPE" HeaderText="SPE"    
                                  ReadOnly="True" SortExpression="SPE"
                        />
                              <asp:BoundField DataField="NIV_AC" HeaderText="NIV_AC" 
                                  SortExpression="NIV_AC" />
                        </Columns>
                           <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Font-Bold="True" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT count(*) as NB,(  case when SPECIALITE_ESP_ET='05' then 'TIC' when  SPECIALITE_ESP_ET='04' then 'EM' when  SPECIALITE_ESP_ET='03' then 'GC' END) AS SPE,
NIVEAU_ACCES AS NIV_AC from esp_etudiant where id_et like '15%J%' and (NIVEAU_ACCES=1 or NIVEAU_ACCES=3 or niveau_acces=2)
group by NIVEAU_ACCES,SPECIALITE_ESP_ET order by NIVEAU_ACCES"></asp:SqlDataSource>
            </td>
            <td class="style103">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource4">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB"  
                            ReadOnly="True" SortExpression="NB" />
                        <asp:BoundField DataField="SPE" HeaderText="SPE"  
                            ReadOnly="True" SortExpression="SPE" />
                        <asp:BoundField DataField="NIV_AC" HeaderText="NIV_AC" 
                            SortExpression="NIV_AC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                    SelectCommand="SELECT count(*) as NB,(  case when SPECIALITE_ESP_ET='05' then 'TIC' when (SPECIALITE_ESP_ET='01' or SPECIALITE_ESP_ET='02') then 'TIC'   when  SPECIALITE_ESP_ET='04' then 'EM' when  SPECIALITE_ESP_ET='03' then 'GC' END) AS SPE,
NIVEAU_ACCES AS NIV_AC from esp_etudiant where id_et like '15%S%' and (NIVEAU_ACCES=1 or NIVEAU_ACCES=3 or  NIVEAU_ACCES=2 )
group by NIVEAU_ACCES,(  case when SPECIALITE_ESP_ET='05' then 'TIC' when (SPECIALITE_ESP_ET='01' or SPECIALITE_ESP_ET='02') then 'TIC'   when  SPECIALITE_ESP_ET='04' then 'EM' when  SPECIALITE_ESP_ET='03' then 'GC' END)"></asp:SqlDataSource>
            </td>
            <td class="style103">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style17">
                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource8">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ItemStyle-Width="50%" 
                            ReadOnly="True" SortExpression="NB" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" ItemStyle-Width="50%" 
                            ReadOnly="True" SortExpression="ANNEE" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                     
                <br />
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="select nb ,annee from (select count(*) NB,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe) end
 
 ) as annee from esp_etudiant where (id_et like '15%'   or id_et like '14%'  ) and  ((ANNEE_DIPLOME-ANNEE_BAC)&lt;3 ) and annee_bac&lt; annee_diplome  group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
    end)
union 
select count(*) NB,(case
 when id_et like '13%'  then '2013' 
   end) as annee from esp_etudiant where ( id_et like '13%'  ) and  ((ANNEE_DIPLOME-ANNEE_BAC)&lt;3 ) and ANNEE_DIPLOME is not null and annee_bac&lt; annee_diplome and ANNEE_BAC is not null group by (case  
 when id_et like '13%'  then '2013' 
     end)) order by annee"></asp:SqlDataSource>
            </td>
            <td class="style109">
                <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                    
                    SelectCommand="select (case  when SPECIALITE_ESP_ET like '04'  then 'EM' when SPECIALITE_ESP_ET like '05'  then 'TIC' when SPECIALITE_ESP_ET like '03'  then 'GC' END)SPECIALITE_ESP_ET, count(*) from esp_etudiant where id_et like '15%J%' and NIVEAU_ACCES=3 and upper(DIPLOME_SUP_ET) like '%LIC%' and   DIPLOME_SUP_ET not like 'Attestation de réussite' group by SPECIALITE_ESP_ET "></asp:SqlDataSource>
                <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource12">
                    <Columns>
                        <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE"  
                            ReadOnly="True" SortExpression="SPECIALITE_ESP_ET" />
                        <asp:BoundField DataField="COUNT(*)" HeaderText="NB"  
                            ReadOnly="True" SortExpression="COUNT(*)" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                    
                    
                    SelectCommand="select  (case  when SPECIALITE_ESP_ET like '04'  then 'EM' when SPECIALITE_ESP_ET like '05'  then 'TIC' when SPECIALITE_ESP_ET like '03'  then 'GC' END)SPECIALITE_ESP_ET,NIVEAU_ACCES, count(*) from esp_etudiant where id_et like '15%J%' and DIPLOME_SUP_ET='Attestation de réussite' group by SPECIALITE_ESP_ET,niveau_acces"></asp:SqlDataSource>
                <asp:GridView ID="GridView13" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource13">
                    <Columns>
                        <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE"  
                            ReadOnly="True" SortExpression="SPECIALITE_ESP_ET" />
                              <asp:BoundField DataField="niveau_acces" HeaderText="niveau"  
                            ReadOnly="True" SortExpression="niveau_acces" />
                        <asp:BoundField DataField="COUNT(*)" HeaderText="NB"  
                            ReadOnly="True" SortExpression="COUNT(*)" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td gcolor="#FF0000">
                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource7">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB"  
                            ReadOnly="True" SortExpression="NB" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE"  
                            ReadOnly="True" SortExpression="ANNEE" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                    SelectCommand="SELECT COUNT(*) NB,(CASE WHEN id_et LIKE '14%' then '2014' WHEN id_et LIKE '15%' then (select max (annee_deb)  from societe) WHEN id_et LIKE '13%' then '2013' WHEN id_et LIKE '12%' then '2012' WHEN id_et LIKE '11%' then '2011' END) annee ,NIVEAU_ACCES AS niv_ac FROM esp_etudiant WHERE NIVEAU_ACCES IN('1','2','3') AND (id_et LIKE '14%' OR id_et LIKE '15%' OR id_et LIKE '13%' OR id_et LIKE '12%' OR id_et LIKE '12%'OR id_et LIKE '11%') GROUP BY NIVEAU_ACCES, (CASE WHEN id_et LIKE '14%' then '2014' WHEN id_et LIKE '15%' then (select max (annee_deb)  from societe) WHEN id_et LIKE '13%' then '2013' WHEN id_et LIKE '12%' then '2012' WHEN id_et LIKE '11%' then '2011' END) ORDER BY annee,NIVEAU_ACCES"></asp:SqlDataSource>
            </td>
            <td gcolor="#FF0000" class="style113">
                &nbsp;</td>
            <td gcolor="#FF0000">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                             <asp:BoundField DataField="NB" HeaderText="NB"   ItemStyle-Width="50%"
                        />
                         <asp:BoundField DataField="ANNEE" HeaderText="ANNEE"   ItemStyle-Width="50%"
                        />
                        </Columns>
                           <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Font-Bold="True" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView><asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" ShowHeader="False"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                           <asp:BoundField DataField="NB" HeaderText="NB"  ItemStyle-Width="64%"
                        />    
                        <asp:TemplateField HeaderText="annee" SortExpression="annee"  ItemStyle-Width="63%">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='2017'></asp:Label>
                            </ItemTemplate></asp:TemplateField>
                      
                        </Columns>
                           <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Font-Bold="True" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView></td>
        </tr>
        <tr>
            <td class="style104">
                </td>
            <td class="style105">
                </td>
            <td class="style106">
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="select count(*) NB,niveau_acces,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end) annee ,
  (case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END) NAT_BAC from esp_etudiant where NIVEAU_ACCES='01' 
and (id_et like '14%' or id_et like '15%' or id_et like '13%' or id_et like '12%') group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end),(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END),niveau_acces  order by annee
"></asp:SqlDataSource>
                </td>
            <td class="style106">
                &nbsp;</td>
            <td class="style107">
                </td>
            <td class="style107">
                </td>
            <td class="style110">
                </td>
            <td class="style110">
                &nbsp;</td>
            <td class="style110">
                &nbsp;</td>
            <td class="style110">
                &nbsp;</td>
            <td class="style110">
                &nbsp;</td>
            <td class="style110">
                &nbsp;</td>
            <td class="style110">
                &nbsp;</td>
            <td class="style108">
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="select count(*) as nb ,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%' then '2011'    end) annee  from esp_etudiant where NIVEAU_ACCES='03' and     (id_et like '14%' or id_et like '15%' or id_et like '13%' or id_et like '12%' or id_et like '11%')and (ETAB_ORIGINE like '%AUTRE%' or ETAB_ORIGINE like '%ISSAT%' or upper(ETAB_ORIGINE) like '%INSAT%' or UPPER(ETAB_ORIGINE )like '%ISI%') group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012' when id_et like '11%' then '2011'        end) order by annee
 "></asp:SqlDataSource>
                </td>
            <td class="style114">
                &nbsp;</td>
            <td class="style108">
                </td>
        </tr>
        <tr bgcolor="#DA81F5">
            <td  class="style4">
                </td>
            <td   class="style102">
                Nb candidats en 1ère, 2ème , 3ème</td>
            <td class="style103">
 
    
                    
                </td>
            <td class="style103">
 
    
                    
                &nbsp;</td>
            <td class="style17">
                </td>
            <td class="style17">
                Nb candidats en 4 eme</td>
            <td class="style109">
                </td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td class="style109">
                &nbsp;</td>
            <td>
                <br />
                Nb candidats en 1ère année
            <td class="style113">
                &nbsp;</td>
            <td>
                </td>
        </tr>
        <tr bgcolor="#DA81F5">
            <td  class="style13">
                </td>
            <td   class="style14">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource5" 
                    Width="286px">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                            SortExpression="NB" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" ReadOnly="True" 
                            SortExpression="ANNEE" />
                        <asp:BoundField DataField="NIV_AC" HeaderText="NIV_AC" 
                            SortExpression="NIV_AC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
            <td class="style15">
 
    
                    
                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource9">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                            SortExpression="NB" />
                        <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU_ACCES" 
                            SortExpression="NIVEAU_ACCES" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" 
                            SortExpression="ANNEE" ReadOnly="True" />
                        <asp:BoundField DataField="NAT_BAC" HeaderText="NAT_BAC" ReadOnly="True" 
                            SortExpression="NAT_BAC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
 
    
                    
                </td>
            <td class="style15">
 
    
                    
                &nbsp;</td>
            <td class="style19">
                </td>
            <td class="style19">
                <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource11">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                            SortExpression="NB" />
                        <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU_ACCES" 
                            SortExpression="NIVEAU_ACCES" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" 
                            SortExpression="ANNEE" ReadOnly="True" />
                        <asp:BoundField DataField="NAT_BAC" HeaderText="NAT_BAC" ReadOnly="True" 
                            SortExpression="NAT_BAC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
            <td class="style111">
                </td>
            <td class="style111">
                &nbsp;</td>
            <td class="style111">
                &nbsp;</td>
            <td class="style111">
                &nbsp;</td>
            <td class="style111">
                &nbsp;</td>
            <td class="style111">
                &nbsp;</td>
            <td class="style111">
                &nbsp;</td>
            <td class="style16">
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource6">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                            SortExpression="NB" />
                        <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU_ACCES" 
                            SortExpression="NIVEAU_ACCES" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" 
                            SortExpression="ANNEE" ReadOnly="True" />
                        <asp:BoundField DataField="NAT_BAC" HeaderText="NAT_BAC" ReadOnly="True" 
                            SortExpression="NAT_BAC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <br />
                </td>
            <td class="style115">
                &nbsp;</td>
            <td class="style16">
                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SqlDataSource10">
                    <Columns>
                        <asp:BoundField DataField="NB" HeaderText="NB" ReadOnly="True" 
                            SortExpression="NB" />
                        <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU_ACCES" 
                            SortExpression="NIVEAU_ACCES" />
                        <asp:BoundField DataField="ANNEE" HeaderText="ANNEE" 
                            SortExpression="ANNEE" ReadOnly="True" />
                        <asp:BoundField DataField="NAT_BAC" HeaderText="NAT_BAC" ReadOnly="True" 
                            SortExpression="NAT_BAC" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle Font-Bold="True" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style102"  >
                &nbsp;</td>
            <td class="style7" >
                &nbsp;</td>
            <td class="style7" >
                &nbsp;</td>
            <td class="style20">
                &nbsp;</td>
            <td class="style20">
                <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                    SelectCommand="select count(*) NB,niveau_acces,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end) annee ,
  (case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END) NAT_BAC from esp_etudiant where NIVEAU_ACCES='04' 
and (id_et like '14%' or id_et like '15%' or id_et like '13%' or id_et like '12%') group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end),(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END),niveau_acces  order by annee">
                </asp:SqlDataSource>
            </td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style112">
                &nbsp;</td>
            <td class="style8">
                </td>
            <td class="style116">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
    </table>
 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                        SelectCommand="select (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
    end) 
  as annee , COUNT( *)  AS nb from esp_etudiant where   (id_et like '14%' or id_et like '13%' or id_et like '12%' or id_et like '11%') and nature_bac='02'  group by 
case


when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe) 
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012' 
  when id_et like '11%'  then '2011'      end 
   order by annee">
    
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="select count(*) NB,niveau_acces,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end) annee ,
  (case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END) NAT_BAC from esp_etudiant where NIVEAU_ACCES='02' 
and (id_et like '14%' or id_et like '15%' or id_et like '13%' or id_et like '12%') group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end),(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END),niveau_acces  order by annee
 "></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
        SelectCommand="select count(*) NB,niveau_acces,(case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end) annee ,
  (case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END) NAT_BAC from esp_etudiant where NIVEAU_ACCES='03' 
and (id_et like '14%' or id_et like '15%' or id_et like '13%' or id_et like '12%') group by (case  when id_et like '14%'  then '2014' when id_et like '15%'  then (select max (annee_deb)  from societe)
 when id_et like '13%'  then '2013' 
  when id_et like '12%' then '2012'  when id_et like '11%'  then '2011' 
  when id_et like '10%'  then '2010' when id_et like '09%'  then '2009' when id_et like '08%'  then '2008' when id_et like '07%'  then '2007' when id_et like '06%'  then '2006'   when id_et like '05%'  then '2005' when id_et like '04%'  then '2004'  end),(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC not in('01','02','04','03','35') then 'Autre bac' when NATURE_BAC='02' then 'ECO' when NATURE_BAC='03' then 'SC EXP' when NATURE_BAC='04' then 'TECH' when NATURE_BAC='35' then 'INFO' END),niveau_acces  order by annee">
    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
                        SelectCommand=" select count(*) as NB  from esp_etudiant where id_et like '15%' and nature_bac='02'   ">
    
                    </asp:SqlDataSource>
</asp:Content>
