<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Azienda_spedizione_pacchi.info" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Andrea Lombardo,Emiliano Bergonzani">
    <link href="CssVari/admin.css" rel="stylesheet">
    <link href="CssVari/info.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
        <div id="wrapper">
            <!-- Sidebar -->


            <div id="sidebar-wrapper">
                <br />
                <ul class="sidebar-nav">
                    <div style="text-align: center;; height: 170px;">

                        <br />

                        <asp:Image runat="server" ImageUrl="~/Images/bg.png"
                            ID="profileimg" />
                    </div>
                    <li id="nomeUtente" class="sidebar-brand"><a href="#"></a></li>
                    <br />

                    <li><a href="UserView.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;I miei Pacchi</a>
                    </li>
                    <li><a href=""><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Info Utente</a>
                    </li>
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
                            <h1>User HomePage</h1>
                            <p>
                                Benvenuto nell'Area informazioni cliente
                            </p>
                            <br />
                            <h2>Informazioni generiche</h2>
                            <div class="limiter">
                                <div class="container-table100">
                                    <div class="wrap-table100">
                                        <div class="table100">
                                            <table>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="column1">Nome</td>
                                                                <td class="column2"><asp:Literal ID="nome" runat="server"></asp:Literal></td>
                                                            </tr>
                                                             <td class="column1">Cognome</td>
                                                                <td class="column2"><asp:Literal ID="cognome" runat="server"></asp:Literal></td>
                                                            <tr>
                                                                 <td class="column1">Username</td>
                                                                <td class="column2"><asp:Literal ID="username" runat="server"></asp:Literal></td>
                                                            </tr>
                                                            <tr>
                                                                 <td class="column1">Indirizzo</td>
                                                                <td class="column2"><asp:Literal ID="indirizzo" runat="server"></asp:Literal></td>
                                                            </tr>
                                                        </ItemTemplate>

                                                </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
    </form>
</body>
</html>
