<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="etat_absence.aspx.cs" Inherits="ESPOnline.Direction.etat_absence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <style type="text/css">
         .footer td
        {
            border: none;
        }
   .table     td {
border-bottom: 1pt solid black;
}     
  .footer      tr {
border-bottom: 1pt solid black;
}
        .footer th
        {
            border: none;
        }
    </style>

    <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: white;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#d6e6f6;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #7591b1; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}

      
          </style>

           <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>

    <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView2.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<center>
<table>
<tr>
<td> </td>
</tr>
<tr>

<td>
<h3>Etat des absences 2017/2016</h3>
<asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="False" 
       DataSourceID="SqlDataSource2"
                                                          
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" 
        BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
        EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                   
                                                  
                                                       >
                                                        <EmptyDataTemplate>
                                                            Pas d'enregistrement.
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="Red" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        <Columns>
         

                  

                  <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                SortExpression="CODE_CL" /> 

                  <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                SortExpression="DESIGNATION" /> 
               
                <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" 
                SortExpression="NOM_ENS" /> 

                 

                 <asp:BoundField DataField="NBSEANCE" HeaderText="NBSEANCE" ReadOnly="True" 
                SortExpression="NBSEANCE" /> 


                     </Columns>
                     
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>
                                          <asp:Button  ID="Button2" runat="server" Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" 
        onclick="BuTT3_Click" />
                                                    <br />
<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" 
       DataSourceID="SqlDataSource1"
                                                          
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" 
        BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
        EmptyDataRowStyle-CssClass="ItemStyle"  BackColor="#0099CC"
                                                   
                                                  
                                                       >
                                                        <EmptyDataTemplate>
                                                            Pas d'enregistrement.
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="Red" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        <Columns>
         

                  

                  <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" 
                SortExpression="CODE_CL" /> 

                  <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                SortExpression="DESIGNATION" /> 
               
                <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" 
                SortExpression="NOM_ENS" /> 

                 <asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE_SEANCE" DataFormatString="{0:d}"
                SortExpression="DATE_SEANCE" /> 

                 <asp:BoundField DataField="NUM_SEANCE" HeaderText="NUM_SEANCE" 
                SortExpression="NUM_SEANCE" /> 


                                                            <asp:BoundField DataField="NBABSENCE" HeaderText="NBABSENCE" ReadOnly="True" 
                                                                SortExpression="NBABSENCE" />


                     </Columns>
                     
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <RowStyle ForeColor="#000000"  />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        
                                                    </asp:GridView>

<br />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="select code_cl,t3.DESIGNATION,t2.NOM_ENS,t1.DATE_SEANCE,t1.NUM_SEANCE,count(*) as nbabsence from ESP_ABSENCE_NEW t1 , esp_enseignant t2, esp_module t3 where annee_deb=2018 and t3.CODE_MODULE=t1.CODE_MODULE
and t1.id_ens=t2.id_ens group by  code_cl,t3.DESIGNATION,t2.NOM_ENS,t1.DATE_SEANCE,t1.NUM_SEANCE order by t2.NOM_ENS ">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="select code_cl,t3.DESIGNATION,t2.NOM_ENS,count(*) as nbseance from ESP_ENTETE_ABSENCE t1 , esp_enseignant t2, esp_module t3 where annee_deb=2018 and t3.CODE_MODULE=t1.CODE_MODULE
and t1.id_ens=t2.id_ens group by  code_cl,t3.DESIGNATION,t2.NOM_ENS order by t2.NOM_ENS ">
    </asp:SqlDataSource>
                                                    <br />
                                                     <center>
                                           <table>
                                           
                                           <tr>
                                           <td>
                                             
                                                    <asp:Button  ID="Btnprint" runat="server" 
         Text="Imprimer" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="Btnprint_Click" />
                                           </td>
                                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                                          <td>
                                          <asp:Button  ID="Button1" runat="server" Text="Exporter en excel" 
Height="50px" ForeColor="Black" BackColor="#CCCCCC"  CssClass="text-info" onclick="BuTT2_Click" />
                                          </td>  
                                            
                                            </tr>
                                            </table>        
                                                    
                                                    </center>

</td>

<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;</td>



</tr>

</table></center>

                                                   
</asp:Content>