<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ponto_TI.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="../CSS/Style.css" rel="stylesheet" />
    <form id="frm_login" runat="server">
    <div>
    <table>
                <tr>
                    <td colspan="2">
                        <img src="../imagens/61547-logo-gnc.png" /></td>
                </tr>
                <tr>
                    <td>Login:</td>
                    <td>
                        <asp:TextBox ID="txt_login" runat="server" Width="150" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Senha:</td>
                    <td><asp:TextBox ID="txt_senha" runat="server" TextMode="Password" Width="150" MaxLength="10"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr /></td>
                </tr>
                <tr>
                    <td colspan="2" id="botao">
                        <asp:Button ID="btn_submit" runat="server" Text="Acessar" OnClick="btn_submit_Click" />
                    </td>
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
