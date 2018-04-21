<?php
session_start();

if (isset($_POST['code'])) {
    if ($_POST['code'] == $_SESSION['captcha']) {
        echo "Captcha valid";
    }
    else {
        echo "Captcha NOT valid";
    }
}

$_SESSION['captcha'] = mt_rand(10000, 99999);
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Captcha</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">


    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet">


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>

    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Anti-BOT</h3>
                    </div>
                    <div class="panel-body">
                
                        <form method="post" action="" role="form">  
<script type="text/javascript"> document.getElementById("404Found").disabled = false; </script>
                            <fieldset>
                                 <div class="form-group">
                                 <center>
  <p>Enter this number: <input class="form-control" required placeholder="<?php echo $_SESSION['captcha']; ?>" name="404Found" type="404Found" value="" style="width: 67px;" ReadOnly="True"  maxlength="1" disabled cellpadding="2" cellspacing="0"></p></center>

                                 </div>
                                <div class="form-group">
                                Enter the code above: <br>
                                    <input class="form-control" required placeholder="<?php echo $_SESSION['captcha']; ?>" name="code" type="code" value="">
                                </div>
                     
                         <div class="form-group"> 

                         </div>
                                
                                <button type="submit" name="5e8E4atBPAqhgmW06Eo8OeflvgIg" value="5e8E4atBPAqhgmW06Eo8OeflvgIg" class="btn btn-success btn-block">Entrar</button>
                            </fieldset>
                        </form>
                        <script>
function click() {
if (event.button==2||event.button==3) {
oncontextmenu='return false';
}
}
document.onmousedown=click
document.oncontextmenu = new Function("return false;")
</script>
                    </div>
                </div>
            </div>
        </div>
    </div>


</body>

</html>