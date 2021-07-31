<?php
include "connect.php";

$result = mysqli_query($mysqli, "SELECT * FROM console");

while ($row = $result->fetch_assoc()) {
    echo $row['command'];
}