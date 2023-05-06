<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Emplois.aspx.cs" Inherits="ESPOnline.Etudiants.Emplois" %>
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
    <h3 class="text-center text-info"><strong>Emploi du temps</strong></h3>
    <br /><br />
   <div class="row">
   <div class="col-lg-3"></div>
   <div class="col-lg-6 text-center">
   <div class="table-condensed">
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            EmptyDataText = "No files uploaded" CellPadding="4"
            EnableModelValidation="True" ForeColor="#333333" GridLines="None" style="margin-left: 0px" Width="100%" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="Emplois" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "Télécharger" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField >
         <ItemTemplate>
                <asp:LinkButton ID="lnkBrowse" Text = "Apercu" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "BrowseFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
   <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#C80000 " Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#B0B0B0 " ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>
</div>
   </div>
   <div class="col-lg-3"></div>
   </div> 
</asp:Content>
