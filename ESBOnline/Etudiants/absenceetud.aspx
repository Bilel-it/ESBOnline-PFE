<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="absenceetud.aspx.cs" Inherits="ESPOnline.Etudiants.absenceetud" %>

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
<h3 class="text-center text-info"><strong>Absence</strong></h3>
<br /><br />
<div class="row">
   
  <center>

   
    <asp:Label ID="Label6" runat="server" CssClass="h4 text-success" Visible="false"></asp:Label>
    <asp:HiddenField ID="HiddenField1" runat="server" />
       <asp:HiddenField ID="HiddenField2" runat="server" />
      <table><tr>

          <td><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="80%"  OnRowDataBound = "OnRowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EmptyDataTemplate > <label style="color:forestgreen;font-weight:bold;width:200px">Vous n'avez pas d'absences</label></EmptyDataTemplate>


        <Columns>
           <%-- <asp:BoundField DataField="DATE_SEANCE" HeaderText="Date Seance" SortExpression="DATE_SEANCE"
                DataFormatString="{0:d MMMM yyyy}" />
            <asp:BoundField DataField="NUM_SEANCE" HeaderText="N° Seance" SortExpression="NUM_SEANCE" />--%>
            <asp:BoundField DataField="Module" HeaderText="Module" SortExpression="Module" />
                <asp:BoundField DataField="SEMESTRE" HeaderText="SEMESTRE" SortExpression="SEMESTRE" />
            <asp:BoundField DataField="Justification" HeaderText="Justification" SortExpression="Justification" />

                <asp:BoundField DataField="nb_heures" HeaderText="Nombre heures" ReadOnly="True" 
            SortExpression="nb_heures"/>
             <asp:BoundField DataField="nb_absence" HeaderText="Nombre absence" ReadOnly="True" 
            SortExpression="nb_absence"/>
             <%--<asp:BoundField DataField="Observation" HeaderText="Observation" SortExpression="Observation" />--%>
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
           <%--<td> <h3>Le nombre des absences autorisées par module</h3>  --%>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="false"
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
        SelectCommand="SELECT code_module,code_cl,
 (select distinct ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW
 from ESP_MODULE_PANIER_CLASSE_SAISO
 where code_module=t1.CODE_MODULE and ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=(select annee_deb from societe)
 and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL=t1.CODE_CL) AS Module,
 ( select distinct NB_HEURES from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=(select max(annee_deb)  from societe ) and NB_HEURES is not null
      and code_module=t1.CODE_MODULE and code_cl=t1.code_cl) nb_heures,
     (case  when Justification='O' then 'Absence justifiée' else 'Absence injustifiée' end)  Justification,
        semestre, count(t1.CODE_MODULE) nb_absence FROM ESP_ABSENCE_NEW t1,
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
       where annee_deb=2019 and code_cl=:argcode_cl
       order by DESIGNATION_NEW,NUM_SEMESTRE">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField2" Name="argcode_cl" />
        </SelectParameters>
    </asp:SqlDataSource>
    </center>
    </div>
</asp:Content>
