<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/charguia.Master" AutoEventWireup="true" CodeBehind="suivi_abs_charguia.aspx.cs" Inherits="ESPOnline.Direction.suivi_abs_charguia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" bgcolor="#CCCCCC">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>
                choisir date<asp:TextBox ID="TextBox2" runat="server" TextMode="Date" 
                    required=""></asp:TextBox>
    
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
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Suivi" CssClass="active" />
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
    
                <asp:Label ID="Label1" runat="server" Text=" Suivi par date saisie" 
                    style="font-weight: 700; font-style: italic; text-decoration: underline"></asp:Label>
   <br /> 
                <asp:Label ID="Label2" runat="server" Text="Aucune saisie" 
                    Visible="False" ForeColor="Red"></asp:Label>
   
               <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onselectedindexchanging="GridView1_SelectedIndexChanging" >
                   <Columns>
                       <asp:CommandField ShowSelectButton="True" />
                       <asp:BoundField DataField="id_ens" HeaderText="id_ens" SortExpression="id_ens"  Visible="true"/>
                       <asp:BoundField DataField="NOM" HeaderText="NOM" SortExpression="NOM" />
                       <asp:BoundField DataField="DATE_SAISIE" HeaderText="DATE_SAISIE" 
                           ReadOnly="True" SortExpression="DATE_SAISIE" />
                       <asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE_SEANCE" 
                           ReadOnly="True" SortExpression="DATE_SEANCE" />
                       <asp:BoundField DataField="CLASSE" HeaderText="CLASSE" 
                           SortExpression="CLASSE" />
                       <asp:BoundField DataField="NUM_SEANCE" HeaderText="NUM_SEANCE" 
                           SortExpression="NUM_SEANCE" />
                   </Columns>
</asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td >
      <br /> <asp:Label ID="Label4" runat="server" Text=" Suivi par date seance" 
                    style="font-weight: 700; font-style: italic; text-decoration: underline"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Aucune saisie" 
                    Visible="False" ForeColor="Red"></asp:Label>
  
<asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" 
                    onselectedindexchanging="GridView2_SelectedIndexChanging" >
    <Columns>
        <asp:CommandField ShowSelectButton="True" /> 
        <asp:BoundField DataField="id_ens" HeaderText="id_ens" SortExpression="id_ens"  Visible="true"/>
        <asp:BoundField DataField="NOM" HeaderText="NOM" SortExpression="NOM" />
        <asp:BoundField DataField="DATE_SAISIE" HeaderText="DATE_SAISIE" 
            ReadOnly="True" SortExpression="DATE_SAISIE" />
        <asp:BoundField DataField="DATE_SEANCE" HeaderText="DATE_SEANCE" 
            ReadOnly="True" SortExpression="DATE_SEANCE" />
        <asp:BoundField DataField="CLASSE" HeaderText="CLASSE" 
            SortExpression="CLASSE" />
        <asp:BoundField DataField="NUM_SEANCE" HeaderText="NUM_SEANCE" 
            SortExpression="NUM_SEANCE" />
    </Columns>
</asp:GridView>
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
&nbsp;<asp:TextBox ID="TextBox1" runat="server"  
        Visible="False"></asp:TextBox>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select e1.id_ens id_ens, e2.nom_ens Nom,substr(e1.DATE_SAISIE,1,9) Date_saisie,substr(e1.date_seance,1,9) Date_seance,e1.code_cl Classe, e1.num_seance from esp_entete_absence e1,esp_enseignant e2 where e1.id_ens=e2.id_ens and  substr(e1.DATE_SAISIE,1,9) like :DATE_SAISIE  ">
   
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="DATE_SAISIE" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
        SelectCommand="select e1.id_ens id_ens, e2.nom_ens Nom,substr(e1.DATE_SAISIE,1,9) Date_saisie,substr(e1.date_seance,1,9) Date_seance,e1.code_cl Classe, e1.num_seance from esp_entete_absence e1,esp_enseignant e2 where e1.id_ens=e2.id_ens and  substr(e1.date_seance,1,9) like :DATE_SAISIE  ">
   
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="DATE_SAISIE" 
            PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
        </asp:Content>

