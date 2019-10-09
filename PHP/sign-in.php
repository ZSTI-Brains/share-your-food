<?php
    require_once("db-connection.php");

    $email = "email@gmail.com";
    $passwd = "haslo";

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $query = "SELECT * FROM `users` WHERE `email` = '$email' AND password = '$passwd'";

    if ($result = $mysqli->query($query)) {
        if ($result->num_rows > 0) {

            $result->free_result();
            echo "Connect";
        }
        else {
            echo "Incorrect email or password, missing user!";
        }
    }
    else {
        echo "Connection error!";
    }

    $mysqli->close();  
?>