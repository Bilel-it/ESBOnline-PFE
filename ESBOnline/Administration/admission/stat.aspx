<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stat.aspx.cs" Inherits="ESPOnline.Administration.admission.stat" 
MasterPageFile="~/Administration/admission/ad.Master" %>

 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style6
        {
            color: #660066;
        }
        .style7
        {
            color: #CC0000;
        }
        .style8
        {
            color: #3333CC;
        }
    </style>
   <%-- <script type="text/javascript">
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
    <%-- <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView5.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>
    
   
   <%-- <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView3.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>
    <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView4.ClientID %>').Scrollable({
            ScrollHeight: 320,
         
        });
    });
    </script>--%>

    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView2.ClientID %>').Scrollable({
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
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
           
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    &nbsp;
    <br />
    <center>
        <table class="style1">
        <tr> <td class="style6"><strong>LISTE DES PRÉINSCRITS 2018/2019</strong></td>
        </tr>
            <tr>
           
                <td width="20%">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
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
                    </asp:GridView>
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

             
                
               





            

                
            </tr>
            
            
        </table>
       
    </center>
   
 
    
   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="  select DATEENTR,nb,sum(nb) over(PARTITION by annee order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')) as total from
(select  DATEENTR,count(*)nb,(case when DATEENTR like '%19' then 2019 end) annee  from esp_etudiant where id_et like '19%' and dateentr 
is not null group by DATEENTR Order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'))order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')


" ></asp:SqlDataSource>

<%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="  select DATEENTR,nb,sum(nb) 
        over(PARTITION by annee order by  DATEENTR) as total from
(select  DATEENTR,count(*)nb,(case when DATEENTR like '%18' then 2018 end) annee  from esp_etudiant where id_et like '18%' and dateentr 
is not null group by DATEENTR Order by   DATEENTR)order by DATEENTR


" ></asp:SqlDataSource>--%>
   
</asp:Content>