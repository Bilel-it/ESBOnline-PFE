<%@ Page Title="" Language="C#"
     AutoEventWireup="true"
    CodeBehind="ResultatPrincipale2021.aspx.cs" Inherits="ESPOnline.Etudiants.ResultatPrincipale2021" MasterPageFile="~/Etudiants/Eol.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <style type="text/css">
        .footer td
        {
            border: none;
        }
        .table td
        {
            border-bottom: 1pt solid black;
        }
        .footer tr
        {
            border-bottom: 1pt solid black;
        }
        .footer th
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-1">
    </div>
    <div class="col-xs-10">
        <center>
            <h1>
                Resultat Session Principale
            </h1>
        </center>
        <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        &nbsp;

         <asp:Label ID="lbletat" runat="server" Visible="false"></asp:Label>

                 <asp:Label ID="Label1" runat="server" Visible="false" ></asp:Label>
        <asp:Label ID="Label9" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="Label3" runat="server" Visible="false" Text=""></asp:Label>
        <center> 
           <asp:Label ID="Label11" runat="server"  Text="Identifiant: " style="font-weight: 700"></asp:Label> <asp:Label ID="Label12" runat="server" ForeColor="#CC0000" 
            style="font-weight: 700"></asp:Label><br />
         <asp:Label ID="Label7" runat="server"  Text="NOM: " style="font-weight: 700"></asp:Label> <asp:Label ID="Label5" runat="server" ForeColor="#CC0000" 
            style="font-weight: 700"></asp:Label><asp:Label ID="Label10" 
                runat="server"   Text="      PRENOM: " style="font-weight: 700"></asp:Label> <asp:Label ID="Label6" runat="server" 
            ForeColor="Maroon" style="font-weight: 700"></asp:Label><br />
              <asp:Label ID="Label13" runat="server"  Text="CLASSE: " style="font-weight: 700"></asp:Label> <asp:Label ID="Label16" runat="server" ForeColor="#CC0000"  Visible="false"
            style="font-weight: 700"></asp:Label>
        &nbsp;</center>
        <center>
            <br />
            <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource3"
                Height="50px" Width="536px" BackColor="White" BorderColor="White" BorderStyle="Ridge"
                BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                    <asp:BoundField DataField="LIB_DECISION_SESSION_P" HeaderText="Session Principale:"
                        SortExpression="LIB_DECISION_SESSION_P" />
                    <asp:BoundField DataField="moy_general" HeaderText="Moyenne :" SortExpression="moy_general" />
                    <asp:BoundField DataField="NB_ECTS_SP" HeaderText="NB_ECTS_AQUIS :" SortExpression="NB_ECTS_AQUIS" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#D8D8D8" ForeColor="Black" Font-Bold="True" />
            </asp:DetailsView>
        <%--    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                SelectCommand="SELECT moy_general,lib_decision_session_p,nb_ects_sp FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET)  and annee_deb =(select max(annee_deb) from societe) and (SCOESP09.fs_is_student_autorised_new( :ID_ET)=1) ">
                <SelectParameters>
                    <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>--%>

           <%-- and (SCOESP09.fs_is_student_autorised_new( :ID_ET)=1)--%><%--and e4.etat='T'--%>
               <%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                SelectCommand="SELECT moy_general,lib_decision_session_p,nb_ects_sp FROM ESP_INSCRIPTION e1,societe e5 WHERE (ID_ET =:ID_ET) and e5.Delib_resultats='O'  and e1.annee_deb =e5.annee_deb and id_et not in ('201JMT1951','201JMT1907','201JMT1913','201JMT1411','201JMT2156','201JFT3503','201JFT2150','201JFT4130','201JMT4591','201JMT1775','201JMT4045','201JMT3486','201JMT1742','201JMT1757','201JMT2687','201JMT0069','201JMT2165','201JMT3040','201JMT3824','201JFT5622','201JMT1731','201JMT3231','201JMT3326','201JMT3667','201JMT4716','201JFT1848','201JFT3554','201JFT3206','201JMT3469','201JFT3391','201JMT3903','201JMT1749','201JMT4505','201JFT5253','201JMT2442','201JMT2185','201JFT4364','201JMT4968','201JMT4519','201JFT3344','201JMT5444','201JFT0245','201JMT1342','201JFT4061','201JMT2028','201JMT3353','201JMT2245','201JMT3416','201JMT2591','201JMT3341','201JMT1993','201JFT4974','201JMT1729','201JMT2611','201JMT2558','201JMT2070','201JFT3016','201JMT4262','201JMT2348','201JMT2935','201JMT4151','201JMT4641','201JMT2794','201JMT4796','201JMT4671','201JMT3852','201JMT4060','201JMT5316','201JMT0829','201JMT0500','201JFT1996','201JMT0115','201JMT0198','201JMT0182','201JMT0181','201JMT0256','201JMT1960','201JMT3140','201JMT2304','201JMT4792','201JMT1764','201JMT1646','201JMT4882','201JME5715','201JMT1940','201JMT1532','201JMT1096','201JMT2013','201JMT2036','201JMT1089','201JMT1870','201JMT2203','201JMT4119','201JFT5389','201JFT4080','201JMT2597','201JMT3158','201JMT2463','201JMT3274','201JMT4549','201JMT3280','201JMT2166','201JMT3594','201JMT3404','201JFE5507','201JMT2723','201JFT3614','201JFT3677','201JMT3032','201JMT0103','201JMT2956','201JMT3578','201JMT2993','201JMT2866','201JMT2902','201JMT3049','201JMT3966','201JMT3963','201JMT3971','201JMT4253','201JMT5026','201JMT3930','201JMT4205','201JMT3919','201JFT4745','201JFT4902','201JMT3961','201JMT3830','201JFT4291','201JMT2895','201JMT3785','201JMT3806','201JFT4150','201JMT3861','201JMT5147','201JMT3638','201JFT4089','201JMT3818','201JMT4489','201JMT1990','201JFT0297','201JMT4710','201JMT4460','201JFT0478','201JMT4487','201JMT4328','201JFT3056','201JMT4414','201JMT4358','201JMT4419','201JMT0027','201JMT2067','201JFT1831','201JFT4317','201JMT1837','201JFT4790','201JMT1399','201JFT1779','201JMT3095','201JFT1467','201JMT1546','201JFT3051','201JMT4597','201JMT4765','201JMT4848','201JMT3940','201JMT3571','201JMT5600','201JMT4104','201JMT2733','201JMT1844','201JMT1477','201JMT3427','201JFT1974','201JMT1263','201JMT0075','201JMT2576','201JMT0825','201JMT2078','201JMT2040','201JMT2407','201JMT2859','201JMT0144','201JMT3104','201JMT3105','201JFT2568','201JMT4819','201JMT4373','201JMT2435','201JMT2656','201JMT1947','201JMT3403','201JMT3298','201JMT3635','201JFT1782','201JFT1609','201JMT3236','201JMT2194','201JMT2022','201JFT4040','201JMT3071','201JMT4215','201JMT3264','201JMT2492','201JMT3647','201JMT1898','201JFT2629','201JFT3699','203JMT5461','203JFT2837','203JMT1252  202SMT2581','203JMT1029','203JMT2386','203JMT5140','203JMT1414','203JMT5492','203JFT1155','203JMT4815','203JMT0935','203JMT1347','203JMT2354','203JMT2292','203JMT0314','203JMT2819','203JMT1276','203JMT0834','203JMT0870','203JFT5530','203JMT5305','203JMT1773','203JFT2704','203JMT0807','203JMT0918','203JFT5342','203JMT1651','203JMT5074','203JMT4851','203JMT0369','203JMT2029','203JMT1861','203JMT1997','203JMT1086','203JFT2345','203JMT0900','203JMT1294','203JFT0219','203JFT1468','203JMT5301','203JFT5462','203JFT3660','203JMT2240','203JMT1768','203JMT2269','203JFT0555','203JFT2843','203JMT4978','203JMT1172','203JFT0907','203JFT0862','203JFT0410','203JMT1424','203JMT2209','203JFT5277','203JMT2235','203JMT5001','203JMT0155','203JFT1231','203JMT2059','203JMT0737','203JMT5516','203JFT0272','203JMT1278','203JMT0933','203JMT4552','203JMT4213','203JMT1217','203JFT2845','203JMT0746','203JMT2513','203JMT0938','203JFT3617','203JFT3595','203JFT3303','203JFT3572','203JME2596','203JFT3294','203JMT4822','203JMT4234','203JMT4619','203JMT3557','203JMT3582','203JMT2533','203JMT3408','203JFT4167','203JFT4585','203JMT3202 204JMT4443','203JMT3795','203JMT2714','203JMT3093','203JMT1879','203JMT3060','203JMT1885','203JFT3038','203JMT1408','203JFT3177','201JMT2901','203JMT1449','203JFT2759','203JMT1415','203JMT0496','203JMT1877','203JFT2807','203JFT2887','203JMT1098','203JMT1101','203JFT0813','203JFT1572','203JFT3967','203JMT1440','203JFT0006','203JFT2706','203JFT0141','203JFT4935','203JFT3528','203JMT3584','203JFT3413','203JMT4886   204JFT1097','203JMT2721','203JMT0810','203JMT2584','203JMT2791','203JMT0441','203JMT0074','203JFT1561','203JMT1001','203JMT2637','203JMT1581','203JMT1510','203JMT2616','203JMT2969','203JMT0064','203JMT2055','203JMT1039','203JMT4888','203JMT4996','203JMT4407','203JMT1037','201SMT0397','203JMT3219','203JFT4931','203JFT2777','203JMT1147','203JMT5289','203JFT4020','203JFT2470','203JFT2594','203JMT4637','203JFT3286','203JFT3319','203JFT4235','203JMT1502','203JFT2098','203JMT5040','203JFT4063','203JMT3536','203JFT1650','203JMT2206','203JMT4536','203JMT3188','203JMT5064','203JMT2566','203JMT5298','203JFT0035','203JFT1388','203JMT4425','203JMT4704 204JMT3352','203JMT4430') and  (scoesp09.FS_GET_SOLDE_ETUDIANT_2021(:ID_ET) <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2020)  or ( e1.MODE_RGLT='99' and e1.DATE_LIM_PROLONG_RGLT>=sysdate))">
                <SelectParameters>
                    <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>--%>

             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                SelectCommand="SELECT moy_general,lib_decision_session_p,nb_ects_sp FROM ESP_INSCRIPTION e1,societe e5 WHERE (ID_ET =:ID_ET) 
                 and e5.Delib_resultats='O'  and e1.annee_deb =e5.annee_deb 
                 and  e1.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O')
                 ">
                <SelectParameters>
                    <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Visible="false">
                    <Columns>
                        <%-- DataSourceID="SqlDataSource1"<asp:BoundField DataField="CODE_MODULE" HeaderText="CODE_MODULE" SortExpression="CODE_MODULE" />--%>
                        <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" SortExpression="DESIGNATION" />
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" />
                        <asp:BoundField DataField="MOYENNE" HeaderText="MOYENNE" SortExpression="MOYENNE" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#070719" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT * FROM ESP_V_MOY_MODULE_ETUDIANT_UE WHERE (ID_ET =:ID_ET) and type_moy = 'P' and etat='1'">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
            </asp:Panel>
        </center>
        <center>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound" OnRowDataBound="GridView1_test"
                    DataSourceID="ObjectDataSource1" ShowFooter="false" AutoGenerateColumns="False">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_UE" HeaderText="CODE_UE" 
                                 SortExpression="CODE_UE" />--%>
                        <asp:BoundField DataField="LIB_UE" HeaderText="Unite d'Enseignement" ItemStyle-Width="150"
                            SortExpression="LIB_UE">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="NB_ECTS" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150" SortExpression="MOY_UE">
                            <ItemStyle Width="150px" />

                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="MOYENNE /UE" SortExpression="MOY_UE">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MOY_UE") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="Total ECTS acquis :" />
                                        </tr>
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="MOYENNE GENERAL :"  ></asp:Label>
                                        </tr>
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="DECISION" runat="server" Text="DECISION :" ></asp:Label>
                                        </tr>
                                        </td></table>
                                </div>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NB_ECTS Aquis /UE" SortExpression="NB_ECTS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" />
                                        </tr>
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                        </tr>
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </FooterTemplate>
                        </asp:TemplateField>
                       <asp:BoundField DataField="DESIGNATION" HeaderText="MODULES" ItemStyle-Width="150" Visible="false"
                            SortExpression="DESIGNATION">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                      
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="MOY_MODULE" HeaderText="MOY_MODULE" SortExpression="MOY_MODULE" Visible="false">
                        </asp:BoundField>
                       

                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResFinal"
                    TypeName="ESPOnline.Etudiants.ResultatFinalP">
                    <SelectParameters>
                        <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                 <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="     select distinct 
