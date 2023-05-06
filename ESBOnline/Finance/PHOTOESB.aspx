<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PHOTOESB.aspx.cs" Inherits="Image_blob.PHOTOESB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        #Table1
        {
            width: 500px;
        }
        .style1
        {
            height:500px;
            width: 500px;
        }
    </style>
    
</head>
<body>
  <form id="form1" runat="server" method="post">
  <center>

 <asp:DropDownList ID="DropDownList1" required="true" runat="server"  AutoPostBack="True" Width="400px" Height="30px"   DataTextField="tt" DataValueField="ID_ET" OnSelectedIndexChanged="tt" >
    
    </asp:DropDownList>
    
      <br />
      <asp:Button ID="Button2" runat="server" CssClass="form-control"  OnClientClick="return confirm('Etes-vous sûr de vouloir confirmer cet élément ?');"
          onclick="Button1_Click" Text="Valider" Width="200px" />
  </center> </form> 
  <br />
  
  <br /><center>    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label></center>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select e1.id_et as id_et, e2.NOM_ET||''||e2.PNOM_ET||''||e1.id_et ||''||e2.numcompte as tt,
e2.NOM_ET from esp_recu e1,ESP_ETUDIANT e2
where e1.id_et like '17%' and e1.etat='N' and trim(e1.id_et)=trim(e2.id_et) and   specialite_esp_et  in ('06','07','08','09','10') order by (e2.date_saisie)
        "></asp:SqlDataSource>
         
     <center>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
					<TR>
						<TD class="style1"><img height="900px" src='<%# "Images.aspx?id=" + DropDownList1.SelectedValue %>'><br />
                        </TD>
					</TR>
				</TABLE>
			</P>

 </center>
    
</body>
</html>
 