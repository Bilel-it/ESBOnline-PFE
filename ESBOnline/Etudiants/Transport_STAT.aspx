<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transport_STAT.aspx.cs" Inherits="ESPOnline.Etudiants.Transport_STAT" 
    MasterPageFile="~/Etudiants/Eol.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrapmahditheboss007-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
         <br /> <br /> <br /> <br /> <br /> <br /> <br />
         <br /> <br /> <br /> <br /> <br />
       <h2>Pré-inscription (Ligne de transport)</h2>
        <br />
                 <table>

       <tr>

           <td>Merci de choisir:
                 <asp:RadioButtonList ID="RadioBtncjBUS" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                AppendDataBoundItems="true" ForeColor="Blue" OnSelectedIndexChanged="RadioBtncjBUS_SelectedIndexChanged"  >
                 <asp:ListItem Text="OUI" Value="O"></asp:ListItem>
                <asp:ListItem Text="Non" Value="N"></asp:ListItem>
       
               
              
            </asp:RadioButtonList>     

           </td>
       </tr>
                     <tr><td><br /></td></tr>

             <tr><td> <asp:DropDownList ID="ddlannee_debM" runat="server" AppendDataBoundItems="true"  Width="150px" Visible="false"
   Height="30px"   AutoPostBack="true" 
       >
<asp:ListItem Value="0">Veuillez choisir</asp:ListItem>
<asp:ListItem  Text="banlieue nord" Value="banlieue nord" ></asp:ListItem>
<asp:ListItem  Text="banlieue Est" Value="banlieue Est"></asp:ListItem>

        <asp:ListItem  Text="banlieue Sud1 (Fouchana...)" Value="banlieue Sud1 (Fouchana...)" ></asp:ListItem>

         <asp:ListItem Text="banlieue Sud2 (Hamma Lif ...)" Value="banlieue Sud2 (Hamma Lif ...)"></asp:ListItem>
</asp:DropDownList></td></tr>
<tr><td><br /></td></tr>
             <tr><td> <asp:Button ID="Btnscore_finale" width="180px" runat="server" Text="Valider" BackColor="Red"  Visible="false"
             height="44px" OnClick="Btnscore_finale_Click"  /></td></tr>

                      <tr><td> <asp:Button ID="Button1" width="180px" runat="server" Text="Quitter" BackColor="Red"  Visible="false"
             height="44px"  /></td></tr>
    </table>

    </center>
   
  
         

   
  
   

</asp:Content>
            