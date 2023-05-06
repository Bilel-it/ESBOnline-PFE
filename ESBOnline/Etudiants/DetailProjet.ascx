<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailProjet.ascx.cs" Inherits="ESPOnline.Etudiants.DetailProjet" %>

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
&nbsp; Titre:</td>
            <td>
              &nbsp;   &nbsp;<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"  >   
                   <ContentTemplate>      
            <telerik:RadComboBox ID="DropDownList1" runat="server"  DataSourceID="SqlDataSource3"  
                AutoPostBack="True"  DataTextField="NOM" DataValueField="ID_ET"
                EmptyMessage="Tappez le Nom d'etudiant " Filter="Contains" Width="300" MaxHeight="400"
                DropDownWidth="500"  ShowMoreResultsBox="False" BorderStyle="Double"
                BorderColor="Red" HighlightTemplatedItems="True">
            </telerik:RadComboBox></ContentTemplate></asp:UpdatePanel> <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                SelectCommand="select NOM_ET||' '||PNOM_ET || ' '||e2.ID_ET ||'  '|| e1.code_cl as NOM, e2.ID_ET as ID_ET from esp_inscription e1,esp_etudiant e2 where (code_cl like  'PS%' or code_cl like '%') and annee_deb=2013  AND e2.id_et=e1.id_et ">
            </asp:SqlDataSource>--%>
            <asp:TextBox ID="TextBox2" runat="server"  TabIndex="5"   
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_PROJET") %>' 
                    Height="38px" Width="307px" 
                    ></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="TextBox2"
  ErrorMessage="*"
  ForeColor="Red">
</asp:RequiredFieldValidator>
</td>

            <td>
                &nbsp;  &nbsp;  &nbsp;  Technologies:</td>
            <td>
                                    <asp:DropDownList ID="DDlistTech" runat="server" CssClass="form-control" AppendDataBoundItems="True"  DataSourceID="SqlDataSourcetectnologies"
                                           SelectedValue='<%# Bind("TECHNOLOGIES") %>'      Width="300"  DataTextField="LIB_NOME" DataValueField="CODE_NOME"   >
                                            <asp:ListItem Selected="True" Text="Select" Value="">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSourcetectnologies" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65')"></asp:SqlDataSource>
           &nbsp;  &nbsp;  &nbsp; </td>
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
                                                &nbsp;&nbsp; Module:</td>
            <td>
                                                <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True"  DataSourceID="SqlDataSource4" Width="300" AppendDataBoundItems="True"
                                                  CssClass="form-control" DataTextField="DESIGNATION"  
                                                    DataValueField="CODE_MODULE"  EnableViewState="true" 
                                                   ><asp:ListItem Selected="True" Text="Select" Value="">
                                                </asp:ListItem></asp:DropDownList>
                                              
                                               
                                               
                                              <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                            SelectCommand="SELECT &quot;CODE_MODULE&quot;, &quot;DESIGNATION&quot; FROM &quot;ESP_MODULE&quot; order by DESIGNATION ">
                                                        </asp:SqlDataSource> 
                                         </td>
            <td>
              &nbsp;  &nbsp;  &nbsp;  Methodologies:</td>
            <td>
          <%--  DataSourceID="SqlDataSourceMethodologies DataTextField="LIB_NOME"                DataValueField="CODE_NOME""--%>
                                                <asp:DropDownList ID="DDlistMethod" runat="server"  DataTextField="LIB_NOME"      AppendDataBoundItems="True"            DataValueField="CODE_NOME"  DataSourceID="SqlDataSourceMethodologies" TabIndex="7"
                                                CssClass="form-control" Width="300" 
                                                     SelectedValue='<%# Bind("METHODOLOGIE") %>'  ><asp:ListItem Selected="True" Text="Select" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSourceMethodologies" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64')">
                                                </asp:SqlDataSource>
                                            </td>  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;
        </tr>
        <tr>
            <td>
                        Type Projet:</td>
            <td>
                        <asp:DropDownList ID="Droptypeproj" runat="server" Width="300"    AppendDataBoundItems="True"
                                                    DataSourceID="Sqltypeprojet" DataTextField="LIB_NOME"
                                                    DataValueField="CODE_NOME">
                                                    
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Sqltypeprojet" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79')">
                                                </asp:SqlDataSource>
                    </td>
            <td>
              &nbsp;  &nbsp;  &nbsp;&nbsp; Duree:</td>
            <td>
                        <asp:DropDownList ID="Dropmois" CssClass="form-control" runat="server"   Width="300" AppendDataBoundItems="True"  SelectedValue='<%# Bind("DUREE") %>'  >
                                               <asp:ListItem Selected="True" Text="Select" Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="NBMois">NB Mois</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>
            &nbsp;  &nbsp;  &nbsp;</td>
        </tr>
        <tr>
            <td>
                <%--Titre de projet:--%></td>
            <td>
                <%--<telerik:RadTextBox Width="293px" ID="RadTextBox1" runat="server" Label="Titre de projet: "   
                    EmptyMessage="Titre" InvalidStyleDuration="100" AutoPostBack="true" 
                    Height="34px"/>--%>
                    <%--<asp:TextBox ID="TextBox2" runat="server"  TabIndex="5"   
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_PROJET") %>' 
                    Height="38px" Width="307px" 
                    ></asp:TextBox>--%></td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Description: </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Columns="60" Rows="5" TabIndex="5"  ReadOnly="True"
                    Text='<%# DataBinder.Eval( Container, "DataItem.DESCRIPTION_PROJET") %>' 
                    TextMode="MultiLine">
                        </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <%--<td>
            Semestre:&nbsp;  <telerik:RadButton ID="RadButton24" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
               GroupName="Radios" AutoPostBack="false">
               <ToggleStates>
                    <telerik:RadButtonToggleState Text="S2"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="S1"></telerik:RadButtonToggleState>
               </ToggleStates>
          </telerik:RadButton>
      &nbsp; &nbsp;<telerik:RadButton ID="RadButton23" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
               Checked="true" GroupName="Radios" AutoPostBack="false">
               <ToggleStates>
                    <telerik:RadButtonToggleState Text="S2"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="S1"></telerik:RadButtonToggleState>
               </ToggleStates>
          </telerik:RadButton>
            </td>--%>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <%--<td>
            Periode:&nbsp; &nbsp;  <telerik:RadButton ID="RadButton1" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
               GroupName="Radios" AutoPostBack="false">
               <ToggleStates>
                    <telerik:RadButtonToggleState Text="P2"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="P1"></telerik:RadButtonToggleState>
               </ToggleStates>
          </telerik:RadButton>
      &nbsp; &nbsp;<telerik:RadButton ID="RadButton2" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
               Checked="true" GroupName="Radios" AutoPostBack="false">
               <ToggleStates>
                    <telerik:RadButtonToggleState Text="P2"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="P1"></telerik:RadButtonToggleState>
               </ToggleStates>
          </telerik:RadButton>
            </td>--%>
            <td>
                &nbsp;</td>
            <td>
                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("TYPE_PROJET2")%>'></asp:Label>--%>
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
           
            
            &nbsp;
            <asp:Button ID="btnCancel" Text="Annuler" runat="server" CausesValidation="False"
                CommandName="Cancel"></asp:Button></td>
        </tr>
    </table>
</p>

          </td>
    </tr>