<%@ Page Title="" Language="C#" MasterPageFile="~/Parents/Par.Master" AutoEventWireup="true" CodeBehind="ResultatRattrapage.aspx.cs" Inherits="ESPOnline.Parents.ResultatRattrapage" %>
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
     <style type="text/css">
         .footer td
        {
            border: none;
        }
   .table     td {
border-bottom: 1pt solid black;
}     
  .footer      tr {
border-bottom: 1pt solid black;
}
        .footer th
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="col-xs-1">
    </div>
    <div class="col-xs-10">
        <center>
        <br />
            <asp:Label ID="Label18" runat="server" Text="Resultat session rattrapage" Font-Bold="True" 
                Font-Italic="True" Font-Names="Bookman Old Style" Font-Size="X-Large" 
                Width="634px" ForeColor="#CC0000"></asp:Label>
               
           <%-- <h1>
                Resultat Session Rattrapage
            </h1>--%>
        </center>
        <center>
                    <%-- <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource1" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                    <asp:BoundField DataField="LIB_DECISION_SESSION_P" 
                        HeaderText="Session principale:" SortExpression="LIB_DECISION_SESSION_P" />
                   
                    <asp:BoundField DataField="MOY_GENERAL" HeaderText="Moyenne principale:" 
                        SortExpression="MOY_GENERAL" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"  />
                <RowStyle BackColor="#000066" ForeColor="White" Font-Bold="True" />
            </asp:DetailsView>--%>
                
                      <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_GENERAL, LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2015'">
                                       <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                                        </asp:SqlDataSource>--%>
                                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT MOY_RATT,LIB_DECISION_SESSION_Rat,NB_ECTS_SR FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2015'">
                                       <SelectParameters>
            <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
        </SelectParameters>
                                        </asp:SqlDataSource>
              
                      <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource2" Height="50px" Width="536px" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
                <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <Fields>
                     
                    <asp:BoundField DataField="LIB_DECISION_SESSION_Rat" 
                        HeaderText="Session de rattrapage:" 
                        SortExpression="LIB_DECISION_SESSION_Rat" />
                    <asp:BoundField DataField="MOY_RATT" HeaderText="Moyenne rattapage:" 
                        SortExpression="MOY_RATT" />
                         <asp:BoundField DataField="NB_ECTS_SR" HeaderText="NB_ECTS_AQUIS:" 
                        SortExpression="NB_ECTS_SR" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#660066" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>
           </center>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>

      <%--  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        &nbsp;
        <asp:Label ID="Label9" runat="server"  Visible="false" Text=""></asp:Label>
         <asp:Label ID="Label3" runat="server"  Visible="false" Text=""></asp:Label>
        &nbsp;<asp:Label ID="Label16" runat="server" Visible="false" Text="Label"></asp:Label>
