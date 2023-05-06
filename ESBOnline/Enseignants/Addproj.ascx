<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Addproj.ascx.cs" Inherits="ESPOnline.Enseignants.Addproj" %>
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
    .style1
    {
        color: #FF0000;
        font-weight: 700;
    }
    .style3
    {
        width: 500px;
    }
    .style4
    {
        width: 198px;
    }
    .style5
    {
        width: 262px;
    }
    .style6
    {
        width: 262px;
        color: #FF0000;
    }
    .style7
    {
        font-size: large;
        color: #FF0000;
    }
    .style8
    {
        color: #000000;
    }
    .style9
    {
        color: #000000;
        font-weight: 700;
    }
    .style10
    {
        color: #FF0000;
    }
</style>     
<p>
&nbsp;<table id="Table2"   cellpadding="1" width="100%" border="1" rules="none" >
         
            <tr>
         
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>

            <td class="style5" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
                &nbsp;</td>
            <td class="style3" >
                                    &nbsp;</td>
        </tr>
                     
            <td class="style5">
                <br />
                <strong 
                    style="font-family: 'Times New Roman', Times, serif; font-size: large"> 
                <span class="style9">
                &nbsp;Titre</span><span class="style10">*</span><span 
                    class="style9">:</span></strong></td>
            <td class="style3">
              <asp:TextBox ID="TextBox2" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_PROJET") %>' 
                    Height="38px" Width="330px" 
                    ></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="TextBox2"
  ErrorMessage="Valeur Requise!"
  ForeColor="Red" style="font-weight: 700">
</asp:RequiredFieldValidator>
</td>

            <td class="style5"
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
               <span class="style9"> Technologies</span><span 
                    class="style10">*</span><span class="style9">:</span></td>
            <td class="style3">
                                    <asp:DropDownList ID="DDlistTech" runat="server" CssClass="form-control" AppendDataBoundItems="True"  DataSourceID="SqlDataSourcetectnologies"
                                           SelectedValue='<%# Bind("TECHNOLOGIES") %>'     Height="38px" Width="330px"  DataTextField="LIB_NOME" DataValueField="CODE_NOME"   >
                                            <asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                            <strong>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DDlistTech"
                ErrorMessage="Valeur Requise!" InitialValue="" style="color: #FF0000"></asp:RequiredFieldValidator>
           &nbsp;  </strong>&nbsp;  &nbsp; </td>
        </tr>
        <tr>
            <td class="style6">
                                                <strong 
                                                    style="font-family: 'Times New Roman', Times, serif; font-size: large">
                                                <span class="style8">&nbsp;Module:</span></strong></td>
            <td class="style3">
                                                <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True"  DataSourceID="SqlDataSource4" Width="330px" Height="38px"  AppendDataBoundItems="True"
                                                  CssClass="form-control" DataTextField="DESIGNATION"   SelectedValue='<%# Bind("DESI") %>'  
                                                    DataValueField="CODE_MODULE"  EnableViewState="true" 
                                                   ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem></asp:DropDownList>
                                              
                                               
                                               
                                              <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                            SelectCommand="SELECT &quot;CODE_MODULE&quot;, &quot;DESIGNATION&quot; FROM &quot;ESP_MODULE&quot; order by DESIGNATION ">
                                                        </asp:SqlDataSource> 
                                         </td>
            <td class="style5" 
                style="font-family: 'Times New Roman', Times, serif; font-size: x-large">
             <span class="style9" 
                    
                    
                    style="font-family: 'Times New Roman', Times, serif; font-size: large; font-weight: 700;">Methodologies</span><span 
                    class="style7">*</span>:</td>
            <td>
          <%--  DataSourceID="SqlDataSourceMethodologies DataTextField="LIB_NOME"                DataValueField="CODE_NOME""--%>
                                                <asp:DropDownList ID="DDlistMethod" runat="server"  DataTextField="LIB_NOME"      AppendDataBoundItems="True"            DataValueField="CODE_NOME"  DataSourceID="SqlDataSourceMethodologies" TabIndex="7"
                                                CssClass="form-control" Width="330px" Height="38px"
                                                     SelectedValue='<%# Bind("METHODOLOGIE") %>'  ><asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDlistMethod"
                ErrorMessage="Valeur Requise!" InitialValue="" CssClass="style1"></asp:RequiredFieldValidator>
                                                <asp:SqlDataSource ID="SqlDataSourceMethodologies" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64')">
                                                </asp:SqlDataSource>
                                            </td>   
        </tr>
        <tr>
            <td class="style5" style="font-size: large">
                        <strong style="font-family: 'Times New Roman', Times, serif; font-size: large">
                        <span class="style1">
                        &nbsp;</span><span class="style9">Type Projet</span></strong><span class="style10">*</span>:</td>
            <td class="style3">
                        <asp:DropDownList ID="Droptypeproj" runat="server" Width="330px" Height="38px"   AppendDataBoundItems="True"
                                               CssClass="form-control"     DataSourceID="Sqltypeprojet" DataTextField="LIB_NOME" SelectedValue='<%# Bind("TYPE_PROJET") %>' 
                                                    DataValueField="CODE_NOME">
                                         <asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>           
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Sqltypeprojet" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79')">
                                                </asp:SqlDataSource>
                    </td>
            <td class="style5" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
               <span class="style9">Duree</span><span class="style10">*</span>:</td>
            <td>
                        <asp:DropDownList ID="Dropmois" CssClass="form-control" runat="server"   Width="330px" Height="38px" AppendDataBoundItems="True"  SelectedValue='<%# Bind("DUREE") %>'  >
                                               <asp:ListItem Selected="True" Text="" Value="">
                                                </asp:ListItem>
                                          
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
                                            
 

 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Dropmois"
                ErrorMessage="Valeur Requise!" InitialValue="" CssClass="style1"></asp:RequiredFieldValidator>
                        <span class="style1"> </span></td>
        </tr>
        <tr>
            <td class="style5">
                <%--Titre de projet:--%></td>
            <td class="style3">
                <%--<telerik:RadTextBox Width="293px" ID="RadTextBox1" runat="server" Label="Titre de projet: "   
                    EmptyMessage="Titre" InvalidStyleDuration="100" AutoPostBack="true" 
                    Height="34px"/>--%>
                    <%--<asp:TextBox ID="TextBox2" runat="server"  TabIndex="5"   
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_PROJET") %>' 
                    Height="38px" Width="307px" 
                    ></asp:TextBox>--%>
                                            <asp:SqlDataSource ID="SqlDataSourcetectnologies" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
                                                SelectCommand="SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65')"></asp:SqlDataSource>
            </td>
            <td class="style5" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
              
                <span class="style9">Description</span><span class="style10">*</span>: </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Columns="60" Rows="5" TabIndex="5"    CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.DESCRIPTION_PROJET") %>' 
                    TextMode="MultiLine">
                        </asp:TextBox>
            </td>
        </tr>
        <tr>
            <%--<td>
                &nbsp;</td>
            <td>
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
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID_PROJET")%>' Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
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
    