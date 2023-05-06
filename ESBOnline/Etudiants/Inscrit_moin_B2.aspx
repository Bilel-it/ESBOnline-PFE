<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscrit_moin_B2.aspx.cs" Inherits="ESPOnline.Etudiants.Inscrit_moin_B2"

MasterPageFile="~/Etudiants/Eol.Master" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../Contents/jquery.js" type="text/javascript"></script>
    <link href="../Contents/Css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap-datetimepicker.js" type="text/javascript"></script>
      <link rel="stylesheet" type="text/css" href="../Styles/style.css" />
      <style type="text/css">
          .style1
          {
              color: #FFFFFF;
          }
          </style>


      <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: white;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#d6e6f6;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #7591b1; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}

      
          .style3
          {
              font-size: large;
          }

      
          .style4
          {
              color: #FF0000;
              width: 780px;
          }
          .style5
          {
              width: 780px;
          }

      
          .style6
          {
              width: 780px;
              color: #000000;
          }

      
          </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<br />
<br />
<br />
<center>
<table runat="server" ID="tbl">
<tr>
<td class="style4"> 
   Il est porté à la connaissance des étudiants ayant dépassé la date de l'inscription en ligne (français/anglais) pour le test de niveau B2 que la date limite a été prolongée jusqu'au samedi 02 Mai à midi. Veuillez procéder à l'inscription au plus vite sachant que les dates disponibles sont  le 11 et 12 Mai'</td>
</tr> 

<tr>
<td class="style6"> 
   *  Après validation, vos choix ne seront plus modifiables.
 </td>
</tr>  


<tr><td class="style6">
* Le nombre d'inscription ne doit pas dépasser 120 personnes par date.
</td></tr>   
<tr><td class="style6">
<span class="text-info">*  les étudiants auront droit à une seule inscription par épreuve, les absences ne seront pas donc tolérées.
    </span>
</td></tr>  
<tr><td class="style5"></td></tr>  
</table>

<asp:Panel ID="panel"  runat="server" BackColor="#CC0000">

 <center><h1 class="style1">INSCRIPTION AU TEST DU LANGUE POUR L'ANNEE UNIVERSITAIRE: <asp:Label ID="lblanneedeb" runat="server" CssClass="style7"></asp:Label>/<asp:Label 
            ID="lblanneefin" runat="server" CssClass="style7"></asp:Label></h1></center>
 
   

 
  
    </asp:Panel>

 <asp:Panel ID="panel1"  runat="server" BackColor="Gray">
    
    <table  height="300px" bgcolor="#CCCCCC" 
         style="background-color: #CCCCCC; width: 860px;">
         <tr><td></td></tr>
 
         <tr>
             <td>
                 <asp:Label ID="lblfr" runat="server" Text="Test Français"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="ddltestfr" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                    DataTextField="DATETEST" DataValueField="DATETEST" DataTextFormatString="{0:d}"
                     onselectedindexchanged="ddltestfr_SelectedIndexChanged">
                     <asp:listitem Value="" Text="Choisir la date du test français"> </asp:listitem>
                 </asp:DropDownList>
             </td>
             <td> <asp:Label ID="Label6" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="LabCount" runat="server"></asp:Label><asp:Label ID="lbl" runat="server" Text=":étudiant(e)s"></asp:Label></td>
         </tr>
 <tr><td></td></tr>

 <tr>
 <td>
 <asp:Label ID="lbltestang" runat="server" Text="Test Anglais"></asp:Label>
 </td>

 <td>
 <asp:DropDownList ID="ddltestang" runat="server" AutoPostBack="true" DataTextField="DATETEST" DataValueField="DATETEST"
         AppendDataBoundItems="true" onselectedindexchanged="ddltestang_SelectedIndexChanged"
       DataTextFormatString="{0:d} ">
                    <asp:listitem Value="" Text="Choisir la date du test Anglais"> </asp:listitem>
                    </asp:DropDownList>
 </td>
 <td> <asp:Label ID="Label1" runat="server" Text="Nombre d'Inscription :"></asp:Label>
                                    <asp:Label ID="LabCountang" runat="server"></asp:Label><asp:Label ID="Lab" runat="server" Text=":étudiant(e)s"></asp:Label></td>
 </tr> 
 <tr>
  <td></td>
   <td>
         <%--<asp:Button ID="btnRemove" runat="server" CssClass="style12" Height="38px" 
             onclick="btnRemove_Click" Text="Annuler" Width="91px" />--%>
     </td>
     <td  align="center">
         <asp:Button ID="btnOk" runat="server" CssClass="style12" Height="38px" 
             Text="Valider" Width="91px" onclick="btnOk_Click" 
             BorderColor="#CCCCCC"   />
     </td>
 </tr>
 </table>
    </asp:Panel>
 
 </center>

 <center>
 <table>
 <tr><td></td></tr>
 <tr>
 
                                                <td valign="top">

