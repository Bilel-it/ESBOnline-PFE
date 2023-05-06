<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suivi_Abs.aspx.cs" Inherits="ESPOnline.Direction.Suivi_Abs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
        SelectCommand="SELECT e2.nom_et||' '||e2.pnom_et  Nom,e1.JUSTIFICATION,e1.A_CONVOQUER,e1.OBSERVATION FROM ESP_ABSENCE_NEW e1,esp_etudiant e2 WHERE  e1.id_et=e2.id_et and ((CODE_CL =:CODE_CL) AND (ID_ENS = :ID_ENS) AND (DATE_SEANCE = :DATE_SEANCE) AND (NUM_SEANCE =:NUM_SEANCE))">
            <SelectParameters>
                <asp:SessionParameter Name="CODE_CL" SessionField="CLASSE" Type="String" />
                <asp:SessionParameter Name="ID_ENS" SessionField="ID" Type="String" />
                <asp:SessionParameter Name="DATE_SEANCE" SessionField="DATE_SEANCE" 
                    Type="DateTime" />
                <asp:SessionParameter Name="NUM_SEANCE" SessionField="NUM_SEANCE" 
                    Type="Decimal" />
            </SelectParameters>
            
        </asp:SqlDataSource><div align="center">
   <asp:Label ID="Label1" runat="server" Text="Liste des étudiants absents" 
                style="font-weight: 700; text-decoration: underline"></asp:Label>
            <br />
            <br />
            <div align="center">   <div align="left">  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  classe:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            date séance:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            numéro séance:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                <br />
            <br /></div></div>
        </div>
         <div align="center" >  
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        
      >
        <Columns>
            <asp:BoundField DataField="Nom" HeaderText="Nom" ReadOnly="True" 
                SortExpression="Nom" />
           <%-- <asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" 
                ReadOnly="True" SortExpression="CODE_MODULE" />--%>
         <%--   <asp:BoundField DataField="CODE_CL" HeaderText="CODE_CL" ReadOnly="True" 
                SortExpression="CODE_CL" />--%>
           <%-- <asp:BoundField DataField="ANNEE_DEB" HeaderText="ANNEE_DEB" ReadOnly="True" 
                SortExpression="ANNEE_DEB" />--%>
             <%--<asp:BoundField DataField="ID_ENS" HeaderText="ID_ENS" ReadOnly="True" 
                SortExpression="ID_ENS" />--%>
            <%--asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE_SEANCE" 
                ReadOnly="True" SortExpression="DATE_SEANCE" />
                 <asp:BoundField DataField="NUM_SEANCE" HeaderText="NUM_SEANCE" ReadOnly="True" 
                SortExpression="NUM_SEANCE" />
          
            <asp:BoundField DataField="DATE_SAISIE" HeaderText="DATE_SAISIE" 
                ReadOnly="True" SortExpression="DATE_SAISIE" />
            <asp:BoundField DataField="SEMESTRE" HeaderText="SEMESTRE" ReadOnly="True" 
                SortExpression="SEMESTRE" />--%>
            <asp:BoundField DataField="JUSTIFICATION" HeaderText="JUSTIFICATION" 
                ReadOnly="True" SortExpression="JUSTIFICATION" />
            <asp:BoundField DataField="A_CONVOQUER" HeaderText="A_CONVOQUER" 
                ReadOnly="True" SortExpression="A_CONVOQUER" />
            <asp:BoundField DataField="OBSERVATION" HeaderText="OBSERVATION" 
                ReadOnly="True" SortExpression="OBSERVATION" />
        </Columns>
    </asp:GridView>
   <asp:Label ID="Label2" runat="server" Text="Aucune absence" ForeColor="Red" 
                 style="font-weight: 700"></asp:Label></div>
   
           
    </div>
    </form>
</body>
</html>
