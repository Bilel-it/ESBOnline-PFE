<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="noterat.aspx.cs" Inherits="ESPOnline.Etudiants.noterat2021" %>
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
                <asp:Label ID="lbletat" runat="server" Visible="false"></asp:Label>

                 <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="col-xs-10">
              <center><h1> Notes Des Modules session Rattrapage </h1></center>
                
                <asp:Panel ID="Panel1" runat="server">
                <hr /><hr />
                <center>
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                 <asp:Label ID="Label11" runat="server" 
                        Text="Sauf erreur ou omission, nous vous communiquons ci-après vos notes relatives aux examens de rattrapage.
                      Elles vous sont données à titre indicatif et ne seront définitives qu'avec l'annonce des résultats finaux. " 
                        ForeColor="#CC0000" Font-Size="Large"></asp:Label><br /><br />
                    
                    <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False" 
                        CssClass="list-inline" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                         >
                        <EmptyDataTemplate>
                                        Aucune saisie n' a été effectuée.
                                    </EmptyDataTemplate>
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
                    SelectCommand="SELECT * FROM ESP_V_NOTE_RAT where id_et=:ID_ET ">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--and esp_note_rat.code_cl  like '5%' --%>

                   <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="select  distinct esp_note_rat.CODE_MODULE,
        esp_note_rat.ID_ET,
        esp_note_rat.CODE_CL,
         ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,
         ESP_MODULE_PANIER_CLASSE_SAISO.COEF,
         esp_note_rat.NOTE,
        EXISTE_NOTE_TP
  FROM 
       
         scoesb02.esp_note_rat,
         scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO,
