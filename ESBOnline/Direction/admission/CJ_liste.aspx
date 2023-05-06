<%@ Page Title="" Language="C#"  AutoEventWireup="true" 
CodeBehind="CJ_liste.aspx.cs" Inherits="ESPOnline.Direction.admission.CJ_liste"  MasterPageFile="~/Direction/admission/ad.Master" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
 
     
              <center><asp:Label ID="Label2" runat="server" Text="Nombre de candidats inscrits à ce jour :">   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></asp:Label></center>
     
    <br />
  <center>    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Excel_XLSX.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" Height="45px" 
                Width="120px" /> </center>
        
    <center>

                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
           <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
    
                    
    
    <div>
    <telerik:RadGrid ID="RadGrid1" runat="server" ShowFooter="true"  AllowFilteringByColumn="True" AllowSorting="True" 
     CssClass="RadGridCustomClass" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"
            BorderColor="Maroon"   CellSpacing="0"  SelectedItemStyle-CssClass="SelectedItem" GridLines="Vertical" 
             allowmultirowselection="True" 
            AutoGenerateColumns="False" onItemDataBound="grid1" Width="100%"
          
            DataSourceID="ee"     BorderStyle="Groove" OnPreRender="RadGrid1_PreRender"
             >
            
       <ExportSettings HideStructureColumns="true" FileName="liste"/>
           
            <ClientSettings AllowKeyboardNavigation="true" >
               
                
<Selecting AllowRowSelect="true"></Selecting>
            </ClientSettings>
<ExportSettings FileName="liste" HideStructureColumns="True"></ExportSettings>

               <ClientSettings>
                            <Scrolling   AllowScroll="true"  SaveScrollPosition="True"/>
                          <%--  <Resizing   AllowColumnResize="true"/> --%>                  
<Selecting AllowRowSelect="True"></Selecting>

<Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>

<Resizing AllowColumnResize="True"></Resizing>
                          </ClientSettings>
            <MasterTableView   DataSourceID="ee" datakeynames="ID_ET"><CommandItemSettings ShowAddNewRecordButton="false" />
                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>
               <%-- <CommandItemSettings AddNewRecordText="Ajouter Nouveau projet"></CommandItemSettings>--%>
               <%-- <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>--%>

<CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />

