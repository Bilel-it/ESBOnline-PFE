<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="AValid_Cahier_classe.aspx.cs" 
    Inherits="ESPOnline.Vacataire.AValid_Cahier_classe"   
    
     MasterPageFile="~/Vacataire/Vaca.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       <style type="text/css">
        .MessageBoxPopupBackground
        {
            filter: Alpha(Opacity=40);
            -moz-opacity: 0.4;
            opacity: 0.4;
            width: 100%;
            height: 100%;
            background-color: #999999;
            position: absolute;
            z-index: 500001;
            top: 0px;
            left: 0px;
        }
        .popupHeader
        {
            float: left;
            padding: 5px 0px 0px 0px;
            width: 520px;
            font-family: tahoma;
            font-weight: bold;
            height: 25px;
            text-decoration: none;
            background-image: url("../Contentcls/Images/bg1.png");
           
            color: #FFFFFF;
        }
        .popupHeader span
        {
            color: #fff;
            text-decoration: none;
            line-height: 15px;
            text-decoration: none;
            float: left;
            margin-left: 10px;
        }
        .popupHeader a
        {
            color: #fff !important;
            text-decoration: none !important;
            line-height: 15px;
            text-decoration: none;
            float: right;
            margin-right: 10px;
        }
        .popup_button
        {
            color: #fff !important;
            font-family: arial, Geneva, sans-serif;
            font-size: 12px;
            font-weight: normal;
            text-decoration: none !important;
            width: auto;
            background-image: url('../Contentcls/Images/ok.png');
            background-repeat: repeat-x; /*height: 24px;*/
            line-height: 22px;
            padding: 3px 15px 3px 15px;
            float: left;
            margin: 0px 0px 0px 5px;
        }
    </style>
    <style type="text/css">
        .MessageBoxPopupBackground
        {
            filter: Alpha(Opacity=40);
            -moz-opacity: 0.4;
            opacity: 0.4;
            width: 100%;
            height: 100%;
            background-color: #999999;
            position: absolute;
            z-index: 500001;
            top: 0px;
            left: 0px;
        }
        .popupHeader
        {
            float: left;
            padding: 5px 0px 0px 0px;
            width: 520px;
            font-family: tahoma;
            font-weight: bold;
            height: 25px;
            text-decoration: none;
            background-image: url("../Contentcls/Images/bg1.png");
           
            color: #FFFFFF;
        }
        .popupHeader span
        {
            color: #fff;
            text-decoration: none;
            line-height: 15px;
            text-decoration: none;
            float: left;
            margin-left: 10px;
        }
        .popupHeader a
        {
            color: #fff !important;
            text-decoration: none !important;
            line-height: 15px;
            text-decoration: none;
            float: right;
            margin-right: 10px;
        }
        .popup_button
        {
            color: #fff !important;
            font-family: arial, Geneva, sans-serif;
            font-size: 12px;
            font-weight: normal;
            text-decoration: none !important;
            width: auto;
            background-image: url('../Contentcls/Images/ok.png');
            background-repeat: repeat-x; /*height: 24px;*/
            line-height: 22px;
            padding: 3px 15px 3px 15px;
            float: left;
            margin: 0px 0px 0px 5px;
        }
    </style>


       

     
         <style type="text/css">
      
      table.grid tbody tr:hover {background-color:#e5ecf9;}
.GridHeaderStyle{color:#FEF7F7;background-color: #877d7d;font-weight: bold;}
.GridItemStyle{background-color:#eeeeee;color: Black;}
.GridAlternatingStyle{background-color:#dddddd;color: black;}
.GridSelectedStyle{background-color:#680810;color: black;}


.GridStyle
{
	border-bottom: white 2px ridge; 
	border-left: white 2px ridge; 
	background-color: white; 
	width: 100%; 
	border-top: white 2px ridge; 
	border-right: white 2px ridge; 
}
.ItemStyle {
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}

.ItemStyle td{
	BACKGROUND-COLOR: #eeeeee; 
	COLOR: black;
	padding-bottom: 5px;
	padding-right: 3px;
	padding-top: 5px;
	padding-left: 3px;
	height: 25px
}
.FixedHeaderStyle {
	BACKGROUND-COLOR:  #660731; 
	COLOR: #FFFFFF; 
	FONT-WEIGHT: bold;
	position:relative ;   
	top:expression(this.offsetParent.scrollTop);  
	z-index: 10;
    height:50px;  
}
.Caption_1_Customer
{
	background-color:#beccda;
	color: #000000;
	width: 30%;
	height: 20px;
}
 #hurfDurf table
 .Gridstudent
    {
      
        margin-right:80px;
    }
      
          </style>

         <%-- style row color chnged--%>
         <style type="text/css">
  .successMerit {
    background-color: #1fa756;
    border: medium none;
    color: White;
  }
    .defaultColor
    {
        background-color: white;
        color: black;
    }
  .dangerFailed {
    background-color: #f2283a;
    color: White;
  }
             .style12
             {
                 color: #006666;
             }
         </style>
     <script type="text/javascript">
    $(document).ready(function () {
        $('#<%=crd.ClientID %>').Scrollable({
            ScrollHeight: 300,
         
        });
    });
    </script>
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>

      <script src="../Contents/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="../Contents/Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>

  <%--  Prob***--%>
 <link href="../Contents/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
   
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
     <link href="../Contents/Css/bootstrap.css" rel="stylesheet" type="text/css" />
   
   <%-- ***--%>
    <link href="../Contents/Css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
     <link href="../Contents/Css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script src="../Contents/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Contents/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Contents/CSS3/js/bootstrap.min.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
  <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
          
 </asp:ToolkitScriptManager>

    <asp:UpdatePanel runat="server" ID="upMain1">
        <ContentTemplate>
            <%--<asp:Button runat="server" ID="btnShow"
                OnClick="btnShowSuccess_Click" Text="Success" />
            <asp:Button runat="server" ID="Button1"
                OnClick="btnShowError_Click" Text="Error" />
            <asp:Button runat="server" ID="Button2"
                OnClick="btnShowWarning_Click" Text="Warning" />
            <asp:Button runat="server" ID="Button3"
                OnClick="btnShowMessage_Click" Text="Message" />--%>
            <%--Message popup area start--%>
            <asp:Button runat="server" ID="btnMessagePopupTargetButton" Style="display: none;" />
            <ajaxToolkit:ModalPopupExtender ID="mpeMessagePopup" runat="server" PopupControlID="pnlMessageBox"
                TargetControlID="btnMessagePopupTargetButton" OkControlID="btnOk" CancelControlID="btnCancel"
                BackgroundCssClass="MessageBoxPopupBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel runat="server" ID="pnlMessageBox"
                BackColor="White" Width="423"
                Style="display: none; border: 2px solid #780606;">
                <div class="popupHeader" style="width: 423px;">
                    <asp:Label ID="lblMessagePopupHeading" Text="Information"
                        runat="server"></asp:Label><asp:LinkButton
                            ID="btnCancel" runat="server"
                            Style="float: right; margin-right: 5px; background-color: #d82222;">X</asp:LinkButton>
                </div>
                <div style="max-height: 500px; width: 423px; overflow: hidden;">
                    <div style="float: left; width: 300px; margin: 10px;">
                        <table style="padding: 0; border-spacing: 0; border-collapse: collapse; width: 100%;">
                            <tr>
                                <td style="text-align: left; vertical-align: top; width: 11%;">
                                    <asp:Literal runat="server" ID="ltrMessagePopupImage"></asp:Literal>
                                </td>
                                <td style="width: 2%;"></td>
                                <td style="text-align: left; vertical-align: top; width: 87%;">
                                    <p style="margin: 0px; padding: 0px; color: #5F0202;">

                                        <asp:Label runat="server" ID="lblMessagePopupText"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; vertical-align: top;" colspan="3">
                                    <div style="margin-right: -65px; float: right; width: auto;">
                                        <asp:LinkButton ID="btnOk" runat="server"
                                            CssClass="popup_button">Ok</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <%--Message popup area end--%>
        </ContentTemplate>
    </asp:UpdatePanel>

 
    <br />

   <center>
       
       <h2 class="style12">VALIDATION CAHIER DE CLASSE</h2>

    <table>
                           
       

         <tr>


        <td>
                 <%--<asp:Label runat="server" ID="Label2" Text="Année" Visible="false"></asp:Label>--%>
             
                  
                
                   <%--<asp:DropDownList runat="server" ID="DropDownList1" 
                   AppendDataBoundItems="true" AutoPostBack="true" Width="320px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                       >
                       <asp:ListItem Value="" Text="---Selectionner année---"></asp:ListItem>
                       <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                        <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                        <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                        <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                   </asp:DropDownList>--%>
                    </td>

             <td>
                                  
                                
                                      <asp:Label runat="server" ID="Label8" Text="Module" ></asp:Label>
                              
                              
                                       
                                    <telerik:RadComboBox ID="RadComboBox4" runat="server" AutoPostBack="True"
                                        EnableLoadOnDemand="True"
                                        EmptyMessage="Saisir module" Filter="Contains" Width="320px" DataTextField="des"
                                        DataValueField="code_module" 
                                        OnSelectedIndexChanged="RadComboBox4_SelectedIndexChanged" >
                                    </telerik:RadComboBox>                                           
                                </td>
             
            <td runat="server" id="td2" visible="false">
                                  
                                
                                      <asp:Label runat="server" ID="Label2" Text="Classe" ></asp:Label>
                              
                              
                                       
                                    <telerik:RadComboBox ID="RadComboBox2" runat="server" AutoPostBack="True"
                                        EnableLoadOnDemand="True"
                                        EmptyMessage="Saisir classe" Filter="Contains" 
                                        Width="320px" DataTextField="code_cl"
                                        DataValueField="code_cl" 
                                        OnSelectedIndexChanged="CL_SelectedIndexChanged" >
                                    </telerik:RadComboBox>                                           
                                </td>
             
        

              <td runat="server" id="td1" visible="false">
                                  
                                
                                      <asp:Label runat="server" ID="Label1" Text="Seance de cours" ></asp:Label>
                              
                              
                                       
                                   <%-- <telerik:RadComboBox ID="RadComboBox1" runat="server" AutoPostBack="True" 
                                        EnableLoadOnDemand="True"
                                        EmptyMessage="Saisir séance" Filter="Contains" Width="320px" DataTextField="endd"
                                        DataValueField="endd" OnSelectedIndexChanged="Rad1_SelectedIndexChanged">
                                    </telerik:RadComboBox>--%>
                                
                            
                                   <asp:DropDownList ID="dropseance" runat="server"
                                      
                                        AutoPostBack="True"
                                    Width="320px" DataTextField="endd"
                                        DataValueField="endd" OnSelectedIndexChanged="ddlseance" >
                                     

                                   </asp:DropDownList>        
                                           
                                </td>
             <td><asp:TextBox runat="server" ID="txtclasse" Visible="false"></asp:TextBox></td>
        
                            </tr>
                            </table>

    </center> 
    <br />
    <center>
        
        <h2 class="style5"><asp:Label Visible="false" id="l1" runat="server"
         Text=" LISTE DES ACQUIS D'APPRENTISSAGE"></asp:Label></h2>
    </center>
    <br />
    <center>


        <table>
  
        <%--<tr><td><asp:TextBox runat="server" ID="txt1" Visible="false">
            </asp:TextBox></td></tr>
        --%>
           <tr><td style="text-align:center"><asp:Label Font-Bold="true"
                runat="server" 
                 ID="lbltxt1" Visible="false" ></asp:Label></td></tr>
            <tr><td><br /></td></tr>
            
            <tr>
            <td>
                <asp:GridView ID="crd" runat="server" AutoGenerateColumns="false" 
                    OnRowDataBound = "OnRowDataBoundS" DataKeyNames = "code_module"
 Style="border-bottom: #160f4e 2px ridge; border-left: #160f4e 2px ridge;
 background-color: #160f4e; 
     border-top: #160f4e 2px ridge; border-right: #160f4e 2px ridge;"
  BorderWidth="0px" 
        BorderColor="#160f4e" CellSpacing="1" 
                    CellPadding="3" CssClass="grid" Visible="false" Width="1000px" RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle"  GridLines="Both" 
        EmptyDataRowStyle-CssClass="ItemStyle"  >
    <Columns>
      
       


          <asp:TemplateField HeaderText="CODE MODULE"  
               ItemStyle-Width="35%" Visible="false">
              <ItemTemplate>
                    <asp:Label ID="LBLCODE_MODULE" runat="server" Text='<%# Eval("CODE_MODULE") %>'></asp:Label>
                </ItemTemplate>
              
          
            </asp:TemplateField>

<%--<asp:BoundField DataField="NUM_CHAPTER" ItemStyle-Width="15%"  HeaderText="NUM_CHAPTER" SortExpression="NUM_CHAPTER" />--%>
     
        <asp:TemplateField HeaderText="NUMERO DU CHAPITRE"  
               ItemStyle-Width="35%" Visible="false">
              <ItemTemplate>
                    <asp:Label ID="LBLNUM_CHAPTER" runat="server" Text='<%# Eval("NUM_CHAPTER") %>'></asp:Label>
                </ItemTemplate>
              
          
            </asp:TemplateField>


           <%--<asp:BoundField DataField="TITRE_CHAPTER" HeaderText="TITRE_CHAPTER" SortExpression="TITRE_CHAPTER"
            ItemStyle-Width="35%" />--%>

          <asp:TemplateField HeaderText="TITRE DU CHAPITRE" 
               ItemStyle-Width="35%">
              <ItemTemplate>
                    <asp:Label ID="LBLTITRE_CHAPTER" runat="server" Text='<%# Eval("TITRE_CHAPTER") %>'></asp:Label>
                </ItemTemplate>
              
          
            </asp:TemplateField>


        

          <%--<asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" SortExpression="DESIGNATION"
            ItemStyle-Width="60%" />--%>


        <asp:TemplateField HeaderText="ACQUIS DES CHAPITRES"   ItemStyle-Width="60%">
              <ItemTemplate>
                    <asp:Label ID="LBLDESIGNATION" runat="server" Text='<%# Eval("DESIGNATION") %>'></asp:Label>
                </ItemTemplate>
              
          
            </asp:TemplateField>

        <%-- <asp:TemplateField ItemStyle-Width="20%" HeaderText="Valider">
      
     
           <ItemTemplate> 
              <asp:CheckBox ID="CheckBox1"   runat="server"  OnCheckedChanged="OnCheckedChanged" />
           </ItemTemplate>
        </asp:TemplateField>--%>

         <asp:TemplateField HeaderText="Progression du cours">
                                        <ItemTemplate>
                                             <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("PROG_COURS") %>'></asp:Label>--%>
                                            <asp:RadioButtonList ID="RadioButtonds"  runat="server"
                                                 RepeatDirection="Horizontal" SelectedValue='<%# Bind("PROG_COURS") %>'
                                                OnSelectedIndexChanged = "CountryChanged" AutoPostBack = "true">
                                                <asp:ListItem Value="done">done</asp:ListItem>
                                                <asp:ListItem Value="doing">doing</asp:ListItem>
                                                <asp:ListItem Value="to_do" Selected="True">to_do</asp:ListItem>
                                            </asp:RadioButtonList>
                                              
                                       

                 <asp:DropDownList ID="DrpPercentageComplete" 
                     SelectedValue='<%# Bind("PROG_COURS_PERCENT") %>'
                     runat="server" BackColor="LightBlue"
 BorderColor="Black" BorderWidth="1px" Font-Bold="True" Font-Names="Verdana" Visible="false"
 Font-Size="X-Small" DataTextFormatString="{0:0.# %}" ForColor="Black" Height="16px" 
 
 style="text-align: center" Width="135px">
  <asp:ListItem Value="">Etat d'avancement</asp:ListItem>
  
  <asp:ListItem Value="0%">0%</asp:ListItem>
  <asp:ListItem Value="10%">10%</asp:ListItem>
  <asp:ListItem Value="20%">20%</asp:ListItem>
  <asp:ListItem Value="30%">30%</asp:ListItem>
  <asp:ListItem Value="40%">40%</asp:ListItem>
  <asp:ListItem Value="50%">50%</asp:ListItem>
  <asp:ListItem Value="60%">60%</asp:ListItem>
  <asp:ListItem Value="70%">70%</asp:ListItem>
  <asp:ListItem Value="80%">80%</asp:ListItem>
  <asp:ListItem Value="90%">90%</asp:ListItem>
  <asp:ListItem Value="100%">100%</asp:ListItem>
  </asp:DropDownList>
             </ItemTemplate>
          
                                    </asp:TemplateField>

          <%--<asp:BoundField DataField="ID_ACQUIS" HeaderText="ID_ACQUIS" SortExpression="ID_ACQUIS"
            ItemStyle-Width="25px" Visible="false" />--%>

 <asp:TemplateField HeaderText="ACQ" Visible="false">
              <ItemTemplate>
                    <asp:Label ID="LBLID_ACQUIS" runat="server" Text='<%# Eval("ID_ACQUIS") %>'></asp:Label>
                </ItemTemplate>
              
          
            </asp:TemplateField>



        
       
         
    </Columns>
</asp:GridView>


            </td>

       
              

                   


                </tr>
            <tr><td><br /></td></tr>
<tr>
    <td align="center">
<asp:TextBox ID="txtid" runat="server" TextMode="MultiLine" 
    Visible="false" placeholder="Vos remarques ici..."
    Height="150px" Width="500px"></asp:TextBox>

    </td>

</tr>
            <tr><td><br /></td></tr>
<tr>
     <td align="center">
<asp:Button ID="btnUpdate" runat="server"
     Text="Enregistrer" OnClick = "Update2"
     Visible="false" height="55px"  Width="150px"/></td></tr>
    </table>
    </center>

            
    </asp:Content>