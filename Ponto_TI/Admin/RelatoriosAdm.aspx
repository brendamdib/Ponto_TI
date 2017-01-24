<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RelatoriosAdm.aspx.cs" Inherits="Ponto_TI.Admin.RelatoriosAdmin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>      
    <p>
        <asp:Label ID="lbl_info_relatorio" runat="server" Font-Bold="True" Text="Insira o período desejado para a geração do relatório" Font-Names="Arial"></asp:Label>
    </p>

    <p>
        <asp:Table runat="server">            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Middle">
                    <asp:Label ID="lbl_inicio" runat="server" Font-Bold="True" Text="Início" Font-Names="Arial"></asp:Label> &nbsp;
                    <asp:TextBox ID="txt_dataini" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Middle">
                    <asp:Label ID="lbl_fim" runat="server" Font-Bold="True" Text="Fim" Font-Names="Arial"></asp:Label> &nbsp;
                    <asp:TextBox ID="txt_datafim" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                </asp:TableCell>               
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="btn_pesquisar" runat="server" Text="Pesquisar" OnClick="btn_pesquisar_Click" />
     </p>
    
    <rsweb:ReportViewer ID="rpt_rel_horas" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Admin\Relatorios\Relatorio de Ponto.rdlc">
        </LocalReport>
    </rsweb:ReportViewer> 
</asp:Content>
