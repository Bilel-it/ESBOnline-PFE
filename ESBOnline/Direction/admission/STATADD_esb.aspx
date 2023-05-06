<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="STATADD_esb.aspx.cs" Inherits="ESPOnline.Direction.admission.STATADD_esb" 
MasterPageFile="~/Direction/admission/ad.Master" %>

 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
   
<%--    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>
    <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView2.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView5.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>
    
   
    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView3.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>
  <%--  <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView4.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>

    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView8.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center class="style7"><strong>ADMISSION 2019-2020</strong></center> 
    <table class="style1">
   
        
        <tr>
            <td>
             
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
           
        </tr>
    </table>
    &nbsp;
    <br />
    <center>
        <table class="style1">
        <tr> 
        <span 
                class="style8"><strong>COMPARAISON </strong></span></td></tr>
            <tr>
           
                <td width="20%">
                    <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="list-inline"
                        DataSourceID="SQLDataSource3">
                        <Columns>
                            <asp:BoundField DataField="DATEENTR" HeaderText="Date d'entretien" DataFormatString="{0:d}" SortExpression="DATEENTR" />
                            <asp:BoundField DataField="nb" HeaderText="nombre" SortExpression="nb" />
                            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>--%>
                </td>
                 <%--<td width="19%">
                     <strong>2015</strong>
                <span style='font-size: 15pt'> 
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" PageSize="27"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource15">
                        <Columns>
                            <asp:BoundField DataField="test" ItemStyle-Width="68%"  HeaderText="Date" DataFormatString="{0:d}" SortExpression="test" />
                           
                            <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>--%>
                 <%--<td width="10%">
                   <strong>2016</strong>
                <span style='font-size: 15pt'> 
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" PageSize="27"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource16">
                        <Columns>
                            <asp:BoundField DataField="test" ItemStyle-Width="68%" HeaderText="Date" DataFormatString="{0:d}" SortExpression="test" />
                           
                            <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>--%>

                <td width="10%">
                   <strong>2017</strong>
                <span style='font-size: 15pt'> 
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" PageSize="27"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource2">
                        <Columns>
                            <asp:BoundField DataField="test" HeaderText="Date" ItemStyle-Width="68%" DataFormatString="{0:d}" SortExpression="test" />
                           
                            <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
                
                <td width="10%">
                 <strong>2018</strong>
                <span style='font-size: 15pt'> 
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" PageSize="27"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource6">
                        <Columns>
                            <asp:BoundField DataField="test" ItemStyle-Width="550px"  HeaderText="Date" DataFormatString="{0:d}" SortExpression="test" />
                           
                            <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>





                <td width="10%">
                 <strong>2019</strong>
                <span style='font-size: 15pt'> 
                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" PageSize="27"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource66">
                        <Columns>
                            <asp:BoundField DataField="test" ItemStyle-Width="550px"  HeaderText="Date" DataFormatString="{0:d}" SortExpression="test" />
                           
                            <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>

                
            </tr>
            <tr>
                <%--<td class="style6">
                    <strong>&nbsp;NOMBRE DES PRÉINSCRITS PAR SPÉCIALITES
                </strong>
                </td>--%>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
               <%-- <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="list-inline"
                        DataSourceID="SQLDataSource4">
                        <Columns>
                            <asp:BoundField DataField="DATEENTR" HeaderText="Date d'entretien" DataFormatString="{0:d}" SortExpression="DATEENTR" />
                            <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE" SortExpression="SPECIALITE_ESP_ET" />
                            <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU" SortExpression="NIVEAU_ACCES" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        </Columns>
                          <EmptyDataTemplate>
                                    Pas d'enregistrement.
                                </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>--%>
                <td>
                    &nbsp;
                </td>
                <%--<td>
                    <span style='font-size: 15pt'>
                    <h1>Nombre des admis par date d'entretien</h1>
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CCCCCC" DataSourceID="SQLDataSource5">
                            <Columns>
                                <asp:BoundField DataField="DATEENTR" HeaderText="Date" DataFormatString="{0:d}" SortExpression="DATEENTR" />
                                <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE" SortExpression="SPECIALITE_ESP_ET" />
                                <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU" SortExpression="NIVEAU_ACCES" />
                                <asp:BoundField DataField="Nombre" HeaderText="Admis" SortExpression="Nombre" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                </td>--%>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </center>
    &nbsp;</td>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '17%' then 2016 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '17%' and date_saisie like '%17'
group by trunc(DATE_SAISIE),  (case when id_et like '17%' then 2016 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>
<%--<asp:SqlDataSource ID="SqlDataSource15" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '15%' then 2015 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '15%' and date_saisie like '%15'
group by trunc(DATE_SAISIE),  (case when id_et like '15%' then 2015 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>--%>


<%--<asp:SqlDataSource ID="SqlDataSource16" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '16%' then 2016 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '16%' and date_saisie like '%16'
group by trunc(DATE_SAISIE),  (case when id_et like '16%' then 2016 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>--%>

<asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '18%' then 2018 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '18%' and date_saisie like '%18'
group by trunc(DATE_SAISIE),  (case when id_et like '18%' then 2018 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>





    <asp:SqlDataSource ID="SqlDataSource66" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '19%' then 2018 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '19%' and date_saisie like '%19'
group by trunc(DATE_SAISIE),  (case when id_et like '19%' then 2018 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>


    
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand=" select DATEENTR,nb,sum(nb) over(PARTITION by annee order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')) as total from
(select  DATEENTR,count(*)nb,(case when DATEENTR like '%18' then 2018 end) annee  from esp_etudiant where id_et like '18%' and dateentr 
is not null group by DATEENTR Order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'))order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')


" ></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT DISTINCT DATE_SAISIE FROM SCO_ADMIS1415.ESP_ETUDIANT WHERE (id_et LIKE '19%') ORDER BY DATE_SAISIE">
    </asp:SqlDataSource>
    <span style='font-size: 15pt'>
       <%-- <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>"
            SelectCommand="select  DATEENTR,SPECIALITE_ESP_ET,NIVEAU_ACCES,sum(nombre)nombre from(
select count(*)nombre,t1.DATEENTR, (case when (t1.SPECIALITE_ESP_ET='05' or t1.SPECIALITE_ESP_ET='01' or t1.SPECIALITE_ESP_ET='02') then 'TIC' when   t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC' end)SPECIALITE_ESP_ET,t1.NIVEAU_ACCES from esp_etudiant t1, scoesp09.esp_etudiant_enreg t2 where t1.id_et like '19%T%' and 
t1.DATEENTR    like '%-%' and trim(t1.id_et)=trim(t2.id_et) and t2.code_decision='01' group by t1.DATEENTR,t1.SPECIALITE_ESP_ET ,t1.NIVEAU_ACCES 
order by TO_DATE(  t1.DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),t1.SPECIALITE_ESP_ET,t1.NIVEAU_ACCES)
 group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES">
        </asp:SqlDataSource>--%>
    </span>
    <br />
    <span style='font-size: 15pt'>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>"
            SelectCommand="select DATEENTR,SPECIALITE_ESP_ET,NIVEAU_ACCES,sum(nombre)nombre  from(
select count(*)nombre,DATEENTR, (case when (SPECIALITE_ESP_ET='05' or SPECIALITE_ESP_ET='01' or SPECIALITE_ESP_ET='02') then 'TIC' when   SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC' end)SPECIALITE_ESP_ET,NIVEAU_ACCES from esp_etudiant where id_et like '19%T%' and 
DATEENTR    like '%-%'  group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES 
order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES)
group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES ">
        </asp:SqlDataSource>
</asp:Content>