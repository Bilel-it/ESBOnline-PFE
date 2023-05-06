<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="res.aspx.cs" Inherits="ESPOnline.Etudiants.res" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Resultas.aspx.cs" Inherits="ESPOnline.Etudiants.res" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
        }
        .style3
        {
            width: 232px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <asp:Panel ID="Panel1" runat="server">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetListNotes" 
    TypeName="ESPOnline.Class1" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style2">
                                <strong>Notes Des Modules Semestre 1</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
                        GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                                SortExpression="DESIGNATION" />
                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" 
                                SortExpression="NOM_ENS" />
                            <asp:BoundField DataField="NOTE_CC" HeaderText="NOTE_CC" 
                                SortExpression="NOTE_CC" />
                            <asp:BoundField DataField="NOTE_TP" HeaderText="NOTE_TP" 
                                SortExpression="NOTE_TP" />
                            <asp:BoundField DataField="NOTE_EXAM" HeaderText="NOTE_EXAM" 
                                SortExpression="NOTE_EXAM" />
                            <asp:BoundField DataField="ABSENT_CC" HeaderText="ABSENT_CC" 
                                SortExpression="ABSENT_CC" />
                            <asp:BoundField DataField="ABSENT_TP" HeaderText="ABSENT_TP" 
                                SortExpression="ABSENT_TP" />
                            <asp:BoundField DataField="ABSENT_EXAM" HeaderText="ABSENT_EXAM" 
                                SortExpression="ABSENT_EXAM" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="#FF3300"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