scoesb02.ESP_ENTETE_NOTE,scoesb02.societe s,scoesb02.esp_inscription
   WHERE esp_inscription.id_et=esp_note_rat.id_et and (esp_note_rat.CODE_MODULE= ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE  ) and
 	(esp_note_rat.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and
 	(esp_note_rat.code_cl = ESP_ENTETE_NOTE.code_cl ) and
 	(esp_note_rat.code_module = ESP_ENTETE_NOTE.code_module )  and
                         s.AFFICH_NOTE='O'
                         and  (scoesb02.FS_GET_SOLDE_ETUDIANT_2021(:Id_et) <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2020) 
                         or ( esp_inscription.MODE_RGLT='99' and esp_inscription.DATE_LIM_PROLONG_RGLT>=sysdate)) 
                         and
 
 	     ( scoesb02.esp_note_rat.ANNEE_DEB = scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and
         ( scoesb02.esp_note_rat.CODE_CL = scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL )  and
         ( scoesb02.esp_note_rat.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and
         ( scoesb02.esp_note_rat.type_rat in('O')) and  esp_note_rat.ID_ET=:Id_et and 
          
       (scoesb02.esp_note_rat.annee_deb=(select max(annee_deb) from scoesb02.societe))  
       and
        ( esp_note_rat.id_et not in (select id_et from scoesb02.esp_inscription
where annee_deb=(select max(annee_deb) from scoesb02.societe) and reserve='O'))
">

                  <SelectParameters>
                            <asp:SessionParameter Name="Id_et" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
                </asp:SqlDataSource>--%>




                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="select  distinct esp_note_rat.CODE_MODULE,
        esp_note_rat.ID_ET,
        esp_note_rat.CODE_CL,
         ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,
         ESP_MODULE_PANIER_CLASSE_SAISO.COEF,
         esp_note_rat.NOTE,
        EXISTE_NOTE_TP
  FROM 
       
         scoesb02.esp_note_rat,
         scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO,
scoesb02.ESP_ENTETE_NOTE,scoesb02.societe s
   WHERE (esp_note_rat.CODE_MODULE= ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE  ) and
 	(esp_note_rat.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and
 	(esp_note_rat.code_cl = ESP_ENTETE_NOTE.code_cl ) and
 	(esp_note_rat.code_module = ESP_ENTETE_NOTE.code_module )   and
                         s.AFFICH_NOTE='O'
                         -- and esp_note_rat.id_et not in ('201JMT1907','201JMT1913','201JMT1411','201JMT2156','201JFT3503','201JFT4130','201JMT4591','201JMT1775','201JMT4045','201JMT3486','201JMT1757','201JMT2687','201JMT0069','201JMT3040','201JMT3824','201JMT1731','201JMT3326','201JMT4716','201JFT1848','201JFT3554','201JFT3391','201JMT3903','201JMT4505','201JFT5253','201JMT2442','201JMT4968','201JMT4519','201JFT3344','201JMT5444','201JFT0245','201JMT1342','201JFT4061','201JMT2028','201JMT3416','201JMT1993','201JFT4974','201JMT1729','201JMT2611','201JMT2558','201JMT2070','201JMT4262','201JMT2348','201JMT2935','201JMT4151','201JMT4641','201JMT4796','201JMT3852','201JMT4060','201JMT5316','201JMT0829','201JFT1996','201JMT0115','201JMT0198','201JMT0182','201JMT0181','201JMT0256','201JMT1960','201JMT3140','201JMT2304','201JMT4792','201JMT1764','201JMT1646','201JMT4882','201JME5715','201JMT1940','201JMT1532','201JMT1096','201JMT2013','201JMT1089','201JMT2203','201JMT4119','201JFT5389','201JMT2597','201JMT3158','201JMT2463','201JMT3274','201JMT4549','201JMT3280','201JMT2166','201JMT3594','201JFE5507','201JMT2723','201JFT3677','201JMT0103','201JMT2956','201JMT3578','201JMT2993','201JMT2866','201JMT2902','201JMT3966','201JMT3963','201JMT3971','201JMT4253','201JMT5026','201JMT3930','201JMT4205','201JMT3919','201JFT4745','201JFT4902','201JMT3961','201JMT3830','201JMT2895','201JMT3785','201JMT3806','201JFT4150','201JMT3861','201JMT5147','201JMT3818','201JMT1990','201JFT0297','201JMT4460','201JFT0478','201JMT4487','201JMT4328','201JFT3056','201JMT4358','201JMT4419','201JMT2067','201JFT1831','201JFT4317','201JMT1837','201JFT4790','201JMT3095','201JFT1467','201JMT1546','201JFT3051','201JMT4597','201JMT4765','201JMT4848','201JMT3940','201JMT3571','201JMT5600','201JMT4104','201JMT1844','201JMT1477','201JFT1974','201JMT1263','201JMT0075','201JMT2576','201JMT0825','201JMT2078','201JMT2040','201JMT2859','201JMT0144','201JMT3104','201JMT3105','201JMT4819','201JMT4373','201JMT2435','201JMT2656','201JMT3403','201JMT3298','201JMT3635','201JFT1609','201JMT3236','201JMT2194','201JMT2022','201JFT4040','201JMT3071','201JMT4215','201JMT3264','201JMT3647','201JMT1898','201JFT2629','201JFT3699','203JMT5461','203JMT1252  202SMT2581','203JMT1029','203JMT2386','203JMT1414','203JMT5492','203JMT4815','203JMT0935','203JMT1347','203JMT2354','203JMT2292','203JMT0314','203JMT2819','203JMT1276','203JMT0834','203JFT5530','203JMT5305','203JMT1773','203JFT2704','203JFT5342','203JMT4851','203JMT0369','203JFT1468','203JMT5301','203JFT5462','203JMT2240','203JMT1768','203JMT2269','203JFT0862','203JMT1424','203JMT2209','203JMT5001','203JMT0155','203JFT1231','203JMT0737','203JMT5516','203JMT1278','203JMT0933','203JMT4213','203JMT0746','203JMT2513','203JMT0938','203JFT3294','203JMT4234','203JMT4619','203JMT3557','203JMT3582','203JMT2533','203JFT4167','203JMT3202','203JMT2714','203JMT3093','203JMT3060','203JMT1885','203JFT3038','201JMT2901','203JFT2759','203JMT1415','203JMT0496','203JFT2887','203JFT0813','203JFT3967','203JMT1440','203JFT2706','203JFT4935','203JFT3528','203JMT3584','203JFT3413','204JFT1097','203JMT2721','203JMT0810','203JMT2584','203JMT2791','203JMT0441','203JMT0074','203JMT1001','203JMT2637','203JMT1581','203JMT1510','203JMT2969','203JMT2055','203JMT1039','203JMT1037','201SMT0397','203JMT3219','203JMT5289','203JFT4020','203JMT4637','203JFT3286','203JFT3319','203JFT4235','203JMT1502','203JFT4063','203JFT1650','203JMT2206','203JMT5064','203JMT5298','203JFT1388','203JMT4425','203JMT4704','203JMT4430') 
                           
                        and  
 
 	     ( scoesb02.esp_note_rat.ANNEE_DEB = scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and
         ( scoesb02.esp_note_rat.CODE_CL = scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL )  and
         ( scoesb02.esp_note_rat.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and
         ( scoesb02.esp_note_rat.type_rat in('O')) and  esp_note_rat.ID_ET=:Id_et and 
          
       (scoesb02.esp_note_rat.annee_deb=(select max(annee_deb) from scoesb02.societe))  
       and
        ( esp_note_rat.id_et not in (select id_et from scoesb02.esp_inscription
where annee_deb=(select max(annee_deb) from scoesb02.societe) and reserve='O'))
">

                  <SelectParameters>
                            <asp:SessionParameter Name="Id_et" SessionField="ID_ET" Type="String" />
                        </SelectParameters>
                </asp:SqlDataSource>


                     <br />
                     
                      <br />
                    
                <hr /><hr />
                </asp:Panel>
                
                </div>
                <div class="col-xs-1">
               
            </div>
            </div>

</asp:Content>