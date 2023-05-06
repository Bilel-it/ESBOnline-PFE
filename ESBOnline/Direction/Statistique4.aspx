<%@ Page Title="" Language="C#" MasterPageFile="~/Direction/Site2.Master" AutoEventWireup="true" CodeBehind="Statistique4.aspx.cs" Inherits="ESPOnline.Direction.Statistique4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            color: #800000;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
   
    <table class="style1">
        <tr>
            <td class="style3">
               <center>  <strong>Pré-inscription aux cours du jour par niveau et spécialité</strong></center></td>
        </tr>
    </table>
   <br>
    <table class="style1" 
        style="font-family: 'Times New Roman', Times, serif; border-style: ridge ridge Ridge Ridge; border-color: #FF0000; border-width: medium">
        <tr>
            <td style="border: thin ridge #C0C0C0">
                &nbsp;</td>
            <td style="border: thin ridge #C0C0C0" >
                Capacité 15-16</td>
            <td style="border: thin ridge #C0C0C0">
                Pré-inscrits</td>
            <td style="border: thin ridge #C0C0C0">
                PLACES DISPO</td>
            <td style="border: thin ridge #C0C0C0">
                Admis</td>
            <td style="border: thin ridge #C0C0C0">
                Entretenu</td>
            <td style="border: thin ridge #C0C0C0">
                Enregistrés</td>
            <td style="border: thin ridge #C0C0C0">
                pré/Admis</td>
            <td style="border: thin ridge #C0C0C0">
                Admis/Ent</td>
            <td style="border: thin ridge #C0C0C0">
                Ent/Enr</td>
        </tr>
        <tr>
            <td style="border: thin ridge #C0C0C0">
                1A</td>
            <td style="border: thin ridge #C0C0C0" >
                210</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label57" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label79" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #C0C0C0"   >
                2P</td>
            <td style="border: thin ridge #C0C0C0" >
                58</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label42" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label58" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label69" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label80" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #C0C0C0" >
                3A</td>
            <td  style="border: thin ridge #C0C0C0">
                390</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label59" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label81" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                3B</td>
            <td  style="border: thin ridge #C0C0C0">
                90</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label60" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label71" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label82" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                1EM</td>
            <td  style="border: thin ridge #C0C0C0">
                112</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label45" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label61" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label72" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label83" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                2EM</td>
            <td  style="border: thin ridge #C0C0C0">
                30</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label46" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label62" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label73" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label84" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                3EM</td>
            <td  style="border: thin ridge #C0C0C0">
                150</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label47" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label63" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label74" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label85" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                1GC</td>
            <td  style="border: thin ridge #C0C0C0">
                60</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label48" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label64" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label75" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label86" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                2GC</td>
            <td  style="border: thin ridge #C0C0C0">
                30</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label49" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label65" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label76" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label87" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                3GC</td>
            <td  style="border: thin ridge #C0C0C0">
                60</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label50" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label66" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label77" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label88" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="border: thin ridge #C0C0C0" >
                Total</td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label51" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label52" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label53" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label54" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label55" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label56" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label67" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label78" runat="server" Text="Label"></asp:Label>
            </td>
            <td  style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label89" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    
      <span class="style3">  <strong>Inscription aux cours du soir par niveau et spécialité</strong></span>&nbsp;
 
    <br />
    <table class="style1" style="border: medium ridge #CC0066">
        <tr>
            <td style="border: thin ridge #000000">
                &nbsp;</td>
            <td style="border: thin ridge #000000">
                TIC(admis)</td>
            <td style="border: thin ridge #000000">
                TIC(inscrits)</td>
            <td style="border: thin ridge #000000">
                EM(admis)</td>
            <td style="border: thin ridge #000000">
                EM(inscrits)</td>
            <td style="border: thin ridge #000000">
                GC(admis)</td>
            <td style="border: thin ridge #000000">
                GC(inscrits)</td>
        </tr>
        <tr>
            <td style="border: thin ridge #000000">
                1</td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label90" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label91" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label92" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label93" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label94" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label95" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #000000">
                2</td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label96" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label97" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label98" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label99" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label100" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label101" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #000000">
                3</td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label102" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label103" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label104" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label105" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label106" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #000000">
                <asp:Label ID="Label107" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
       
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_inscription where trim(id_et) like '15%'   and trim(id_et) in (select trim(id_et) from esp_etudiant where  etat='A' and SPECIALITE_ESP_ET='05' and niveau_acces=1)and trim(id_et) like '15%'  ">
   
     
</asp:SqlDataSource>

 
 
 
<asp:SqlDataSource ID="SqlDataSource27" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_inscription where trim(id_et) like '15%'   and trim(id_et) in (select trim(id_et) from esp_etudiant where  etat='A' and SPECIALITE_ESP_ET='04' and niveau_acces=1)and trim(id_et) like '15%' ' ">
   
     
</asp:SqlDataSource>
    <table class="style1">
        <tr>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource39" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='05'  and   (CODE_SPEC_ORIGINE in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))  ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource38" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=2 and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource37" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=1 and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource40" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='05'  and (CODE_SPEC_ORIGINE not in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))  ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
        </tr>
        <tr>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource41" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=1 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource42" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=2 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource43" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource44" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=1 and specialite_esp_et='03'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource45" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=2 and specialite_esp_et='03'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
       
       <asp:SqlDataSource ID="SqlDataSource46" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
                    
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='03'   ">
   
     
</asp:SqlDataSource>

 
 
 
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
 
 
    <table class="style1">
        <tr>
            <td>
 
 
