<?php
session_start();
include('connect.php');
?>

<?php
function href()
{
    ?>
    <script>
        document.location.href = "/index.php";
    </script>
    <?php
}?>
<?php
if (!mysqli_connect_errno()) {
    if($result) {
        while ($row = mysqli_fetch_row($result)) {
            if ($_SESSION["login"] == "$row[1]" && $_SESSION["password"] == "$row[2]"){}
            else{
                $_SESSION = array();
                session_destroy();
                href();
            }
        }
        mysqli_free_result($result);
    }
}
?>