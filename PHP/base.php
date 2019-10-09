<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $query = "SELECT * FROM `users`";

    if ($result = $mysqli->query($query)) {
        while ($row = $result->fetch_assoc())
            echo $row["email"] . " " . $row["password"] . " " . $row["first_name"] . " " . $row["last_name"] . "<br>"; 

        $result->free_result();
    }
    else {
        echo "Connection error!";
    }
?>
