<%@ Page Title="" Language="C#"  AutoEventWireup="true" 
CodeBehind="Envoi_mail.aspx.cs" Inherits="ESPOnline.Direction.admission.Envoi_mail"  MasterPageFile="~/Direction/admission/ad.Master" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
 
     
              <center><asp:Label ID="Label2" runat="server" Text="Nombre de candidats inscrits à ce jour :">   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></asp:Label></center>
     
    <br />
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource1" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource1"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%T%' and CODE_DECISION='01'
and SPECIALITE_ESP_ET in ('18','20','23','30') and (NIVEAU_ACCES='1'or NIVEAU_ACCES='3' or NIVEAU_ACCES='4') and ENVOI_MAIL is null ">
   </asp:sqldatasource>

    <asp:Button ID="Button1" runat="server" Text="envoyer licence niv1" OnClick="Button1_Click" />



    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource2" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource2"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%T%' and CODE_DECISION='01' 
and SPECIALITE_ESP_ET in ('18','20','23','30') and NIVEAU_ACCES='2' and ENVOI_MAIL is null">
   </asp:sqldatasource>

    <asp:Button ID="Button2" runat="server" Text="envoyer licence niv 2" OnClick="Button2_Click" />


    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource3" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource3"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%T%' and CODE_DECISION='01' 
and SPECIALITE_ESP_ET in ('08','09','11','12','28','24','25','26','29') and NIVEAU_ACCES='4' and ENVOI_MAIL is null">
   </asp:sqldatasource>

    <asp:Button ID="Button3" runat="server" Text="envoyer master niv 4" OnClick="Button3_Click" />





    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource4" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource4"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%T%' and CODE_DECISION='01' 
and SPECIALITE_ESP_ET = '27' and NIVEAU_ACCES='4' and ENVOI_MAIL is null">
   </asp:sqldatasource>

    <asp:Button ID="Button4" runat="server" Text="envoyer vermeg" OnClick="Button4_Click" />




    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource5" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource5"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%E%' and CODE_DECISION='01' and ENVOI_MAIL is null">
   </asp:sqldatasource>

    <asp:Button ID="Button5" runat="server" Text="envoyer internationaux" OnClick="Button5_Click" />


    <%--refus--%>
    
    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sqldatasource6" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Bold="True" 
        Font-Italic="True" ShowFooter="True">
    <Columns>
        <asp:BoundField DataField="ID_ET" HeaderText="ID_ET" SortExpression="ID_ET" />
        <asp:BoundField DataField="NOM_ET" HeaderText="NOM_ET" SortExpression="NOM_ET" />
        <asp:BoundField DataField="PNOM_ET" HeaderText="PNOM_ET" SortExpression="PNOM_ET" />
        <asp:BoundField DataField="E_MAIL_ET" HeaderText="E_MAIL_ET" 
            SortExpression="E_MAIL_ET" />
       
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" BorderStyle="Dashed" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
         
    <asp:sqldatasource runat="server"  id="Sqldatasource6"
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" 
        
   SelectCommand="select ID_ET,NOM_ET,PNOM_ET,E_MAIL_ET from esp_etudiant  where ID_ET like'22%' and CODE_DECISION='03' and ENVOI_MAIL is null">
   </asp:sqldatasource>

    <asp:Button ID="Button6" runat="server" Text="Refus" OnClick="Button6_Click" />

</asp:Content>