e2.code_ue ,e2.lib_ue,e2.nb_ects, e3.DESIGNATION_NEW,e4.coef,e1.moyenne as moy_module,e4.moyenne as moy_ue 
from  
ESP_MOY_UE_ETUDIANT e1 ,  
esp_ue e2 , 
ESP_MODULE_PANIER_CLASSE_SAISO e3,
ESP_MOY_MODULE_ETUDIANT e4 ,
SOCIETE e5
where 

e1.id_et=:ID_ET and 

e4.ANNEE_DEB=(select max(annee_deb) from societe) and
e4.ANNEE_DEB=e3.ANNEE_DEB and
e2.ANNEE_DEB=(select max(annee_deb) from societe) and

e2.CODE_UE=e1.CODE_UE  and  e4.ID_ET!='163JFT0108' 
                     and e5.Delib_resultats='O' and

e3.CODE_MODULE=e4.CODE_MODULE  
                     --or e4.code_cl not like '5%'(  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL  like '5GC%' or ESP_MODULE_PANIER_CLASSE_SAISO.code_cl not like '5%')   
                     --(e4.CODE_CL  in ('5ARCTIC1','5ARCTIC2','5NIDS','5SLEAM','5IRT','5SIM1','5SIM2','5SIM3','5OGI1','5OGI2','5OGI3','5OGI4','5OGI5','5MécaT1','5MécaT2','5MécaT3','5DS1','5DS2','5ERP-BI1','5ERP-BI2','5ERP-BI3','5ERP-BI3','5ERP-BI4','5ERP-BI5','5INFOB1','5INFOB2','5INFOB3','5TWIN1','5TWIN2','5GL1','5GL2','5GL3','5GL4') ) 
                     and 
