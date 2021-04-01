<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Azienda_spedizione_pacchi.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 679px;
            height: 316px;
            margin-left: 463px;
        }
        .auto-style2 {
            width: 100%;
            height: 185px;
        }
        .auto-style4 {
            width: 279px;
        }
        .auto-style5 {
            width: 275px;
        }
        .auto-style6 {
            height: 40px;
        }
    </style>
</head>
<body style="height: 416px">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <form  id ="formLog" runat="server">
    <div class="auto-style3">
        <table class="auto-style2">
            <tr>
                <td>TITOLO FIGO LOGIN</td>
            </tr>
            <tr>
                <td>Nome utente</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:TextBox ID="txtUsername" class="auto-style4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPassword" class="auto-style5" runat="server"></asp:TextBox>
                    </td>
            </tr>
                        <tr>
                <td>
                    <asp:Button ID="submitReg" runat="server" Text="Registrati" OnClick="submitReg_Click" />
                    </td>
            </tr>

        </table>
    </div>
        </form>
</body>
</html>
