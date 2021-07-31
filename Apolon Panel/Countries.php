<?php
session_start();
include('protect.php');
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Countries statistic</title>

    <!-- Bootstrap -->

    <link href="css/style_table.css" rel="stylesheet">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="js/bootstrap.js"></script>
	<style>[class="cbalink"]{display:none;}</style>
  </head>
    <body style = "background-color: #ffffff">
    <nav class="navbar navbar-inverse";">
        
            <div class="container-fluid" style = "background-color: #ffffff">               
                <ul class="nav navbar-nav">
				<li><a href="table.php" style="color: black">Panel</a></li>
                    <li><a href="loader.php" style="color: black">Loader</a></li>
                    <li><a href="telegram.php" style="color: black">Telegram Notifications</a></li>
                    <li><a href="cis.php" style="color: black">CIS</a></li>
                    <li><a href="comma.php" style="color: black">CMD control</a></li>
                    <li><a href="modules.php" style="color: black">Modules</a></li>
				<li><a href="logout.php" style="color: black">Logout</a></li>
                
                </ul>
            </div>
        </nav>
        <div class="container">
           <div class="row">
                <?php
                $logs = 0;       
                $q = mysqli_query($mysqli, "SELECT * FROM `bots` WHERE `checked`='false'");

                $logs = mysqli_num_rows($q);
                for ($i = 0; $i < $logs; $i++)
                {
                    $log = mysqli_fetch_assoc($q);              
                }
                print 
                '
                <div style="color: black; font-size: 15pt">All bots:'.$logs.'</div>
                ';
                ?>
            </div>
            <form action="cmd.php" method="post">
                <input type="hidden" name="del" value="1">
            </form> 
            <br>          
            <table class="table table-bordered">
                <thead>
                <tr>
                    <th style="color: black">Country</th>
                    <th style="color: black">Value</th>
                    <th style="color: black">%</th>
                </tr>					
                </thead>
                <tbody>
                    <?php
                        $workers;
                        $p1 = 0;
                        $p2 = 0;
                        if(isset($_GET['p'])){
                            $p1 = $_GET['p'];
                            $t1 = $_GET['p'] * 10;
                            $workers = mysqli_query("SELECT * FROM `countries` ORDER BY `country` DESC LIMIT $t1, 10");
                        }
                        else{
                            $workers = mysqli_query($mysqli, "SELECT * FROM `countries` ORDER BY `country` DESC LIMIT 10");
                        }
                        
                        for ($i = 0; $i < mysqli_num_rows($workers); $i++)
						{
                            $curr = mysqli_fetch_assoc($workers);

                            echo
                            "
                            <tr style=\"background-color: #ffffff; opacity: 0.9;\">
                            <td><strong>".$curr['country']."</strong></td>
                            <td><strong>".$curr['value']."</strong></td>
                            <td><strong>".$curr['value'] / $logs * 100 ."</strong></td>
                            </tr>
                            ";
                        }
                         if(mysqli_num_rows(mysqli_query($mysqli, "SELECT * FROM `countries`")) > 10){
                            $p11 = $p1 - 1;
                            $p1 += 1;
                            echo
                            "
                            <ul class=\"pager\">
                                <li><a href=\"?p=$p11\">Back</a></li>
                                <li><a href=\"?p=$p1\">Next</a></li>
                            </ul>
                            ";
                        }

                    ?>
                </tbody>
            </table>
        </div>
		
        <?php
        mysqli_close($mysqli);
        ?>
    </body>
</html>