<PopUpSettings Modal="True"></PopUpSettings>
                </EditFormSettings>
                <Columns>
                 <%-- <telerik:GridBoundColumn DataField="ID_ET"   FilterControlAltText="Filter ID_ET column"
                        HeaderText="ID_ET" SortExpression="ID_ET" UniqueName="ID_ET" Visible="false">
                    </telerik:GridBoundColumn>--%>

                    

                    <telerik:GridBoundColumn DataField="NUM_CIN_PASSEPORT"  FilterControlAltText="Filter NUM_CIN_PASSEPORT column" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        HeaderText="CIN_PASSEPORT" SortExpression="NUM_CIN_PASSEPORT" 
                          UniqueName="NUM_CIN_PASSEPORT">
                         <HeaderStyle Width="150px" />
    <ItemStyle Width="150px" />
    <FooterStyle Width="150px" />
                    </telerik:GridBoundColumn>
                     
                     
                     
                     
                     <telerik:GridBoundColumn DataField="DATE_DELIVRANCE" HeaderText="Date délivrance CIN" SortExpression="DATE_DELIVRANCE"
                      AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        UniqueName="DATE_DELIVRANCE" FilterControlAltText="Filter DATE_DELIVRANCE column" ReadOnly="True">
                    </telerik:GridBoundColumn>
                     
                     
                     <telerik:GridBoundColumn DataField="ID_ET"  AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter ID_ET column" HeaderText="ID_ET" ReadOnly="True" 
                          SortExpression="ID_ET" UniqueName="ID_ET">
                      </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn UniqueName="DATE_ENC" HeaderText="Date Encadrement" DataField="DATE_ENC"/>--%>
                    <telerik:GridBoundColumn DataField="NOM" HeaderText="NOM" SortExpression="NOM" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        UniqueName="NOM" FilterControlAltText="Filter NOM column" ReadOnly="True">
                    </telerik:GridBoundColumn>




                     



                     <telerik:GridBoundColumn DataField="DATE_NAIS_ET" HeaderText="DATE_NAIS_ET" SortExpression="DATE_NAIS_ET" 
                     AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        UniqueName="DATE_NAIS_ET" FilterControlAltText="Filter DATE_NAIS_ET column" ReadOnly="True">
                    </telerik:GridBoundColumn>



                     <telerik:GridBoundColumn DataField="DATE_SAISIE" HeaderText="Date enreg" SortExpression="DATE_SAISIE" AutoPostBackOnFilter="true" 
                     CurrentFilterFunction="Contains" ShowFilterIcon="false"
                        UniqueName="DATE_SAISIE" FilterControlAltText="Filter DATE_SAISIE column" ReadOnly="True">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="SESSION_BAC" 
                          FilterControlAltText="Filter SESSION_BAC column" HeaderText="SESSION_BAC" 
                          AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" 
                          ShowFilterIcon="false" 
                          SortExpression="SESSION_BAC" UniqueName="SESSION_BAC">
                      </telerik:GridBoundColumn>
                     
                      <telerik:GridBoundColumn DataField="NATURE_BAC" 
                          FilterControlAltText="Filter NATURE_BAC column" HeaderText="BAC" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="NATURE_BAC" UniqueName="NATURE_BAC">
                      </telerik:GridBoundColumn>
                      
                    
                      <telerik:GridBoundColumn DataField="ANNEE_BAC" 
                          FilterControlAltText="Filter ANNEE_BAC column" HeaderText="ANNEE" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="ANNEE_BAC" UniqueName="ANNEE_BAC">
                      </telerik:GridBoundColumn>
                      
                      <telerik:GridBoundColumn DataField="MOY_BAC_ET" 
                          FilterControlAltText="Filter MOY_BAC_ET column" HeaderText="MOY_BAC" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="MOY_BAC_ET" UniqueName="MOY_BAC_ET">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="NIVEAU_ACCES" DataType="System.Int16" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter NIVEAU_ACCES column" HeaderText="NIV" 
                          SortExpression="NIVEAU_ACCES" UniqueName="NIVEAU_ACCES">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="DIPLOME_SUP_ET" 
                          FilterControlAltText="Filter DIPLOME_SUP_ET column" HeaderText="DIPLOME" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="DIPLOME_SUP_ET" UniqueName="DIPLOME_SUP_ET">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="E_MAIL_ET" 
                          FilterControlAltText="Filter E_MAIL_ET column" HeaderText="MAIL" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="E_MAIL_ET" UniqueName="E_MAIL_ET">
                      </telerik:GridBoundColumn>
                    <%--  <telerik:GridBoundColumn DataField="PASSWORD" 
                          FilterControlAltText="Filter PASSWORD column" HeaderText="PASSWORD" 
                          SortExpression="PASSWORD" UniqueName="PASSWORD">
                      </telerik:GridBoundColumn>--%>
                      <telerik:GridBoundColumn DataField="SPECIALITE_ESP_ET" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          FilterControlAltText="Filter SPECIALITE_ESP_ET column" 
                          HeaderText="SPECIALITE" SortExpression="SPE" 
                          UniqueName="SPECIALITE_ESP_ET"></telerik:GridBoundColumn>
                          
                      
                     
                      <telerik:GridBoundColumn DataField="DATEENTR" 
                          FilterControlAltText="Filter DATEENTR column" HeaderText="DATE" 
                          SortExpression="DATEENTR" UniqueName="DATEENTR">
                      </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="TEL_ET" 
                          FilterControlAltText="Filter TEL_ET column" HeaderText="TEL" 
                          SortExpression="TEL_ET" UniqueName="TEL_ET">
                      </telerik:GridBoundColumn>
                       
                       <telerik:GridBoundColumn DataField="ETAB_origine" 
                          FilterControlAltText="Filter ETAB_origine column" HeaderText="ETAB" 
                          SortExpression="ETAB_origine" UniqueName="ETAB_origine">
                      </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CULTURE_MOODLE"  ReadOnly="True" 
                          FilterControlAltText="Filter CULTURE_MOODLE column" HeaderText="Culture Général" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false"
                          SortExpression="CULTURE_MOODLE" UniqueName="CULTURE_MOODLE">
                      </telerik:GridBoundColumn>

                      
  <telerik:GridBoundColumn DataField="SCORE_ENTRETIEN" 
                          FilterControlAltText="Filter SCORE_ENTRETIEN column" HeaderText="ENTRETIEN" 
                          SortExpression="SCORE_ENTRETIEN" UniqueName="SCORE_ENTRETIEN"/>
                            <telerik:GridBoundColumn DataField="SCORE_francais" 
                          FilterControlAltText="Filter SCORE_francais column" HeaderText="FR" 
                          SortExpression="SCORE_francais" UniqueName="SCORE_francais"/>
                            <telerik:GridBoundColumn DataField="SCORE_ANGLAIS"
                          FilterControlAltText="Filter SCORE_ANGLAIS column" HeaderText="AN" 
                          SortExpression="SCORE_ANGLAIS" UniqueName="SCORE_ANGLAIS"/>
                              <telerik:GridBoundColumn DataField="SCORE_QI" 
                          FilterControlAltText="Filter SCORE_QI column" HeaderText="QI" 
                          SortExpression="SCORE_QI" UniqueName="SCORE_QI"/>
                           <telerik:GridBoundColumn DataField="SCORE_dossier" 
                          FilterControlAltText="Filter SCORE_dossier column" HeaderText="Dossier" 
                          SortExpression="SCORE_dossier" UniqueName="SCORE_dossier"/>
                             <telerik:GridBoundColumn DataField="score_final" 
                          FilterControlAltText="Filter score_final column" HeaderText="Total" 
                          SortExpression="score_final" UniqueName="score_final"/>
                   
                </Columns>
       
                  
            </MasterTableView>
       

