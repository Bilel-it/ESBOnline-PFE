<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="Listeattente.aspx.cs" Inherits="ESPOnline.Direction.Listeattente" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" class="style2">
                <strong><em class="style3">Admission&nbsp; 2017/2016</em></strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            
                                                        <br /> <tr>
                        <td>
                                                        &nbsp;</td><tr><td> &nbsp;</td></tr></tr> 
                    </tr>
                    <tr>
                        <td>
                           
                             <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="300px" Width="1300px" align="center" >
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                     DataKeyNames="ID_ET"   
                                     >
                                     <Columns>
                                         <asp:BoundField DataField="NUM_CIN_PASSEPORT" HeaderText="CIN" 
                                             SortExpression="NUM_CIN_PASSEPORT" />
                                         <asp:BoundField DataField="NOM_et" HeaderText="NOM" ReadOnly="True" 
                                             SortExpression="NOM_et" />
                                      
                                      <asp:BoundField DataField="PNOM_et" HeaderText="PNOM" ReadOnly="True" 
                                             SortExpression="PNOM_et" />
                                          
                                         <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" ReadOnly="True" 
                                             SortExpression="ID_ET" />
                                         <asp:BoundField DataField="Dateentr" HeaderText="Date entretien" 
                                             SortExpression="Date entretien" />
                                         <asp:BoundField DataField="SPECIALITE_ESP_ET" HeaderText="SPECIALITE_ESP_ET" 
                                             SortExpression="SPECIALITE_ESP_ET" />
                                         
                                        
                                         <asp:BoundField DataField="COMPTE_MOODEL" HeaderText="C_MOODLE" 
                                             SortExpression="COMPTE_MOODEL" />
                                         <asp:BoundField DataField="PWD_MOODEL" HeaderText="PWD_MOODLE" 
                                             SortExpression="PWD_MOODEL" />
                                     </Columns>
                                 </asp:GridView>
                             </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server"  Text="Refrech" 
                    CssClass="btn-lg" Width="138px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
