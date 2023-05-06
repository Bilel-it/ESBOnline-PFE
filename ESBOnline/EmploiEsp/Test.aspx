<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs"  MasterPageFile="~/EmploiEsp/Edt.Master" Inherits="ESPOnline.EmploiEsp.Test"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
          <meta name="description" content="" />
          <meta name="keywords" content="" />
        <script src="../EDTCss/jsemploi/jquery.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/skel-layers.min.js" type="text/javascript"></script>
        <script src="../EDTCss/jsemploi/init.js" type="text/javascript"></script>
        <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/skel.css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/style.css" />
          <link rel="stylesheet" href="../EDTCss/cssemploi/style-desktop.css" />
          <link href="../Contents/CSS3/css/bootstrap.css" rel="stylesheet" type="text/css" />
	
    
        <style type="text/css">
            .style1
            {
                color: #CCCCCC;
            }
        </style>
</asp:Content>

	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       
        <div style="background-color: #808080; text-align: center; font-family: 'Times New Roman', Times, serif;
        font-size: x-large;">
        <br />
        <span class="style6"><span class="style1"><strong>Indisponibilité de l'Enseignant:</strong>
        <asp:Label ID="lblnomprenom" runat="server" text=""> </asp:Label>
        </span></span><span class="style5"><br />
        </span>
        <br />
        <%--<table><tr><td><asp:TextBox ID="txtnom" runat="server"></asp:TextBox></td></tr></table>--%>
        <center>
        <table align="center" 

            style="height: 300px; width: 600px; background-color: #333333">
				<tr class="HeaderDay">
                <td><asp:label id="Label2" runat="server" CssClass="style1" Width="220px">Horaires\Jours</asp:label>
                </td>
					<td width="200px"><asp:label id="lblMonday" Width="100px" runat="server" CssClass="style1">Lundi</asp:label></td>
					<td width="200px"><asp:label id="lblTuesday" runat="server" Width="100px" CssClass="style1">Mardi</asp:label></td>
					<td width="200px"><asp:label id="lblWednesday" runat="server" Width="100px" CssClass="style1">Mercredi</asp:label></td>
					<td width="200px"><asp:label id="lblThursday" runat="server" Width="100px" CssClass="style1">Jeudi</asp:label></td>
					<td width="200px"><asp:label id="lblFriday" runat="server" Width="100px" CssClass="style1">Vendredi</asp:label></td>
					<td width="200px"><asp:label id="lblSaturday" runat="server" Width="100px" CssClass="style1">Samedi</asp:label></td>
					
				</tr>
				<tr>
					<td width="100px" class="style1">8h-10h</td>
					<td><input type="checkbox" id="check" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox1" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox2" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox3" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox4" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox5" runat="server" /></td>
					
					
				</tr>
				<tr>
					<td width="100px" class="style1">10h-12h</td>
					<td><input type="checkbox" id="Checkbox6" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox7" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox8" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox9" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox10" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox11" runat="server" /></td>
				</tr>
				<tr>
					<td width="100px" class="style1">12h-14h</td>
					<td><input type="checkbox" id="Checkbox12" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox13" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox14" runat="server"  /></td>
                    <td><input type="checkbox" id="Checkbox15" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox16" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox17" runat="server" /></td>
				</tr>
				<tr>
					<td width="100px" class="style1">14h-16h</td>
					<td><input type="checkbox" id="Checkbox18" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox19" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox20" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox21" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox22" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox23" runat="server" /></td>
				</tr>
				<tr>
					<td width="100px" class="style1">16h-18h</td>

					<td><input type="checkbox" id="Checkbox24" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox25" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox26" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox27" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox28" runat="server" /></td>
                    <td><input type="checkbox" id="Checkbox29" runat="server" /></td>

				</tr>
			</table>
            </center>
            <br />
            <asp:Button  ID="btndispo" runat="server" Text="Valider" Height="39px" 
            onclick="btndispo_Click" Width="119px"/>

<div id="ID_Month" style="DISPLAY: none"></div>
			<div id="ID_Year" style="DISPLAY: none"></div>
		<br />
        <br />
        </div>
      

</asp:Content>