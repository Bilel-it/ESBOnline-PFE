<%@ Page Title="" Language="C#" MasterPageFile="~/Etudiants/Eol.Master" AutoEventWireup="true" CodeBehind="InformationsEnArabe.aspx.cs" Inherits="ESPOnline.Etudiants.InformationsEnArabe" %>
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
        .style2
        {
        }
        .style4
        {
            width: 198px;
        }
        .style5
        {
        }
        .style6
        {
            width: 121px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server" Direction="RightToLeft">
    
    <div  class="clearfix">
    <div class="panel panel-default" >
  <%--<div class="panel-heading" >
    <h3 class="panel-title"  align="center" >veuillez remplir les données suivant en 
        utilisant l&#39;arabe</h3>
  </div>--%>
    </div></div>
            </asp:Panel>
             
            
    <table class="nav-justified">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2" align="center" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Veuillez remplir les champs suivant en utilisant l&#39;arabe&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                <table class="nav-justified" dir="rtl">
                    <tr>
                        <td class="style6" >
                            <asp:Label ID="Label4" runat="server" Text="الإسم:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="danger" required=""       Text='<%# DataBinder.Eval( Container, "DataItem.NOM_ARB") %>'  
                                TextMode="MultiLine" Width="221px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox1" 
                                ValidationExpression="^[\u0600-\u06ff ]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label5" runat="server" Text="اللقب:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox2" runat="server" required="" TextMode="MultiLine" Text='<%# DataBinder.Eval( Container, "DataItem.PNOM_ARB") %>'  
                                Width="221px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox2" 
                                ValidationExpression="^[\u0600-\u06ff ]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td class="style1">
                            <asp:Label ID="Label6" runat="server" Text="تاريخ الولادة:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox3" runat="server" required="" TextMode="Date" 
                                Width="181px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ControlToValidate="TextBox3" 
                                  ErrorMessage="Format de date:AAAA-MM-JJ"
ValidationExpression="^[1-2][0-9][0-9][0-9][-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                    
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label7" runat="server" Text="مكان الولادة: "></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox4" runat="server" required="" TextMode="MultiLine"  Text='<%# DataBinder.Eval( Container, "DataItem.LIEU_NAIS_ARB") %>'
                                Width="221px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox4" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                 <%--   <tr>
                        <td class="style1">
                            <asp:Label ID="Label8" runat="server" Text="رقم بطاقة التعريف الوطنية/جواز السفر:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox5" runat="server" required="" TextMode="MultiLine"></asp:TextBox>
                           </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox5" 
                                ValidationExpression="^[0-9]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label9" runat="server" Text=" البكالوريا :" Font-Bold="True" 
                                Font-Italic="False" Font-Underline="True"></asp:Label>
                        </td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label10" runat="server" Text="نوعها:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox6" runat="server" required="" TextMode="MultiLine" Text='<%# DataBinder.Eval( Container, "DataItem.NATURE_BAC_ARB") %>'
                                Width="221px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox6" 
                                ValidationExpression="^[\u0600-\u06ff ]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label11" runat="server" Text="تاريخها:" Visible="false"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox7" runat="server" required="" TextMode="Date" Visible="false"
                                Width="220px"></asp:TextBox>
                            </td>
                        <td>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" 
                                ControlToValidate="TextBox7" 
                                  ErrorMessage="Format de date:AAAA-MM-JJ"
ValidationExpression="^[1-2][0-9][0-9][0-9][-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" colspan="2">
                            <asp:Label ID="Label12" runat="server" Text="السنة الجامعية 2014-2015:" 
                                Font-Underline="True"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label13" runat="server" Text=" المستوى الدراسي:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox8" runat="server" required="" TextMode="MultiLine" Text='<%# DataBinder.Eval( Container, "DataItem.DIPLOME_SUP_ARB") %>'
                                Width="221px"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox8" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label14" runat="server" Text="المؤسسة الأصلية:"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="TextBox9" runat="server" required="" TextMode="MultiLine" Text='<%# DataBinder.Eval( Container, "DataItem.ETAB_ORIGINE_ARB") %>'
                                Width="221px"></asp:TextBox>
                           </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" 
                                ErrorMessage="utiliser les caractères arabes" ControlToValidate="TextBox9" 
                                ValidationExpression="^[\u0600-\u06ff0-9.,;: ()]*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2" align="center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <br />  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                <asp:Button ID="Button1" runat="server" Text="Enregistrer" 
                    CssClass="btn-lg btn-primary" Height="44px" Width="141px" 
                    onclick="Button1_Click1" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString2 %>" 
                    ProviderName="<%$ ConnectionStrings:DefaultConnectionString2.ProviderName %>" 
                    SelectCommand="SELECT NOM_ARB,PNOM_ARB,LIEU_NAIS_ARB,NATURE_BAC_ARB,DIPLOME_SUP_ARB,ETAB_ORIGINE_ARB  FROM  ESP_ETUDIANT WHERE ( ID_ET  = :ID_ET)">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_ET" SessionField="ID_ET" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
             
            
</asp:Content>
