<?php
include('connect.php');

    function Clean()
    {
        ?>
        <script>
location = 'javascript:document.write();\n\
document.close()'
</script>
        <?php
    }
?>

<?php
$token;
$chatid;

$res = mysqli_query($mysqli,"SELECT * FROM `telegram`");
while ($row = mysqli_fetch_row($res))
{
    $token = "$row[0]";
    $chatid = "$row[1]";
    break;
}

function send_mess($text, $token, $chatid)
{
    if($text != null){
        $url = "https://api.telegram.org/bot" . $token . "/sendMessage";
        $ch = curl_init();

        $data = array(
            'chat_id' => $chatid,
            'text' => $text,
        );

        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_POST, 1);
        curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 10);
        curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
        curl_exec($ch);
        curl_close($ch);
    }
    else
    {
        echo 'Text: null';
    }
}
?>