<?php
include('protect.php');

$country = $_GET['c'];

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
$countryCo = $ipwhois_result['country_code'];

$check = mysqli_query($mysqli, "SELECT * FROM `cis` WHERE `black`='$countryCo'");
if (mysqli_num_rows($check) > 0) {
    echo "YES";
}