e4.CODE_UE=e1.CODE_UE and  (SCOESP09.fs_is_student_autorised_new(:ID_ET) in (1,-1)) and
e4.ID_ET = e1.ID_ET 
and 
e4.TYPE_MOY='P'   and e1.TYPE_MOY='P' and (e1.moyenne IS NOT NULL) and e4.moyenne is not null  order by lib_ue "
                    >
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <%--e5.ANNEE_DEB--%>
            </asp:Panel>
        </center>
        <br />
        <br />
        <center>
            <asp:Panel ID="Panel3" runat="server">
                <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource2" Visible="false">
                </asp:GridView>
                <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT MOY_GENERAL as moyenne_general, LIB_DECISION_SESSION_P as DECISION  FROM ESP_INSCRIPTION WHERE ID_ET!='163JFT0108' AND ANNEE_DEB =(select max(annee_deb) from societe) and (ID_ET =:ID_ET) ">
                    <SelectParameters>--%>

                          <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                    SelectCommand="SELECT MOY_GENERAL as moyenne_general, LIB_DECISION_SESSION_P as DECISION  FROM ESP_INSCRIPTION e1,societe e5 WHERE ID_ET!='163JFT0108' AND e5.Delib_resultats='O'    and (ID_ET =:ID_ET) ">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </center>
</asp:Content>
