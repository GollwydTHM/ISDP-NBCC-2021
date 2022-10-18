<?php
$projectRoot = $_SERVER['DOCUMENT_ROOT'] . '/Bullseye';
require_once 'ConnectionManager.php';
require_once ($projectRoot . '/entity/StoreTable.php');
require_once ($projectRoot . '/utils/ChromePhp.php');

class StoreTableAccessor {

    private $getInventoryByBoxesStatementString = "select inv.itemID, i.itemName, i.itemCategory, inv.quantity as inStock, 0 as quantity, inv.locationID from inventory inv, item i where inv.itemID = i.itemid AND inv.locationInStore = 'Storeroom' AND ItemCategory = :ItemCategory AND inv.locationID = :locationID";
    private $getTxnStatusByIDStatementString = "select txnStatus from txn where txnID = :txnID";
    private $getAllLocationsStatementString = "select locationID from location where locationID != 'SALE' AND locationType = 'Retail'";
    private $getAllCategoriesStatementString = "select itemCategory from itemcategory";
    private $insertTxnStatementString = "insert INTO txnItem (txnID, itemID, quantity) values (:txnID, :itemID, :quantity)";
    private $insertTxnItemsStatementString = "insert INTO txnItems (estimatedArrival, originalLocationID, destinationLocationID, txnType, txnStatus, note) values (NOW() + 5, 'SALE', :locationID, 'ONLINEORDER', 'SUBMITTED', :notes)";
    private $conn = NULL;
    private $getInventoryByBoxes= NULL;
    private $getTxnStatusByID = NULL;
    private $getAllLocations= NULL;
    private $getAllCategories= NULL;
    private $insertTxn = NULL;
    private $insertTxnItems = NULL;

    public function __construct() {
        $cm = new ConnectionManager();

        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
        $this->getInventoryByBoxes = $this->conn->prepare($this->getInventoryByBoxesStatementString);
        if (is_null($this->getInventoryByBoxes)) {
            throw new Exception("bad statement: '" . $this->getInventoryByBoxesStatementString . "'");
        }

        $this->getTxnStatusByID = $this->conn->prepare($this->getTxnStatusByIDStatementString);
        if (is_null($this->getTxnStatusByID)) {
            throw new Exception("bad statement: '" . $this->getTxnStatusByIDStatementString . "'");
        }

        $this->getAllLocations = $this->conn->prepare($this->getAllLocationsStatementString);
        if (is_null($this->getAllLocations)) {
            throw new Exception("bad statement: '" . $this->getAllLocationsStatementString . "'");
        }

        $this->getAllCategories = $this->conn->prepare($this->getAllCategoriesStatementString);
        if (is_null($this->getAllCategories)) {
            throw new Exception("bad statement: '" . $this->getAllCategoriesStatementString . "'");
        }

        $this->insertTxn = $this->conn->prepare($this->insertTxnStatementString);
        if (is_null($this->insertTxn)) {
            throw new Exception("bad statement: '" . $this->insertTxnStatementString . "'");
        }
        
        $this->insertTxnItems = $this->conn->prepare($this->insertTxnItemsStatementString);
        if (is_null($this->insertTxn)) {
            throw new Exception("bad statement: '" . $this->insertTxnItemsStatementString . "'");
        }
    }

    public function getItemsByQuery($selectString) {
        $result = [];
        try {
            $stmt = $this->conn->prepare($selectString);
            $stmt->execute();
            $dbresults = $stmt->fetchAll(PDO::FETCH_ASSOC);

            ChromePhp::log($dbresults);
            
            foreach ($dbresults as $r) {
                $itemID = $r['itemID'];
                $itemName = $r['itemName'];
                $itemCategory = $r['itemCategory'];
                $inStock = $r['inStock'];
                $quantity = $r['quantity'];
                $locationID = $r['locationID'];
                $obj = new StoreTable($itemID, $itemName, $itemCategory, $inStock, $quantity, $locationID);
                array_push($result, $dbresults);
            }
        } catch (Exception $e) {
            $result = [];
            array_push($result, "ERRROR");
        } finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
        return $result;
    }

 
    public function getAllItems() {
        return $this->getItemsByQuery("select inv.itemID, i.itemName, i.itemCategory, inv.quantity as inStock, 0 as quantity, inv.locationID from inventory inv, item i where inv.itemID = i.itemid AND inv.locationInStore = 'Storeroom'");
    }


    public function getInventoryByBoxes($location, $category) {
        $result = [];
        try {
            $this->getInventoryByBoxes->bindParam(":ItemCategory", $category);
            $this->getInventoryByBoxes->bindParam(":locationID", $location);
            $this->getInventoryByBoxes->execute();
            
            $dbresults = $this->getInventoryByBoxes->fetchAll(PDO::FETCH_ASSOC); 

            foreach ($dbresults as $r) {
                $itemID = $r["itemID"];
                $itemName = $r["itemName"];
                $itemCategory = $r["itemCategory"];
                $inStock = $r["inStock"];
                $quantity = $r["quantity"];
                $locationID = $r["locationID"];
                $obj = new StoreTable($itemID, $itemName, $itemCategory, $inStock, $quantity, $locationID);
                array_push($result, $obj);
            }
        } catch (Exception $e) {
            $result = [];
            array_push($result, $e);
        } finally {
            if (!is_null($this->getInventoryByBoxes)) {
                $this->getInventoryByBoxes->closeCursor();
            }
        }

        return $result;
    }
    
    public function getCategories() {
        $result = [];
        try {
            $this->getAllCategories->execute();
            $dbresults = $this->getAllCategories->fetchAll(PDO::FETCH_ASSOC);

            foreach ($dbresults as $r) {
                $itemID = $r['itemCategory'];
                array_push($result, $itemID);
            }
        } catch (Exception $e) {
            $result = NULL;
        } finally {
            if (!is_null($this->getAllLocations)) {
                $this->getAllLocations->closeCursor();
            }
        }
        return $result;
    }

    public function getLocations() {
        $result = [];
        try {
            $this->getAllLocations->execute();
            $dbresults = $this->getAllLocations->fetchAll(PDO::FETCH_ASSOC);

            foreach ($dbresults as $r) {
                $itemID = $r['locationID'];
                array_push($result, $itemID);
            }
        } catch (Exception $e) {
            $result = NULL;
        } finally {
            if (!is_null($this->getAllLocations)) {
                $this->getAllLocations->closeCursor();
            }
        }
        return $result;
    }

    public function getTxnStatusByID($id) {
        $result = NULL;
        try {
            $this->getTxnStatusByID->bindParam(":txnID", $id);
            $this->getTxnStatusByID->execute();
            $dbresults = $this->getTxnStatusByID->fetch(PDO::FETCH_ASSOC); 

            if ($dbresults) {
     
                $result = $txnStatus = $dbresults['txnStatus'];
            }
        } catch (Exception $e) {
            $result = NULL;
        } finally {
            if (!is_null($this->getTxnStatusByID)) {
                $this->getTxnStatusByID->closeCursor();
            }
        }

        return $result;
    }

}