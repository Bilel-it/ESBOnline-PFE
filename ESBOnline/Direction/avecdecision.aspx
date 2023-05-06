<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="avecdecision.aspx.cs" Inherits="ESPOnline.Direction.avecdecision" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                                                       
                        </td></tr></tr> 
                    </tr>
                    <tr>
                        <td>
                           
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
          ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
          ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
          
          
            SelectCommand="SELECT  T1.num_cin_passeport, T1.NOM_ET||' '||T1.PNOM_ET nom,T1.NATURE_BAC,T1.SCORE_ENTRETIEN,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,T1.SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr, score_dossier,score_final, code_decision,T1.score_francais,T1.score_anglais,score_qi, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT_enreg t1  WHERE  id_et like '15%T%' and code_decision is not null order by specialite_esp_et desc

            " onselecting="SqlDataSource1_Selecting">
           
        </asp:SqlDataSource>
         
                             
         
                             <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="300px" Width="1300px" align="center" >
                             <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                                     AutoGenerateColumns="False" DataKeyNames="ID_ET" OnRowDataBound="GridView1_test">
                                 <Columns>
                                     <asp:BoundField DataField="NUM_CIN_PASSEPORT" HeaderText="CIN" 
                                         SortExpression="NUM_CIN_PASSEPORT" />
                                     <asp:BoundField DataField="NOM" HeaderText="NOM" ReadOnly="True" 
                                         SortExpression="NOM" />
                                          <asp:BoundField DataField="NATIONALITE" HeaderText="NATIONALITE" 
                                         SortExpression="NATIONALITE" />
                                           <asp:TemplateField HeaderText = "NAT_BAC" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblNom" runat="server"  Text='<%#Eval("NATURE_BAC") %>'></asp:Label>
                    
                </ItemTemplate></asp:TemplateField>
                                     
                                     <asp:BoundField DataField="MOY_BAC_ET" HeaderText="BAC" 
                                         SortExpression="MOY_BAC_ET"  />
                                         <asp:BoundField DataField="ANNEE_BAC" HeaderText="AN_BAC" 
                                         SortExpression="ANNEE_BAC"  />
                                     <asp:BoundField DataField="NIVEAU_ACCES" HeaderText="NIV" 
                                         SortExpression="NIVEAU_ACCES" />
                                     <asp:BoundField DataField="DIPLOME_SUP_ET" HeaderText="DIPLOME" 
                                         SortExpression="DIPLOME_SUP_ET" /> 
                                         <asp:TemplateField HeaderText = "SPECIALITE_ESP" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblNom1" runat="server"  Text='<%#Eval("SPECIALITE_ESP_ET") %>'></asp:Label>
                    
                </ItemTemplate></asp:TemplateField>
                                          
                                     
                                     <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" ReadOnly="True" 
                                         SortExpression="ID_ET" />
                                            <asp:BoundField DataField="Dateentr" HeaderText="Date entretien" 
                                         SortExpression="Date entretien" />
                                         <asp:BoundField DataField="score_dossier" HeaderText="SD" 
                                         SortExpression="Score_dossier" />
                                         <%--<asp:BoundField DataField="TEL_ET" HeaderText="TEL" 
                                         SortExpression="TEL_ET" />--%>
                                         <asp:BoundField DataField="SCORE_ENTRETIEN" HeaderText="SE" 
                                         SortExpression="SCORE_ENTRETIEN" />
                                         <asp:BoundField DataField="score_final" HeaderText="SFinal" 
                                         SortExpression="Score_final" />
                                         <asp:BoundField DataField="code_decision" HeaderText="decision" 
                                         SortExpression="code_decision" />
                                          <asp:BoundField DataField="SCORE_FRANCAIS" HeaderText="SF" 
                                         SortExpression="SCORE_FRANCAIS" />
                                           <asp:BoundField DataField="SCORE_anglais" HeaderText="SA" 
                                         SortExpression="SCORE_anglais" />
                                          <asp:BoundField DataField="SCORE_QI" HeaderText="QI" 
                                         SortExpression="SCORE_QI" />
                                           <asp:BoundField DataField="E_MAIL_ET" HeaderText="EMAIL" 
                                         SortExpression="E_MAIL_ET" />
                                          <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" 
                                         SortExpression="PASSWORD" />
                                           
                                 </Columns>
                             </asp:GridView></asp:Panel>
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
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Refrech" 
                    CssClass="btn-lg" Width="138px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>