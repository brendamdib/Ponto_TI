<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RelatoriosAdm.aspx.cs" Inherits="Ponto_TI.Admin.RelatoriosAdmin" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
    <link href="../CSS/Style.css" rel="stylesheet" />
    

    <table>
        <caption>Selecione o tipo de relatório</caption>
        <tbody>
            <tr>
                <td><asp:Label ID="lbl_periodo" runat="server" Text="Período"></asp:Label></td>
                <td><asp:Label ID="lbl_dataini" runat="server" Text="&nbsp; Início"></asp:Label></td>
                <td><asp:TextBox ID="txt_dataini" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox></td>
                <td><asp:Label ID="lbl_datafim" runat="server" Text="&nbsp; Fim"></asp:Label></td>
                <td><asp:TextBox ID="txt_datafim" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>                
            </tr>
            <tr>
                <td><asp:Label ID="lbl_tiposrel" runat="server" Text="Tipos"></asp:Label></td>
                <td><asp:RadioButton ID="rdo_colab" Text="Por Colaborador" runat="server" GroupName="relatorios" OnCheckedChanged="rdo_colab_CheckedChanged" AutoPostBack="true" /></td>
                <td><asp:DropDownList ID="cbo_Colab" runat="server" Width="300px" DataSourceID="SQLDS_Colab" DataTextField="nome_colab" DataValueField="id_colab" Enabled="false"></asp:DropDownList></td>
                <td><asp:RadioButton ID="rdo_regional" Text="Por Regional" runat="server" GroupName="relatorios" OnCheckedChanged="rdo_regional_CheckedChanged" AutoPostBack="true"/><br /></td>                    
                <td><asp:DropDownList ID="cbo_regional" runat="server" Width="300px" DataSourceID="SQLDS_Regional" DataTextField="nome_regional" DataValueField="id_regional" Enabled="False"></asp:DropDownList></td>
            </tr>             
            <tr>
                <td colspan="7" style="text-align:center;"><asp:Button ID="btn_pesquisar" runat="server" Text="Gerar" OnClick="btn_pesquisar_Click" Enabled="false"/></td>
            </tr>
        </tbody>
        </table>
        
        
                    
    
    <br />
                 <asp:SqlDataSource ID="SQLDS_Colab" runat="server" ConnectionString="<%$ ConnectionStrings:PontoOnLineConnectionString %>" SelectCommand="SELECT * FROM [tbl_colab] ORDER BY [nome_colab]"></asp:SqlDataSource>       
    <asp:SqlDataSource ID="SQLDS_Regional" runat="server" ConnectionString="<%$ ConnectionStrings:PontoOnLineConnectionString %>" SelectCommand="SELECT * FROM [tbl_regional] ORDER BY [nome_regional]"></asp:SqlDataSource>
    <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableDrillDown="True" EnableParameterPrompt="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" ToolPanelView="None" Width="1000px" BestFitPage="False" HasCrystalLogo="False" Height="600px" RenderingDPI="96" PageZoomFactor="100" />
    <br />
    <br />
    </asp:Content>
