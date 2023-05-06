<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUpAjoutEmploi.aspx.cs" Inherits="ESPOnline.EmploiEsp.PopUpAjoutEmploi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            background-color: #800000;
            color: #CCCCCC;
        }
        .style3
        {
            color: #CCCCCC;
        }
        .style4
        {
            color: #FF0000;
        }
        .style5
        {
            color: #800000;
        }
        .style6
        {
            background-color: #FFF0F0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table align="center" 
            style="height: 300px; width: 450px; background-color: #333333">
          <h2 align="center" style="color: #800000" >Affecter Les Enseignants</h2> 

           <tr>
            <td class="style4">
                <asp:Label ID="Label4" Text="Code:" runat="server" CssClass="style3"> </asp:Label>
                * 
            </td>
            <td>
               <asp:TextBox runat="server" ID="txtcode" >
                    </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style4">
                <asp:Label ID="lblMatiere" Text="Matiere:" runat="server" CssClass="style3"> </asp:Label>
                * 
            </td>
            <td>
               <asp:DropDownList runat="server" ID="ddlmodule" 
                   AutoPostBack="true" AppendDataBoundItems="true"  
                    onselectedindexchanged="ddlmodule_SelectedIndexChanged">
                    <asp:listitem>--Veuillez choisir la matiere-</asp:listitem>
                    </asp:DropDownList>
            </td>
        </tr>



        <tr>
            <td class="style4">
                <asp:Label ID="lblType" runat="server" Text="Type" 
                    CssClass="style3"></asp:Label>
                *</td>
            <td><asp:DropDownList ID="ddlType" runat="server" Height="30px" Width="170px" CssClass="style1" >
            <asp:ListItem>Cours</asp:ListItem>
               <asp:ListItem>TD</asp:ListItem>
                  <asp:ListItem>TP</asp:ListItem>
                  <asp:ListItem>Formation</asp:ListItem>

                </asp:DropDownList></td></tr>
                <tr>
            <td class="style4">
                <asp:Label ID="lblEns" runat="server" Text="Enseignant" 
                    CssClass="style3"></asp:Label>
                *</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlnomenseig" 
                    AutoPostBack="true"
                    >
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" Text="Date Séance" runat="server" CssClass="style3" 
                    ></asp:Label>
                     <span
                    class="style4">*</span>
            </td>
            
            
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <br class="style1" />
                <asp:TextBox ID="txtdebutDate" runat="server" Height="30px" Width="170px" placeholder="Date de debut"
                    CssClass="style1"></asp:TextBox>

                <asp:PopupControlExtender ID="txtdebutDate_PopupControlExtender1" runat="server"
                    Enabled="true" TargetControlID="txtdebutDate" DynamicServicePath="" PopupControlID="Panel1"
                    Position="Bottom">
                </asp:PopupControlExtender>
                <br class="style1" />
                <asp:Panel ID="Panel1" runat="server" Width="200px" CssClass="style1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"
                                BorderWidth="1px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged"
                                
                                >
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" BorderColor="Black" BorderWidth="4px"
                                    Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <br />
                <br />
            </td>
        
        </tr>
      <tr><td class="style5">
       <asp:Label ID="lblClasse" Text="Promotion" runat="server" CssClass="style3" ></asp:Label>
                 <span class="style4">*</span></td>
                 <td>
                  <asp:DropDownList runat="server" ID="ddlcodclasse" 
                          AutoPostBack="true"
                         onselectedindexchanged="ddlcodclasse_SelectedIndexChanged" AppendDataBoundItems="True">
                      <asp:ListItem>--Veuillez choisir la promotion-- </asp:ListItem>
                    </asp:DropDownList>
                 </td>
                 </tr>
           
           
           
            
            
        
        <tr>
            <td class="style4">
                <asp:Label ID="lblSalle" runat="server" Text="Salle" 
                    CssClass="style3"></asp:Label>
                     *</td>
            <td>
                <asp:DropDownList ID="ddlSalle" runat="server" Height="30px" Width="170px" CssClass="style1" 
                   AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="style4">
                <asp:Label ID="Label1" runat="server" Text="Heure Entree" 
                    CssClass="style3"></asp:Label>
                     *</td>
            
            <td>
              <asp:TextBox ID="txthd" runat="server" CssClass="style6" >
              
              </asp:TextBox> 
            </td>
        </tr>

        <tr>
            <td class="style4">
                <asp:Label ID="Label7" runat="server" Text="Minute Entree" 
                    CssClass="style3"></asp:Label>
                     *</td>
            
            <td>
              <asp:TextBox ID="TextminE" runat="server" >
              
              </asp:TextBox> 
            </td>
        </tr>
         <tr>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Text="Heure Sortie" 
                    CssClass="style3"></asp:Label>
                     <span
                    class="style4">*</span></td>
            
            <td>
               <asp:TextBox ID="txthf" runat="server" CssClass="style6" >
               
               </asp:TextBox> 
            </td>
        </tr>

        
        <tr>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Minute Sortie" 
                    CssClass="style3"></asp:Label>
                     *</td>
            
            <td>
              <asp:TextBox ID="TextminS" runat="server" >
              
              </asp:TextBox> 
            </td>
        </tr>
        <tr align="center"><td align="center">
        <asp:Button  runat="server"  ID="btnadd" Text="Ajouter" BackColor="Maroon" 
                ForeColor="#CCCCCC" Height="30px" Width="150px" onclick="btnadd_Click"/></td>
     <td>    <asp:Button  runat="server"  ID="Button1" Text="Reintialiser" BackColor="Maroon" onclick="btnRemove_Click"
                ForeColor="#CCCCCC" Height="30px" Width="150px"/></td>
       </tr>
       
    </table>
    </div>
    </form>
</body>
</html>
