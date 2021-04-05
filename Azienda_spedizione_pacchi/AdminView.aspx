<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="Azienda_spedizione_pacchi.Amministratore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Andrea Lombardo,Emiliano Bergonzani">
    <link href="css/admin.css" rel="stylesheet">
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

                        <asp:Image runat="server" ImageUrl="~/Images/hitesh.png"
                            ID="profileimg" />
                    </div>
                    <li id="nomeUtente" class="sidebar-brand"><a href="#"></a></li>
                    <br />

                    <li><a href="InserimentoViaggi.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;Viaggi</a>
                    </li>
                    <li><a href="inserimentoVeicoli"><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Veicoli</a>
                    </li>
                    <li><a href="inserimentoCorrieri.aspx"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Corrieri</a>
                    </li>
                    <li><a href="inserimentoPacchi.aspx"><span class="glyphicon glyphicon-trash"></span>&nbsp;&nbsp;Pacchi</a>
                    </li>
                    <li><a href="Login.aspx"><span class="glyphicon glyphicon-cloud"></span>&nbsp;&nbsp;Torna al login</a>
                    </li>

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

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
