<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication9.WebForm2" %>

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
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="" DataKeyNames="id">
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
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select distinct code_cl from scoesb02.esp_inscription where annee_deb=(select max (annee_deb)  from societe)    ">
                </asp:SqlDataSource>
 <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT e2.id_et as id ,e2.NOM_ET||''||e2.PNOM_ET as nom,e1.photo_etudiant as recu FROM SCO_ADMIS1415.ESP_RECU e1 ,esp_etudiant e2,scoesb02.esp_inscription e3 
where  (e1.id_et=e2.id_et and e2.id_et=e3.id_et and e1.id_et=e3.id_et) and e3.code_cl=:code_cl and e3.annee_deb=2018 and e1.id_et like '15%'   ">
                 <SelectParameters>
                                <asp:SessionParameter Name="code_cl" SessionField="ID_ET" Type="String" />
                            </SelectParameters>
                 <%-- <SelectParameters>
                 ID_ET = Session["ID_ET"].ToString();
               <asp:ControlParameter ControlID="DropDownList1"  
                    PropertyName="" DefaultValue="code_cl" /></SelectParameters>--%>
               
                </asp:SqlDataSource>
    </div>
    </form>
</body>

</html>
