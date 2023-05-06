<%@ Page Title="" Language="C#" MasterPageFile="~/EnseignantsCUP/Cup.Master" AutoEventWireup="true" CodeBehind="AffichageNote.aspx.cs" Inherits="ESPOnline.EnseignantsCUP.AffichageNote" %>
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
        .style4
        {
            width: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server">
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
                            
                        </tr>
                    </table>
                      
                </td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>  <td class="style3">
                                &nbsp;</td><td> <strong><span class="alert-dismissable">Classe:</span></strong>      
          
    
       <asp:DropDownList  ID="DropDownList1" runat="server"  AutoPostBack="True"  
                 DataSourceID="ObjectDataSource1"      
            DataTextField="CODE_CL" AppendDataBoundItems="True" CssClass="form-control" 
            DataValueField="CODE_CL" ForeColor="#CC0000" Height="36px" Width="202px" 
            BackColor="#CCCCCC" 
             >
            <asp:ListItem>Choisir Une classe</asp:ListItem>
        
    </asp:DropDownList> 
          
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetListNotes" TypeName=" ESPOnline.EnseignantsCUP.Classenote">
            <SelectParameters>
                <asp:SessionParameter Name="_Id_ens" SessionField="ID_ENS" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
      </td>
      </tr>
      <tr><td>&nbsp;&nbsp;&nbsp;&nbsp; </td>
     
      <td><strong><span class="alert-dismissable">Module:</span></strong>
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" 
            DataSourceID="ObjectDataSource2" DataTextField="DESIGNATION" AppendDataBoundItems="True"
            DataValueField="DESIGNATION" ForeColor="#CC0000" Height="36px" Width="202px" 
            BackColor="#CCCCCC" 
              >
           
        </asp:DropDownList>
        
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetListNotes" TypeName="ESPOnline.EnseignantsCU.modulnote" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="_id_ens" SessionField="ID_ENS" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="codcl" 
                    PropertyName="SelectedValue" Type="String" />
                   
            </SelectParameters>
        </asp:ObjectDataSource>
        
        </td></tr> 
         <tr><td></td></tr>
         <tr><td></td></tr>
            <tr> 
                 
                     
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource1" 
                            >
                            <HeaderStyle BackColor="#A8A8A8" Font-Bold="True" ForeColor="#D80000" />
                            <RowStyle BackColor="	#E0E0E0" ForeColor="#000000" />
                            <Columns>
                                <asp:BoundField DataField="ID_ET" HeaderText="Identifiant" SortExpression="ID_ET" />
                                <asp:BoundField DataField="Nom Prénom" HeaderText="Nom Prénom" ReadOnly="True" 
                                    SortExpression="Nom Prénom" />
                                <asp:BoundField DataField="NOTE_CC" HeaderText="NOTE CC" 
                                    SortExpression="NOTE_CC" />
                                <asp:BoundField DataField="NOTE_TP" HeaderText="NOTE TP" 
                                    SortExpression="NOTE_TP" />
                                <asp:BoundField DataField="NOTE_EXAM" HeaderText="NOTE EXAM" 
                                    SortExpression="NOTE_EXAM" />
                                <asp:BoundField DataField="ABSENT_CC" HeaderText="ABSENT CC" 
                                    SortExpression="ABSENT_CC" />
                                <asp:BoundField DataField="ABSENT_TP" HeaderText="ABSENT TP" 
                                    SortExpression="ABSENT_TP" />
                                <asp:BoundField DataField="ABSENT_EXAM" HeaderText="ABSENT EXAM" 
                                    SortExpression="ABSENT_EXAM" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="    SELECT ESP_V_NOTE_SEM1.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS &quot;Nom Prénom&quot;,ESP_V_NOTE_SEM1.NOTE_CC,ESP_V_NOTE_SEM1.NOTE_TP,ESP_V_NOTE_SEM1.NOTE_EXAM,ESP_V_NOTE_SEM1.ABSENT_CC,ESP_V_NOTE_SEM1.ABSENT_TP,ESP_V_NOTE_SEM1.ABSENT_EXAM
FROM         ESP_ETUDIANT,ESP_V_NOTE_SEM1 
WHERE     ESP_ETUDIANT.ID_ET = ESP_V_NOTE_SEM1.ID_ET AND (ESP_V_NOTE_SEM1.CODE_CL =: codcl)  AND (ESP_V_NOTE_SEM1.DESIGNATION = :desg) 
                     
ORDER BY ESP_ETUDIANT.NOM_ET">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="codcl" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="DropDownList2" Name="desg" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                 
            </tr>
</table>
       
    <%--<div class="col-lg-3">
           <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>--%>
    
  
              </asp:Panel>
             
</asp:Content>
     