<SelectedItemStyle CssClass="SelectedItem"></SelectedItemStyle>


<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </div><br />
                    <asp:sqldatasource runat="server"  id="ee"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="SELECT  T1.num_cin_passeport, T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' 
then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,T1.SCORE_ENTRETIEN,score_final,score_dossier,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  
when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en sciences de gestion Parcours Management'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en sciences de gestion Parcours comptabilité'   when 
t1.SPECIALITE_ESP_ET='08' then 'Master professionnel de management digital et systèmes d information'   when t1.SPECIALITE_ESP_ET='09' then 'Master professionnel en Marketing digital' when t1.SPECIALITE_ESP_ET='10' then 'Master professionnel en innovation et entrepreneuriat' 
                      when t1.SPECIALITE_ESP_ET='16' then 'Licence Informatique Mention Business Computing Parcours Information System'
                          
                                              when t1.SPECIALITE_ESP_ET='17' then 'Licence Informatique Mention Business Computing Parcours Business Intelligence'
                          when t1.SPECIALITE_ESP_ET='18' then 'Licence Mathématiques appliqués à l analyse des données et à la décision'

                          when t1.SPECIALITE_ESP_ET='11' then 'Master professionnel en Business Analytics'
                          when t1.SPECIALITE_ESP_ET='12' then 'Master professionnel comptabilité contrôle audit'  
                          when t1.SPECIALITE_ESP_ET='21' then 'MDSI Alternance VERMEG'  
                          when t1.SPECIALITE_ESP_ET='22' then 'MDSI Exécutif'  
                         
