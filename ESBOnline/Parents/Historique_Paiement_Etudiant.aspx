<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="Historique_Paiement_Etudiant.aspx.cs" Inherits="ESPOnline.Parents.Historique_Paiement_Etudiant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
  <center>
            
            <h3>
                <asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Interface Parent Etudiant Extrait de compte"></asp:Label>

            </h3>
        </center>


        <center>
        <br />
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource3" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                     
                    <asp:BoundField DataField="id_et"   HeaderText="Identifiant étudiant:"    SortExpression="id_et" />
                    <asp:BoundField DataField="numcompte" HeaderText="Compte :" SortExpression="numcompte" />
                    <asp:BoundField DataField="NomPrenom" HeaderText="Nom & Prénom :" SortExpression="NomPrenom" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#9999ff" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>

<asp:SqlDataSource ID="SqlDataSource3" runat="server"
 ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
SelectCommand="SELECT id_et,numcompte,nom_et||' '||pnom_et as nomPrenom FROM esp_etudiant 
WHERE (ID_ET =:ID_ET)  AND  etat='A'">
            <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
           </asp:SqlDataSource><br />
            <asp:Panel ID="Panel1" runat="server">
               <br />
                 <b>Votre solde à ce jour est:</b>
                <asp:Label ID="Label7" runat="server" Text="Label" Visible="true" style="color: #800000" ></asp:Label>
                <br />
                        <asp:GridView ID="GridView2" runat="server" Visible="true"  AutoGenerateColumns="False"
                Height="74px" Width="623px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" ondatabound="GridView2_DataBound" ShowFooter="True"  >
                 <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <Columns>
                     <asp:BoundField DataField="PostingDate" HeaderText="Date" 
                        SortExpression="PostingDate"  ItemStyle-Width="40%"/>

                         <asp:BoundField DataField="documenttype" HeaderText=" Type Document" 
                        SortExpression="documenttype" />
                          <asp:BoundField DataField="documentNo_" HeaderText=" N° Document" 
                        SortExpression="documentNo_" />
                          <asp:BoundField DataField="description" HeaderText="Libellé" 
                        SortExpression="description" />
                        <asp:BoundField DataField="amount" HeaderText=" Montant" 
                        SortExpression="amount" />
                    </Columns>
              <FooterStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#9999ff" ForeColor="White" Font-Bold="True"/>
                </asp:GridView>
                <asp:DetailsView ID="TotalSoldEtudiant" runat="server" AutoGenerateRows="False" 
                 Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None" Visible="false">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"  />
                <Fields>
                     
                    <asp:BoundField DataField="1"   HeaderText="Total Solde:"    SortExpression="1" />
         
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#9999ff" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>
               
                <br />
                
            </asp:Panel>
        </center>

</asp:Content>
