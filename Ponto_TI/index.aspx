<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Ponto_TI.index"%>
    
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</head>
<body>
    <link href="CSS/Style.css" rel="stylesheet" />
    <form id="frm_index" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2"><img src="imagens/61547-logo-gnc.png" /></td>
            </tr>
            <tr>
                <td>CPF:</td>
                <td><asp:TextBox ID="txt_cpf" runat="server" MaxLength="14"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td colspan="2"><hr /></td>
            </tr>
            <tr>
                <td>Ação:</td>
                <td>
                    <asp:RadioButtonList ID="rdo_acao" runat="server">
                        <asp:ListItem Selected="True" Value="0">Início do Expediente</asp:ListItem>
                        <asp:ListItem Value="1">Saída Almoço</asp:ListItem>
                        <asp:ListItem Value="2">Retorno Almoço</asp:ListItem>
                        <asp:ListItem Value="3">Fim Expediente</asp:ListItem>
                        <asp:ListItem Value="4">Início Hora Extra</asp:ListItem>
                        <asp:ListItem Value="5">Fim Hora Extra</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2"><hr /></td>
            </tr>
            <tr>
                <td colspan="2" id="botao">
                    <asp:Button ID="btn_submit" runat="server" Text="Salvar" OnClick="btn_submit_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>     
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