end) SPECIALITE_ESP_ET ,T1.ID_ET,REPLACE(REPLACE(T1.dateentr,'-JUL-2019','/07/2019'),'-AUG-2019','/08/2019')  dateentr ,etab_origine, T1.TEL_ET,T1.NATIONALITE,t1.CULTURE_MOODLE,t1.DATE_DELIVRANCE,t1.DATE_NAIS_ET,t1.LIEU_NAIS_ET,t1.DATE_SAISIE,T1.SESSION_BAC FROM   ESP_ETUDIANT t1  WHERE   id_et like '19%' order by specialite_esp_et desc ">

        
      
     
   
   
   </asp:sqldatasource><br />
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
                        SelectCommand="select count(*) from esp_etudiant where id_et LIKE '22%'"></asp:SqlDataSource>
   </center>
         
    
    
       
    <telerik:RadGrid ID="RadGrid2" runat="server" ShowFooter="True"  AllowFilteringByColumn="True" AllowSorting="True" 
     CssClass="RadGridCustomClass" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"
            BorderColor="Maroon"   CellSpacing="0"  SelectedItemStyle-CssClass="SelectedItem" GridLines="Vertical" 
             allowmultirowselection="True" 
            AutoGenerateColumns="False" onItemDataBound="grid1" Width="100%"
          Visible="False"
            DataSourceID="Sqldatasource2"     BorderStyle="Groove" OnPreRender="RadGrid1_PreRender" Culture="fr-FR"
             >
            
       <ExportSettings HideStructureColumns="true" FileName="liste"/>
           
            <ClientSettings AllowKeyboardNavigation="true" >
               
                
<Selecting AllowRowSelect="true"></Selecting>

<Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>

<Resizing AllowColumnResize="True"></Resizing>
            </ClientSettings>
<ExportSettings FileName="liste" HideStructureColumns="True"></ExportSettings>

               <ClientSettings>
                            <Scrolling   AllowScroll="true"  SaveScrollPosition="True"/>
                          <%--  <Resizing   AllowColumnResize="true"/> --%>                  
<Selecting AllowRowSelect="True"></Selecting>

<Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>

<Resizing AllowColumnResize="True"></Resizing>
                          </ClientSettings>
            <MasterTableView   DataSourceID="Sqldatasource2" DataKeyNames="ID_ET">
               <%-- <CommandItemSettings AddNewRecordText="Ajouter Nouveau projet"></CommandItemSettings>--%>
               <%-- <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>--%>

                <CommandItemSettings ShowAddNewRecordButton="false" />

                <NoRecordsTemplate>
                    Aucun enregistrement à afficher!
                </NoRecordsTemplate>

<CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="ID_ET" FilterControlAltText="Filter ID_ET column" HeaderText="ID_ET" SortExpression="ID_ET" UniqueName="ID_ET" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_SAISIE" FilterControlAltText="Filter DATE_SAISIE column" HeaderText="DATE_SAISIE" SortExpression="DATE_SAISIE" UniqueName="DATE_SAISIE" DataType="System.DateTime">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PNOM_ET" FilterControlAltText="Filter PNOM_ET column" HeaderText="PNOM_ET" SortExpression="PNOM_ET" UniqueName="PNOM_ET" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NUM_CIN_PASSEPORT" FilterControlAltText="Filter NUM_CIN_PASSEPORT column" HeaderText="NUM_CIN_PASSEPORT" SortExpression="NUM_CIN_PASSEPORT" UniqueName="NUM_CIN_PASSEPORT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NATURE_PIECE_ID" FilterControlAltText="Filter NATURE_PIECE_ID column" HeaderText="NATURE_PIECE_ID" SortExpression="NATURE_PIECE_ID" UniqueName="NATURE_PIECE_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LIEU_DELIVRANCE" FilterControlAltText="Filter LIEU_DELIVRANCE column" HeaderText="LIEU_DELIVRANCE" SortExpression="LIEU_DELIVRANCE" UniqueName="LIEU_DELIVRANCE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_DELIVRANCE" FilterControlAltText="Filter DATE_DELIVRANCE column" HeaderText="DATE_DELIVRANCE" SortExpression="DATE_DELIVRANCE" UniqueName="DATE_DELIVRANCE" DataType="System.DateTime">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SEXE" FilterControlAltText="Filter SEXE column" HeaderText="SEXE" SortExpression="SEXE" UniqueName="SEXE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="E_MAIL_ET" FilterControlAltText="Filter E_MAIL_ET column" HeaderText="E_MAIL_ET" SortExpression="E_MAIL_ET" UniqueName="E_MAIL_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TEL_ET" FilterControlAltText="Filter TEL_ET column" HeaderText="TEL_ET" SortExpression="TEL_ET" UniqueName="TEL_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NATIONALITE" FilterControlAltText="Filter NATIONALITE column" HeaderText="NATIONALITE" SortExpression="NATIONALITE" UniqueName="NATIONALITE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATE_NAIS_ET" FilterControlAltText="Filter DATE_NAIS_ET column" HeaderText="DATE_NAIS_ET" SortExpression="DATE_NAIS_ET" UniqueName="DATE_NAIS_ET" DataType="System.DateTime">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LIEU_NAIS_ET" FilterControlAltText="Filter LIEU_NAIS_ET column" HeaderText="LIEU_NAIS_ET" SortExpression="LIEU_NAIS_ET" UniqueName="LIEU_NAIS_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NATURE_ET" FilterControlAltText="Filter NATURE_ET column" HeaderText="NATURE_ET" SortExpression="NATURE_ET" UniqueName="NATURE_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FONCTION_ET" FilterControlAltText="Filter FONCTION_ET column" HeaderText="FONCTION_ET" SortExpression="FONCTION_ET" UniqueName="FONCTION_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ADRESSE_ET" FilterControlAltText="Filter ADRESSE_ET column" HeaderText="ADRESSE_ET" SortExpression="ADRESSE_ET" UniqueName="ADRESSE_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CP_ET" FilterControlAltText="Filter CP_ET column" HeaderText="CP_ET" SortExpression="CP_ET" UniqueName="CP_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VILLE_ET" FilterControlAltText="Filter VILLE_ET column" HeaderText="VILLE_ET" SortExpression="VILLE_ET" UniqueName="VILLE_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PAYS_ET" FilterControlAltText="Filter PAYS_ET column" HeaderText="PAYS_ET" SortExpression="PAYS_ET" UniqueName="PAYS_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GOUVERNORAT" FilterControlAltText="Filter GOUVERNORAT column" HeaderText="GOUVERNORAT" SortExpression="GOUVERNORAT" UniqueName="GOUVERNORAT">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TEL_PARENT_ET" FilterControlAltText="Filter TEL_PARENT_ET column" HeaderText="TEL_PARENT_ET" SortExpression="TEL_PARENT_ET" UniqueName="TEL_PARENT_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NATURE_BAC" FilterControlAltText="Filter NATURE_BAC column" HeaderText="NATURE_BAC" SortExpression="NATURE_BAC" UniqueName="NATURE_BAC" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PAY_BAC" FilterControlAltText="Filter PAY_BAC column" HeaderText="PAY_BAC" SortExpression="PAY_BAC" UniqueName="PAY_BAC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ANNEE_BAC" FilterControlAltText="Filter ANNEE_BAC column" HeaderText="ANNEE_BAC" SortExpression="ANNEE_BAC" UniqueName="ANNEE_BAC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MOY_BAC_ET" FilterControlAltText="Filter MOY_BAC_ET column" HeaderText="MOY_BAC_ET" SortExpression="MOY_BAC_ET" UniqueName="MOY_BAC_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NUM_BAC_ET" FilterControlAltText="Filter NUM_BAC_ET column" HeaderText="NUM_BAC_ET" SortExpression="NUM_BAC_ET" UniqueName="NUM_BAC_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SESSION_BAC" FilterControlAltText="Filter SESSION_BAC column" HeaderText="SESSION_BAC" SortExpression="SESSION_BAC" UniqueName="SESSION_BAC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ETABL_NOM" FilterControlAltText="Filter ETABL_NOM column" HeaderText="ETABL_NOM" SortExpression="ETABL_NOM" UniqueName="ETABL_NOM">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ETAB_BAC" FilterControlAltText="Filter ETAB_BAC column" HeaderText="ETAB_BAC" SortExpression="ETAB_BAC" UniqueName="ETAB_BAC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ACTIVITE_ANNEE_PREC" FilterControlAltText="Filter ACTIVITE_ANNEE_PREC column" HeaderText="ACTIVITE_ANNEE_PREC" SortExpression="ACTIVITE_ANNEE_PREC" UniqueName="ACTIVITE_ANNEE_PREC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIPLOME_SUP_ET" FilterControlAltText="Filter DIPLOME_SUP_ET column" HeaderText="DIPLOME_SUP_ET" SortExpression="DIPLOME_SUP_ET" UniqueName="DIPLOME_SUP_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ETAB_ORIGINE" FilterControlAltText="Filter ETAB_ORIGINE column" HeaderText="ETAB_ORIGINE" SortExpression="ETAB_ORIGINE" UniqueName="ETAB_ORIGINE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ANNEE_DIPLOME" FilterControlAltText="Filter ANNEE_DIPLOME column" HeaderText="ANNEE_DIPLOME" SortExpression="ANNEE_DIPLOME" UniqueName="ANNEE_DIPLOME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NIVEAU_DIPLOME_SUP_ET" FilterControlAltText="Filter NIVEAU_DIPLOME_SUP_ET column" HeaderText="NIVEAU_DIPLOME_SUP_ET" SortExpression="NIVEAU_DIPLOME_SUP_ET" UniqueName="NIVEAU_DIPLOME_SUP_ET" DataType="System.Decimal">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NIVEAU_COURANT_ET" FilterControlAltText="Filter NIVEAU_COURANT_ET column" HeaderText="NIVEAU_COURANT_ET" SortExpression="NIVEAU_COURANT_ET" UniqueName="NIVEAU_COURANT_ET" DataType="System.Int16">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NIVEAU_ACCES" FilterControlAltText="Filter NIVEAU_ACCES column" HeaderText="NIVEAU_ACCES" SortExpression="NIVEAU_ACCES" UniqueName="NIVEAU_ACCES" DataType="System.Int16">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SPECIALITE_ESP_ET" FilterControlAltText="Filter SPECIALITE_ESP_ET column" HeaderText="SPECIALITE_ESP_ET" SortExpression="SPECIALITE_ESP_ET" UniqueName="SPECIALITE_ESP_ET" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DATEENTR" FilterControlAltText="Filter DATEENTR column" HeaderText="DATEENTR" SortExpression="DATEENTR" UniqueName="DATEENTR" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OBSERVATION_ET" FilterControlAltText="Filter OBSERVATION_ET column" HeaderText="OBSERVATION_ET" SortExpression="OBSERVATION_ET" UniqueName="OBSERVATION_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NATURE_COURS" FilterControlAltText="Filter NATURE_COURS column" HeaderText="NATURE_COURS" SortExpression="NATURE_COURS" UniqueName="NATURE_COURS">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ID_ENS_ENTRETIEN" FilterControlAltText="Filter ID_ENS_ENTRETIEN column" HeaderText="ID_ENS_ENTRETIEN" SortExpression="ID_ENS_ENTRETIEN" UniqueName="ID_ENS_ENTRETIEN">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OBSERVATION_ENTRETIEN" FilterControlAltText="Filter OBSERVATION_ENTRETIEN column" HeaderText="OBSERVATION_ENTRETIEN" SortExpression="OBSERVATION_ENTRETIEN" UniqueName="OBSERVATION_ENTRETIEN">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NUM_SESSION" FilterControlAltText="Filter NUM_SESSION column" HeaderText="NUM_SESSION" SortExpression="NUM_SESSION" UniqueName="NUM_SESSION">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CYCLE_ET" FilterControlAltText="Filter CYCLE_ET column" HeaderText="CYCLE_ET" SortExpression="CYCLE_ET" UniqueName="CYCLE_ET">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CULTURE_MOODLE" FilterControlAltText="Filter CULTURE_MOODLE column" HeaderText="CULTURE_GENERAL" SortExpression="CULTURE_MOODLE" UniqueName="CULTURE_MOODLE" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_DOSSIER" FilterControlAltText="Filter SCORE_DOSSIER column" HeaderText="SCORE_DOSSIER" SortExpression="SCORE_DOSSIER" UniqueName="SCORE_DOSSIER" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_FRANCAIS" FilterControlAltText="Filter SCORE_FRANCAIS column" HeaderText="SCORE_FRANCAIS" SortExpression="SCORE_FRANCAIS" UniqueName="SCORE_FRANCAIS" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_ANGLAIS" FilterControlAltText="Filter SCORE_ANGLAIS column" HeaderText="SCORE_ANGLAIS" SortExpression="SCORE_ANGLAIS" UniqueName="SCORE_ANGLAIS" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_QI" FilterControlAltText="Filter SCORE_QI column" HeaderText="SCORE_QI" SortExpression="SCORE_QI" UniqueName="SCORE_QI" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_ENTRETIEN" FilterControlAltText="Filter SCORE_ENTRETIEN column" HeaderText="SCORE_ENTRETIEN" SortExpression="SCORE_ENTRETIEN" UniqueName="SCORE_ENTRETIEN" DataType="System.Double">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SCORE_FINAL" FilterControlAltText="Filter SCORE_FINAL column" HeaderText="SCORE_FINAL" SortExpression="SCORE_FINAL" UniqueName="SCORE_FINAL" DataType="System.Double">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
<EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>

                    <PopUpSettings Modal="true" />

