<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="absenceetud_autorise.aspx.cs" Inherits="ESPOnline.Etudiants.absenceetud_autorise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<h3 class="text-center text-info"><strong>Nombre des absences autorisées par module</strong></h3>
<br /><br />
<div class="row">
   
  <center>

   
    <asp:Label ID="Label6" runat="server" CssClass="h4 text-success" Visible="false"></asp:Label>
    <asp:HiddenField ID="HiddenField1" runat="server" />
       <asp:HiddenField ID="HiddenField2" runat="server" />
      <table><tr>

         
          <td>   
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" 
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="40%"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
          
            <asp:BoundField DataField="DESIGNATION_NEW" HeaderText="Module" SortExpression="DESIGNATION_NEW" />
                <asp:BoundField DataField="NB_HEURES" HeaderText="NB_HEURES" SortExpression="NB_HEURES" />
            <asp:BoundField DataField="Nb_H_Autorise" HeaderText="Nb_H_Autorise" SortExpression="Nb_H_Autorise" />

               
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#D8D8D8 " Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#D00000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView></td>

             </tr></table>
    
      
   
      


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="      SELECT code_module,code_cl, (select DESIGNATION from ESP_MODULE
         where code_module=t1.CODE_MODULE)AS Module ,( select distinct NB_HEURES from ESP_MODULE_PANIER_CLASSE_SAISO where 
         annee_deb=(select max(annee_deb)  from societe ) and NB_HEURES is not null  and code_module=t1.CODE_MODULE) nb_heures,
         (case  when Justification='O' then 'Absence justifiée' else 'Absence injustifiée' end)  Justification,
         semestre,count(t1.CODE_MODULE) nb_absence FROM ESP_ABSENCE_NEW t1, 
        societe t2 WHERE (ID_ET = :argidetud) and t1.annee_deb=(select max(annee_deb)  from societe)  
       group by Justification,semestre,CODE_MODULE,code_cl">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField1" Name="argidetud" />
        </SelectParameters>
    </asp:SqlDataSource>

       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="select DESIGNATION_NEW,NB_HEURES,case
       when NB_HEURES='21' then '3'  
        when NB_HEURES='28' then '4'  
        when NB_HEURES='31,5' then '5'  
         when NB_HEURES='42' then '6'  
          when NB_HEURES='49' then '8'  
           when NB_HEURES='56' then '8' 
            when NB_HEURES='63' then '9'  
             when NB_HEURES='64' then '9'  
              when NB_HEURES='84' then '12'
              else ''
       end Nb_H_Autorise
       from ESP_MODULE_PANIER_CLASSE_SAISO 
       where annee_deb=(select max(annee_deb) from societe) and code_cl=:argcode_cl
       order by DESIGNATION_NEW,NUM_SEMESTRE">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField2" Name="argcode_cl" />
        </SelectParameters>
    </asp:SqlDataSource>
    </center>
    </div>
</asp:Content>