<asp:GridView runat="server" ID="Gridbord" AutoGenerateColumns="False" 
                                                         
                                                         Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
                                                        background-color: white; width: 100%; border-top: white 2px ridge; border-right: white 2px ridge;"
                                                        BorderWidth="0px" BorderColor="Red" CellSpacing="1" CellPadding="3" CssClass="grid"
                                                        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" Width="100%"
                                                        GridLines="Both" EmptyDataRowStyle-CssClass="ItemStyle"  DataKeyNames="id_et" BackColor="#0099CC"
                                                       >
                                                        <EmptyDataTemplate>
                                                           non enregistré
                                                        </EmptyDataTemplate>
                                                        
                                                        <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" />
                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                                        <FooterStyle CssClass="ItemStyle" />
                                                        <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                                        <RowStyle CssClass="GridItemStyle" />
                                                        <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                        <Columns>
 <asp:TemplateField >
  <ItemTemplate>
    <%# Container.DataItemIndex + 1 %>
  </ItemTemplate>
</asp:TemplateField>


  <asp:TemplateField HeaderText="Identifiant" ItemStyle-HorizontalAlign  ="center"  ItemStyle-Width ="100%">
                        <ItemTemplate>
                            <asp:Label  ID="lbid" runat="server" Text='<% # Eval("id_et") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>  
                     
                     
                     
                    

                         

<asp:TemplateField HeaderText="Nom" ItemStyle-HorizontalAlign  ="center"  ItemStyle-Width ="100%" >
                <ItemTemplate >
                    <asp:Label ID="lblnom" runat="server" Text='<%# Eval("NOM_ET") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnom" runat="server" Text='<%# Eval("NOM_ET")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Prenom" ItemStyle-HorizontalAlign  ="center"  ItemStyle-Width ="100%" >
                <ItemTemplate >
                    <asp:Label ID="lblpnom" runat="server" Text='<%# Eval("PNOM_ET") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtpnom" runat="server" Text='<%# Eval("PNOM_ET")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Classe" ItemStyle-HorizontalAlign  ="center"  ItemStyle-Width ="100%" >
                <ItemTemplate >
                    <asp:Label ID="lblcodecl" runat="server" Text='<%# Eval("CODE_CL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtcodecl" runat="server" Text='<%# Eval("CODE_CL")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Date examen français" ItemStyle-Width ="100%">
                <ItemTemplate>
                    <asp:Label ID="lbldteSoin" runat="server" Text='<%# Eval("DATE_TEST_FR","{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("DATE_TEST_FR","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            

             <asp:TemplateField HeaderText="Date examen Anglais" ItemStyle-Width ="100%">
                <ItemTemplate>
                    <asp:Label ID="lbldteSoin" runat="server" Text='<%# Eval("DATE_TEST_ANG","{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="txtnumbs" runat="server" Text='<%# Eval("DATE_TEST_ANG","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
                     </Columns>
                                                        <HeaderStyle CssClass="GridHeaderStyle" />
                                                    <RowStyle ForeColor="#000000" />
                                                        <SelectedRowStyle CssClass="GridSelectedStyle" />
                                                    </asp:GridView>

                                              </td>
 
 
 </tr>
 </table>
 <br />
 <br />
 </center>
 

 <br />
 <br />
 <center>
 <asp:Label ID="lblTOIEC" runat="server" CssClass="style3"></asp:Label>
 <br />
  <asp:Label ID="LblprepTOIEC" runat="server" CssClass="style3"></asp:Label>

 
 <asp:Panel ID="paneltoiec" runat="server">
 <table bgcolor="#999999" style="background-color: #CCCCCC">
 <tr><td height="30px"></td></tr>
 


 <tr>
<td>
<asp:Label ID="lblchek" runat="server" ForeColor="Red" CssClass="style4">
</asp:Label>

</td>
</tr>
<tr>
<td>
<asp:Label ID="lblchekPREP" runat="server" ForeColor="#333333" CssClass="style4"></asp:Label>

</td>
</tr>
 <tr>
 
<td><h1>Si vous êtes interssé par Toic ou prep TOIEC cochez:</h1></td> </tr>
<tr><td></td></tr>
 <tr><td><asp:CheckBox  ID="chkTOIEC" runat="server" Text="Examen TOIEC" AutoPostBack="true"
         oncheckedchanged="chkTOIEC_CheckedChanged"/></td></tr><tr><td></td></tr>
 <tr> <td><asp:CheckBox  ID="chkprepTOIEC" runat="server" Text="PREPARATION TOIEC"  AutoPostBack="true"
         oncheckedchanged="chkprepTOIEC_CheckedChanged"/></td>
 </tr>
 <tr><td></td></tr>
 
 <tr>
 
 <td align="center">
     <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Large"
            Height="41px"  Text="Envoyer" Width="150px" onclick="Button1_Click" /></td>
 </tr>
 </table>
 </asp:Panel>
 
 </center>
    
 <center> 
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Etudiants/Accueil.aspx" Text="Créer un compte" runat="server" ForeColor="#0033CC" > Retour à la page d'Accueil</asp:HyperLink></td></tr>
 

</center>
 

</asp:Content>




