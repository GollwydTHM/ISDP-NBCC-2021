<?php


$projectRoot = filter_input(INPUT_SERVER, "DOCUMENT_ROOT") . '/Bullseye';

require_once ($projectRoot . '/db/StoreTableAccessor.php');
require_once ($projectRoot . '/entity/StoreTable.php');
include_once ($projectRoot . '/utils/ChromePhp.php');

$method = filter_input(INPUT_SERVER, 'REQUEST_METHOD'); 
if ($method === "GET") {
    doGet();
} else if ($method === "POST") {
    doPost();
} else if ($method === "DELETE") {
    doDelete();
} else if ($method === "PUT") {
    doPut();
}

function doGet() {
    if (filter_has_var(INPUT_GET, 'locations')) {
        try {
            $mia = new StoreTableAccessor();
            $results = $mia->getLocations(); 
            $results = json_encode($results);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
    else if (filter_has_var(INPUT_GET, 'categories')) {
        try {
            $mia = new StoreTableAccessor();
            $results = $mia->getCategories(); 
            $results = json_encode($results);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
    else if (filter_has_var(INPUT_GET, 'locationID') && filter_has_var(INPUT_GET, 'categoryID')) {
        $locationID = filter_input(INPUT_GET, 'locationID');
        $categoryID = filter_input(INPUT_GET, 'categoryID');
        try {
            $mia = new StoreTableAccessor();
            $results = $mia->getInventoryByBoxes($locationID, $categoryID); 
            $results = json_encode($results);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }else if (filter_has_var(INPUT_GET, 'orderID')) {
        $orderID = filter_input(INPUT_GET, 'orderID');
        try {
            $mia = new StoreTableAccessor();
            $results = $mia->getTxnStatusByID($orderID); 
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
    else if (!filter_has_var(INPUT_GET, 'locationID')) {
        try {
            $mia = new StoreTableAccessor();
            $results = $mia->getAllItems(); 
            $results = json_encode($results);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
    else {
        ChromePhp::log("You are requesting game " . filter_input(INPUT_GET, 'locationID'));
    }
}
