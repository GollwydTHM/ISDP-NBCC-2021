<?php

class ConnectionManager {

    public function connect_db() {
        $db = new PDO("mysql:host=localhost;dbname=bullseye2021", "root", "TSOMI#1990gt");
        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        return $db;
    }

}
