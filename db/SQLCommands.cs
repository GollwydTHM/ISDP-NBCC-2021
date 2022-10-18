using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_AlexanderK.db
{
    public class SQLCommands
    {
        public const string LOCATION = "SELECT * FROM location";
        public const string LOCATIONCOMBOBOX = "SELECT locationID FROM location WHERE active = 1";
        public const string LOCATIONCLASS = "SELECT locationID, locationType, defaultDeliveryDay FROM location";
        
        public const string INVENTORY = "SELECT * FROM inventory iv, item it WHERE iv.itemID = it.itemID";

        public const string USER = "SELECT * FROM user WHERE active = 1";
        public const string USERCLASS = "SELECT userID, firstName, lastName, email, locationID, roleID FROM user WHERE active = 1 AND username = ";

        public const string ORDERLIST = "SELECT * FROM txn WHERE txnType != 'SUPPLIERORDER' AND txnStatus != ";
        public const string ORDERPOPULATEITEM = "SELECT inv.itemID, quantity, reorderAmount, reorderLevel, i.caseSize FROM inventory inv, item i WHERE inv.itemID = i.itemid AND quantity < reorderLevel AND inv.active = 1 AND i.active = 1 AND locationID = ";
       
        public const string ITEMSLIST = "SELECT txnID, ti.itemID, i.itemName, quantity, (quantity * i.caseSize) as total FROM txnItem ti, item i WHERE ti.itemID = i.itemID AND txnID = ";
        public const string TXNITEMINSERT = "INSERT INTO txnItem (txnID, itemID, quantity) VALUES ";

        public const string VEHICLETYPECLASS = "SELECT vehicleTypeID, description, weightLimit FROM vehicletype WHERE vehicleTypeID != 'Pickup' order by weightLimit ";

        public const string WAREHOUSEPROCESSLIST = "SELECT ti.txnID, ti.itemID, ti.quantity, (ti.quantity * i.caseSize) AS orderQuant, inv.inventoryID, inv.quantity AS invQuant, tx.txnType FROM txnItem ti, inventory inv, item i, txn tx WHERE tx.txnID = ti.txnID AND ti.itemID = inv.itemID AND inv.itemID = i.itemid AND inv.locationID = 'WARE' AND inv.active = 1 AND i.active = 1 AND ti.txnID = ";
        public const string CHECKBACKORDER = "SELECT txnID from txn where txnType = 'BACKORDER' and destinationLocationID = ";

        public const string DELETETXNITEM = "DELETE FROM txnItem WHERE itemID IN ";

        public const string CALCULATEWEIGHT = "SELECT sum((ti.quantity * i.weight)) AS CARRY FROM txn tx, txnItem ti, item i WHERE ti.itemID = i.itemID AND tx.txnID = ti.txnID AND tx.txnStatus = 'READY' AND tx.estimatedArrival = ";

        public const string TRANSACTIONTYPE = "SELECT * FROM transactiontype";

        public const string DELIVERYLIST = "SELECT * FROM delivery WHERE deliveryDate = ";
        public const string ROUTELIST = "SELECT dr.deliveryID, dr.routeID FROM deliveryroutes dr, route r WHERE dr.routeID = r.routeID AND deliveryID = ";

        public const string PRODUCTSDGV = "SELECT itemid, description, itemCategory, caseSize, sku, itemName, s.supplierName, costPrice, retailPrice, weight, i.note, i.active FROM item i, supplier s WHERE s.supplierID = i.supplierID and i.supplierID = ";

        public const string SUPPLIERCLASS = "SELECT supplierID, supplierName FROM supplier";

        public const string CATEGORYCLASS = "select * from itemcategory";

        public const string SUPPLIERORDERSLIST = "SELECT * FROM txn WHERE txnType = 'SUPPLIERORDER' AND txnStatus != 'CLOSED' AND txnStatus != 'CANCELLED'";

        public const string SUPPLIERORDERPOPULATEITEM = "SELECT inv.itemID, quantity, reorderAmount, reorderLevel, i.caseSize FROM inventory inv, item i WHERE inv.itemID = i.itemid AND quantity < reorderLevel AND inv.active = 1 AND i.active = 1 AND locationID = 'WARE'";
        public const string SUPPLIERITEMSLIST = "SELECT txnID, ti.itemID, i.itemName, s.supplierName, quantity, i.caseSize FROM txnItem ti, item i, supplier s WHERE ti.itemID = i.itemID AND s.supplierID = i.supplierID AND txnID = ";

        public const string ORDERDELIVERYLIST = "SELECT * FROM txn tx, deliverytxns dtx WHERE tx.txnID = dtx.txnID AND dtx.deliveryID = ";

        public const string MESSAGERECEIVERLIST = "SELECT messageID, senderID, u.username, receiverID, startDate, endDate, transactionID, details FROM message m, user u WHERE m.senderID = u.userID AND receiverID = ";
        public const string MESSAGEUSERLIST = "SELECT userID, username, firstName, lastName, locationID, email, r.description FROM user u, role r WHERE u.roleID = r.roleID";
        public const string MESSAGEORDERLIST = "SELECT * FROM txn";

        public const string LOSSRETURNVIEW = "select tx.txnID, txnType, creationDate, originalLocationID, ti.itemID, ti.quantity, i.itemName, i.description, tx.note from txn tx, txnitem ti, item i WHERE tx.txnID = ti.txnID AND ti.itemID = i.itemid AND tx.txnType = ";

    }
}
