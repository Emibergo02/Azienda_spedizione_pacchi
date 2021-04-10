<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inserimentoPacchi.aspx.cs" Inherits="Azienda_spedizione_pacchi.inserimentoPacchi" %>
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

                    <li><a href="InserimentoViaggi.aspx"><span class="glyphicon glyphicon-music"></span>&nbsp;&nbsp;<b>Viaggi</b></a>
                    </li>
                    <li><a href="inserimentoVeicoli.aspx"><span class="glyphicon glyphicon-search"></span>&nbsp;&nbsp;Veicoli</a>
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
                            <h1>Inserimento nuove consegne</h1>
                            <p>
                                Benvenuto nella pagina da amministratore per l'inserimento di nuovi veicoli. compili il form sottostante grazie.
                            </p>
                            <form id="formLog" runat="server">
                                <div class="auto-style3">
                                    <table class="auto-style2">

                                        <tr>
                                            <td>Mittente</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:DropDownList ID="mittente" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Destinatario</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="destinatario" runat="server"></asp:DropDownList>
                                        </tr>
                                        <tr>
                                            <td>Volume in cm^3</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="volume" class="auto-style5" runat="server"  TextMode="Number" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Viaggio </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="viaggio" runat="server"></asp:DropDownList>
                                        </tr>
                                        
                                       
                                        <tr>
                                            <td class="auto-style7">
                                                <asp:Button ID="submitReg" runat="server" Text="Inserisci" OnClick="submitReg_Click"  />
                                                <asp:Literal ID="msgErrorRegister" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </form>


                        </div>
                    </div>
                </div>
            </div>
        </div>
</body>
</html>
