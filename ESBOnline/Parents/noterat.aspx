<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="noterat.aspx.cs" Inherits="ESPOnline.Parents.noterat" %>
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
              <center><h1> Notes Des Modules session Rattrapage </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                  <asp:Label ID="Label1" runat="server" 
                        Text="Sauf erreur ou omission, nous vous communiquons ci-après vos notes relatives aux examens de rattrapage. Elles vous sont données à titre indicatif et ne seront définitives qu'avec l'annonce des résultats finaux. " 
                        ForeColor="#CC0000" Font-Size="Medium"></asp:Label><br />
                    <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" DataSourceID="SQLDataSource1" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="NOM MODULES" 
                        SortExpression="DESIGNATION" />
                      
                                 <asp:BoundField DataField="COEF" HeaderText="COEF" 
                                SortExpression="COEF" />
                             
                           <asp:BoundField DataField="NOTE" HeaderText="NOTE_EXAM_RAT" 
                                SortExpression="NOTE" />
                            
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

                       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT * FROM ESP_V_NOTE_RAT where id_et=:ID_ET">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>



                    <br />


                    
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="select  esp_note_rat.CODE_MODULE,
        esp_note_rat.ID_ET,
        esp_note_rat.CODE_CL,
         ESP_MODULE.DESIGNATION,
         ESP_MODULE_PANIER_CLASSE_SAISO.COEF,
         esp_note_rat.NOTE,
        EXISTE_NOTE_CC,
        EXISTE_NOTE_TP
  FROM 
         ESP_MODULE,
         esp_note_rat,
         ESP_MODULE_PANIER_CLASSE_SAISO,
	ESP_ENTETE_NOTE
   WHERE (esp_note_rat.CODE_MODULE= ESP_MODULE.CODE_MODULE  ) and
 	  (esp_note_rat.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and
 	  (esp_note_rat.code_cl = ESP_ENTETE_NOTE.code_cl ) and
 	  (esp_note_rat.code_module = ESP_ENTETE_NOTE.code_module ) and
 
 	       ( esp_note_rat.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and
         ( esp_note_rat.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL )  and
         ( esp_note_rat.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and
         ( esp_note_rat.type_rat ='O') and    (esp_note_rat.CODE_CL  in ('3-LFIG-1','3-LFIG-2','3-LFG-1' ,  '3-LFG-2'  ,  '3-LFG-3'
,'2-LFG-1' ,  '2-LFG-2'  ,  '2-LFG-3' ,  '2-LFG-4' , '2-LFG-5' , 
'1-MDSI-1' ,  '1-MDSI-2',
'1-MKD-1' ,  '1-MKD-2',
'1-CCA-1',
'1-BA-1' ,  '1-BA-2')  or  esp_note_rat.CODE_CL like '2-MD%')  
          and esp_note_rat.id_et=:ID_ET  and
       (esp_note_rat.annee_deb=(select max(annee_deb) from societe)) and
       --(scoesb02.fs_is_student_autorised_new( esp_note_rat.ID_ET) =1) and
        ( id_et not in (select id_et from esp_inscription
		where annee_deb=(select max(annee_deb) from societe) and reserve='O'))
                    
                    ">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                     <br />
                <hr /><hr />
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
            </div>

</asp:Content>