<PopUpSettings Modal="True"></PopUpSettings>
                </EditFormSettings>
       
                  
            </MasterTableView>
       

<SelectedItemStyle CssClass="SelectedItem"></SelectedItemStyle>


<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
         
    
    
       
    <asp:sqldatasource runat="server"  id="Sqldatasource2"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="
        select ID_ET, DATE_SAISIE,NOM_ET||' '||PNOM_ET as PNOM_ET,NUM_CIN_PASSEPORT,NATURE_PIECE_ID,(case when LIEU_DELIVRANCE is null then '-' when LIEU_DELIVRANCE is not null then LIEU_DELIVRANCE   end)LIEU_DELIVRANCE,DATE_DELIVRANCE,SEXE,E_MAIL_ET,TEL_ET,
NATIONALITE,DATE_NAIS_ET,LIEU_NAIS_ET,(case when NATURE_ET is null then '-' when NATURE_ET is not null then NATURE_ET  end)NATURE_ET,(case when FONCTION_ET is null then '-' when FONCTION_ET is not null then FONCTION_ET end)FONCTION_ET,ADRESSE_ET,
(case when CP_ET is null then '-' when CP_ET is not null then CP_ET  end)CP_ET,VILLE_ET,(case when PAYS_ET is null then '-'  end)PAYS_ET,GOUVERNORAT,(case when TEL_PARENT_ET is null then '-'  end)TEL_PARENT_ET
,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' 
then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,PAY_BAC,ANNEE_BAC,MOY_BAC_ET,
(case when num_bac_et is null then '-' when NUM_BAC_ET is not null then NUM_BAC_ET end )NUM_BAC_ET,
SESSION_BAC,ETABL_NOM,ETAB_BAC,ACTIVITE_ANNEE_PREC,DIPLOME_SUP_ET,(case when ETAB_ORIGINE is null then '-' when ETAB_ORIGINE is not null then ETAB_ORIGINE end )ETAB_ORIGINE,
ANNEE_DIPLOME,NIVEAU_DIPLOME_SUP_ET, (case when NIVEAU_COURANT_ET is null then '-' end )NIVEAU_COURANT_ET,NIVEAU_ACCES,(case when SPECIALITE_ESP_ET='05' then 'TIC' when SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC'  
when SPECIALITE_ESP_ET='01' then 'INFO' when SPECIALITE_ESP_ET='02' then 'TELECOM'   when SPECIALITE_ESP_ET='06' then 'Licence en sciences de gestion Parcours Management'  
when SPECIALITE_ESP_ET='07'  then 'Licence en sciences de gestion Parcours comptabilité'   when 
SPECIALITE_ESP_ET='08' then 'Master professionnel de management digital et systèmes d information'   when SPECIALITE_ESP_ET='09' then 'Master professionnel en Marketing digital' when SPECIALITE_ESP_ET='10' then 'Master professionnel en innovation et entrepreneuriat' 
                      when SPECIALITE_ESP_ET='16' then 'Licence Informatique Mention Business Computing Parcours Information System'
                          
                                              when SPECIALITE_ESP_ET='17' then 'Licence Informatique Mention Business Computing Parcours Business Intelligence'
                          when SPECIALITE_ESP_ET='18' then 'Licence Mathématiques appliqués à l analyse des données et à la décision'

                          when SPECIALITE_ESP_ET='11' then 'Master professionnel en Business Analytics'
                          when SPECIALITE_ESP_ET='12' then 'Master professionnel comptabilité contrôle audit'
                          when SPECIALITE_ESP_ET='21' then 'MDSI Alternance VERMEG'  
                          when SPECIALITE_ESP_ET='22' then 'MDSI Exécutif'     
end) SPECIALITE_ESP_ET ,replace(replace (replace(dateentr,'-AUG-2019','/08/2019'),'-JUL-2019','/07/2019'),'-SEP-2019','/09/2019')dateentr,(case when OBSERVATION_ET is null then '-' when OBSERVATION_ET is not null then OBSERVATION_ET end )OBSERVATION_ET,
(case when NATURE_COURS is null then '-' when NATURE_COURS is not null then NATURE_COURS end )NATURE_COURS,
(case when ID_ENS_ENTRETIEN is null then '-' when ID_ENS_ENTRETIEN is not null then ID_ENS_ENTRETIEN end )ID_ENS_ENTRETIEN,
(case when OBSERVATION_ENTRETIEN is null then '-' when OBSERVATION_ENTRETIEN is not null then OBSERVATION_ENTRETIEN end )OBSERVATION_ENTRETIEN,
(case when NUM_SESSION is null then '-' when NUM_SESSION is not null then NUM_SESSION end ) NUM_SESSION,
(case when CYCLE_ET is null then '-' when CYCLE_ET is not null then CYCLE_ET end )CYCLE_ET,
(case when SCORE_DOSSIER is null then 0 when SCORE_DOSSIER is not null then SCORE_DOSSIER end )SCORE_DOSSIER,
(case when SCORE_FRANCAIS is null then 0 when SCORE_FRANCAIS is not null then SCORE_FRANCAIS end )SCORE_FRANCAIS,
(case when SCORE_ANGLAIS is null then 0 when SCORE_ANGLAIS is not null then SCORE_ANGLAIS end )SCORE_ANGLAIS,
(case when SCORE_QI is null then 0 when SCORE_QI is not null then SCORE_QI end )SCORE_QI,
(case when CULTURE_MOODLE is null then 0 when CULTURE_MOODLE is not null then CULTURE_MOODLE end )CULTURE_MOODLE,
(case when SCORE_ENTRETIEN is null then 0 when SCORE_ENTRETIEN is not null then SCORE_ENTRETIEN end )SCORE_ENTRETIEN,
(case when SCORE_FINAL is null then 0 when SCORE_FINAL is not null then SCORE_FINAL end )SCORE_FINAL 
from esp_etudiant WHERE (ID_ET LIKE '19%')order by specialite_esp_et desc

">

   
          
   
   
   </asp:sqldatasource>

              <asp:GridView ID="GridView1" runat="server" Visible="false" DataSourceID="Sqldatasource2" >
              </asp:GridView>

</asp:Content>
