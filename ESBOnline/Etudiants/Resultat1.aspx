<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="Resultat1.aspx.cs" Inherits="ESPOnline.Etudiants.Resultat1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--  <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
            <div class="col-xs-1">
               
                &nbsp;&nbsp;</div>
            <div class="col-xs-10">
              <center><h1> Notes Des Modules </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                <asp:DetailsView ID="DetailsView1" runat="server"  DataSourceID="SqlDataSource3" Height="50px"
                                            Width="549px" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" 
                                            GridLines="None">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                            <Fields>
                                                <%--<asp:BoundField DataField="MOY_SEM1" HeaderText="MOYENNE SEMESTRE 1" SortExpression="MOY_GENERAL" />
                                                 --%>
                                                  <asp:BoundField DataField="MOY_GENERAL" HeaderText="MOYENNE SEMESTRE 1" SortExpression="MOY_GENERAL" />
                                            </Fields>

                                          
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        </asp:DetailsView><hr />
                </center>


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
                </center>
                <center>
                 
                    <asp:GridView ID="GridView3" runat="server" 
                AutoGenerateColumns="False" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="NOM MODULES" 
                        SortExpression="DESIGNATION" />
                      
                            <asp:BoundField DataField="NOM_ENS" HeaderText="NOM ENSEIGNANT" 
                                SortExpression="NOM_ENS" />
                                 <asp:BoundField DataField="COEF" HeaderText="COEF" 
                                SortExpression="COEF" />
                            <asp:TemplateField HeaderText="NOTE CC" SortExpression="NOTE_CC">
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# ExisteNote(Eval("NOTE_CC"),Eval("EXISTE_NOTE_CC"),("ABSENT_CC"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <%--   <asp:TemplateField HeaderText="NOTE TP" SortExpression="NOTE_TP">
                                
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# ExisteNote(Eval("NOTE_TP"),Eval("EXISTE_NOTE_TP"),Eval("ABSENT_TP")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="NOTE EXAM" SortExpression="NOTE_EXAM">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#  FormatNullValue(Eval("NOTE_EXAM"), Eval("ABSENT_EXAM")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
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
                <hr />

                 <asp:GridView ID="GridView2" runat="server" 
                AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
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
                     
<asp:TemplateField HeaderText="DS1" SortExpression="note_esb_01">
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#NullValue(Eval("note_esb_01"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DS2" SortExpression="note_esb_02 ">
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#NullValue(Eval("note_esb_02"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                     
                     
                     
                     
                            <asp:TemplateField HeaderText="NOTE CC" SortExpression="NOTE_CC">
                                 
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# ExisteNote(Eval("NOTE_CC"),Eval("EXISTE_NOTE_CC"),("ABSENT_CC"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <%--   <asp:TemplateField HeaderText="NOTE TP" SortExpression="NOTE_TP">
                                
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# ExisteNote(Eval("NOTE_TP"),Eval("EXISTE_NOTE_TP"),Eval("ABSENT_TP")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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


                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="select  DESIGNATION,CODE_MODULE,NOM_ENS,COEF,
 DECODE(note_esb_01 ,'','','Module non encore évalué' ) note_esb_01
  , DECODE(note_esb_02 ,'','','Module non encore évalué' ) note_esb_02 , 
  DECODE(NOTE_CC,'','','Module non encore évalué' ) NOTE_CC  ,
  DECODE(NOTE_TP,'','','Module non encore évalué' ) NOTE_TP,DECODE(NOTE_EXAM,'','','Module non encore évalué' ) NOTE_EXAM 
  ,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP 
  from  ESP_V_NOTE_SEM1 where id_et =:ID_ET and code_module not in(select code_module 
  from (select t1.CODE_MODULE from ESP_V_NOTE_SEM1  t1 , ESP_EVALUATION  t2, esp_module t3 
  where t1.ID_ET = t2.ID_ET and t1.id_et=:ID_ET and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE )) 
  UNION (select t1.DESIGNATION as DESIGNATION ,t2.CODE_MODULE as CODE_MODULE,t1.NOM_ENS as NOM_ENS ,t1.COEF as COEF  ,
  TO_CHAR(t1.note_esb_01 ) note_esb_01
  , TO_CHAR(t1.note_esb_02  ) note_esb_02 ,

  TO_CHAR(t1.NOTE_CC) as  NOTE_CC,TO_CHAR(t1.NOTE_TP) as NOTE_TP,TO_CHAR(t1.NOTE_EXAM) as  NOTE_EXAM,
  ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP from ESP_V_NOTE_SEM1  t1 ,ESP_EVALUATION  t2, esp_module t3 
  where t1.ID_ET = t2.ID_ET and t1.id_et=:ID_ET and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE) ">
           <SelectParameters>
                            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
        
        </asp:SqlDataSource>
              
              </center>
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="select  DESIGNATION,CODE_MODULE,NOM_ENS,COEF,
 to_char( note_esb_01)note_esb_01
  , to_char( note_esb_02 )note_esb_02, 
  to_char( NOTE_CC)NOTE_CC  ,
  to_char (NOTE_TP) NOTE_TP,to_char(NOTE_EXAM )NOTE_EXAM
  ,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP 
  from  ESP_V_NOTE_SEM1 where id_et =:ID_ET and code_module not in(select code_module 
  from (select t1.CODE_MODULE from ESP_V_NOTE_SEM1  t1 , ESP_EVALUATION  t2, esp_module t3 
  where t1.ID_ET = t2.ID_ET and t1.id_et=:ID_ET and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE )) 
  UNION (select t1.DESIGNATION as DESIGNATION ,t2.CODE_MODULE as CODE_MODULE,t1.NOM_ENS as NOM_ENS ,t1.COEF as COEF  ,
  TO_CHAR(t1.note_esb_01 ) note_esb_01
  , TO_CHAR(t1.note_esb_02  ) note_esb_02 ,

  TO_CHAR(t1.NOTE_CC) as  NOTE_CC,TO_CHAR(t1.NOTE_TP) as NOTE_TP,TO_CHAR(t1.NOTE_EXAM) as  NOTE_EXAM,
  ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP from ESP_V_NOTE_SEM1  t1 ,ESP_EVALUATION  t2, esp_module t3 
  where t1.ID_ET = t2.ID_ET and t1.id_et=:ID_ET and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE) ">
           <SelectParameters>
                            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
        
        </asp:SqlDataSource>
                  <%--  and FS_IS_STUDENT_AUTORISED_NEW(:ID_ET)='1'--%>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="select  MOY_GENERAL from esp_inscription wHERE (ID_ET =:ID_ET)   AND annee_deb=(select max(annee_deb) from societe)">
                        <SelectParameters>
                            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
            </div>

<%--            and (esp_inscription.code_cl in ('1 MAD','2-LFG-1','2-LFG-2','2-LFG-3','2-LFG-4','2-LFG-5','1-CCA-1','3-LFIG-2','3-LFIG-1','2-BA-1','2-MKD-1','3-LFG-2','3-LFG-3','3-LFG-1') or esp_inscription.code_cl like '2-MD%') AND--%>

</asp:Content>
