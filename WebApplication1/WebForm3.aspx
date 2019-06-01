<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sample project</title>
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome/css/font-awesome.min.css" />
    <!-- Important Owl stylesheet -->
    <link rel="stylesheet" href="owl-carousel/owl.carousel.css">
    <link rel="stylesheet" href="owl-carousel/owl.theme.css">
    <link href="css/style.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12 mt">
                <div class="grid">
                    <h3 class="pt1">REGISTER:</h3>
                    <form class="form login" runat="server">
                        <div class="form__field">
                        <label for="login__username">
                            <span class="hidden">Lastname</span></label>
                        <input id="Text4" runat="server" type="text" name="username" class="form__input" placeholder="First name" required/>
                    </div>
                        <div class="form__field">
                        <label for="login__username">
                            <span class="hidden">Username</span></label>
                        <input id="Text3" runat="server" type="text" name="username" class="form__input" placeholder="Last name" required/>
                    </div>
                    <div class="form__field">
                        <label for="login__username">
                            <span class="hidden">Username</span></label>
                        <input id="Text1" runat="server" type="text" name="username" class="form__input" placeholder="Username" required/>
                    </div>
                    <div class="form__field">
                        <label for="login__password">
                            <span class="hidden">Password</span></label>
                        <input id="Password1" runat="server" type="password" name="password" class="form__input" placeholder="Password" required />
                    </div>
                    <div class="form__field">
                        <asp:Button runat="server" Text="SignUp" onClick="done_ServerClick" Value="Sign Up" class="btn btn-lg btn-primary" style="width:100%;background-color:#337ab7;" />
                        
                    </div>
                    </form>
                    
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Include js plugin -->
    <script src="owl-carousel/owl.carousel.js"></script>
    
</body>
</html>
