<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $email = $_POST["email"];
    $passwd = $_POST["password"];
	$failed_msg = [ "email_correct" => null, "password_correct" => null ];

    $query = "SELECT password FROM `users` WHERE `email` = '$email'";
    $result = $mysqli->query($query);

    if ($result->num_rows > 0) {
		$failed_msg["email_correct"] = true;
        $row = $result->fetch_assoc();

        if (password_verify($passwd, $row["password"])) {
            $query = "SELECT first_name, last_name, email, points FROM `users` WHERE `email` = '$email'";
            $result = $mysqli->query($query);
            $row = $result->fetch_assoc();
            echo json_encode($row);
        }
		else {
			$failed_msg["password_correct"] = false;
			echo json_encode($failed_msg);
		}
    }
    else {
		$failed_msg["email_correct"] = false;
        echo json_encode($failed_msg);
    }

    $mysqli->close();
?>
