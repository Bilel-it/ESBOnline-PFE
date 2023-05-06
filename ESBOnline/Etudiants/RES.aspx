<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true"
    CodeBehind="RES.aspx.cs" Inherits="ESPOnline.Etudiants.RES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Contents/jquery.notifyBar.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Contents/Scripts/jquery.notifyBar.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #F78181;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .Grid th
        {
            background-color: #FE2E2E;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        .GridViewEditRow input[type=text]
        {
            width: 50px;
        }
        /* size textboxes */
        .GridViewEditRow select
        {
            width: 90px;
        }
    </style>
    <style type="text/css">
         .footer td
        {
            border: none;
        }
   .table     td {
border: none;
}     
  .footer      tr {
border: none;
}
        .footer th
        {
            border: none;
        }
    </style>

  <script type="text/javascript">
      $("[src*=plus]").live("click", function () {
          $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
          $(this).attr("src", "../Contents/Img/minus.png");
      });
      $("[src*=minus]").live("click", function () {
          $(this).attr("src", "../Contents/Img/plus.png");
          $(this).closest("tr").next().remove();
      });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
 <center>
        <br />
            <asp:Label ID="Label18" runat="server" Text="Resultat session Principale 2014/2015" Font-Bold="True" 
                Font-Italic="True" Font-Names="Bookman Old Style" Font-Size="X-Large" 
                Width="634px" ForeColor="#CC0000"></asp:Label>
               
           <br />
           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT moy_general,lib_decision_session_p FROM ESP_INSCRIPTION WHERE (ID_ET =:ID_ET) and annee_deb ='2014'">
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
                     
                    <asp:BoundField DataField="LIB_DECISION_SESSION_P" 
                        HeaderText="Session Principale:" 
                        SortExpression="LIB_DECISION_SESSION_P" />
                    <asp:BoundField DataField="moy_general" HeaderText="Moyenne :" 
                        SortExpression="moy_general" />
                </Fields>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#660066" ForeColor="White" Font-Bold="True"/>
            </asp:DetailsView>
          
        </center>
<br />
<br /> 
    <asp:GridView ID="gvue" runat="server" AutoGenerateColumns="false" CssClass="Grid" ShowFooter="True" 
        DataKeyNames="CODE_UE" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt="" style="cursor: pointer" src="../Contents/Img/plus.png" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvnotes" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid" OnRowDataBound="OnRowDataBound2">
                            <Columns>
                                <asp:BoundField  DataField="COEF" HeaderText="COEF" ReadOnly="True" />
                                <asp:BoundField  DataField="designation" HeaderText="MODULE" ReadOnly="True" >   <ItemStyle Width="400px" HorizontalAlign="Left" /></asp:BoundField>
                                <asp:BoundField  DataField="MOY_MODULE" HeaderText="MOY_MODULE" ReadOnly="True" />

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:BoundField ItemStyle-Width="50%" DataField="LIB_UE" HeaderText="Unite d'Enseignement" ReadOnly="True"  />
                <asp:BoundField ItemStyle-Width="15%" DataField="NB_ECTS" HeaderText="NB_ECTS" ReadOnly="True"  />
                     
                     <asp:TemplateField HeaderText="MOYENNE_UE" SortExpression="MOY_UE">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("MOY_UE") %>' ReadOnly="True"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                     <div style="text-align: center">
                               <table width="100%" >
                    <tr><td>          <asp:Label ID="Label4" runat="server" Text="Total ECTS encaissés :" ReadOnly="True"></asp:Label></tr></td>
                  </table>
                                </div>
                  
                    </FooterTemplate>
                </asp:TemplateField>
                         <asp:TemplateField HeaderText="NB_ECTS_AQUIS" SortExpression="NB_ECTS">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NB_ECTS") %>' ReadOnly="True"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                     <div style="text-align: center">
                               <table width="100%" >
                    <tr><td>          <asp:Label ID="Label2" runat="server"  ReadOnly="True"></asp:Label></tr></td>
                  </table>
                                </div>
                  
                    </FooterTemplate>
                </asp:TemplateField>
        </Columns>
           <FooterStyle BackColor="White" ForeColor="#000066" CssClass="footer" />
    </asp:GridView></center>
</asp:Content>
