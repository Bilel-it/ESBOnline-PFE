<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reset_pwd_etudiant.aspx.cs" Inherits="ESPOnline.Direction.reset_pwd_etudiant" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


*,
*:before,
*:after {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}

  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    box-shadow: none !important;
  }
  *,*:before,*:after{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}*{color:#000!important;text-shadow:none!important;background:transparent!important;box-shadow:none!important}

th {
  text-align: left;
}

th{text-align:left}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <center>  
      <asp:Panel ID="Panel1" runat="server"><center>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<h1 
                
                style="margin: 0px 0px 26px; padding: 0px; border: 0px; outline: 0px; font-weight: 400; font-style: normal; font-size: 34px; font-family: Roboto, 'Helvetica Neue', Helvetica, sans-serif; vertical-align: baseline; color: rgb(33, 33, 33); line-height: 40px; font-variant: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);" 
                align="center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Réinitialisation le mot de passe de compte 
                Esprit-Online</h1></center>
            <br />
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="1">Etudiants</asp:ListItem>
                                    <asp:ListItem Value="2">Enseignants</asp:ListItem>
                                </asp:RadioButtonList>
            <br />
            <br />
             <asp:Panel ID="Panel2" runat="server" Visible="false">

        <asp:Label ID="Label1" runat="server" 
            Text="Cherchez l'etudiant en utilisant:nom ou prénom ou cin ou adresse mail" 
            Font-Bold="True"></asp:Label>
            <br />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="DropDownList1" runat="server" 
                AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="cc" 
                DataValueField="ID_ET" DropDownWidth="500" 
                EmptyMessage="Tappez le Nom d'etudiant " EnableLoadOnDemand="True" 
                Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400" 
                ShowMoreResultsBox="False" Width="300">
            </telerik:RadComboBox>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT trim(t1.NOM_ET)||'        '||trim(t1.PNOM_ET)||'       '||trim(t1.NUM_CIN_PASSEPORT)||'       '||trim(t1.ADRESSE_MAIL_ESP)  cc,trim(t1.ADRESSE_MAIL_ESP) ,t1.ID_ET FROM ESP_ETUDIANT t1,esp_inscription t2  where t2.annee_deb=(select max (annee_deb)  from societe) and t2.id_et=t1.id_et  and ETAT='A'
      ">
      
            </asp:SqlDataSource>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT Id_et,trim(upper(nom_et))||' '|| trim(pnom_et) nom_prenom,ADRESSE_MAIL_ESP FROM ESP_ETUDIANT aa 
where  id_et=:ID_ET
  ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="ID_ET" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
                            <asp:GridView ID="GridView4" runat="server" 
                DataSourceID="SqlDataSource10" Visible="false">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT LIB_NOME FROM CODE_NOMENCLATURE where CODE_NOME='01' and CODE_STR='66'">
            </asp:SqlDataSource><br /><br /><br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Reset pwd " />
                            <asp:Button ID="Button2" runat="server" Text="Exit" 
                onclick="Button2_Click" />
                            <br />
                        </asp:Panel>

                        <asp:Panel ID="Panel3" runat="server" Visible="false">

        <asp:Label ID="Label2" runat="server" 
            Text="Cherchez l'enseignant en utilisant:nom ou prénom ou cin ou adresse mail" 
            Font-Bold="True"></asp:Label>
            <br />
            
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
                            <telerik:RadComboBox ID="RadComboBox1" runat="server" 
                AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="cc" 
                DataValueField="ID_ENS" DropDownWidth="500" 
                EmptyMessage="Tappez le Nom d'enseignant " EnableLoadOnDemand="True" 
                Filter="Contains" HighlightTemplatedItems="True" MaxHeight="400" 
                ShowMoreResultsBox="False" Width="300">
            </telerik:RadComboBox>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString%>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT trim(NOM_ENS)||'             '||trim(ID_ENS)||'       '||trim(MAIL_ENS)  cc,MAIL_ENS,ID_ENS FROM ESP_Enseignant    where   ETAT='A'
      ">
      
            </asp:SqlDataSource>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT ID_ENS,NOM_ENS,MAIL_ENS FROM ESP_Enseignant aa 
where  ID_ENS=:ID_ET
  ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="RadComboBox1" Name="ID_Ens" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
                            <asp:GridView ID="GridView2" runat="server" 
                DataSourceID="SqlDataSource5" Visible="false">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT LIB_NOME FROM CODE_NOMENCLATURE where CODE_NOME='01' and CODE_STR='66'">
            </asp:SqlDataSource><br /><br /><br />
            <asp:Button ID="Button3" runat="server"  
                Text="Reset pwd " onclick="Button3_Click" />
                            <asp:Button ID="Button4" runat="server" Text="Exit" 
                onclick="Button2_Click" />
                            <br />
                        </asp:Panel>
                        </asp:Panel>
                        </center>
    
    </div>
    </form>
</body>
</html>
