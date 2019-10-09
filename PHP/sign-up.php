<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);


    $first_name = "Dorian";
    $last_name = "Hanselwield";
    $email = "dsadsadada@gdsaddsaaaildsad.com";
    $passwd = "eStfdsfs0";

    $query = "SELECT * FROM `users` WHERE `email` = '$email'";
    if ($result = $mysqli->query($query)) {
        if ($result->num_rows > 0) {
            echo "Email exists.";
        }
        else {
            if (ereg('^[a-zA-Z0-9]{8,55}$',$passwd)) {
                $query = "INSERT INTO `users`(`user_id`, `first_name`, `last_name`, `password`, `email`) VALUES ('','$first_name', '$last_name', '$passwd','$email')";
                $mysqli->query($query);
                echo "Account created successful!";
            }
            else {
                echo "Wrong password!";
            }
            
        }
    }
    $mysqli->close();
?>
