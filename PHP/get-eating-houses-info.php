<?php
    require_once("db-connection.php");

    $mysqli = new mysqli($db_server, $db_user, $db_pass, $db_name);
    $mysqli->set_charset("uft8");

    $query = "SELECT eh.name, eh.street_name, eh.house_number, eh.apartament_number, eah.latitude, eah.longitude
              FROM eating_houses AS eh JOIN eating_house_coordinates AS eah ON eh.house_id = eah.house_id";
    $result = $mysqli->query($query);

    $eh = [];
    while ($row = $result->fetch_assoc()) {
        array_push($eh, $row);
    }

    echo json_encode($eh[0]);

    $mysqli->close();
?>
