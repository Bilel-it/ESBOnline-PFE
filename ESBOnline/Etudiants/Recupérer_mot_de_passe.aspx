<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Resetpwd.Master" AutoEventWireup="true" CodeBehind="Recupérer_mot_de_passe.aspx.cs"
     Inherits="ESPOnline.Etudiants.Recupérer_mot_de_passe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
 
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
 
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
 
 
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>
   <asp:Panel ID="Panel2" runat="server" Width="95%">

<div align="center" >    
<center><asp:Label ID="label100" runat="server" style="color:#ae002e "> <h3>Récupérer le Mot de passe de votre compte </h3></asp:Label></center>

<hr />
                
                
           
                
                
                </div>

<table class="table table-bordered table-striped table-hover">
      
        
        <tr align="center">
          
            <td align="center">






               

                <asp:TextBox ID="Adresse_mail_esp" runat="server" placeholder="Adresse e-mail Esprit,Exemple:xyz@esprit.tn"  Height="30px" Width="400px" required="" ></asp:TextBox>






               

            </td>
            <td align="left">






               

                <asp:Button ID="btn_renitialiser_mot_depasse" runat="server" Text="Récupérer mot de passe" 
                    onclick="btn_renitialiser_mot_depasse_Click" Width="200px" Height="30" />






               

            </td>
         
        </tr>
        <tr align="center">
          
            <td>



            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red"
ControlToValidate="Adresse_mail_esp"  ErrorMessage="Adresse e-mail incorrecte"
ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


               

                <br />


                <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>

            </td>
            <td>




                <asp:Label ID="motdepasse" runat="server" Text="" Visible="false"></asp:Label>

               

                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>

               

            </td>
         
        </tr>
    </table>

  



        </asp:Panel>
        </center>

</asp:Content>
