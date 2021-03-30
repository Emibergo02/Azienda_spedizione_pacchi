<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viaggi.aspx.cs" Inherits="Azienda_spedizione_pacchi.viaggi" %>

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
                    <%#Eval("Data") %> - <%#Eval("NomeCorriere") %> - <%#Eval("Targa") %> - <a href="dettaglioViaggio.aspx?idViaggio=<%#Eval("IdViaggio") %>">Dettaglio</a> ><br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
