<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="STATADD.aspx.cs" Inherits="ESPOnline.Direction.STATADD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
   
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
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
      <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView3.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script> 
      <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView4.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" Visible="false"   Width="330px" Height="38px"  AppendDataBoundItems="True"  DataTextField="date_saisie"     
                                           OnSelectedIndexChanged="ddltestang_SelectedIndexChanged"      dataTextFormatString="{0:dd/MM/yyyy}"    DataValueField="date_saisie"> 
                  <asp:listitem Value="" Text="Choisir une date"> </asp:listitem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
              Nombre d'inscrits:</td>
            <td>
    
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td >
      <br />  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
&nbsp; 
            <center>
                <table class="style1">
                    <tr>
                        <td width="50%">
            
               <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource3">
                    <Columns>
                          <asp:BoundField DataField="DATE_ent" HeaderText="date" DataFormatString="{0:d}"
                        SortExpression="date_ent" />
                      
                                 <asp:BoundField DataField="nombre_condidats" HeaderText="nombre" 
                                SortExpression="nombre_condidats" /> 
<asp:BoundField DataField="TOTAL" HeaderText="TOTAL" 
                                SortExpression="TOTAL" /> 

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
                        <td  width="50%">
                            &nbsp;</td>
                        <td  width="50%">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   PageSize="27"
       
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource2">
                    <Columns>
                          <asp:BoundField DataField="test" HeaderText="date" DataFormatString="{0:d}"
                        SortExpression="test" />
                      
                                 <asp:BoundField DataField="total" HeaderText="total" 
                                SortExpression="total" /> 
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
                        <td>
                             &nbsp;</td>
                       
                        <td>
                            &nbsp;</td>
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CssClass="list-inline" DataSourceID="SQLDataSource4">
                    <Columns> <asp:BoundField DataField="DATEENTR" HeaderText="date" DataFormatString="{0:d}"
                        SortExpression="DATEENTR" />
                          <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE" 
                                SortExpression="SPECIALITE_ESP_ET" /> 
                                 <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU" 
                                SortExpression="NIVEAU_ACCES" /> 
                                 <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                SortExpression="Nombre" /></Columns> <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                         </asp:GridView></td>
                       
                        <td>
                            &nbsp;</td>
                       
                        <td>
                            <span style='font-size: 15pt'> 
                             <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC"   
                DataSourceID="SQLDataSource5">
                    <Columns> <asp:BoundField DataField="DATEENTR" HeaderText="date" DataFormatString="{0:d}"
                        SortExpression="DATEENTR" />
                          <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE" 
                                SortExpression="SPECIALITE_ESP_ET" /> 
                                 <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIVEAU" 
                                SortExpression="NIVEAU_ACCES" /> 
                                 <asp:BoundField DataField="Nombre" HeaderText="Admis" 
                                SortExpression="Nombre" /></Columns> <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                         </asp:GridView></td>
                    </tr>
                </table>
&nbsp;&nbsp;&nbsp;&nbsp; </center>
            
    &nbsp;</td>
            
         
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
        SelectCommand="select test, sum(nb) over(PARTITION by annee order by test) as total from(select (case when id_et like '18%' then 2014 end) annee, trunc(DATE_SAISIE) test, count(*) nb

from esp_etudiant where id_et like '18%' and date_saisie like '%18'
group by trunc(DATE_SAISIE),  (case when id_et like '18%' then 2014 end) order by trunc(DATE_SAISIE))"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
        
        SelectCommand=" select date_ent,nombre_condidats, sum(nombre_condidats) over(PARTITION by annee order by TO_DATE(  date_ent, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')) as total from(select  nombre_condidats,date_ent,
(case when DATE_ENT like '%18' then 2017 end)  annee 

from DATE_ENT ) where DATE_ENT    like '%-%'
">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" 
    
       
        
        SelectCommand="SELECT DISTINCT DATE_SAISIE FROM SCO_ADMIS1415.ESP_ETUDIANT WHERE (id_et LIKE '18%') ORDER BY DATE_SAISIE">
   
     
</asp:SqlDataSource>
 
    <span style='font-size: 15pt'>  
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
    
       
        
        
        
        SelectCommand="select  DATEENTR,SPECIALITE_ESP_ET,NIVEAU_ACCES,sum(nombre)nombre from(
select count(*)nombre,t1.DATEENTR, (case when (t1.SPECIALITE_ESP_ET='05' or t1.SPECIALITE_ESP_ET='01' or t1.SPECIALITE_ESP_ET='02') then 'TIC' when   t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC' end)SPECIALITE_ESP_ET,t1.NIVEAU_ACCES from esp_etudiant t1, scoesb02.esp_etudiant_enreg t2 where t1.id_et like '18%' and 
t1.DATEENTR    like '%-%' and trim(t1.id_et)=trim(t2.id_et) and code_decision='01' group by t1.DATEENTR,t1.SPECIALITE_ESP_ET ,t1.NIVEAU_ACCES 
order by TO_DATE(  t1.DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),t1.SPECIALITE_ESP_ET,t1.NIVEAU_ACCES)
 group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES">
   
     
</asp:SqlDataSource>
 
    </span>
 
    <br />
    <span style='font-size: 15pt'> 
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
    
       
        
        
        SelectCommand="select DATEENTR,SPECIALITE_ESP_ET,NIVEAU_ACCES,sum(nombre)nombre  from(
select count(*)nombre,DATEENTR, (case when (SPECIALITE_ESP_ET='05' or SPECIALITE_ESP_ET='01' or SPECIALITE_ESP_ET='02') then 'TIC' when   SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC' end)SPECIALITE_ESP_ET,NIVEAU_ACCES from esp_etudiant where id_et like '18%' and 
DATEENTR    like '%-%'  group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES 
order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES)
group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES ">
   
     
</asp:SqlDataSource>
 
    </asp:Content>
