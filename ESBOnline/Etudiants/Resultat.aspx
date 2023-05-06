<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Resultat.aspx.cs" Inherits="ESPOnline.Etudiants.Resultat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
            <div class="col-xs-1">
               
            </div>
            <div class="col-xs-10">
              <center><h1> Notes Des Modules </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                 
                    <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="NOM MODULES" 
                        SortExpression="DESIGNATION" />
                       <%--  <asp:BoundField DataField="COEF" HeaderText="COEF"    SortExpression="COEF" />--%>
                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM ENSEIGNANT" 
                                SortExpression="NOM_ENS" />
                                 <asp:BoundField DataField="COEF" HeaderText="COEF" 
                                SortExpression="COEF" />
                            <asp:TemplateField HeaderText="NOTE CC" SortExpression="NOTE_CC">
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# ExisteNote(Eval("NOTE_CC"),Eval("EXISTE_NOTE_CC"),("ABSENT_CC"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOTE TP" SortExpression="NOTE_TP">
                                
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# ExisteNote(Eval("NOTE_TP"),Eval("EXISTE_NOTE_TP"),Eval("ABSENT_TP")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOTE EXAM" SortExpression="NOTE_EXAM">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#  FormatNullValue(Eval("NOTE_EXAM"), Eval("ABSENT_EXAM")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="NOTE" SortExpression="NOTE">
                                <ItemTemplate>
                                    <asp:Label ID="Labelt" runat="server" 
                                        Text='<%#   FormatNullValue(Eval("NOTE_EXAM"), Eval("ABSENT_EXAM")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="EXISTE_NOTE_CC" SortExpression="EXISTE_NOTE_CC" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EXISTE_NOTE_CC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABSENT CC" SortExpression="ABSENT_CC" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("ABSENT_CC") %>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EXISTE_NOTE_TP"  SortExpression="EXISTE_NOTE_TP" Visible="false">
                                 
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("EXISTE_NOTE_TP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABSENT TP" SortExpression="ABSENT_TP" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ABSENT_TP") %>'></asp:Label>
                                </ItemTemplate>
                                 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABSENT EXAM" SortExpression="ABSENT_EXAM" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ABSENT_EXAM") %>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
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
                <hr /><hr />
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
            </div>

</asp:Content>
