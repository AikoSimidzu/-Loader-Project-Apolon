<?php
session_start();
include('connect.php');
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Enter</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="js/funcs.js"></script>
	<style>[class="cbalink"]{display:none;}</style>
  </head>
  <body>  
<div id="login-form">
      <h1>AUTH</h1>
        <fieldset>
            <div style="height: 20px;">
                <div class="alert" id="wrong">
                    <strong>Warn!</strong>
                </div>
            </div>
            <form method="post" id="auth">
                <input type="text" required name="login" value="LOGIN" onBlur="if(this.value=='')this.value='LOGIN'" onFocus="if(this.value=='LOGIN')this.value='' "> 
                <input type="password" required name="pass" value="AUT" onBlur="if(this.value=='')this.value='AUT'" onFocus="if(this.value=='AUT')this.value='' "> 
                <input type="submit" value="ENTER" name="sub">
            </form>
        </fieldset>
    </div> 
    
      <?php

    function href()
    {
        ?>
        <script>
            document.location.href = "/table.php";
        </script>
        <?php
    }

    if ($_POST['sub'] == true) {
        $_SESSION["login"] = htmlspecialchars($_POST['login']);
        $_SESSION["password"] = htmlspecialchars($_POST['pass']);

        if (!mysqli_connect_errno()) {
            if($result) {
                while ($row = mysqli_fetch_row($result)) {
                    if ($_SESSION["login"] == "$row[1]" & $_SESSION["password"] == "$row[2]"){
                        href();
                    }
                    else{
                        if ($_SESSION["login"] != null) {
                            echo "Bad password!!!";
                        }
                    }
                }
                mysqli_free_result($result);
            }
            exit();
        }
    }
    ?>
  </body>
</html>