<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/PaimentEnLigne.Master" AutoEventWireup="true"
     CodeBehind="esprit_payment_notification.aspx.cs" Inherits="ESPOnline.Parents.esprit_payment_notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    
    <div >

 
<br/><center> <strong>   <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red"   Text="Retour de paiement En ligne " ></asp:Label> </strong> </center><br>
      </div>

     <div >

    

<br/>
       <center>  <strong>Message de Retour Aprés le paiement  :  </strong> </center> <br/>
         <center><b><asp:Label ID="Label1" runat="server" Text=""  CssClass="alert-info" ></asp:Label></b></center>   
<br />
 </div>

    <div>

        <center>
           


            <table  runat="server" >
                <tr>

                <td>Ip Adress</td><td><asp:TextBox runat="server" ID="Ip" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>Montant</td><td><asp:TextBox runat="server" ID="amount" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>AuthCode</td><td><asp:TextBox runat="server" ID="authCode" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>CardholderName</td><td><asp:TextBox runat="server" ID="cardholderName" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                 
                </tr>

           <tr>
                <td>DepositMontant</td><td><asp:TextBox runat="server" ID="depositAmount" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>Pan</td><td><asp:TextBox runat="server" ID="Pan" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>OrderStatus</td><td><asp:TextBox runat="server" ID="OrderStatus" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>OrderNumber</td><td><asp:TextBox runat="server" ID="OrderNumber" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
           </tr>
            <tr>
                <td>expiration</td><td><asp:TextBox runat="server" ID="expiration" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>ErrorMessage</td><td><asp:TextBox runat="server" ID="ErrorMessage" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>ErrorCode</td><td><asp:TextBox runat="server" ID="ErrorCode" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td>currency</td><td><asp:TextBox runat="server" ID="currency" ReadOnly="true" BackColor="WhiteSmoke"></asp:TextBox></td>
           </tr>
            </table>
            

        </center>

    </div>

    <br /><br />

        <div>

       <center>       <asp:GridView ID="GridView2" runat="server" 
            AutoGenerateColumns="False"
                Height="74px" Width="786px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1"  ShowFooter="True" DataKeyNames="ORDERNUMBER" DataSourceID="SqlDataSource1"  >
                 <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <Columns>
                         <asp:BoundField DataField="ID_ET" HeaderText="Identifiant" 
                        SortExpression="ID_ET" />
                        <%-- <asp:BoundField DataField="Nom" HeaderText="Nom&Prénom" 
                        SortExpression="Nom" />
                         <asp:BoundField DataField="CODE_CL" HeaderText="Classe" 
                        SortExpression="CODE_CL" />--%>
                          <asp:BoundField DataField="AMOUNT" HeaderText="Montant" 
                        SortExpression="AMOUNT" />
                       
                         <asp:BoundField DataField="ORDERNUMBER" HeaderText="Order Number" 
                        SortExpression="ORDERNUMBER" ReadOnly="True" />   
                         
                         <asp:BoundField DataField="DATE_PAIEMENT" HeaderText="Date Paiement" SortExpression="DATE_PAIEMENT" />
                       
                          <asp:BoundField DataField="orderId" HeaderText="Oorder Id" SortExpression="orderId" />
                          
                    </Columns>
              <FooterStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#9999ff" ForeColor="White" Font-Bold="True"/>
                </asp:GridView>

           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
               ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
               SelectCommand="SELECT  t1.ID_ET  , t1.AMOUNT, t1.orderId, t1.ORDERNUMBER,  
               t1.DATE_PAIEMENT FROM  HISTORIQUE_PAIEMENT t1 
                 where  t1.id_et=:id_et ">
               <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
           </asp:SqlDataSource>

           <br />
           <br />
        
           

           </center>

   </div>
  
   <center>

       

   </center>
</asp:Content>