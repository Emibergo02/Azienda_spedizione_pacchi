<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="Azienda_spedizione_pacchi.UserView" %>

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
    <form id="form2"  runat="server">
        <div id="wrapper">
            <!-- Sidebar -->


            <div id="sidebar-wrapper">
                <br />
                <ul class="sidebar-nav">
                    <div style="text-align: center; background-image: url(Images/bg.jpg); height: 170px;">

                        <br />

                        <asp:Image runat="server" ID="profileimg" />
                        <asp:FileUpload ID="fileUpload1" runat="server" />
                        <asp:Button id="UploadButton" 
                            Text="Upload file"
                            OnClick="btnupload_Click"
                            runat="server">
                        </asp:Button>    

                    </div>
                    <li id="nomeUtente" class="sidebar-brand"><a href="#"></a></li>
                    <br />

                    <li><a href=""><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;I miei Pacchi</a>
                    </li>
                    <li><a href="info.aspx"><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Info Utente</a>
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
                                Benvenuto nell'Area clienti
                            </p>
                            <div class="limiter">
                                <div class="container-table100">
                                    <div class="wrap-table100">
                                        <div class="table100">
                                            
                                                <table>
                                                    <tr class="table100-head">
                                                        <th class="column1">Nome Mittente</th>
                                                        <th class="column2">Cognome </th>
                                                        <th class="column3">Nome Destinatario</th>
                                                        <th class="column4">Cognome </th>
                                                        <th class="column5">Volume Pacco</th>
                                                        <th class="column6">Data del Viaggio</th>
                                                    </tr>
                                                    <asp:Repeater ID="rptViaggi" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="column1"><%#Eval("Mittente.Nome") %></td>
                                                                <td class="column2"><%#Eval("Mittente.Cognome") %></td>
                                                                <td class="column3"><%#Eval("Destinatario.Nome") %></td>
                                                                <td class="column4"><%#Eval("Destinatario.Cognome") %></td>
                                                                <td class="column5"><%#Eval("Volume") %></td>
                                                                <td class="column6"><%#Eval("Viaggio.Data").ToString().Substring(0,10) %></td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
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

