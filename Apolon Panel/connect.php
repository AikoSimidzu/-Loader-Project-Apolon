<?php
session_start();
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
</head>
<body>
<?php
$host = "localhost";
$user = "mysql";
$pass = "mysql";
$bdn = "apolon";

$mysqli = mysqli_connect($host, $user, $pass, $bdn);
$result = mysqli_query($mysqli, "SELECT * FROM userinfo") or die("Ошибка " . mysqli_error($mysqli));

if (mysqli_connect_errno()) {
    exit();
}
?>
</body>
</html>