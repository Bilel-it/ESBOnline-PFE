<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUpAjout semaine.aspx.cs" Inherits="ESPOnline.EmploiEsp.PopUpAjout_semaine" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            background-color: #800000;
            color: #CCCCCC;
            font-weight: bold;
        }
       
      
        .style3
        {
            color: #CCCCCC;
        }
        .style5
        {
            color: #800000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="background-color: #333333" width="120px" align="left">
    <h2 class="style5">Ajout d&#39;une semaine</h2>
    <tr>
    <td>

    <span class="style3">
    <strong>N° de la semaine:</strong></span> <asp:TextBox  Height="35px" Width="400px" ID="TxtSem1" placeholder="Entrez la semaine ici" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtSem1"

            ValidationGroup="EnsignantInfoGroup" ErrorMessage="Identifiant incorrect " 
            CssClass="text-danger" style="color: #800000"></asp:RequiredFieldValidator>
                                    </td></tr> 
                                    <tr><td>  <span class="style3"><strong>Date de 1er Jours:</strong></span> <asp:TextBox  Height="35px" Width="400px" ID="TxtDate" placeholder="Entrez la date ici" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                            runat="server" ControlToValidate="TxtDate"
                                                        ValidationGroup="EnsignantInfoGroup" 
                                            ErrorMessage="Identifiant incorrect " CssClass="text-danger" 
                                            style="color: #800000"></asp:RequiredFieldValidator>
</td></tr>              
    
  <tr align="center" ><td>
  <asp:Button  ID="txtbtn" runat="server" Text="OK" Width="100px" CssClass="style1" 
          Height="40px"/>
   <asp:Button  ID="Button1" runat="server" Text="Annuler" Width="100px" 
          CssClass="style1" Height="40px"/>
  </td>
  </tr>
    </table>
    </div>
    </form>
</body>
</html>
