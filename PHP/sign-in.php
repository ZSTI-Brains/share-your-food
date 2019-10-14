<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $email = $_POST["email"];
    $passwd = $_POST["password"];

    echo "POST: ";
    print_r($_POST);
    echo "GET: ";
    print_r($_GET);

    $query = "SELECT password FROM `users` WHERE `email` = '$email'";
    $result = $mysqli->query($query);

    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();

        if (password_verify($passwd, $row["password"])) {
            $query = "SELECT first_name, last_name, email, points FROM `users` WHERE `email` = '$email'";
            $result = $mysqli->query($query);
            $row = $result->fetch_assoc();
            echo json_encode($row);
        }
    }
    else {
        echo "Incorrect email or password!";
    }

    $mysqli->close();
?>
