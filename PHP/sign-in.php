<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $email = $_POST["email"];
    $passwd = $_POST["passwd"];
    $passwd = @crypt($passwd);

    $query = "SELECT first_name, last_name, email, points FROM `users` WHERE `email` = '$email' AND password = '$passwd'";

    if ($result = $mysqli->query($query)) {
        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc(); 
            echo json_encode($row);
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