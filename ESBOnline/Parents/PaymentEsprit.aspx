<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentEsprit.aspx.cs" Inherits="ESPOnline.Parents.PaymentEsprit" MasterPageFile="~/Parents/PaimentEnLigne.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
      


            <div>

    

<center>

    <table>

       <tr align="center">
        <td colspan="2">

            
        
        <img src="../Contents/Img/logoPaimentNewx.png" style="width: 533px; height: 77px;"  alt="140x140">


        </td>

        <td>


        </td>
    </tr>
    </table>
  

<table  align="center"  class="form-group " frame="border" style="border-style: double; border-width: inherit; border-color: #FF0000; background-color: #CCCCCC; font-family: 'Times New Roman', Times, serif; font-size: x-large;"  >
    <tr >
        <td >

            
        <br />
       


        </td>

        <td>

<br />
        </td>
    </tr>
    <br />
     <tr >
    
    <td width="48%"><%--Order Number :--%></td>
<td width="52%">
    <asp:TextBox ID="orderNumbers" runat="server" type="text" value="" ReadOnly="true" class="form-group "  Visible="false"></asp:TextBox>

    </tr>

     <tr>
        <td width="48%"><%--User Name :--%></td>
<td width="52%">
    <asp:TextBox ID="userNames" runat="server" type="text" value="sb-api"  Text="sb-api" ReadOnly="true" class="form-group "  Visible="false" ></asp:TextBox>
    <tr>
        <td width="48%"><%--Password :--%></td>
<td width="52%">
    <asp:TextBox ID="passwords" runat="server" type="Password" value="u3PL43xjT"  Text="u3PL43xjT" ReadOnly="true" class="form-group "  Visible="false" ></asp:TextBox>

</td>

 </tr>

   <%-- //formulaire--%>

<%--//identifiant--%>
    <tr>
     <td width="48%">Identifiant :</td>
<td width="52%">
    <asp:TextBox ID="identifiant" runat="server" ReadOnly="true" CssClass="form-group"  ></asp:TextBox>
</td>

 </tr>

  <%--  //nom--%>

     <tr>
     <td width="48%">Nom  :</td>
<td width="52%">
    <asp:TextBox ID="nomet" runat="server" ReadOnly="true" CssClass="form-group"></asp:TextBox>
</td>

 </tr>

   <%-- //Prénom--%>
      <tr>
     <td width="48%">Prénom :</td>
<td width="52%">
    <asp:TextBox ID="prenomet" runat="server" ReadOnly="true" CssClass="form-group"></asp:TextBox>
</td>

 </tr>

<%--    //classe--%>

     <tr>
     <td width="48%">Classe :</td>
<td width="52%">
    <asp:TextBox ID="classe" runat="server" ReadOnly="true" CssClass="form-group"></asp:TextBox>
</td>

 </tr>

  <%--  //NumCin Passport--%>

     <tr>
     <td width="48%">Num Cin/Passport :</td>
<td width="52%">
    <asp:TextBox ID="numcinpassport" runat="server" ReadOnly="true" CssClass="form-group"></asp:TextBox>
</td>

 </tr>
<%--// Télèphone--%>

     <tr>
     <td width="48%">Num Téléphone :</td>
<td width="52%">
    <asp:TextBox ID="telephone" runat="server" ReadOnly="true" CssClass="form-group" ></asp:TextBox>
</td>

 </tr>








