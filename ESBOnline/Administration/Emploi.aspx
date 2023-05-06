<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="Emploi.aspx.cs" Inherits="ESPOnline.Administration.Emploi" %>
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
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br /><br /><br /><br /><br /><br /><br /><br />
    <center>
    <asp:FileUpload ID="FileUploadControl" runat="server"
            Height="100px" Width="414px" CssClass="" 
            ForeColor="Black"/><br /> 
      <asp:Button runat="server" id="UploadButton" text="Charger" 
        CssClass="btn btn-lg  btn-danger" onclick="UploadButton_Click" 
         Width="217px" />   
    <br /><br />   
    <asp:Label runat="server" id="StatusLabel" text="Status de chargement: " 
         BorderColor="Red"  />   </center>
         <div class="row">
   <div class="col-lg-3"></div>
   <div class="col-lg-6 text-center">
   <div class="table-condensed"><center>
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            EmptyDataText = "Aucun fichiers téléchargés" CellPadding="4" ForeColor="#333333" 
           GridLines="None" style="margin-left: 0px" Width="100%" >
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="Documents Chargés" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "Télécharger" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField >
         <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" Text = "Supprimer" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DeleteFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField >
         <ItemTemplate>
                <asp:LinkButton ID="lnkBrowse" Text = "Apercu" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "BrowseFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#C80000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#E00000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>
</div>
   </div>
 <br /><br /><br /><br /><br /><br /><br />
 <center><h4>Historique</h4></center>

 <center>
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false " ShowHeader="true">
             <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Nom" />
                    
                    
                    <asp:BoundField DataField="LastWriteTime" HeaderText="Date derniere modification" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#C80000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#E00000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             </asp:GridView>  </center></center>
</asp:Content>
