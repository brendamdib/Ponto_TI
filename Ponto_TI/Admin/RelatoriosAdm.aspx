<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RelatoriosAdm.aspx.cs" Inherits="Ponto_TI.Admin.RelatoriosAdmin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
    <p>
        <asp:Label ID="lbl_info_relatorio" runat="server" Font-Bold="True" Text="Insira o período desejado para a geração do relatório" Font-Names="Arial"></asp:Label>
    </p>

        <asp:Table runat="server">            
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Middle">
                    <asp:Label ID="lbl_inicio" runat="server" Font-Bold="True" Text="Data Início" Font-Names="Verdana" Font-Size="Small"></asp:Label> 
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txt_dataini" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Middle">
                    <asp:Label ID="lbl_fim" runat="server" Font-Bold="True" Text="Data Fim" Font-Names="Verdana" Font-Size="Small"></asp:Label> 
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txt_datafim" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                </asp:TableCell>               
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="btn_pesquisar" runat="server" Text="Pesquisar" OnClick="btn_pesquisar_Click" />
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    <br />
    <rsweb:ReportViewer ID="rpt_rel_horas" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Admin\Relatorios\Relatorio de Ponto.rdlc">
        </LocalReport>
    </rsweb:ReportViewer> 
    <asp:SqlDataSource ID="DSOracleReport" runat="server"></asp:SqlDataSource>
</asp:Content>
