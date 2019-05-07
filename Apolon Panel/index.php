<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title></title>
    <link href="css/style.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="js/funcs.js"></script>
	<style>[class="cbalink"]{display:none;}</style>
  </head>
  <body>
  
<?php
session_start();
if($_SESSION['auth'] == 'true')
    header("Location: /table.php");

?>

<div id="login-form">
      <h1>АВТОРИЗАЦИЯ</h1>
        <fieldset>
            <div style="height: 20px;">
                <div class="alert" id="wrong">
                    <strong>Не правильный пароль!</strong>
                </div>
            </div>
            <form method="post" id="auth">
                <input type="text" required name="login" value="LOGIN" onBlur="if(this.value=='')this.value='LOGIN'" onFocus="if(this.value=='LOGIN')this.value='' "> 
                <input type="password" required name="password" value="Пароль" onBlur="if(this.value=='')this.value='Пароль'" onFocus="if(this.value=='Пароль')this.value='' "> 
                <input type="submit" value="ВОЙТИ">
            </form>
        </fieldset>
    </div> 
    <script>
        $("#auth").submit(function(e) {
            var url = "cmd.php"; // the script where you handle the form input.

            $.ajax({
                type: "POST",
                url: url,
                data: $("#auth").serialize(), // serializes the form's elements.
                success: function(data)
                {
                    if(data == 'true')
                        location.href = '/table.php';
                    else
                        err(); // show response from the php script.
                }
                });

            e.preventDefault(); // avoid to execute the actual submit of the form.
        });
    </script>
  </body>
</html>