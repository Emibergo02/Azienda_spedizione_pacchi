<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="Azienda_spedizione_pacchi.AdminView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Andrea Lombardo,Emiliano Bergonzani">
    <link href="CssVari/admin.css" rel="stylesheet">
    <link href="CssVari/table.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Sidebar -->

            <div id="sidebar-wrapper">
                <br />
                <ul class="sidebar-nav">
                    <div style="text-align: center; background-image: url(Images/bg.jpg); height: 170px;">

                        <br />

                        <asp:Image runat="server" ImageUrl="~/Images/bg.png"
                            ID="profileimg" />
                    </div>
                    <li id="nomeUtente" class="sidebar-brand"><a href="#"></a></li>
                    <br />
                    
                    <li><a href="AdminView.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;Home</a>
                    </li>
                    <li><a href="InserimentoViaggi.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;Viaggi</a>
                    </li>
                    <li><a href="inserimentoVeicoli.aspx"><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Veicoli</a>
                    </li>
                    <li><a href="inserimentoCorrieri.aspx"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Corrieri</a>
                    </li>
                    <li><a href="inserimentoPacchi.aspx"><span class="glyphicon glyphicon-trash"></span>&nbsp;&nbsp;Pacchi</a>
                    <li><a href="Login.aspx"><span class="glyphicon glyphicon-cloud"></span>&nbsp;&nbsp;Torna al login</a>
                    </li>


                </ul>
            </div>
            <!-- /#sidebar-wrapper -->
            <!-- Page Content -->
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1>Admin HomePage</h1>
                            <p>
                                Benvenuto nella pagina da amministratore dell nostro gestionale.
                            </p>
                            <p>
                                A lato è presente un menu che ti permetterà di selezionare quale ambito vuoi andare a modificare, puoi aggiungere elementi direttamente al tuo DB.
                            </p>
                            <br />
                            <br />
                            <h3>Ordinamento tabella</h3>
                            <asp:DropDownList ID="ddlSort" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                  <asp:ListItem Selected="True" Value="Cliente"> Nome Destinatario </asp:ListItem>
                                  <asp:ListItem Value="Consegna"> Consegna </asp:ListItem>
                                  <asp:ListItem Value="Volume"> Volume </asp:ListItem>
                            </asp:DropDownList>

                            <h3>Attiva il filtro per pacchi con viaggio assegnato</h3>
                            <asp:CheckBox ID="cbvedidata" runat="server" />
                            <br />
                            <br />
                            <br />
                            <h1 style="text-align:center">TABELLA PACCHI</h1>
                           <table>
                                <tr class="table100-head">
                                    <th class="column1">Id Pacco</th>
                                    <th class="column2">Nome Destinatario</th>
                                    <th class="column3">Cognome </th>
                                    <th class="column4">Nome Mittente</th>
                                    <th class="column5">Cognome </th>
                                    <th class="column6">Volume Pacco</th>
                                    <th class="column7">Data del Viaggio Spedizione</th>
                                    <th class="column7">Indirizzo</th>
                                </tr>
                                <asp:Repeater ID="rptPacchi" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="column1"><%#Eval("IdPacco") %></td>
                                            <td class="column2"><%#Eval("Destinatario.Nome") %></td>
                                            <td class="column3"><%#Eval("Destinatario.Cognome") %></td>
                                            <td class="column4"><%#Eval("Mittente.Nome") %></td>
                                            <td class="column5"><%#Eval("Mittente.Cognome") %></td>
                                            <td class="column6"><%#Eval("Volume") %></td>
                                            <td class="column7"><%#Eval("Viaggio.Data").ToString().Substring(0,10) %></td>
                                            <td class="column7"><%#Eval("Destinatario.Indirizzo") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <br />
                            <br />
                            <br />
                            <h1 style="text-align:center">TABELLA VIAGGI </h1>
                            <table  style=" align-content:center" width="50%">
                                <tr class="table100-head">
                                    <th class="column1">Numer Viaggio</th>
                                    <th class="column2"></th>
                                    <th class="column3">Targa Mezzo </th>
                                    <th class="column4"></th>
                                    <th class="column5">Data del viaggio</th>
                                    <th class="column6"></th>
                                    <th class="column7">Nome corriere</th>
                                </tr>
                                <asp:Repeater ID="rptViaggi" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="column1"><%#Eval("idViaggio") %></td>
                                            <td class="column2"></td>
                                            <td class="column3"><%#Eval("Veicolo.Targa") %></td>
                                            <td class="column4"></td>
                                            <td class="column5"><%#Eval("Data").ToString().Substring(0,10) %></td>
                                            <td class="column6"></td>
                                            <td class="column7"><%#Eval("NomeCorriere") %></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
