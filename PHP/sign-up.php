<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);

    $first_name = $_POST["first_name"];
    $last_name = $_POST["last_name"];
    $email = $_POST["email"];
    $passwd = $_POST["password"];

	$failed_msg = [ 
		"first_name_correct"	=> true,
		"last_name_correct"		=> true,
		"email_correct"			=> true,
		"password_correct"		=> true,
	];

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
        if (filter_var($email, FILTER_VALIDATE_EMAIL) === false)
			return false;

		return true;
    }

    $query = "SELECT * FROM `users` WHERE `email` = '$email'";
    if ($result = $mysqli->query($query)) {
        if ($result->num_rows > 0 || !checkEmail($email)) {
            $failed_msg["email_correct"] = false;
        }
		if (!checkPassword($passwd)) {
			$failed_msg["password_correct"] = false;
		}

        if ($failed_msg["password_correct"] && $failed_msg["email_correct"]) {
            $passwd = @password_hash($passwd, PASSWORD_DEFAULT);
            $query = "INSERT INTO `users`(`first_name`, `last_name`, `password`, `email`, `points`) 
					  VALUES ('$first_name', '$last_name', '$passwd', '$email', 0)";
            $mysqli->query($query);
        }
    }

    $mysqli->close();

	echo json_encode($failed_msg);
?>
