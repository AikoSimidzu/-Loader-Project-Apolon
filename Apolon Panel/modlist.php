<?php
include "connect.php";

$check =  mysqli_query($mysqli, "SELECT * FROM `modules`");

while ($row = mysqli_fetch_row($check))
{
    echo "$row[0]|$row[1]<br>";
}
