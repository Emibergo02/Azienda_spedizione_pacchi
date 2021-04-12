<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Azienda_spedizione_pacchi.LogIn" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Login V10</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" type="text/css" href="CssVari/util.css">
	<link rel="stylesheet" type="text/css" href="CssVari/main.css">

</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-50 p-b-90">
				<form class="login100-form validate-form flex-sb flex-w" id ="formLog" runat="server">
					<span class="login100-form-title p-b-51">
						Login
					</span>

					<div class="wrap-input100 validate-input m-b-16" data-validate = "Username is required">
						 <asp:TextBox ID="txtUsername" class="input100" runat="server" type="text" name="username" placeholder="Username"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
					
					
					<div class="wrap-input100 validate-input m-b-16" data-validate = "Password is required">
						<asp:TextBox ID="txtPassword" class="input100" runat="server" type="password" name="password" placeholder="Password"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
					
					<div class="flex-sb-m w-full p-t-3 p-b-24">


						<div>
							<a href="Reg.aspx" class="txt1">
								Register
							</a>
						</div>
					</div>

					<div class="container-login100-form-btn m-t-17">
						 <asp:Button ID="submitReg" class="login100-form-btn"  runat="server" Text="Login" OnClick="submitReg_Click" />
					</div>
					<asp:Literal ID="msgErr" runat="server"></asp:Literal>
				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>

</body>
</html>