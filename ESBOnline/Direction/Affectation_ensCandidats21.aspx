<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Affectation_ensCandidats21.aspx.cs" 
    Inherits="ESPOnline.Direction.Affectation_ensCandidats21"  MasterPageFile="~/Direction/Site112.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>--%>
<%--<%@ Register TagPrefix="qsf" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="qsf" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="qsf" TagName="Footer" Src="~/Common/Footer.ascx" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
  <%--<script src="jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="jquery-ui-1.8.16.min.js" type="text/javascript"></script>
    <script src="../Css-encad/DDScript.js" type="text/javascript"></script>
     <script type="text/javascript">
        $(function () {        
            //Get data and fill first box
            var $json = <% =GetJsonData() %>;
            pageload($json);
            });
    </script>--%>
<%--     <qsf:headtag runat="server" ID="Headtag1" />--%>

     <style>
.custom-button-gris
{color:#fff!important;background-color:#848484;text-shadow:none;padding:10px 20px;
 line-height:1.6;box-shadow:none;font-size:13px;font-weight:700;border-style:solid;
 border-radius:3px;-webkit-transition:background-color .15s ease-out;
 transition:background-color .15s ease-out;border-width:0;border-radius:3px!important;margin-bottom:20px

}
.custom-button-gris:hover{background-color:#780606

}
        
    </style>


      <style>
.custom-button-green
{color:#fff!important;background-color:#0024ff;text-shadow:none;padding:10px 20px;
 line-height:1.6;box-shadow:none;font-size:13px;font-weight:700;border-style:solid;
 border-radius:3px;-webkit-transition:background-color .15s ease-out;
 transition:background-color .15s ease-out;border-width:0;border-radius:3px!important;margin-bottom:20px

}
.custom-button-green:hover{background-color:#a9cbce

}
        
    </style>
    <style>



.custom-button
{color:#fff!important;background-color:#cd2122;text-shadow:none;padding:10px 20px;
 line-height:1.6;box-shadow:none;font-size:13px;font-weight:700;border-style:solid;
 border-radius:3px;-webkit-transition:background-color .15s ease-out;
 transition:background-color .15s ease-out;border-width:0;border-radius:3px!important;margin-bottom:20px

}
.custom-button:hover{background-color:#979797

}
/*.width100{width:100%}.gobox{color:#535353;padding:25px;min-height:100px;position:relative;line-height:1.6;margin-bottom:25px;border-radius:5px;background-color:#ededed;-webkit-transition:all .2s ease-out;transition:all .2s ease-out}.gobox-first::after{margin-top:0;top:0;right:-5px;background-color:#ededed;width:40%;height:100%;border-radius:5px;-webkit-transform:skewX(-12deg);-ms-transform:skewX(-12deg);transform:skewX(-12deg);-webkit-transform-origin:bottom right;-ms-transform-origin:bottom right;transform-origin:bottom right;content:"";position:absolute}.gobox-last::before{margin-top:0;top:0;left:-5px;background-color:#ededed;width:40%;height:100%;border-radius:5px;-webkit-transform:skewX(-12deg);-ms-transform:skewX(-12deg);transform:skewX(-12deg);-webkit-transform-origin:top left;-ms-transform-origin:top left;transform-origin:top left;content:"";position:absolute}.gobox-content{z-index:1;position:relative}.gobox-title{margin-top:0;text-transform:uppercase;font-size:14px;font-weight:700*/

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      }

    </style>
    
    <style type="text/css">
        #targetTextBox
        {
        }
        #targetTextBox textarea
        {
            border: 1px solid #979797;
            font: 12px/1.2em "segoe ui" ,arial,sans-serif;
            cursor: default;
        }
        .example-panel
        {
            background: transparent url(bg.jpg) no-repeat 0 0;
            position: relative;
            width: 748px;
            height: 383px;
        }
        #RadListBox1
        {
            position: absolute;
            top: 143px;
            left: 68px;
        }
        #RadListBox2
        {
            position: absolute;
            top: 143px;
            left: 304px;
        }
        #targetTextBox
        {
            left: 545px;
            position: absolute;
            top: 143px;
        }
    </style>
