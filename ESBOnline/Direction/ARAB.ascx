<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ARAB.ascx.cs" Inherits="ESPOnline.Direction.ARAB" %>

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
    .style5
    {
        width: 262px;
    }
    .style6
    {
        width: 262px;
        color: #FF0000;
        height: 31px;
    }
    .style8
    {
        color: #000000;
        font-size: medium;
    }
    .style9
    {
        color: #000000;
        }
    .style12
    {
        width: 500px;
        height: 31px;
    }
    .style13
    {
        width: 273px;
        height: 31px;
    }
    .style14
    {
        height: 31px;
    }
    .form-control
    {}
    .style15
    {
        color: #FF0000;
    }
    .style16
    {
        width: 273px;
    }
</style>     
<p>
&nbsp;<table id="Table2"   cellpadding="1" width="100%" border="1" rules="none" >
         
            <tr>
         
            <td class="style5">
                IDENTIFIANT</td>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID_ET")%>' style="font-weight: 700; color: #009900" 
                    ></asp:Label>
                </td>

            <td class="style3">
                &nbsp;</td>

            <td class="style16" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
                &nbsp;</td>
            <td class="style3" >
                                    &nbsp;</td>
        </tr>
                     
            <td class="style5">
                <br />
                <span 
                    style="font-family: 'Times New Roman', Times, serif; font-size: large"> 
                <span 
                    class="style9">PRENOM:</span></span></td>
            <td class="style3">
              <asp:TextBox ID="TextBox2" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.PNOM_ET") %>' 
                    Height="38px" Width="280px"  ReadOnly="true"
                    ></asp:TextBox>
                    
</td>

            <td class="style3">
                &nbsp;</td>

            <td class="style16"
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
              <asp:TextBox ID="TextBox8" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_ARB") %>' 
                    Height="38px" Width="280px"   
                    ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox8" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" 
                    ForeColor="Red" style="font-size: medium"></asp:RegularExpressionValidator>
            </td>
            <td class="style3">
                                    <strong>
             </strong>
                                    <asp:Label ID="Label4" runat="server" Text=" :الإسم"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                                                <span 
                                                    style="font-family: 'Times New Roman', Times, serif; font-size: large">
                                                <span class="style8">NOM:</span></span></td>
            <td class="style12">
              <asp:TextBox ID="TextBox3" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_ET") %>' 
                    Height="38px" Width="280px"  ReadOnly="true"
                    ></asp:TextBox>
                                                </td>
            <td class="style12">
                &nbsp;</td>
            <td class="style13" 
                style="font-family: 'Times New Roman', Times, serif; font-size: x-large">
              <asp:TextBox ID="TextBox9" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.PNOM_ARB") %>' 
                    Height="38px" Width="280px"   
                    ></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox9" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" 
                    ForeColor="Red" style="font-size: medium"></asp:RegularExpressionValidator>  
            </td>
            <td class="style14">
          <%--  DataSourceID="SqlDataSourceMethodologies DataTextField="LIB_NOME"                DataValueField="CODE_NOME""--%>
                                            <asp:Label ID="Label5" runat="server" Text="اللقب"></asp:Label>
                                            </td>   
        </tr>
        <tr>
            <td class="style5" style="font-size: large">
                        <span style="font-family: 'Times New Roman', Times, serif; font-size: large">
                        <span class="style15">
                        &nbsp;</span><span class="style8">LIEU_NAIS</span></span>:</td>
            <td class="style3">
              <asp:TextBox ID="TextBox4" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.LIEU_NAIS_ET") %>' 
                    Height="38px" Width="280px"  ReadOnly="true"
                    ></asp:TextBox>
                    </td>
            <td class="style3">
                &nbsp;</td>
            <td class="style16" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
              <asp:TextBox ID="TextBox10" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.LIEU_NAIS_ARB") %>' 
                    Height="38px" Width="280px"  
                    ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox10" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" 
                    ForeColor="Red" style="font-size: medium"></asp:RegularExpressionValidator>
                    
            </td>
            <td>
                        <span class="style1"> </span>
                        <asp:Label ID="Label7" runat="server" Text="مكان الولادة: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <%--Titre de projet:--%>Nature_BAC:</td>
            <td class="style3">
                <%--<telerik:RadTextBox Width="293px" ID="RadTextBox1" runat="server" Label="Titre de projet: "   
                    EmptyMessage="Titre" InvalidStyleDuration="100" AutoPostBack="true" 
                    Height="34px"/>--%>
                    <%--<asp:TextBox ID="TextBox2" runat="server"  TabIndex="5"   
                    Text='<%# DataBinder.Eval( Container, "DataItem.NOM_PROJET") %>' 
                    Height="38px" Width="307px" 
                    ></asp:TextBox>--%>
              <asp:TextBox ID="TextBox5" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.Nature_bac") %>' 
                    Height="38px" Width="280px"  ReadOnly="true"
                    ></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td class="style16" 
                style="font-size: large; font-family: 'Times New Roman', Times, serif">
              
              <asp:TextBox ID="TextBox11" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.NATURE_BAC_ARB") %>' 
                    Height="38px" Width="280px"   
                    ></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox11" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" 
                    ForeColor="Red" style="font-size: medium"></asp:RegularExpressionValidator>  
            </td>
            <td>
                
                <asp:Label ID="Label10" runat="server" Text=":نوع البكالوريا"></asp:Label>
                
            </td>
        </tr>

        <tr style="text-align: right">
         <td><b>Annee_universitaire 2014-2017</b></td>
            <td></td>
          
                    
        </tr>

        <tr>
         
            <td class="style5">
                DIPLOME_SUP:</td>
            <td class="style3">
              <asp:TextBox ID="TextBox6" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.DIPLOME_SUP_ET") %>' ReadOnly="true"
                    Height="38px" Width="330px"  
                    ></asp:TextBox>
                    </td>
            <td class="style3">
                &nbsp;</td>
                    <td>
              <asp:TextBox ID="TextBox13" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.DIPLOME_SUP_ARB") %>' 
                    Height="38px" Width="280px"   
                    ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox13" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" ForeColor="Red"></asp:RegularExpressionValidator>   
            </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text=": المستوى الدراسي"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="style5">
                ETAB_ORIGINE:</td>
            <td class="style3">
              <asp:TextBox ID="TextBox7" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.ETAB_ORIGINE") %>' 
                    Height="38px" Width="330px"  ReadOnly="true"
                    ></asp:TextBox>
                    </td>
            <td class="style3">
                &nbsp;</td>
            <td class="style16">
              <asp:TextBox ID="TextBox14" runat="server"      Font-Size="11pt"  CssClass="form-control"
                    Text='<%# DataBinder.Eval( Container, "DataItem.ETAB_ORIGINE_ARB") %>' 
                    Height="38px" Width="280px"    
                    ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox14" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
                <td>
            &nbsp;
                    <asp:Label ID="Label14" runat="server" Text="المؤسسة الأصلية:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style16">
          <asp:Button ID="btnUpdate" Text="Modifier" runat="server" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'>
            </asp:Button>
            </td>
                <td>
            &nbsp;
            <asp:Button ID="btnCancel" Text="Annuler" runat="server" CausesValidation="False"
                CommandName="Cancel"></asp:Button></td>
        </tr>

    </table>
 
</p>
          