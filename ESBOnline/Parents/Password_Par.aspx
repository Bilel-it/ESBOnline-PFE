<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Password_Parent.Master" AutoEventWireup="true" CodeBehind="Password_Par.aspx.cs" Inherits="ESPOnline.Parents.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Contents/Css/sticky-footer-navbar.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/Css/signin.css" rel="stylesheet" type="text/css" />
        <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            width: 172px;
        }
        .style2
        {
            width: 132px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="global">
      <div class="login">
        <div class="login-header"></div>
        <div class="login-content" align="center"  style="border: thick double #FF0000; font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bolder; font-style: normal; font-variant: normal; color: #000000">
          Bienvenue dans l'espace </br>
<span class="login-title">Parents</span>
</br>
<panel>
<br />
<table style="border: thick groove #FF0000; background-color: #C0C0C0; width: 656px; height: 122px;">
<br /><br />
    <tr>
      <td class="style1">
          <br />
          Numéro cin</td>
      <td class="form-separator"> : </td>
      <td class="style2">
          <asp:TextBox ID="TextBox1"   ValidationGroup="ajouter_passe" runat="server" ></asp:TextBox>

        </td>
        <td class="form-label"></td>
    </tr>
    <tr>
      <td class="style1">Mot de passe</td>
      <td class="form-separator"> : </td>
      <td class="style2">
          <asp:TextBox ID="txt_npassword" TextMode="Password"  runat="server"></asp:TextBox>
          <br />
          
        </td>
        <td class="form-label"> 
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_npassword"
                ValidationGroup="ajouter_passe" ErrorMessage="S'il vous plaît entrer nouveau mot de passe"
                ForeColor="Red"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="RegExp1" runat="server" 
                ControlToValidate="txt_npassword" ErrorMessage=" Le mot de passe ne doit pas contenir d'espace et ne dépasse pas 20 caractères"
              ValidationGroup="ajouter_passe"    
                ValidationExpression="^([\w\W](?!.*\s))*$" ForeColor="#CC0000" />
        </td>
    </tr>
     <tr>
      <td class="style1">Confirmer Mot de passe</td>
      <td class="form-separator"> : </td>
      <td class="style2">
          <asp:TextBox ID="txt_ccpassword" TextMode="Password"  runat="server"></asp:TextBox>
       
           
         </td>
         <td class="form-label">
         
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ccpassword"
                ErrorMessage="S'il vous plaît entrez le mot de passe de confirmation" ValidationGroup="ajouter_passe"
                ForeColor="Red"></asp:RequiredFieldValidator><br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_npassword"
                ControlToValidate="txt_ccpassword" 
                ErrorMessage="Mot de passe Incompatible" ForeColor="Red" 
                ValidationGroup="ajouter_passe"></asp:CompareValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                runat="server" ControlToValidate="txt_ccpassword" ErrorMessage=" Le mot de passe ne doit pas contenir d'espace et ne dépasse pas 20 caractères"
              ValidationGroup="ajouter_passe"    
                ValidationExpression="^([\w\W](?!.*\s))*$" ForeColor="#CC0000" />
                
                
                </td>

                 
    <tr>
      <td class="style1"></td>
      <td class="form-separator"> </td><br>
      </td>
      
      <td class="style2"><br>
      </td>
       <td class="form-label"></td>
    </tr>
    <tr>
      <td colspan="2"></td>
      <td class="style2">
          <asp:Button ID="Button1" runat="server" Height="25px" Text="Modifier" 
              Width="138px" onclick="Button1_Click" Font-Bold="True" ValidationGroup="ajouter_passe"
              Font-Names="Times New Roman" Font-Size="Medium" ForeColor="Black" />
        </td>
         <td class="form-label"></td>
    </tr>
  </table>
  <br />
  <br />
</panel>
 

  
       </div>
        <div class="login-footer"></div>
      </div>
    </div>
</asp:Content>
