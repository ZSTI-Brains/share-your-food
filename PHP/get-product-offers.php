<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);
	$mysqli->set_charset("utf8");

    $query = "SELECT po.name, po.discount, poo.name AS offeror_name FROM product_offers AS po 
			  JOIN product_offerors AS poo ON po.offeror_id = poo.offeror_id GROUP BY po.offeror_id, po.discount";
    $result = $mysqli->query($query);

	$arr = array();

	while ($row = $result->fetch_assoc()) {
		$arr[] = $row;
	}

	echo json_encode($arr, JSON_UNESCAPED_UNICODE);

    $mysqli->close();
?>
