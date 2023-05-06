<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/administration.Master" AutoEventWireup="true" CodeBehind="eval3.aspx.cs" Inherits="ESPOnline.Direction.eval3" %>
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
    <asp:Label ID="Label3" runat="server" 
        Text="Total évaluation par module semstre 1 " 
        style="font-weight: 700; color: #990033"></asp:Label>
    <br /><br />
  <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #333333">Nombre Total des modules semestere 1:</asp:Label>  <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" style="font-weight: 700; color: #333333">Nombre des modules qui ont été évalués semestere 1:</asp:Label>
    <asp:Label ID="Label5" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
<br />&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" 
        CssClass="text-info" ForeColor="Black" Height="27px" onclick="BuTT2_Click" 
        Text="Exporter en excel" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource4" OnRowDataBound="GridView1_test"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="'TOTALPARRAPPORT194:'" HeaderText="'TOTAL PAR RAPPORT 194 Module:'" 
                SortExpression="'TOTALPARRAPPORT194:'" ReadOnly="True" />
 
         
         
   
            <asp:BoundField DataField="STATISFACTION" HeaderText="STATISFACTION" ReadOnly="True" 
                SortExpression="STATISFACTION" />
            <asp:BoundField DataField="TAUX_REP" HeaderText="TAUX_REP" ReadOnly="True" 
                SortExpression="TAUX_REP" />
           
        </Columns>
        
    </asp:GridView>
    <br />
<br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_test"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" 
                SortExpression="DESIGNATION" ReadOnly="True" />
 
         
         
   
         
            <asp:BoundField DataField="CODE_CL" HeaderText="Classe" ReadOnly="True" 
                SortExpression="CODE_CL" />
           
            
            <asp:BoundField DataField="SATISFACTION" HeaderText="SATISFACTION" 
                ReadOnly="True" SortExpression="SATISFACTION" />
            <asp:BoundField DataField="TAUX_REP" HeaderText="TAUX_REP" ReadOnly="True" 
                SortExpression="TAUX_REP" />
            
           
        </Columns>
        
    </asp:GridView></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        
        
        SelectCommand="select designation,code_module,code_cl, 0 as ord,concat(round((sum((s+b+tb))*100)/( count (designation)),2),'%') satisfaction,concat(round( sum(taux_rep)/( count (designation)),2),'%') taux_rep,(( count ( distinct designation)))nb from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit ,e3.CODE_MODULE,e3.code_cl,


(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe)) AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2018 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )      group by designation,code_cl,code_module order by designation"></asp:SqlDataSource>
  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
        SelectCommand="select count(*) from (select designation,code_module, 0 as ord,(round((sum((s+b+tb))*100)/( count (designation)),2)) satisfaction2,(round((sum((ti+i))*100)/( count (designation)),2)) insatis,concat(round((sum((s+b+tb))*100)/( count (designation)),2),'%') satisfaction,concat(round( sum(taux_rep)/( count (designation)),2),'%') taux_rep,round( sum(taux_rep)/( count (designation)),2) taux_rep2,(( count ( distinct designation)))nb from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit ,e3.CODE_MODULE,


(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe)) AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2018 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )      group by designation,code_module order by designation)"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="select count(distinct code_module) from ESP_MODULE_PANIER_CLASSE_SAISO where annee_deb=2018 and NUM_SEMESTRE=1

 



"></asp:SqlDataSource>
    <br />
<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="select 'TOTAL par rapport 194:',concat(round(sum(satisfaction2)/sum(nb),2),'%') Statisfaction,concat(round(sum(TAUX_rep2)/sum(nb),2),'%')Taux_rep from (
select designation,code_module, 0 as ord,(round((sum((s+b+tb))*100)/( count (designation)),2)) satisfaction2,(round((sum((ti+i))*100)/( count (designation)),2)) insatis,concat(round((sum((s+b+tb))*100)/( count (designation)),2),'%') satisfaction,concat(round( sum(taux_rep)/( count (designation)),2),'%') taux_rep,round( sum(taux_rep)/( count (designation)),2) taux_rep2,(( count ( distinct designation)))nb from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit ,trim(e3.CODE_MODULE)code_module,


(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe)) AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2018 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )      group by designation,code_module order by designation)
 



"></asp:SqlDataSource>
    <br />
<asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        
        
        
        
        
        ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" SelectCommand="select 'TOTAL par rapport 270:',concat(round(sum(satisfaction2)/270,2),'%') Statisfaction,concat(round(sum(TAUX_rep2)/270,2),'%')Taux_rep from (
select designation,code_module, 0 as ord,(round((sum((s+b+tb))*100)/( count (designation)),2)) satisfaction2,(round((sum((ti+i))*100)/( count (designation)),2)) insatis,concat(round((sum((s+b+tb))*100)/( count (designation)),2),'%') satisfaction,concat(round( sum(taux_rep)/( count (designation)),2),'%') taux_rep,round( sum(taux_rep)/( count (designation)),2) taux_rep2,(( count ( distinct designation)))nb from ( (SELECT designation,round((e3.NB_PALIER1/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TI, round((e3.NB_PALIER2/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) I, round((e3.NB_PALIER3/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) S, round((e3.NB_PALIER4/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) B,  round((e3.NB_PALIER5/(( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit ,trim(e3.CODE_MODULE)code_module,


(round(((( e3.NB_PALIER1+e3.NB_PALIER2+ e3.NB_PALIER3+e3.NB_PALIER4+e3.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe)) AND 
( trim(ESP_INSCRIPTION.CODE_CL) = trim(e3.CODE_CL))))*100)))
taux_rep

FROM ESP_EVAL_CL_MODULE e3, ESP_CRITERE_EVAL, ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO tt2 WHERE tt2.ANNEE_DEB=2018 and trim(e3.code_cl)=trim(tt2.code_cl) and trim(tt2.code_module)=trim(e3.code_module) and tt2.NUM_SEMESTRE=1 and
 ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 )) and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  
( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  
 
and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE
( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) AND 
( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 ))&gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'  and  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(e3.CODE_CRITERE,1,3 ))
and  ( trim(e3.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( e3.ANNEE_DEB = (select max (annee_deb)  from societe) )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%'  and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB =(select max (annee_deb)  from societe) ) 
AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(e3.CODE_CL)) )-(e3.NB_PALIER1+ e3.NB_PALIER2+ e3.NB_PALIER3+ e3.NB_PALIER4 + e3.NB_PALIER5 )) &gt;=0) 
and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%') )      group by designation,code_module order by designation)
 



"></asp:SqlDataSource>
</asp:Content>