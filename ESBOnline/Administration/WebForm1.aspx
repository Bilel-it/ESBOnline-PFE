<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication9.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">
        function imprimer() { window.print(); }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Telecherger_PDF" />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
            DataSourceID="SqlDataSource1" DataTextField="code_cl" DataValueField="code_cl">
        </asp:DropDownList>
        <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                    SortExpression="id" />
                     <asp:BoundField DataField="nom" HeaderText="nom" ReadOnly="True" 
                    SortExpression="nom" />
                    <asp:TemplateField>  
    
   <ItemTemplate>  
   <img src='data:Image_Detail/jpg;base64,   <%# Eval("RECU") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("RECU")) : string.Empty %>' alt="image" height="180px" width="150px"/>  

      
   </ItemTemplate>  
</asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString1.ProviderName %>" 
            SelectCommand="select distinct code_cl from scoesb02.esp_inscription where annee_deb='2017'  order by FN_TRI_CLASSE(code_cl)    ">
                </asp:SqlDataSource>
 <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString1.ProviderName %>" 
            SelectCommand="SELECT e2.id_et as id ,e2.NOM_ET||''||e2.PNOM_ET as nom,e1.photo_etudiant as recu FROM SCO_admis1415.ESP_RECU e1 ,esp_etudiant e2,scoesb02.esp_inscription e3 
where  (e1.id_et=e2.id_et and e2.id_et=e3.id_et and e1.id_et=e3.id_et) and e3.code_cl=:code_cl and e3.annee_deb=2017 and e2.id_et like '15%'  ">
               
                  <SelectParameters>
               
               <asp:ControlParameter ControlID="DropDownList1"  Name="code_cl" PropertyName="SelectedValue" DefaultValue="1A1"
                  /></SelectParameters>
               
                </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