&nbsp;<center>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" runat="server" OnDataBound="OnDataBound" OnRowDataBound="GridView1_test" OnRowCreated="grdView2_RowCreated"  Width="100%"
                    DataSourceID="ObjectDataSource1" ShowFooter="false" AutoGenerateColumns="False">
                    <Columns>
                        <%-- <asp:BoundField DataField="CODE_UE" HeaderText="CODE_UE" 
                                 SortExpression="CODE_UE" />--%>
                        <asp:BoundField DataField="LIB_UE" HeaderText="Unite d'Enseignement" ItemStyle-Width="150" SortExpression="LIB_UE">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="NB_ECTS" SortExpression="NB_ECTS">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="MOY_UE" HeaderText="MOY_UE" ItemStyle-Width="150" SortExpression="MOY_UE">
                            <ItemStyle Width="150px" />

                        </asp:BoundField>--%>
                                                  <asp:TemplateField HeaderText="MOYENNE UE PRINCIPALE" SortExpression="MOY_UE">
                                           <ItemStyle Width="7000px" />           
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("MOY_UE") %>'></asp:Label>
                            
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center;">
                                    <table  width="100%" >
                    <tr><td ><asp:Label ID="Label15" runat="server" Text="Total ECTS encaissés:" /></td><%--<td >       <asp:Label ID="Label2" runat="server" /></td>--%></tr>
                    
                        <%--    <tr><td>     <asp:Label ID="Label1" runat="server" Text="Moyenne Principale:"></asp:Label></td><td>  <asp:Label ID="Label3" runat="server"  ></asp:Label></td></tr>
                                 <tr><td>   <asp:Label ID="DECISION" runat="server" Text="Decision Principale:"></asp:Label></td><td>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>  </td></tr>--%></table>
                                </div>
                            </FooterTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="NB_ECTS Aquis UE PRINCIPALE" SortExpression="NB_ECTS" Visible="false">
                               <%-- <ItemStyle Width="3500px" />     --%>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center">
                               <table width="100%"  >
                    <tr  ><%--<td > <asp:Label ID="Label15" runat="server" Text="Total ECTS encaissés:" /></td>--%><td >       <asp:Label ID="Label2" runat="server" /></td></tr>
                    <%-- <tr  ><td>  <asp:Label ID="Label3" runat="server"  ></asp:Label></td></tr>--%>
                           <%--  <tr ><td>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>  </td></tr> --%></table>
                                </div>
                            </FooterTemplate>
                            </asp:TemplateField>
                             
                            <%-- <asp:BoundField DataField="MOY_UE_RATT" HeaderText="UE RATT" ItemStyle-Width="150" SortExpression="MOY_UE_RATT">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>--%>
                         <asp:TemplateField HeaderText="MOYENNE UE RATTRAPPAGE" SortExpression="MOY_UE_RATT">
                                  <ItemStyle Width="7000px" />   
                            <ItemTemplate>
                               <%-- <asp:Label ID="Label6" runat="server" Text='<%# Bind("MOY_UE_RATT") %>'></asp:Label>--%>
                                  <asp:Label ID="Label6" runat="server" Text='<%# Eval("MOY_UE_RATT") %>'></asp:Label>
                            </ItemTemplate>
 <FooterTemplate>
                                <div style="text-align: center;">
                                    <table width="100%" >
                                         
                                        
                    <tr><td ><asp:Label ID="Label7" runat="server" Text="Total ECTS encaissés:" /></td><%--<td>       <asp:Label ID="Label12" runat="server" /></td>--%></tr>
                    
                           <%-- <tr><td>     <asp:Label ID="Label10" runat="server" Text="Moyenne Rattrapage:"></asp:Label></td><td>       <asp:Label ID="Label13" runat="server"  /></td></tr>
                                 <tr><td>   <asp:Label ID="DECISIONR" runat="server" Text="Decision Rattrapage:"/> </td>  <td>   <asp:Label ID="Label17" runat="server" /></td></tr>--%></table>
                                </div>
                            </FooterTemplate>
 </asp:TemplateField><%--
                         <asp:BoundField DataField="NB_ECTS_R" HeaderText="NB_ECTS_R" ItemStyle-Width="150"
                            SortExpression="NB_ECTS_R">
                            
                        </asp:BoundField>--%>
                         <asp:TemplateField HeaderText="NB_ECTS Aquis UE RATTRAPAGE" SortExpression="NB_ECTS_R" Visible="false">
                          
                            <ItemTemplate>
                                 
  <asp:Label ID="Label11" runat="server" Text='<%# Bind("NB_ECTS") %>'></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <div style="text-align: center">
                               <table width="100%" >
                                    
                    <tr><%--<td ><asp:Label ID="Label7" runat="server" Text="Total ECTS encaissés:" /></td>--%><td>        <asp:Label ID="Label12" runat="server" /></td></tr>
                    <%-- <tr><td>       <asp:Label ID="Label13" runat="server"  /></td></tr>--%>
             <%--         <tr><td>       <asp:Label ID="Label17" runat="server" /></td></tr>--%>
                     </table>
                                </div>
                            </FooterTemplate>
 </asp:TemplateField>
      
                        <asp:BoundField DataField="DESIGNATION" HeaderText="MODULES" ItemStyle-Width="150"
                            SortExpression="DESIGNATION">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="NB_ECTS" HeaderText="NB_ECTS" ItemStyle-Width="150" SortExpression="NB_ECTS" />--%>
                        <asp:BoundField DataField="COEF" HeaderText="COEF" SortExpression="COEF" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="MOY_MODULE" HeaderText="MOYENNE MODULE PRINCIPALE"  
                            SortExpression="MOY_MODULE">
                             
                        </asp:BoundField>
                         <asp:BoundField DataField="MOY_MODULERATT" HeaderText="MOYENNE MODULE RATTRAPPAGE"  
                            SortExpression="MOY_MODULERATT">
                             
                        </asp:BoundField>
                        
                  
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
                    <HeaderStyle BackColor="#A80000 " Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E0E0E0 " ForeColor="#000000" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetResFinal"
                    TypeName="ESPOnline.Etudiants.Rattra">
                    <SelectParameters>
                        <asp:SessionParameter Name="_Id_et" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </center>
</asp:Content>