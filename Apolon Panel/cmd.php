<?php
session_start();
if(!isset($_POST['login']) || isset($_POST['change']))
{
    if (!isset($_SESSION['auth']))
        exit(0);
}
include('config.php');

if (isset($_POST['login']) && isset($_POST['password']) && isset($_POST['change']))
{
    $l = mysql_real_escape_string($_POST['login']);
    $p = mysql_real_escape_string($_POST['password']);
    mysql_query("UPDATE `userinfo` SET `login`='$l', `password`='$p' WHERE `id` < 10");
    header("Location: ".$_SERVER['HTTP_REFERER']."");
}

else if (isset($_POST['login']) && isset($_POST['password']))
{
    $l = mysql_real_escape_string($_POST['login']);
    $p = mysql_real_escape_string($_POST['password']);

    if(mysql_num_rows(mysql_query("SELECT * FROM `userinfo` WHERE `login`='$l' AND `password`='$p'")) > 0){
        $_SESSION['auth'] = 'true';
        echo 'true';
        
    }     
}

else if (isset($_POST['del'])){
    mysql_query("UPDATE `files` SET `checked`='true' WHERE `id` < 999999");
    echo mysql_error();
   header("Location: ".$_SERVER['HTTP_REFERER']."");
}

else if (isset($_POST['checked'])){
    mysql_query("UPDATE `files` SET `checked`='true' WHERE `id` = ".$_POST['checked']."");
    echo mysql_error();
   header("Location: ".$_SERVER['HTTP_REFERER']."");
}
mysql_close($dbcnx);