<link type="text/css" href="../Css-encad/DDStyle.css" rel="Stylesheet" />

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
        .auto-style1 {
            right: 671px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <h3>Affectation des Enseignants aux candidats</h3>
    <hr />
       <telerik:RadComboBox ID="RadComboBox1" runat="server" DataSourceID="SqlDataSource1" 
           DataTextField="NOM" DataValueField="ID_ENS" EmptyMessage="Tappez le Nom d'enseignant " required=""
         onselectedindexchanged="DropDownList2_SelectedIndexChanged"   Filter="Contains" Width="400px" Height="100px">
        </telerik:RadComboBox>
    <br />
        <br />
     <telerik:RadDatePicker runat="server" ID="TBdateseance"  Width="400px"
                                    Height="37px" required="">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                         ViewSelectorText="x"></Calendar>

                                    <DateInput ToolTip="Date input" DateFormat="dd/MM/yy"
                                        DisplayDateFormat="dd/MMM/yy" Height="37px">
                                    </DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="TBdateseance" ValidationGroup="ajouter_date"
                                    ErrorMessage="Date!!!" CssClass="style11" Font-Bold="True" ForeColor="Red">

                                </asp:RequiredFieldValidator>

    <br />
        <br />
  <%-- <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
  <%--  <qsf:header runat="server" ID="Header1" NavigationLanguage="C#" />--%>
     
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" CssClass="example-panel">
        
       
        <telerik:RadListBox ID="RadListBox1" runat="server" Width="400px" Height="300px"  DataSourceID="SqlDataSource2" 
            SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBox2" AutoPostBackOnTransfer="true"
            DataTextField="nom" DataValueField="id_et" AutoPostBack="true"
            AllowReorder="true" AutoPostBackOnReorder="true" EnableDragAndDrop="true" OnDropped="RadListBox_Dropped">

        </telerik:RadListBox>
      
        <telerik:RadListBox ID="RadListBox2" runat="server" Width="300px" Height="300px"
            SelectionMode="Multiple" AllowReorder="true" AutoPostBackOnReorder="true" EnableDragAndDrop="true"
            OnDropped="RadListBox_Dropped">
         
        </telerik:RadListBox>

<br />
        
        
<br />
<br />
<br />
        
      

                  <asp:Button ID="Btnscore_finale" CssClass="custom-button" width="180px" runat="server" Text="Affecter"  height="44px" OnClick="Btnscore_finale_Click"  />
               
                &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button1" CssClass="custom-button-gris" runat="server" Text="Annuler" 
             height="44px" width="220px" OnClick="Button1_Click"/>

                 
                &nbsp;&nbsp;&nbsp;&nbsp;
           
          <asp:Button ID="Button2" CssClass="custom-button-green" runat="server" Text="Exporter en excel" 
             height="44px" width="220px" OnClick="Buttonexcel_Click"/>



               
        
    </telerik:RadAjaxPanel>
  

       
        
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" visible="false"
        DataKeyNames = "ID_ET"
       
       
 Style="border-bottom: white 2px ridge; border-left: white 2px ridge;
 background-color: white; 
     border-top: white 2px ridge; border-right: white 2px ridge;"
  BorderWidth="0px" 
        BorderColor="White" CellSpacing="1" CellPadding="3" CssClass="grid"
       
             GridLines="Both"                                           
        RowStyle-CssClass="ItemStyle" HeaderStyle-CssClass="FixedHeaderStyle" 
                                                         
        EmptyDataRowStyle-CssClass="ItemStyle" 
             >

         <EmptyDataTemplate>
                                    Pas d'enregistrement.
                                </EmptyDataTemplate>
                                <HeaderStyle HorizontalAlign="Center" Height="20px" Width="100px" BackColor="#CC0000" ForeColor="White" />
                                <RowStyle HorizontalAlign="Center" CssClass="ItemStyle"></RowStyle>
                                <FooterStyle CssClass="ItemStyle" />
                                <EmptyDataRowStyle CssClass="ItemStyle"></EmptyDataRowStyle>
                                <RowStyle CssClass="GridItemStyle" />
                                <AlternatingRowStyle CssClass="GridAlternatingStyle" />
                                <HeaderStyle CssClass="GridHeaderStyle" />
                                <SelectedRowStyle CssClass="GridSelectedStyle" />
    <Columns>
     

       <%-- <asp:TemplateField>
     
     <HeaderTemplate>
                   <asp:CheckBox ID="CheckBox1" AutoPostBack="true"
                        OnCheckedChanged="chckchanged" runat="server" /> 
            </HeaderTemplate>
           <ItemTemplate> 
              <asp:CheckBox ID="CheckBox2"  runat="server"  />
           </ItemTemplate>
        </asp:TemplateField>--%>

        <%--<asp:BoundField DataField="ID_ET" HeaderText="ID Etudiant" SortExpression="ID_ET"
            ItemStyle-Width="25px" />
<asp:BoundField DataField="NUM_CIN_PASSEPORT" HeaderText="NUM CIN" SortExpression="NOM" />--%>

     

        

          <%--<asp:TemplateField HeaderText="NOM">

             <ItemTemplate>
                <asp:Label ID = "lblnom" runat="server" Text='<%# Eval("NOM") %>'></asp:Label>
               
            </ItemTemplate>
               
            </asp:TemplateField>--%>
                <asp:BoundField DataField="id_et" HeaderText="id_et" SortExpression="id_et"
            ItemStyle-Width="25px" />
         
     <asp:BoundField DataField="NOM_et" HeaderText="Nom" SortExpression="NOM_et"
            ItemStyle-Width="25px" />

     <asp:BoundField DataField="pNOM_et" HeaderText="Prenom" SortExpression="PNOM_et"
            ItemStyle-Width="25px" />
   
 

           <asp:BoundField DataField="e_mail_et" HeaderText="e_mail_et" SortExpression="e_mail_et"
            ItemStyle-Width="25px" />
       
             <asp:BoundField DataField="NOM_ENS" HeaderText="NOM_ENS" SortExpression="NOM_ENS"  ItemStyle-Width="25px" />

            
           
        <asp:BoundField DataField="DATE_AFFECTATION_ENS" HeaderText="DATE_AFFECTATION_ENS" SortExpression="DATE_AFFECTATION_ENS"
            ItemStyle-Width="25px" />
      <%--  <asp:BoundField DataField="USER_AFFECTATION_ENS" HeaderText="USER_AFFECTATION_ENS" SortExpression="USER_AFFECTATION_ENS"
            ItemStyle-Width="25px" />--%>
   
         
        <%--//ID_ENS_ENTRETIEN,DATE_AFFECTATION_ENS,USER_AFFECTATION_ENS --%>
          <asp:BoundField DataField="dateentr" HeaderText="date entretien" SortExpression="dateentr"
            ItemStyle-Width="25px" />
    </Columns>

        <HeaderStyle CssClass="GridHeaderStyle" />
                                <RowStyle ForeColor="#000000" />
                                <SelectedRowStyle CssClass="GridSelectedStyle" />
                                <AlternatingRowStyle BackColor="#d2c1bf" />
</asp:GridView>


    
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
            <asp:Panel runat="server" ID="pnlMessageBox" BackColor="White" Width="423" Style="display: none;
                border: 2px solid #780606;">
                <div class="popupHeader" style="width: 423px;">
                    <asp:Label ID="lblMessagePopupHeading" Text="Information" runat="server"></asp:Label><asp:LinkButton
                        ID="btnCancel" runat="server" Style="float: right; margin-right: 5px; background-color: #d82222;">X</asp:LinkButton>
                </div>
                <div style="max-height: 500px; width: 423px; overflow: hidden;">
                    <div style="float: left; width: 300px; margin: 10px;">
                        <table style="padding: 0; border-spacing: 0; border-collapse: collapse; width: 100%;">
                            <tr>
                                <td style="text-align: left; vertical-align: top; width: 11%;">
                                    <asp:Literal runat="server" ID="ltrMessagePopupImage"></asp:Literal>
                                </td>
                                <td style="width: 2%;">
                                </td>
                                <td style="text-align: left; vertical-align: top; width: 87%;">
                                    <p style="margin: 0px; padding: 0px; color: #5F0202;">
                                        <asp:Label runat="server" ID="lblMessagePopupText"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; vertical-align: top;" colspan="3">
                                    <div style="margin-right: -65px; float: right; width: auto;">
                                        <asp:LinkButton ID="btnOk" runat="server" CssClass="popup_button">Ok</asp:LinkButton>
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

     <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select   distinct e.id_ens, e.id_ens ||' '||e.NOM_ENS  nom from esp_enseignant e ,ESP_MODULE_PANIER_CLASSE_SAISO e1 where( e.id_ens= e1.id_ens  or e.id_ens= e1.ID_ENS2 or e.id_ens= e1.id_ens3 or e.id_ens= e1.id_ens4 or e.id_ens= e1.id_ens5 )and etat='A' and e.id_ens !='V-463-12'  and e.id_ens not in ( select e.ID_ENS_ENTRETIEN from SCO_ADMIS1415.ESP_ETUDIANT e where (trim(e.DATE_AFFECTATION_ENS)  BETWEEN TRUNC(sysdate, 'iw')and  TRUNC(sysdate, 'iw') + 7 - 1/86400) ) ">
        </asp:SqlDataSource>--%>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select   distinct e.id_ens, e.id_ens ||' '||e.NOM_ENS  nom from esp_enseignant e ,ESP_MODULE_PANIER_CLASSE_SAISO e1 
where( e.id_ens= e1.id_ens  or e.id_ens= e1.ID_ENS2 or e.id_ens= e1.id_ens3 or e.id_ens= e1.id_ens4 or e.id_ens= e1.id_ens5 )and etat='A'
and  e.id_ens !='V-463-12'  ">
        </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
            ProviderName="<%$ ConnectionStrings:DefaultConnectionString.ProviderName %>"
            SelectCommand="select id_et,id_et||' '||nom_et||' '||pnom_et ||' '||dateentr nom from admis_esb.esp_etudiant where id_et like '22%'  
        and ID_ENS_ENTRETIEN is  null
         order by dateentr desc">
        </asp:SqlDataSource>


    </asp:Content>