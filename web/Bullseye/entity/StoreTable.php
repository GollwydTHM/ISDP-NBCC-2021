<?php

class StoreTable implements JsonSerializable {

    private $itemID;
    private $itemName;
    private $itemCategory;
    private $inStock;
    private $quantity;
    private $locationID;

    function __construct($itemID, $itemName, $itemCategory, $inStock, $quantity, $locationID) {
        $this->itemID = $itemID;
        $this->itemName = $itemName;
        $this->itemCategory = $itemCategory;
        $this->inStock = $inStock;
        $this->quantity = $quantity;
        $this->locationID = $locationID;
    }

    function getItemID() {
        return $this->itemID;
    }

    function getItemName() {
        return $this->itemName;
    }

    function getItemCategory() {
        return $this->itemCategory;
    }

    function getInstock() {
        return $this->inStock;
    }

    function getQuantity() {
        return $this->quantity;
    }

    function getLocationID() {
        return $this->locationID;
    }
    
    public function jsonSerialize() {
        return get_object_vars($this);
    }

}

