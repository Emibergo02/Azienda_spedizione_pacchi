<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="Azienda_spedizione_pacchi.UserView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Repeater ID="rptViaggi" runat="server">
                <ItemTemplate>
                    <%#Eval("NOrdineConsegna") %> - <%#Eval("Mittente.Nome") %> <%#Eval("Mittente.Cognome") %> - <%#Eval("Destinatario.Nome") %> <%#Eval("Destinatario.Cognome") %> - <%#Eval("Volume") %> - <%#Eval("Viaggio.Data") %><br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
