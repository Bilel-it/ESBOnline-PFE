<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AffectProjetetudiant.ascx.cs" Inherits="ESPOnline.EnseignantsCUP.AffectProjetetudiant" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    #Table2
    {background: #C8C8C8  ;
        
    }
    #Table1
    {   
        width: 537px;
        height: 87px;
    }
    .RadButton_Default.rbToggleButton{color:#000}.RadButton.rbToggleButton{border:0 none;outline:0 none}.RadButton_Default.rbToggleButton{color:#000}.RadButton.rbToggleButton{border-style: none;
        border-color: inherit;
        border-width: 0;
        outline: 0 none;
        top: 0px;
        left: -67px;
        height: 20px;
        width: 12px;
    }.rbToggleButton{position:relative;display:inline-block;cursor:default;height:20px;line-height:20px;text-decoration:none;padding-left:20px}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.rbToggleButton{position:relative;display:inline-block;cursor:default;height:20px;line-height:20px;text-decoration:none;padding-left:20px}.RadButton{cursor:pointer}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton_Default .rbToggleRadio{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Button.ToggleSprite.png')}.rbPrimaryIcon.rbToggleRadio{cursor:default}.RadButton .rbPrimaryIcon{cursor:pointer}.RadButton_Default .rbToggleRadio{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Button.ToggleSprite.png')}.rbPrimaryIcon.rbToggleRadio{cursor:default}.RadButton .rbPrimaryIcon{cursor:pointer}.rbPrimaryIcon{left:5px}.rbToggleRadio{background-position:-24px 0}.rbPrimaryIcon{top:3px;left:4px}.rbPrimaryIcon{position:absolute;display:block;width:16px;height:16px;overflow:hidden;background-repeat:no-repeat;cursor:default}.rbPrimaryIcon{left:5px}.rbToggleRadio{background-position:-24px 0}.rbPrimaryIcon{top:3px;left:4px}.rbPrimaryIcon{position:absolute;display:block;width:16px;height:16px;overflow:hidden;background-repeat:no-repeat;cursor:default}.rbText{display:inline-block}.rbText{display:inline-block}.RadButton_Default .rbToggleRadioChecked{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Button.ToggleSprite.png')}.rbPrimaryIcon.rbToggleRadioChecked{cursor:default}.RadButton_Default .rbToggleRadioChecked{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Button.ToggleSprite.png')}.rbPrimaryIcon.rbToggleRadioChecked{cursor:default}.rbToggleRadioChecked{background-position:-24px -40px}.rbToggleRadioChecked{background-position:-24px -40px}
</style>     
<p>
&nbsp;<table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="1" rules="none" >
         
            <td>
                <br />
&nbsp; Etudiant:</td>
            <td>
              &nbsp;   &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server"  >   
                   <ContentTemplate>      
            <telerik:RadComboBox ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource3"  
                  DataTextField="NOM" DataValueField="ID_ET"
                EmptyMessage="Tappez le Nom d'etudiant " Filter="Contains" Width="300" MaxHeight="400"
                DropDownWidth="500"  ShowMoreResultsBox="False" BorderStyle="Double"
                BorderColor="Red" HighlightTemplatedItems="True">
            </telerik:RadComboBox></ContentTemplate></asp:UpdatePanel> <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select NOM_ET||' '||PNOM_ET || ' '||e2.ID_ET ||'  '|| e1.code_cl as NOM, e2.ID_ET as ID_ET from esp_inscription e1,esp_etudiant e2 where annee_deb=2014  AND e2.id_et=e1.id_et AND e2.etat='A' order by e1.code_cl">
            </asp:SqlDataSource>
            </td>

            <td>
                 </td>
            <td>
                                    </td>
        </tr>
            <tr>
         
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>

            <td>
                &nbsp;</td>
            <td>
                                    &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
                <td>
          <asp:Button ID="btnUpdate" Text="Modifier" runat="server" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'>
            </asp:Button>
            <asp:Button ID="btnInsert" Text="Ajouter" runat="server" CommandName="PerformInsert"
                Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>'></asp:Button>
            &nbsp;
            <asp:Button ID="btnCancel" Text="Annuler" runat="server" CausesValidation="False"
                CommandName="Cancel"></asp:Button></td>
        </tr>
    </table>
</p>

          </td>
    </tr>
    