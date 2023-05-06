<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfert_envoiemail.aspx.cs" Inherits="ESPOnline.Direction.admission.transfert_envoiemail"
     MasterPageFile="~/Direction/admission/ad.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </asp:ToolkitScriptManager>
    <h1>
        <b>Transfert des candidat(e)s</b></h1>
    <br />
    Résultat Finale<br />

    <center>
           <asp:RadioButtonList ID="RadioButtonListspe" runat="server"  RepeatDirection="Horizontal"
                  AppendDataBoundItems="true"  ForeColor="Brown" required=""
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged1">

                <asp:ListItem Text="1ére année Master" Value="4"></asp:ListItem>
              

                   <asp:ListItem Text="1ére année Licence" Value="1"></asp:ListItem>

               <asp:ListItem Text="2éme année Licence" Value="2"></asp:ListItem>

               <asp:ListItem Text="3éme année Licence" Value="3"></asp:ListItem>

                
                 
            </asp:RadioButtonList>
           <br />
         <asp:Label runat="server" ID="Label2" Text="Date Debut Entretien" ForeColor="Blue" Font-Bold="true"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" required="required" TextMode="Date" ></asp:TextBox>
        <asp:Label runat="server" ID="Label3" Text="Date Fin Entretien" ForeColor="Blue" Font-Bold="true"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" required="required" TextMode="Date" ></asp:TextBox>
           <br />
         <asp:Label runat="server" ID="Label4" Text="Score Min Entretien" ForeColor="Blue" Font-Bold="true"></asp:Label>
        <asp:TextBox ID="TextBox14" runat="server" required="required" ></asp:TextBox>
           &nbsp;
        <asp:Button ID="Button2" runat="server" Text="Valider"  OnClick="RadButton2_Click" />
    </center>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="TextBox14" runat="server"
    ErrorMessage="Only Numbers allowed"
    ValidationExpression="\d+">
       </asp:RegularExpressionValidator>
    <center>
     
        <br />
        <asp:TextBox ID="TextBox1" runat="server" required="required" TextMode="Date" OnTextChanged="TextBox1_TextChanged"  Visible="false"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Transfert" OnClick="RadButton1_Click" Visible="false"/>
        <asp:Button ID="Cancel1" runat="server" Text="Cancel" OnClick="chk_CheckedChanged" Visible="false" />
    </center>
    <br />
    <%--Veuillez Chercher:--%>
   <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
        AppendDataBoundItems="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
        <asp:ListItem Text="Cours du soir" Value="S"></asp:ListItem>

        
        <asp:ListItem Text="Autres" Value=""></asp:ListItem>

        <asp:ListItem Text="Liste 4émme année" Value="4"></asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
        AppendDataBoundItems="true" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged1">
        <asp:ListItem Text="Prepa" Value="P"></asp:ListItem>
        <asp:ListItem Text="Autres" Value=""></asp:ListItem>
    </asp:RadioButtonList>--%>
    <br />
    <asp:UpdatePanel ID="plGRID" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <asp:Label runat="server" ID="lbladmis" ForeColor="Blue" Font-Bold="true"></asp:Label>
            <br />
            <asp:Label runat="server" ID="Label1" ForeColor="Blue" Font-Bold="true"></asp:Label>
            <br />
            <div id="scrollDivs" style="width: 80%; height: 500px; overflow: scroll; align: left;
                background-color: #EFEFEF">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBoundS"
                    DataKeyNames="ID_ET" OnDataBound="OnDataBound" OnRowCreated="OnRowCreated" Style="border-bottom: white 2px ridge;
                    border-left: white 2px ridge; background-color: white; border-top: white 2px ridge;
                    border-right: white 2px ridge;" BorderWidth="0px" BorderColor="White" CellSpacing="1"
                    CellPadding="3" CssClass="grid" GridLines="Both" RowStyle-CssClass="ItemStyle"
                    HeaderStyle-CssClass="FixedHeaderStyle" EmptyDataRowStyle-CssClass="ItemStyle">
                    <EmptyDataTemplate>
                        Pas d'enregistrement.
                    </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="#CC0000"
                        ForeColor="White" />
                    <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                    <FooterStyle CssClass="ItemStyle" />
                    <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                    <RowStyle CssClass="GridItemStyle" />
                    <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="chckchanged" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID_ET" HeaderText="ID Etudiant" SortExpression="ID_ET"
                            ItemStyle-Width="25px" />
                        <asp:TemplateField HeaderText="NUM CIN">
                            <ItemTemplate>
                                <asp:Label ID="lblnumcin" runat="server" Text='<%# Eval("NUM_CIN_PASSEPORT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOM">
                            <ItemTemplate>
                                <asp:Label ID="lblnom" runat="server" Text='<%# Eval("NOM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NATURE DU BAC">
                            <ItemTemplate>
                                <asp:Label ID="lblbacnat" runat="server" Font-Bold="true" Text='<%# Eval("NATURE_BAC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MOY_BAC_ET">
                            <ItemTemplate>
                                <asp:Label ID="lblbac" runat="server" Text='<%# Eval("MOY_BAC_ET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SPECIALITE ESP ET">
                            <ItemTemplate>
                                <asp:Label ID="lblspe" runat="server" Text='<%# Eval("SPECIALITE_ESP_ET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DIPLOME SUP">
                            <ItemTemplate>
                                <asp:Label ID="lbldip" runat="server" Text='<%# Eval("DIPLOME_SUP_ET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E MAIL ET">
                            <ItemTemplate>
                                <asp:Label ID="lblmail" runat="server" Text='<%# Eval("E_MAIL_ET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NIVEAU ACCES">
                            <ItemTemplate>
                                <asp:Label ID="lblniv" runat="server" Text='<%# Eval("NIVEAU_ACCES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE FINAL">
                            <ItemTemplate>
                                <asp:Label ID="lblsfin" runat="server" Font-Bold="true" ForeColor="Green" Text='<%# Eval("score_final") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE_ENTRETIEN">
                            <ItemTemplate>
                                <asp:Label ID="lblse" runat="server" Text='<%# Eval("SCORE_ENTRETIEN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE_francais">
                            <ItemTemplate>
                                <asp:Label ID="lblsfr" runat="server" Text='<%# Eval("SCORE_francais") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE_ANGLAIS">
                            <ItemTemplate>
                                <asp:Label ID="lblsang" runat="server" Text='<%# Eval("SCORE_ANGLAIS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE_QI">
                            <ItemTemplate>
                                <asp:Label ID="lblsq" runat="server" Text='<%# Eval("SCORE_QI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SCORE_dossier">
                            <ItemTemplate>
                                <asp:Label ID="lblsd" runat="server" Text='<%# Eval("SCORE_dossier") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <RowStyle ForeColor="#000000" />
                    <SelectedRowStyle CssClass="GridSelectedStyle" />
                    <%-- <AlternatingRowStyle BackColor="#b0e5e5" />--%>
                </asp:GridView>
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type="text/javascript" src="../Contents/quicksearch.js"></script>
                <script type="text/javascript">
                    $(function () {
                        $('.search_textbox').each(function (i) {
                            $(this).quicksearch("[id*=GridView1] tr:not(:has(th))",

                {
                    'testQuery': function (query, txt, row) {


                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
                        });
                    });
                </script>
            </div>
            <input type="hidden" id="div_position" name="div_position" />
            <br />
            <br />
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content> 
     