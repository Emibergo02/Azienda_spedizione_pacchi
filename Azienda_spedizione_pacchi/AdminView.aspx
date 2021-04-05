<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="Azienda_spedizione_pacchi.AdminView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
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
                    <li class="sidebar-brand"><a href="#">Start Bootstrap </a></li>
                    <br />

                    <li><a href="Music.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;Music</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Search</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Contacts</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-trash"></span>&nbsp;&nbsp;Delete it!</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-cloud"></span>&nbsp;&nbsp;Cloud</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-refresh"></span>&nbsp;&nbsp;Refresh</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-print"></span>&nbsp;&nbsp;Printing</a>
                    </li>
                    <li><a href="#"><span class="glyphicon glyphicon-off"></span>&nbsp;&nbsp;Logout !!!!</a>
                    </li>
                </ul>
            </div>
            <!-- /#sidebar-wrapper -->
            <!-- Page Content -->
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1>Simple Sidebar</h1>
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