<tr>
    
     <td>Montant / Amount * <br />
 en Dinars Tunisiens /<br /> in Tunisian Dinars </td><td>
   
    <asp:DropDownList ID="DdrAmount" runat="server" Height="30px" Width="180px" class="form-group " Visible="false"
        OnSelectedIndexChanged="amount_SelectedIndexChanged">
         <asp:ListItem Value="0"> Choisir  Montant </asp:ListItem>
        <asp:ListItem Value="100000"> 100 DT </asp:ListItem>
      
    </asp:DropDownList>


    <br />
    <asp:TextBox ID="mntdt" runat="server" MaxLength="10"  class="form-group "  dir="rtl"  Width="90px" ></asp:TextBox>  DT, <asp:TextBox ID="mntmillime" runat="server"  class="form-group "  MaxLength="3" value="000"  Width="60px"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="mntdt"
    ValidationGroup="paymentGroupesprit" ErrorMessage="Vous pouvez saisir un montant" CssClass="text-danger" Enabled="false"></asp:RequiredFieldValidator>
                                   
     
    <br />
    <asp:Label ID="Label1" runat="server" Text="(ex : 200,500 مثال )"></asp:Label>

     <br />

                                                     </td>

</tr>
     <br />
     <br />
     
   
     <tr>
     <td bgcolor="#CCCCCC" dir="ltr" style="font-size: medium; font-weight: bold; font-style: normal;" >

         
         <br />
         Remarque :<br />
<asp:Label ID="Label4" runat="server" Text="1 € Euro ~ 3,27 Dinars Tunisiens / Tunisian Dinars"></asp:Label> <br />
         <asp:Label ID="Label5" runat="server" Text="1 $ USD ~ 2,83 Dinars Tunisiens / Tunisian Dinars"></asp:Label>

     </td>
          <td >




          </td>
 



</tr>
    
    <tr>
     <td  bgcolor="#CCCCCC" dir="ltr" style="font-size: medium; font-weight: bold; font-style: normal;">

        <asp:Label ID="Label2" runat="server" Text="Pour consulter le taux de change du jour Veuillez suivre le lien suivant :"></asp:Label> 


      

     </td>
          <td style="font-size: medium" ><a href="https://www.bct.gov.tn/bct/siteprod/index.jsp">https://www.bct.gov.tn/bct/siteprod/index.jsp</a>




          </td>

 </tr>
</td>

    </tr>
    
     <tr>
<td height="52" colspan="2">
    <asp:Label ID="returnUrls" runat="server" visible="false" Text="https://esprit-tn.com/esbonline/Parents/esprit_payment_notification.aspx"  ></asp:Label> 
    <asp:Label ID="languages" runat="server" visible="false" Text="en"  ></asp:Label> 
    <asp:Label ID="pageViews" runat="server" visible="false" Text=""  ></asp:Label> 
    <asp:Label ID="currencys" runat="server" visible="false" Text="788"  ></asp:Label> 
    <asp:Label ID="expirationDates" runat="server" Text="" ></asp:Label> 
    
    
    <br />
    <asp:Button ID="submit" runat="server" name="Submit" Text="Passer au paiement" 
         OnClick="submit_Click" ValidationGroup="paymentGroupesprit" class="btn btn-plain btn-primary btn-small xs-margin-top xs-margin-bottom"/>
    
    
   
</td>
</tr>


</table>
</center>
</div>









          

 
   <div>

       <center>       <asp:GridView ID="GridView2" runat="server" Visible="false" 
            AutoGenerateColumns="False"
                Height="74px" Width="623px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1"  ShowFooter="True"  >
                 <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <Columns>
                         <asp:BoundField DataField="amount" HeaderText="amount" 
                        SortExpression="amount" />
                          <asp:BoundField DataField="currency" HeaderText="currency" 
                        SortExpression="currency" />
                          <asp:BoundField DataField="language" HeaderText="language" 
                        SortExpression="language" />
                        <asp:BoundField DataField="orderNumber" HeaderText="orderNumber" 
                        SortExpression="orderNumber" />
                         <asp:BoundField DataField="returnUrl" HeaderText="returnUrl" 
                        SortExpression="returnUrl" />   
                         <asp:BoundField DataField="expirationDate" HeaderText="expirationDate" 
                        SortExpression="expirationDate" />
                    </Columns>
              <FooterStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#9999ff" ForeColor="White" Font-Bold="True"/>
                </asp:GridView>

           </center>

   </div>
</asp:Content>