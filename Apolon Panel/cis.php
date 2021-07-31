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
    <title>CIS</title>

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
                    <li><a href="Countries.php" style="color: black">Statistic</a></li>
                    <li><a href="telegram.php" style="color: black">Telegram Notifications</a></li>
                    <li><a href="comma.php" style="color: black">CMD control</a></li>
                    <li><a href="modules.php" style="color: black">Modules</a></li>
				<li><a href="logout.php" style="color: black">Logout</a></li>

                </ul>
            </div>
        </nav>
        <div class="container">

            <form action="cmd.php" method="post">
                <input type="hidden" name="del" value="1">
            </form>
            <br>
            <table class="table table-bordered">
                <thead>
                <tr>
                    <th style="color: #000000">Country</th>
                </tr>
                </thead>
                <tbody>
                    <?php
                        $workers = mysqli_query($mysqli, "SELECT * FROM `cis`");

                        for ($i = 0; $i < mysqli_num_rows($workers); $i++)
						{
                            $curr = mysqli_fetch_assoc($workers);

                            echo
                            "
                            <tr style=\"background-color: #ffffff; opacity: 0.9;\">
                            <td><strong>".$curr['black']."</strong></td> 
                            </tr>
                            ";
                        }
                    function refresh()
                    {
                        ?>
                        <script>
                            document.location.href = "/cis.php";
                        </script>
                        <?php
                    }

                    if(isset($_POST['send']))
                    {
                        mysqli_query($mysqli, "INSERT INTO `cis` SET `black`='" . mysqli_real_escape_string($mysqli, $_POST['country']) . "'");
                        refresh();
                    }

                    if(isset($_POST['del']))
                    {
                        mysqli_query($mysqli, "DELETE FROM `cis` WHERE  `black`='" . mysqli_real_escape_string($mysqli, $_POST['country']) . "'");
                        refresh();
                    }
                    ?>
                </tbody>
            </table>
        </div>
    <div style="width:25%; margin: 0 auto;">

        <div class="well" style="opacity: 0.9; text-align:center;">
            <h4>Add country in Black List (County Code)</h4>
            <form method="POST" action="">
                <div class="form-group">
                    <form method="POST" action="">
                        <input name="country" value="Country" type="text">
                </div>
                <input type="submit" class="btn btn-primary" name="send" value="Add">
                <input type="submit" class="btn btn-primary" name="del" value="Delete">
            </form>

        </div>

        <?php
        mysqli_close($mysqli);
        ?>
    </body>
</html>