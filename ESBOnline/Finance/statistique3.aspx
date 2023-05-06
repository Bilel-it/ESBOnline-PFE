<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/Recu.Master" AutoEventWireup="true" CodeBehind="statistique3.aspx.cs" Inherits="ESPOnline.Finance.statistique3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
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
            <td style="border: thin ridge #C0C0C0" colspan="2">
                NB PLACES TIC</td>
            <td style="border: thin ridge #C0C0C0">
                TIC (admis)</td>
            <td style="border: thin ridge #C0C0C0">
                TIC(pré-inscrits)</td>
            <td style="border: thin ridge #C0C0C0">
                NB PLACES EM</td>
            <td style="border: thin ridge #C0C0C0">
                EM(admis)</td>
            <td style="border: thin ridge #C0C0C0">
                EM(pré-inscrit)</td>
            <td style="border: thin ridge #C0C0C0">
                NB PLACES GC</td>
            <td style="border: thin ridge #C0C0C0">
                GC(admis)</td>
            <td style="border: thin ridge #C0C0C0">
                GC(pré-inscrit)</td>
        </tr>
        <tr>
            <td style="border: thin ridge #C0C0C0">
                1</td>
            <td style="border: thin ridge #C0C0C0" colspan="2">
                224</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                152</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                62</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #C0C0C0">
                2</td>
            <td style="border: thin ridge #C0C0C0" colspan="2">
                62</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                32</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                12</td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                3</td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                3A</td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                322</td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                157</td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                66 </td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0" rowspan="2">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" style="border: thin ridge #C0C0C0">
                3B</td>
            <td class="style2" style="border: thin ridge #C0C0C0">
               123</td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style2" style="border: thin ridge #C0C0C0">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    
       <br />
       <span class="style3">  <strong>Pré-inscription aux cours du soir par niveau et spécialité</strong></span>&nbsp;
        <br /> <br /> <br />
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%' and etat='V') and niveau_acces=1 and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource21" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=1 and (specialite_esp_et='05' or  specialite_esp_et='01') and code_decision='01'">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource22" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=2 and (specialite_esp_et='05' or  specialite_esp_et='01') and code_decision='01'">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource23" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=3 and (specialite_esp_et='05' or  specialite_esp_et='01') and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource27" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=1 and (specialite_esp_et='04')and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource28" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=2 and (specialite_esp_et='04' ) and code_decision='01'">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource29" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=3 and (specialite_esp_et='04') and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource33" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=1 and (specialite_esp_et='03')and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource34" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=2 and (specialite_esp_et='03')and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource35" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%S%'  and niveau_acces=3 and (specialite_esp_et='03')and code_decision='01' ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource11" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%'  and niveau_acces=1 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource12" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%'  and niveau_acces=2 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource13" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%' and (CODE_SPEC_ORIGINE  in '1' )   and niveau_acces=3 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource14" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%' and  (CODE_SPEC_ORIGINE not in ('1' ))   and niveau_acces=3 and specialite_esp_et='05' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%J%' and etat='V') and niveau_acces=1 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>

 <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=1 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource16" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=2 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource17" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=3 and specialite_esp_et='04' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSource18" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=1 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource19" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=2 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource20" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant_enreg where trim(id_et) like '16%J%' and niveau_acces=3 and specialite_esp_et='03' and code_decision='01'  ">
   
     
</asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%J%' and etat='V') and niveau_acces=1 and specialite_esp_et='03'   ">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%' and etat='V') and niveau_acces=2 and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource5" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%J%' and etat='V') and niveau_acces=2 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource6" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%J%' and etat='V') and niveau_acces=2 and specialite_esp_et='03'   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%' and etat='V') and niveau_acces=3 and (CODE_SPEC_ORIGINE in ('1' ))  and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource10" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%' and etat='V') and niveau_acces=3 and (CODE_SPEC_ORIGINE not in ('1'))  and specialite_esp_et='05'   ">
   
     
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource8" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%J%' and etat='V') and niveau_acces=3 and specialite_esp_et='04'   ">
   
     
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource9" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
    
       
        SelectCommand="select  COUNT(*) from esp_etudiant where trim(id_et) like '16%J%' and id_et in (select trim(id_et) from esp_recu where id_et like '16%' and etat='V') and niveau_acces=3 and specialite_esp_et='03'   ">
   
     
</asp:SqlDataSource>

</asp:Content>
