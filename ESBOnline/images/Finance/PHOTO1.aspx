<%@ Page Title="" Language="C#" MasterPageFile="~/Finance/RECU.Master" AutoEventWireup="true" CodeBehind="PHOTO1.aspx.cs" Inherits="ESPOnline.Finance.PHOTO1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <script src="../Contents/jquery.js" type="text/javascript"></script>

    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>

    
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Contents/Scripts/JScript1.js"></script>
       <style type="text/css">
        #Table1
        {
            width: 1050px;
        }
        .style1
        {
            width: 1191px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
 <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Width="400px" Height="30px"   DataTextField="ID_ET" DataValueField="ID_ET" OnSelectedIndexChanged="tt" >
    
    </asp:DropDownList>
    
      <br />
      <asp:Button ID="Button2" runat="server" CssClass="form-control" OnClientClick="return confirm('Etes-vous sûr de vouloir confirmer cet élément ?');"
          onclick="Button1_Click" Text="Valider" Width="200px" />
  </center>  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        SelectCommand="select * from esp_recu where etat='N'"></asp:SqlDataSource>
         
     
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
					<TR>
						<TD class="style1"><img src='<%# "Images.aspx?id=" + DropDownList1.SelectedValue %>'><br />
                        </TD>
					</TR>
				</TABLE>
			</P>
</asp:Content>
