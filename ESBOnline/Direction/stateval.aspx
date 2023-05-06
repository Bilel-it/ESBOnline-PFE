<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/administration.Master" AutoEventWireup="true" CodeBehind="stateval.aspx.cs" Inherits="ESPOnline.Direction.stateval" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .text-info
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script> 
    <br />
    <asp:Label ID="Label4" runat="server" 
        Text="Taux de satisfaction global " 
        style="font-weight: 700; color: #000000"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" 
        Text="Trés insuffisant et insuffisant superieur ou egal a 40% semstre 1 " 
        style="font-weight: 700; color: #990033"></asp:Label>
    <br /><br />
  <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #333333">Nombre Total des modules:</asp:Label>  <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" 
        CssClass="text-info" ForeColor="Black" Height="27px" onclick="BuTT2_Click" 
        Text="Exporter en excel" />
<br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_test"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="DESIGNATION" HeaderText="Module" 
                SortExpression="DESIGNATION" ReadOnly="True" />
      
         
           <asp:BoundField DataField="code_cl" HeaderText="Classe" 
                SortExpression="code_cl" ReadOnly="True" />
            <asp:BoundField DataField="SATISFACTION" HeaderText="Insuffisant" ReadOnly="True" 
                SortExpression="SATISFACTION" />
            <asp:BoundField DataField="TAUX_REP" HeaderText="TAUX_REP" ReadOnly="True" 
                SortExpression="TAUX_REP" />
        </Columns>
        
    </asp:GridView></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="   select * from( ( select designation,code_module, 0 as ord,concat(round((sum((i+ti))*100)/( count (designation)),2),'%') satisfaction,concat(round( sum(taux_rep)/( count (designation)),2),'%') taux_rep,(( count ( distinct designation)))nb ,code_cl 
  from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit,e3.code_cl ,e3.CODE_MODULE,

(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017') AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2017 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = '2017' )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = '2017' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )   where taux_rep&gt;=30 and ((ti+i)*100)&gt;=40   group by designation,code_module,code_cl )

union 
  (select 'TOTAL'  designation,' ' code_module,1 as ord,concat(round(sum (satisfaction)/sum(nb),2),'%') statisfaction,concat(round(sum(taux_rep)/ count (designation),2),'%')   taux_rep,(( count ( distinct designation)))nb,''code_cl from (
  
  select * from( ( select designation,code_module, 0 as ord,(round((sum((ti+i))*100)/( count (designation)),2)) satisfaction,(round( sum(taux_rep)/( count (designation)),2)) taux_rep,(( count ( distinct designation)))nb from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit,e3.code_cl ,e3.CODE_MODULE,

(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017') AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2017 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = '2017' )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = '2017' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )   where taux_rep&gt;=30 and ((ti+i)*100)&gt;=40   group by designation,code_module ))

 )) )order by ord, designation
 "></asp:SqlDataSource>
  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="SELECT count(distinct designation) from(SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit,e3.CODE_CL ,e3.CODE_MODULE,


(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017') AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT ,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2017 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(e3.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and 
( ( e3.ANNEE_DEB = '2017' )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(e3.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( e3.ANNEE_DEB = '2017' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='2017' ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%')  where ((ti+i)*100)&gt;=40 and taux_rep&gt;=30



"></asp:SqlDataSource>
</asp:Content>