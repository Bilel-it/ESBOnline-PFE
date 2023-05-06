<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajouter_Matiere.aspx.cs" Inherits="ESPOnline.EmploiEsp.Ajouter_Matiere" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #333333">
    <div>
 <center><h3>Ajouter un Module</h3></center>   
    <table align="center" 
            style="height: 200px; width: 450px; background-color: #B5B5B5">
            
      <tr >
    <td class="style6">
        <asp:Label ID="code" Text="Code Module" runat="server" CssClass="style3" 
        > </asp:Label><span class="style4" >*</span></td>
    <td class="style8"><asp:TextBox ID="TxtCode" runat="server" Height="27px" Width="165px" placeholder="Entrer le code" MaxLength="7"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcode" runat="server" ErrorMessage="Entrer le code"  
                        > <asp:Image ID="Image6" runat="server" ImageUrl="~/Css-Template/listimage/images/warning.jpg" Height="16px" 
                        Width="16px" />
     </asp:RequiredFieldValidator>
     
    </td>
    </tr>
  <%-- <tr> <td class="style6">
        <asp:Label ID="Label1" Text="Libellé" runat="server" CssClass="style3"
          > </asp:Label><span class="style4" >*</span></td>
    <td class="style8"><asp:TextBox ID="txtCin" runat="server" Height="27px" Width="165px" placeholder="Carte d'identité" MaxLength="8"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtcin" runat="server" ErrorMessage="Enter le num de votre CIN"> <asp:Image ID="Image3" runat="server" ImageUrl="~/Css-Template/listimage/images/warning.jpg" Height="16px" 
                        Width="16px" />
     </asp:RequiredFieldValidator>
    </td></tr>--%>
    <tr >
    <td class="style6"><asp:Label ID="labelmodule" Text="Designation" runat="server" 
            CssClass="style3"> </asp:Label><span class="style4" >*</span></td>
    <td class="style8"><asp:TextBox ID="txtnom" runat="server" Height="27px" Width="165px" placeholder="Entrer le Nom"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtnom" runat="server" ErrorMessage="Enter the name"  
                        > <asp:Image ID="Image1" runat="server" ImageUrl="~/Css-Template/listimage/images/warning.jpg" Height="16px" 
                        Width="16px" />
     </asp:RequiredFieldValidator>
     
    </td>
    </tr>
     <tr>

    
    </tr>
    
    

  
  </table>
  <br/>
    <table cellpadding="0" cellspacing="0" border="0" align="center" style="width: 20%">
   
                                            <tr>
                                                <td align="left" valign="bottom" class="style7">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button  runat="server"  ID="btnadd" Text="Ajouter" BackColor="Maroon" 
                                                     ForeColor="#CCCCCC" Height="30px" Width="150px" onclick="btnadd_Click" /></td>
                                                &nbsp;</td>
                                               <%-- <td align="center" valign="bottom">
                                                    <asp:ImageButton runat="server" ID="btnRemove" 
                                                        ImageUrl="~/Css-Template/listimage/Pictures/eraser.png" onclick="btnReset_Click" />
                                                </td>--%>
                                            </tr>
                                            <tr><td>
                                                <asp:Label ID="lblmessage" runat="server" Text="" 
           style="color: #FF0000; font-weight: 700; font-size: medium;"></asp:Label>

       </td>
       </tr>
</table>
    </div>
    </form>
</body>
</html>