<asp:SqlDataSource ID="SqlDataSource33" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=1 and (specialite_esp_et='04')and score_final is not null ">
   
     
</asp:SqlDataSource>
 
 <asp:SqlDataSource ID="SqlDataSource21" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=1 and (specialite_esp_et='03')and score_final is not null ">
   
     
</asp:SqlDataSource>
            </td>
            <td>
<asp:SqlDataSource ID="SqlDataSource22" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=2 and (specialite_esp_et='03')and score_final is not null ">
   
     
</asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource47" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=1 and (   specialite_esp_et in ('01','02')) and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource48" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=2 and (   specialite_esp_et in ('01','02')) and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource49" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=3 and (   specialite_esp_et in ('01','02')) and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource50" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=1 and (   specialite_esp_et='04') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource51" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=2 and (   specialite_esp_et='04') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource52" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=3 and (   specialite_esp_et='04') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource53" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=1 and (   specialite_esp_et='03') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource54" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=2 and (   specialite_esp_et='03') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
 
 <asp:SqlDataSource ID="SqlDataSource55" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
                    
                    SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%S%'  and niveau_acces=3 and (   specialite_esp_et='03') and code_decision='01'">
   
     
</asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<asp:SqlDataSource ID="SqlDataSource23" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=3 and (specialite_esp_et='03')and score_final is not null ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource11" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=1 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource12" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=2 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource13" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and (CODE_SPEC_ORIGINE in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))   and niveau_acces=3 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource14" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and  (CODE_SPEC_ORIGINE not in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))   and niveau_acces=3 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=1 and    specialite_esp_et='04' and trim(id_et) like '15%' and code_decision='01')">
   
     
</asp:SqlDataSource>

 <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=1 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource16" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=2 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource17" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource18" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=1 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource19" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=2 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource20" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%' and niveau_acces=3 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=1 and    specialite_esp_et='03' and trim(id_et) like '15%' and code_decision='01' )   ">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=2 and    specialite_esp_et='05' and trim(id_et) like '15%' and code_decision='01' )">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource5" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=2 and    specialite_esp_et='03' and trim(id_et) like '15%' and code_decision='01' ) ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource6" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=2 and    specialite_esp_et='03' and trim(id_et) like '15%' and code_decision='01' )   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where (CODE_SPEC_ORIGINE  in ('80','01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95','80' )) and niveau_acces=3 and    specialite_esp_et='05' and trim(id_et) like '15%' and code_decision='01' )  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource10" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where (CODE_SPEC_ORIGINE not in ('80','01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95','80' )) and niveau_acces=3 and    specialite_esp_et='05' and trim(id_et) like '15%' and code_decision='01' )    ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource8" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=3 and    specialite_esp_et='04' and trim(id_et) like '15%' and code_decision='01' )  ">
   
     
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource9" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  count(*) from esp_inscription where trim(id_et) like '15%'  and    trim(id_et) in 
(select distinct trim(id_et) from esp_etudiant_enreg where  niveau_acces=3 and    specialite_esp_et='03' and trim(id_et) like '15%' and code_decision='01' )   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource24" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=1 and specialite_esp_et='05'  and score_final is not null  ">
   
     
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource31" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=3 and specialite_esp_et='04'  and score_final is not null  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource32" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=2 and specialite_esp_et='04'  and score_final is not null  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource36" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=1 and specialite_esp_et='04'  and score_final is not null  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource25" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=2 and specialite_esp_et='05'  and score_final is not null  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource26" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=3 and specialite_esp_et='05'  and score_final is not null and (CODE_SPEC_ORIGINE in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource30" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '15%J%'  and niveau_acces=3 and specialite_esp_et='05'  and score_final is not null and (CODE_SPEC_ORIGINE not in ('01','02','03','08','14','19','20','22','26','30','33','35','39','49','57','59','60','65','90','71','91','95' ))  ">
   
     
</asp:SqlDataSource>
</asp:Content>