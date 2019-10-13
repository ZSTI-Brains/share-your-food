<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $first_name = $_POST["first_name"];
    $last_name = $_POST["last_name"];
    $email = $_POST["email"];
    $passwd = $_POST["password"];

    $query = "SELECT * FROM `users` WHERE `email` = '$email'";
    if ($result = $mysqli->query($query)) {
        if ($result->num_rows > 0) {
            echo "Email exists.";
        }
        else {
            if (checkPassword($passwd) && checkEmail($email)) {
                $passwd = @password_hash($passwd, PASSWORD_DEFAULT);
                $query = "INSERT INTO `users`(`user_id`, `first_name`, `last_name`, `password`, `email`, `points`) VALUES ('', '$first_name', '$last_name', '$passwd', '$email', 0)";
                $mysqli->query($query);
                echo "Account created successful!";
            }
            else {
                echo "Wrong password or emial!";
            }
        }
    }
    $mysqli->close();

    function checkPassword($passwd) {
        $length = strlen($passwd);
        $h_letter = 0;
        $n_letter = 0;
        if ($length >= 8) {
            for ($i = 0; $i < $length; $i++) {
                if ($passwd[$i] >= "A" && $passwd[$i] <= "Z")
                    $h_letter++;
                else if ($passwd[$i] >= "0" && $passwd[$i] <= "9")
                    $n_letter++;
            }

            if ($h_letter > 0 && $n_letter > 0)
                return true;
            else
                return false;
        }
        else {
            return false;
        }
    }
    function checkEmail($email) {
        if (filter_var($email, FILTER_VALIDATE_EMAIL))
            return true;
        return false;
    }
?>
