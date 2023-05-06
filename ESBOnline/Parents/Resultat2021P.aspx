<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="Resultat2021P.aspx.cs" Inherits="ESPOnline.Parents.Resultat2021P" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-xs-1">
          <%--      <script type="text/javascript">
                    window.onbeforeunload = function () {
                     
        return "Dude, are you sure you want to leave?!";
    }
</script>--%>
               <asp:Label ID="lbletat" runat="server" Visible="false"></asp:Label>

                 <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="col-xs-10">
              <center><h1> Notes Des Modules </h1>

              </center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                 
                    <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" SortExpression="DESIGNATION" />
                            <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" />
                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" SortExpression="NOM_ENS" />
                            <asp:BoundField DataField="NOTE_CC" HeaderText="NOTE_CC" SortExpression="NOTE_CC" />
                            <asp:BoundField DataField="NOTE_TP" HeaderText="NOTE_TP" SortExpression="NOTE_TP" />
                            <asp:BoundField DataField="NOTE_EXAM" HeaderText="NOTE_EXAM" SortExpression="NOTE_EXAM" />
                            <%--<asp:BoundField DataField="ABSENT_CC" HeaderText="ABSENT_CC" SortExpression="ABSENT_CC" />
                            <asp:BoundField DataField="ABSENT_TP" HeaderText="ABSENT_TP" SortExpression="ABSENT_TP" />
                            <asp:BoundField DataField="ABSENT_EXAM" HeaderText="ABSENT_EXAM" SortExpression="ABSENT_EXAM" />
                            <asp:BoundField DataField="EXISTE_NOTE_CC" HeaderText="EXISTE_NOTE_CC" SortExpression="EXISTE_NOTE_CC" />
                            <asp:BoundField DataField="EXISTE_NOTE_TP" HeaderText="EXISTE_NOTE_TP" SortExpression="EXISTE_NOTE_TP" />--%>
                        </Columns>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#A80000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E0E0E0" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetListNotes" 
                TypeName="ESPOnline.Etudiants.NoteS1" 
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                   
             </center>   <hr /><hr />
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
          

</asp:Content>