<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="RESECTS.aspx.cs" Inherits="ESPOnline.Etudiants.RESECTS" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="row">
            <div class="col-xs-1">
               
            </div>
            <div class="col-xs-10">
              <center><h1> Resultat par unite d'enseignement</h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                    
                <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False"     onrowdatabound="GridView1_test" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        DataSourceID="ObjectDataSource1" 
                       >
                    <Columns>
                        <asp:BoundField DataField="CODE_UE" HeaderText="CODE UE" 
                            SortExpression="CODE_UE" />
                        <asp:BoundField DataField="LIB_UE" HeaderText="LIBELLE UE" 
                            SortExpression="LIB_UE" />
                             <asp:BoundField DataField="C_NB_MODULE_UE" HeaderText="NB MODULE UE" 
                            SortExpression="C_NB_MODULE_UE" />
                        <asp:BoundField DataField="NB_ECTS" HeaderText="NOMBRE ECTS" 
                            SortExpression="NB_ECTS" />
                        <asp:BoundField DataField="MOYENNE" HeaderText="MOYENNE" 
                            SortExpression="MOYENNE" />
                      
                    </Columns>
                      <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000000" />
                        <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView> 
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="GetListRES" TypeName="ESPOnline.Etudiants.NoteEcts">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="" Name="_Id_et" SessionField="ID_ET" 
                                    Type="String" />
                            </SelectParameters>
                    </asp:ObjectDataSource><br /><br />
                        <asp:Label ID="Label1" runat="server" Text="" Font-Size="Medium" 
                        ForeColor="#336600"></asp:Label> 
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="" Font-Size="Medium" 
                        ForeColor="Red" ></asp:Label> 
                        </asp:Panel>
</asp:Content>
