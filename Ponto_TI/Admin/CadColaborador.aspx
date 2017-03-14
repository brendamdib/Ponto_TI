<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CadColaborador.aspx.cs" Inherits="Ponto_TI.Admin.Cadastro_de_Colaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Table ID="tbl_cad_Colab" runat="server" Width="500px" Font-Names="Arial" Font-Size="Small">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Center">
                Cadastro de Colaboradores
            </asp:TableHeaderCell>            
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>NOME:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txt_nome" MaxLength="50" runat="server" Width="300"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>CPF:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txt_cpf" MaxLength="11" runat="server" Width="300"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>LOGIN:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txt_login" MaxLength="30" runat="server" Width="300"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>SENHA:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txt_senha" MaxLength="10" TextMode="Password" runat="server" Width="300"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>GRUPO:</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="cbo_grupo" runat="server" Width="300px" DataSourceID="OracleDS" DataTextField="PERMISSAO_NOME" DataValueField="PERMISSAO_ID"></asp:DropDownList>
                 <asp:SqlDataSource ID="OracleDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStrOracle %>" ProviderName="<%$ ConnectionStrings:ConnStrOracle.ProviderName %>" SelectCommand="SELECT PERMISSAO_ID, PERMISSAO_NOME FROM TESTE.TBL_PERMISSAO ORDER BY PERMISSAO_NOME"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                <asp:Button ID="btn_submit" runat="server" Text="Cadastrar" OnClick="btn_submit_Click" />
            </asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>     
    <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>  
</asp:Content>
