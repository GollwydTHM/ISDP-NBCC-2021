using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class OrdersForm : Form
    {
        private string addOrEdit;
        private bool canCreateBackOrder;
        private bool canMoveInventory = false;
        private DBConnection dbCon = new DBConnection();
        private ArrayList locations = new ArrayList();
        private User user = new User();
        private Location userLocation = new Location();
        private ArrayList vehicles = new ArrayList();

        public OrdersForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void AcceptDeliveryOrder()
        {
            MySqlCommand updateLocationInventory = new MySqlCommand("Update inventory inv SET inv.quantity = IFNULL((select (txi.quantity * i.caseSize) + inv.quantity " +
                $"FROM txnItem txi, item i where i.itemID = txi.itemID AND txi.txnID = '{txtOrderID.Text}' AND txi.itemID = inv.itemID), inv.quantity) " +
                $"where inv.locationID = '{txtOrigin.Text}'", dbCon.Connection);
            updateLocationInventory.ExecuteNonQuery();
            updateLocationInventory.Dispose();

            MySqlCommand updateVehicleInventory = new MySqlCommand("Update inventory inv SET inv.quantity = IFNULL((select inv.quantity - (txi.quantity * i.caseSize)" +
                $"FROM txnItem txi, item i where i.itemID = txi.itemID AND txi.txnID = '{txtOrderID.Text}' AND txi.itemID = inv.itemID), inv.quantity) " +
                $"where inv.locationID = 'VHCL'", dbCon.Connection);
            updateVehicleInventory.ExecuteNonQuery();
            updateVehicleInventory.Dispose();

            new Audit("Order Accepted", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} was accepted by location {txtOrigin.Text}");

            btnNext.Enabled = false;
        }

        private void BackorderCreation(string location)
        {
            if (canCreateBackOrder)
            {
                Location loc = new Location();
                foreach (Location item in locations)
                {
                    if (item.LocationID == txtOrigin.Text)
                    {
                        loc = item;
                        break;
                    }
                }

                string estimated = EstimateDate(loc.DefaultDeliveryDay, DateTime.Parse(txtArrivalDate.Text).ToString("yyyy-MM-dd"));
                MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txn SET txnType = 'BACKORDER', estimatedArrival = '{estimated}', " +
                    $"originalLocationID = 'WARE', destinationLocationID = '{location}',  txnStatus = 'NEW'", dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();

                PopulateDGV("Orders");
            }
            else
            {
                MessageBox.Show("You don't have permission to create a Backorder!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrEdit = "add";
            nudItemID.Value = nudItemID.Minimum;
            nudItemID.Enabled = true;
            nudQuantity.Value = nudQuantity.Minimum;
            EnableEdit(true);
        }

        private void btnBackorder_Click(object sender, EventArgs e)
        {
            if (canCreateBackOrder)
            {
                string id = CheckBackorder(txtOrigin.Text);

                if (CheckBackorder(txtOrigin.Text) == "")
                {
                    BackorderCreation(txtOrigin.Text);
                    id = CheckBackorder(txtOrigin.Text);
                }

                new Audit("Backorder created", user.UserID, id, $"Backorder {id} for location {txtOrigin.Text} was created");

                MySqlCommand backorderInsert = new MySqlCommand(SQLCommands.TXNITEMINSERT + $"({id}, {nudItemID.Value}, {nudQuantity.Value})", dbCon.Connection);
                backorderInsert.ExecuteNonQuery();
                backorderInsert.Dispose();

                MySqlCommand DeleteOrderItems = new MySqlCommand(SQLCommands.DELETETXNITEM + $"({nudItemID.Value}) AND txnID = {txtOrderID.Text}", dbCon.Connection);
                DeleteOrderItems.ExecuteNonQuery();
                DeleteOrderItems.Dispose();

                MySqlCommand backorderNotes = new MySqlCommand($"Update txn SET note = IFNULL(CONCAT(note, ', {nudItemID.Value}'), " +
                    $"'Backorder Items: {nudItemID.Value}') where txnID = {txtOrderID.Text}", dbCon.Connection);
                backorderNotes.ExecuteNonQuery();
                backorderNotes.Dispose();

                PopulateDGV("Items");
            }
            else
                MessageBox.Show("You don't have permission to create a Backorder!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableEdit(false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool duplicated = false;

            //check duplicated entry
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                if (dgvOrders.Rows[i].Cells[1].Value.ToString() == cbxTransaction.Text && dgvOrders.Rows[i].Cells[7].Value.ToString() == "NEW")
                {
                    duplicated = true;
                }
            }

            if (!duplicated)
            {
                string estimated = "";
                if (cbxTransaction.Text == "EMERGENCY")
                     estimated = "estimatedArrival = CURDATE() + INTERVAL 1 DAY, ";
                else if (userLocation.DefaultDeliveryDay != "")
                    estimated = $"estimatedArrival = '{EstimateDate(userLocation.DefaultDeliveryDay, "Now()")}', ";

                MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txn SET txnType = '{cbxTransaction.Text}', {estimated}" +
                    $"originalLocationID = '{cbxLocation.Text}', destinationLocationID = 'WARE',  txnStatus = 'NEW'", dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();
                PopulateDGV("Orders");

                if (dgvOrders.Rows.Count > 0)
                    dgvOrders.Rows[dgvOrders.Rows.Count - 1].Selected = true;

                if (cbxTransaction.Text == "ORDER")
                    PopulateOrderItems();

                new Audit("Create Order", user.UserID, txtOrderID.Text.ToString(), $"{cbxTransaction.Text} Order n.{txtOrderID.Text} was created");
            }
            else
            {
                MessageBox.Show($"Can't create an order of type '{cbxTransaction.Text}' cause there is already one with the status 'NEW' created.",
                    "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeVisibility("Items");
            PopulateDGV("Items");
            if (txtOrderType.Text == "BACKORDER")
            {
                btnBackorder.Enabled = false;
            }
        }

        private void btnItemEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = "edit";
            nudItemID.Enabled = false;
            EnableEdit(true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckPermissions();
            ProcessChange(txtOrderID.Text, txtStatus.Text, txtOrigin.Text);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ChangeVisibility("Orders");
            PopulateDGV("Orders");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addOrEdit == "add")
            {
                bool duplicated = false;
                //check duplicated entry
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (dgvItems.Rows[i].Cells[1].Value.ToString() == nudItemID.Value.ToString())
                    {
                        duplicated = true;
                    }
                }

                if (!duplicated)
                {
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txnItem SET txnID = {txtOrderID.Text}, " +
                        $"itemID = {nudItemID.Value}, quantity = {nudQuantity.Value}", dbCon.Connection);

                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit("Item added to order", user.UserID, txtOrderID.Text.ToString(), $"Items {nudItemID.Value} was added to order ID: {txtOrderID.Text}");

                    PopulateDGV("Items");
                    EnableEdit(false);
                }
                else
                {
                    MessageBox.Show($"Can't add an Item that already exists in the order: '{nudItemID.Value.ToString()}'",
                        "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MySqlCommand editCommand = new MySqlCommand();
                editCommand.Connection = dbCon.Connection;

                if (nudQuantity.Value == 0)
                {
                    editCommand.CommandText = SQLCommands.DELETETXNITEM + $"({nudItemID.Value})";
                    new Audit("Item deleted from order", user.UserID, txtOrderID.Text, $"Items {nudItemID.Value} was deleted from order ID: {txtOrderID.Text}");
                }
                else
                {
                    editCommand.CommandText = $"UPDATE txnItem SET quantity = {nudQuantity.Value} where itemID = {nudItemID.Value}";
                    new Audit("Item quantity changed", user.UserID, txtOrderID.Text, $"Items {nudItemID.Value} in order {txtOrderID.Text} changed to {nudQuantity.Value}");
                }

                editCommand.ExecuteNonQuery();
                editCommand.Dispose(); ;
                PopulateDGV("Items");
                EnableEdit(false);
            }
        }

        private string[] CalculateWeight(string text)
        {
            bool success = false;
            int weight = 0;
            string vehicleID = "";
            string estimated = DateTime.Parse(txtArrivalDate.Text).ToString("yyyy-MM-dd");
            string txnString = text == "" ? "" : $"AND tx.txnID = '{text}'";

            //estimated and status == "ready"
            MySqlDataReader weightSDR = new MySqlCommand(SQLCommands.CALCULATEWEIGHT + $"'{estimated}' {txnString}", dbCon.Connection).ExecuteReader();
            if (weightSDR.Read())
            {
                weight = weightSDR.GetInt32(0);
            }
            weightSDR.Close();

            foreach (VehicleType vehicle in vehicles)
            {
                if (weight < vehicle.WeightLimit)
                {
                    vehicleID = vehicle.VehicleTypeID;
                    break;
                }
            }

            if (vehicleID != "")
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET vehicleTypeID = '{vehicleID}' WHERE estimatedArrival = '{estimated}' AND txnStatus = 'READY'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

                new Audit("Vehicle type updated", user.UserID, "", $" Vehicle type update to {vehicleID} for orders with Status READY and Arrival Date {estimated}");

                success = true;
            }

            string[] res = { success.ToString(), weight.ToString(), vehicleID };

            return res;
        }

        private void cbxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeUserLocation();

            PopulateDGV("Orders");
        }

        private void ChangeUserLocation()
        {
            foreach (Location item in locations)
            {
                if (item.LocationID == cbxLocation.Text)
                {
                    userLocation = item;
                    break;
                }
            }
        }

        private void ChangeVisibility(string change)
        {
            if (change == "Items")
            {
                dgvOrders.Visible = false;
                grbOrder.Enabled = false;
                grbOrder.Visible = false;
                grbOrderButtons.Enabled = false;
                grbOrderButtons.Visible = false;
                dgvItems.Visible = true;
                grbItem.Visible = true;
                grbItemsButtons.Enabled = true;
                grbItemsButtons.Visible = true;
            }
            else
            {
                dgvOrders.Visible = true;
                grbOrder.Enabled = true;
                grbOrder.Visible = true;
                grbOrderButtons.Enabled = true;
                grbOrderButtons.Visible = true;
                dgvItems.Visible = false;
                grbItem.Visible = false;
                grbItemsButtons.Enabled = false;
                grbItemsButtons.Visible = false;
            }
        }

        private string CheckBackorder(string location)
        {
            string id = "";
            MySqlDataReader CheckBackorderSDR = new MySqlCommand(SQLCommands.CHECKBACKORDER + $"'{location}' AND txnStatus = 'NEW'", dbCon.Connection).ExecuteReader();
            if (CheckBackorderSDR.Read())
            {
                id = CheckBackorderSDR.GetString(0);
            }
            CheckBackorderSDR.Close();

            return id;
        }

        private void CheckPermissions()
        {
            btnNext.Enabled = false;
            btnEdit.Enabled = false;
            grbOrderButtons.Enabled = false;
            btnCreate.Enabled = false;
            btnBackorder.Enabled = false;

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {
                    case "CREATESTOREORDER":
                        grbOrderButtons.Enabled = true;
                        btnCreate.Enabled = true;
                        if (txtStatus.Text == "NEW" && txtOrigin.Text == cbxLocation.Text)
                        {
                            btnEdit.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        break;

                    case "RECEIVESTOREORDER":
                        grbOrderButtons.Enabled = true;
                        if (txtStatus.Text == "SUBMITTED")
                        {
                            btnNext.Enabled = true;
                        }
                        break;

                    case "PREPARESTOREORDER":
                        grbOrderButtons.Enabled = true;
                        if (txtStatus.Text == "RECEIVED")
                        {
                            btnNext.Enabled = true;
                            btnEdit.Enabled = true;
                        }
                        break;

                    case "MOVEINVENTORY":
                        canMoveInventory = true;
                        break;

                    case "CREATEBACKORDER":
                        canCreateBackOrder = true;
                        break;

                    case "ADDITEMTOBACKORDER":
                        btnBackorder.Enabled = true;
                        break;

                    case "FULFILSTOREORDER":
                        if (txtStatus.Text == "PROCESSING")
                        {
                            btnEdit.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        break;

                    case "ACCEPTSTOREORDER":
                        if (txtStatus.Text == "DELIVERED")
                        {
                            btnNext.Enabled = true;
                        }
                        break;
                }
            }
        }

        private bool CheckSubmitted()
        {
            bool check = true;

            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                string id = dgvOrders.Rows[i].Cells[0].Value.ToString();
                string type = dgvOrders.Rows[i].Cells[1].Value.ToString();
                string origin = dgvOrders.Rows[i].Cells[5].Value.ToString();
                string status = dgvOrders.Rows[i].Cells[7].Value.ToString();

                if (id != txtOrderID.Text && origin == txtOrigin.Text && type == txtOrderType.Text && status != "NEW" && status != "READY")
                    check = false;
            }

            return check;
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                nudItemID.Value = decimal.Parse(dgvItems.SelectedRows[0].Cells[1].Value.ToString());
                nudQuantity.Value = decimal.Parse(dgvItems.SelectedRows[0].Cells[3].Value.ToString());
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];

                txtOrderID.Text = row.Cells[0].Value.ToString();
                txtOrderType.Text = row.Cells[1].Value.ToString();
                txtCreationDate.Text = row.Cells[2].Value.ToString();
                txtArrivalDate.Text = row.Cells[3].Value.ToString();
                txtVehicle.Text = row.Cells[4].Value.ToString();
                txtOrigin.Text = row.Cells[5].Value.ToString();
                txtDestination.Text = row.Cells[6].Value.ToString();
                txtStatus.Text = row.Cells[7].Value.ToString();
                txtOrderNote.Text = row.Cells[8].Value.ToString();
            }

            CheckPermissions();
        }

        private void EnableEdit(bool enable)
        {
            if (enable)
            {
                grbItem.Enabled = true;
                grbItemsButtons.Enabled = false;
            }
            else
            {
                grbItem.Enabled = false;
                grbItemsButtons.Enabled = true;
            }
        }

        private string EstimateDate(string defaultDeliveryDay, string now)
        {
            int number = 0;
            string date = "";
            DateTime dateTemp;

            switch (defaultDeliveryDay)
            {
                case "MONDAY":
                    number = 2;
                    break;

                case "TUESDAY":
                    number = 3;
                    break;

                case "WEDNESDAY":
                    number = 4;
                    break;

                case "THURSDAY":
                    number = 5;
                    break;

                case "FRIDAY":
                    number = 6;
                    break;

                default:
                    break;
            }

            if (number > 0)
            {
                if (now != "Now()")
                    now = "'" + now + "'";

                MySqlDataReader dateSDR = new MySqlCommand($"select date(adddate({now}, {number} - dayofweek({now}) + " +
                    $"case when dayofweek({now}) < {number} then 0 else 7 end ))", dbCon.Connection).ExecuteReader();

                if (dateSDR.Read())
                {
                    dateTemp = dateSDR.GetDateTime(0);
                    date = dateTemp.ToString("yyyy-MM-dd");
                }
                dateSDR.Close();
            }

            return date;
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void LoadHelpfulClasses()
        {
            //Location Class
            MySqlDataReader locationSDR = new MySqlCommand(SQLCommands.LOCATIONCLASS, dbCon.Connection).ExecuteReader();
            while (locationSDR.Read())
            {
                Location locTemp = new Location();

                locTemp.LocationID = locationSDR.GetString(0);
                locTemp.LocationType = locationSDR.GetString(1);
                if (!locationSDR.IsDBNull(2))
                    locTemp.DefaultDeliveryDay = locationSDR.GetString(2);
                else
                    locTemp.DefaultDeliveryDay = "";

                locations.Add(locTemp);
            }
            locationSDR.Close();

            //Vehicle Class
            MySqlDataReader vehicleSDR = new MySqlCommand(SQLCommands.VEHICLETYPECLASS, dbCon.Connection).ExecuteReader();
            while (vehicleSDR.Read())
            {
                VehicleType vehicleTemp = new VehicleType();

                vehicleTemp.VehicleTypeID = vehicleSDR.GetString(0);
                vehicleTemp.Description = vehicleSDR.GetString(1);
                vehicleTemp.WeightLimit = vehicleSDR.GetDouble(2);

                vehicles.Add(vehicleTemp);
            }
            vehicleSDR.Close();
        }

        private void nudItemID_ValueChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"select * from item where active = '1' and itemID='{nudItemID.Value.ToString()}'", dbCon.Connection);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtDescription.Text = sdr.GetString(1);
                txtItemCategory.Text = sdr.GetString(2);
                txtCase.Text = sdr.GetString(3);
                txtSKU.Text = sdr.GetString(4);
                txtItemName.Text = sdr.GetString(5);
                txtSupplier.Text = sdr.GetString(6);
                txtCost.Text = sdr.GetString(7);
                txtRetail.Text = sdr.GetString(8);
                txtWeight.Text = sdr.GetString(9);
            }
            else
            {
                txtDescription.Text = "";
                txtItemCategory.Text = "";
                txtCase.Text = "";
                txtSKU.Text = "";
                txtItemName.Text = "";
                txtSupplier.Text = "";
                txtCost.Text = "";
                txtRetail.Text = "";
                txtWeight.Text = "";
            }
            sdr.Close();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                LoadHelpfulClasses();
                PopulateComboBox();
                ChangeUserLocation();
                PopulateDGV("Orders");
                CheckPermissions();
            }
        }

        private void PopulateComboBox()
        {
            //populate location combobox
            MySqlDataReader locationsDR = new MySqlCommand(SQLCommands.LOCATIONCOMBOBOX, dbCon.Connection).ExecuteReader();
            while (locationsDR.Read())
            {
                cbxLocation.Items.Add(locationsDR.GetString(0));
            }
            locationsDR.Close();

            if (user.RoleID == "999")
            {
                cbxLocation.Enabled = true;
                cbxLocation.Text = "WARE";
            }
            else
                cbxLocation.Text = user.LocationID;
            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {
                    case "CREATESTOREORDER":
                        cbxTransaction.Items.Add("ORDER");
                        cbxTransaction.Items.Add("EMERGENCY");
                        cbxTransaction.Text = "ORDER";
                        break;

                    case "CREATEBACKORDER":
                        cbxTransaction.Items.Add("BACKORDER");
                        cbxTransaction.Text = "BACKORDER";
                        break;
                }
            }
        }

        private void PopulateDGV(string dgv)
        {
            string command = dgv == "Orders" ? SQLCommands.ORDERLIST + "'CLOSED' AND txnStatus != 'CANCELLED'" : SQLCommands.ITEMSLIST + $"'{txtOrderID.Text}'";

            if (dgv == "Orders")
            {
                switch (userLocation.LocationType)
                {
                    case "Retail":
                        command = SQLCommands.ORDERLIST + $"'CLOSED' and txnStatus != 'CANCELLED' AND originalLocationID = '{cbxLocation.Text}' or destinationLocationID = '{cbxLocation.Text}'";
                        break;

                    case "Warehouse":
                        command = SQLCommands.ORDERLIST + $"'CLOSED' and txnStatus != 'CANCELLED' AND txnStatus != 'NEW' or txnType = 'BACKORDER'";
                        break;

                    default:
                        command = $"Select * from txn where originalLocationID = '{cbxLocation.Text}' or destinationLocationID = '{cbxLocation.Text}'";
                        break;
                }
            }
            else
            {
                command = SQLCommands.ITEMSLIST + $"'{txtOrderID.Text}'";
            }

            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = command;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);

            if (dgv == "Orders")
            {
                dgvOrders.DataSource = dtRecord;
                dgvOrders.ReadOnly = true;

                for (int i = 0; i < dgvOrders.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dgvOrders.Columns[i].HeaderText = "Order ID";
                            break;

                        case 1:
                            dgvOrders.Columns[i].HeaderText = "Order Type";
                            break;

                        case 2:
                            dgvOrders.Columns[i].HeaderText = "Creation Date";
                            break;

                        case 3:
                            dgvOrders.Columns[i].HeaderText = "Estimated Arrival";
                            break;

                        case 5:
                            dgvOrders.Columns[i].HeaderText = "Origin";
                            break;

                        case 6:
                            dgvOrders.Columns[i].HeaderText = "Destination";
                            break;

                        case 7:
                            dgvOrders.Columns[i].HeaderText = "Status";
                            break;

                        default:
                            dgvOrders.Columns[i].Visible = false;
                            break;
                    }
                }
            }
            else
            {
                dgvItems.DataSource = dtRecord;
                dgvItems.ReadOnly = true;

                for (int i = 0; i < dgvItems.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dgvItems.Columns[i].HeaderText = "Order ID";
                            break;

                        case 1:
                            dgvItems.Columns[i].HeaderText = "Item ID";
                            break;

                        case 2:
                            dgvItems.Columns[i].HeaderText = "Item Name";
                            break;

                        case 3:
                            dgvItems.Columns[i].HeaderText = "Quantity";
                            break;

                        case 4:
                            dgvItems.Columns[i].HeaderText = "Total";
                            break;

                        default:
                            dgvItems.Columns[i].Visible = false;
                            break;
                    }
                }
            }
        }

        private void PopulateOrderItems()
        {
            MySqlCommand cmd = new MySqlCommand(SQLCommands.ORDERPOPULATEITEM + $"'{cbxLocation.Text}'", dbCon.Connection);
            MySqlDataReader sdr = cmd.ExecuteReader();

            ArrayList idSet = new ArrayList();
            ArrayList quantitySet = new ArrayList();

            while (sdr.Read())
            {
                int id = sdr.GetInt32(0);
                int quantity = sdr.GetInt32(1);
                int amount = sdr.GetInt32(2);
                int level = sdr.GetInt32(3);
                int caseSize = sdr.GetInt32(4);

                if (caseSize != 0)
                {
                    if (quantity < level)
                    {
                        int caseQuant = 0;

                        int i = 1;

                        while (caseSize * i < amount)
                        {
                            i++;
                        }
                        while (caseSize * caseQuant + quantity < level)
                        {
                            caseQuant = caseQuant + i;
                            quantity = quantity + caseSize;
                        }

                        idSet.Add(id);
                        quantitySet.Add(caseQuant);
                    }
                }
            }
            sdr.Close();

            if (idSet.Count > 0)
            {
                string sqlstring = SQLCommands.TXNITEMINSERT;

                for (int i = 0; i < idSet.Count; i++)
                {
                    sqlstring += $"({txtOrderID.Text}, {idSet[i]}, {quantitySet[i]})";

                    if (i != idSet.Count - 1)
                        sqlstring += ", ";
                }

                MySqlCommand addCommand = new MySqlCommand(sqlstring, dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();

                new Audit("Items added to order", user.UserID, txtOrderID.Text.ToString(), $"New items were added to order ID: {txtOrderID.Text}");
            }
        }

        private void ProcessChange(string orderID, string status, string location)
        {
            string nextstep = status;

            switch (status)
            {
                case "NEW":
                    MySqlDataReader countSDR = new MySqlCommand($"Select count(*) from txnItem where txnID = {orderID}", dbCon.Connection).ExecuteReader();
                    countSDR.Read();

                    if (countSDR.GetInt32(0) != 0)
                    {
                        if (CheckSubmitted())
                            nextstep = "SUBMITTED";
                        else
                            MessageBox.Show($"Can't submit more than 2 order of the same type and location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show($"Can't submit an empty order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    countSDR.Close();
                    break;

                case "SUBMITTED":
                    nextstep = "RECEIVED";
                    break;

                case "RECEIVED":
                    if (canMoveInventory)
                    {
                        nextstep = "PROCESSING";
                    }
                    else
                        MessageBox.Show($"No permission to move Inventory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "PROCESSING":
                    if (WarehouseProcess(orderID, location))
                    {
                        nextstep = "READY";
                    }
                    else
                        MessageBox.Show($"Failed to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "DELIVERED":

                    AcceptDeliveryOrder();
                    nextstep = "CLOSED";

                    break;

                default:
                    break;
            }

            if (status != nextstep)
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET txnStatus = '{nextstep}' where txnID = '{orderID}'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

                new Audit("Order Status Changed", user.UserID, orderID, $"Order {orderID} Status changed to {nextstep}");

                int index = dgvOrders.SelectedRows[0].Index;

                PopulateDGV("Orders");
                if (dgvOrders.Rows.Count > 0)
                    dgvOrders.Rows[index].Selected = true;

                if (nextstep == "READY")
                {
                    ProcessDelivery();
                }
            }
        }

        private void ProcessDelivery()
        {
            bool sameLocation = true;
            bool otherLocation = false;
            bool done = false;

            ArrayList routesID = new ArrayList();

            MySqlDataReader routesSQL = new MySqlCommand($"SELECT routeID from route", dbCon.Connection).ExecuteReader();
            while (routesSQL.Read())
                routesID.Add(routesSQL.GetString(0));

            routesSQL.Close();

            //check order + backorder
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                if (!done)
                {
                    string orderID = dgvOrders.Rows[i].Cells[0].Value.ToString();
                    string orderStatus = dgvOrders.Rows[i].Cells[7].Value.ToString();
                    //string orderStatus = dgvOrders.Rows[i].Cells[7].Value.ToString();
                    string orderDate = dgvOrders.Rows[i].Cells[3].Value.ToString();
                    string orderOrigin = dgvOrders.Rows[i].Cells[5].Value.ToString();

                    if (orderDate == txtArrivalDate.Text &&
                        orderStatus == "READY" &&
                        orderStatus != "CLOSED" &&
                        orderID != txtOrderID.Text)
                    {
                        if (txtOrigin.Text == orderOrigin)
                        {
                            string[] res = CalculateWeight("");

                            if (res[0] == "True")
                            {
                                int id = 0;
                                MySqlDataReader deliveryID = new MySqlCommand($"SELECT deliveryID from deliverytxns where txnID = {orderID}", dbCon.Connection).ExecuteReader();
                                if (deliveryID.Read())
                                {
                                    id = deliveryID.GetInt32(0);
                                }
                                deliveryID.Close();

                                MySqlCommand deliverytxnsUpdate = new MySqlCommand($"INSERT INTO deliverytxns VALUES ({id},'{txtOrderID.Text}')", dbCon.Connection);
                                deliverytxnsUpdate.ExecuteNonQuery();
                                deliverytxnsUpdate.Dispose();

                                new Audit("Order added to delivery", user.UserID, "", $"Order {txtOrderID.Text} was added to delivery {id}");

                                MySqlCommand deliveryUpdate = new MySqlCommand($"UPDATE delivery SET deliveryWeight = {res[1]}, vehicleTypeID = '{res[2]}' WHERE deliveryID = {id}", dbCon.Connection);
                                deliveryUpdate.ExecuteNonQuery();
                                deliveryUpdate.Dispose();

                                new Audit("Delivery update", user.UserID, "", $"Delivery {id} was update: deliveryWeight = {res[1]}, vehicleTypeID = {res[2]}");

                                done = true;
                            }
                            else
                            {
                                sameLocation = false;
                            }
                        }
                        else
                        {
                            sameLocation = false;
                            bool shorter = false;
                            string route = "";

                            for (int index = 0; index < routesID.Count; index++)
                            {
                                if (routesID[index].ToString() == $"{txtOrigin.Text}-{orderOrigin}")
                                {
                                    otherLocation = true;
                                    shorter = true;
                                    route = routesID[index].ToString();
                                }
                                else if (routesID[index].ToString() == $"{orderOrigin}-{txtOrigin.Text}")
                                {
                                    otherLocation = true;
                                    route = routesID[index].ToString();
                                }
                            }

                            if (otherLocation == true)
                            {
                                string[] res = CalculateWeight("");

                                if (res[0] == "True")
                                {
                                    int id = 0;
                                    MySqlDataReader deliveryID = new MySqlCommand($"SELECT deliveryID from deliverytxns where txnID = {orderID}", dbCon.Connection).ExecuteReader();
                                    if (deliveryID.Read())
                                    {
                                        id = deliveryID.GetInt16(0);
                                    }

                                    deliveryID.Close();

                                    MySqlCommand deliverytxnsUpdate = new MySqlCommand($"INSERT INTO deliverytxns VALUES ({id},'{txtOrderID.Text}')", dbCon.Connection);
                                    deliverytxnsUpdate.ExecuteNonQuery();
                                    deliverytxnsUpdate.Dispose();

                                    new Audit("Order added to delivery", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} was added to delivery {id}");

                                    MySqlCommand deliveryUpdate = new MySqlCommand($"UPDATE delivery SET deliveryWeight = {res[1]}, vehicleTypeID = '{res[2]}' WHERE deliveryID = {id}", dbCon.Connection);
                                    deliveryUpdate.ExecuteNonQuery();
                                    deliveryUpdate.Dispose();

                                    new Audit("Delivery update", user.UserID, "", $"Delivery {id} was update: deliveryWeight = {res[1]}, vehicleTypeID = {res[2]}");

                                    if (shorter)
                                    {
                                        MySqlCommand updateRoute = new MySqlCommand($"UPDATE deliveryroutes SET routeID = 'WARE-{txtOrigin.Text}' WHERE deliveryID = {id} AND routeID like 'WARE-{orderOrigin}'", dbCon.Connection);
                                        updateRoute.ExecuteNonQuery();
                                        updateRoute.Dispose();

                                        new Audit("Delivery route updated", user.UserID, "", $"Delivery {id} route WARE-{orderOrigin} changed to WARE-{txtOrigin.Text}");
                                    }

                                    MySqlCommand addRoute = new MySqlCommand($"INSERT INTO deliveryroutes (deliveryID, routeID) SELECT {id}, '{route}' WHERE NOT EXISTS (SELECT * FROM deliveryroutes WHERE deliveryID = {id} AND routeID = '{route}')", dbCon.Connection);
                                    addRoute.ExecuteNonQuery();
                                    addRoute.Dispose();

                                    new Audit("Route added to delivery", user.UserID, "", $"Route {route} added to Delivery {id}");

                                    done = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        sameLocation = false;
                    }
                }
            }

            if (!sameLocation && !otherLocation && !done)
            {
                string estimated = DateTime.Parse(txtArrivalDate.Text).ToString("yyyy-MM-dd");
                string[] res = CalculateWeight(txtOrderID.Text);

                if (cbxTransaction.Text == "EMERGENCY")
                    res[2] = "Courier";


                if (res[0] == "True")
                {
                    int id = 0;
                    MySqlCommand insertDelivery = new MySqlCommand($"INSERT INTO delivery SET deliveryDate = '{estimated}', deliveryWeight = {res[1]}, vehicleTypeID = '{res[2]}'", dbCon.Connection);
                    insertDelivery.ExecuteNonQuery();
                    insertDelivery.Dispose();


                    MySqlDataReader deliveryID = new MySqlCommand($"SELECT deliveryID from delivery where deliveryDate = '{estimated}' ORDER BY deliveryID DESC LIMIT 1", dbCon.Connection).ExecuteReader();

                    if (deliveryID.Read())
                    {
                        id = deliveryID.GetInt16(0);
                    }
                    deliveryID.Close();

                    new Audit("New deliveryID created", user.UserID, "", $"Delivery {id} was created with values: deliveryDate = {estimated}, deliveryWeight = {res[1]}, vehicleTypeID = {res[2]}");


                    MySqlCommand deliverytxnsUpdate = new MySqlCommand($"INSERT INTO deliverytxns VALUES ({id},'{txtOrderID.Text}')", dbCon.Connection);
                    deliverytxnsUpdate.ExecuteNonQuery();
                    deliverytxnsUpdate.Dispose();

                    new Audit("Order added to delivery", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} was added to delivery {id}");

                    MySqlCommand addRoute = new MySqlCommand($"INSERT INTO deliveryroutes SET deliveryID = {id}, routeID = 'WARE-{txtOrigin.Text}'", dbCon.Connection);
                    addRoute.ExecuteNonQuery();
                    addRoute.Dispose();

                    new Audit("Route added to delivery", user.UserID, "", $"Route WARE-{txtOrigin.Text} added to Delivery {id}");
                }
                else
                {
                    MessageBox.Show("Order too heavy to be delivered");
                }
            }
        }

        private bool WarehouseProcess(string orderID, string location)
        {
            bool backorder = false;
            bool backorderTypeFail = false;
            bool success = false;

            MySqlDataReader warehousesdr = new MySqlCommand(SQLCommands.WAREHOUSEPROCESSLIST + orderID, dbCon.Connection).ExecuteReader();

            int txnID;
            ArrayList itemID = new ArrayList();
            ArrayList orderCase = new ArrayList();
            ArrayList orderQuant = new ArrayList();
            ArrayList inventoryID = new ArrayList();
            ArrayList invQuant = new ArrayList();
            string orderType;

            while (warehousesdr.Read())
            {
                itemID.Add(warehousesdr.GetInt32(1));
                orderCase.Add(warehousesdr.GetInt32(2));
                orderQuant.Add(warehousesdr.GetInt32(3));
                inventoryID.Add(warehousesdr.GetInt32(4));
                invQuant.Add(warehousesdr.GetInt32(5));
            }
            txnID = warehousesdr.GetInt32(0);
            orderType = warehousesdr.GetString(6);

            warehousesdr.Close();

            string updateString = "UPDATE inventory SET quantity = CASE inventoryid ";
            string whereString = "";
            string backorderString = SQLCommands.TXNITEMINSERT;
            string backorderID = "";
            string DeleteString = "";

            for (int i = 0; i < itemID.Count; i++)
            {
                int orderQ = int.Parse(orderQuant[i].ToString());
                int invQ = int.Parse(invQuant[i].ToString());

                if (invQ - orderQ >= 0)
                {
                    if (i != itemID.Count - 1 && whereString != "")
                    {
                        whereString += ", ";
                    }
                    updateString += $"WHEN {inventoryID[i].ToString()} THEN {invQ - orderQ} ";
                    whereString += $"{inventoryID[i].ToString()}";
                }
                else
                {
                    if (orderType != "BACKORDER")
                    {
                        if (!backorder)
                        {
                            if (CheckBackorder(location) == "")
                            {
                                BackorderCreation(location);
                            }

                            backorderID = CheckBackorder(location);
                            backorder = true;

                            new Audit("Backorder created", user.UserID, backorderID, $"Backorder {backorderID} for location {location} was created");

                            backorderString += $"({backorderID}, {itemID[i]}, {orderCase[i]})";
                            DeleteString += $"{itemID[i]}";
                        }
                        else
                        {
                            backorderString += ", ";
                            DeleteString += ", ";

                            DeleteString += $"{itemID[i]}";
                            backorderString += $"({backorderID}, {itemID[i]}, {orderCase[i]})";
                        }
                    }
                    else
                        backorderTypeFail = true;
                }
            }

            if (!backorderTypeFail)
            {
                if (whereString != "")
                {
                    MySqlCommand warehouseUpdate = new MySqlCommand(updateString + $" ELSE quantity END WHERE inventoryid IN({whereString})", dbCon.Connection);
                    warehouseUpdate.ExecuteNonQuery();
                    warehouseUpdate.Dispose();

                    new Audit("Warehouse inventory updated", user.UserID, orderID, $"Warehouse inventory updated discounting items from order {orderID}");

                    success = true;
                }

                if (backorder)
                {
                    MySqlCommand backorderInsert = new MySqlCommand(backorderString, dbCon.Connection);
                    backorderInsert.ExecuteNonQuery();
                    backorderInsert.Dispose();

                    new Audit("Items added to backorder", user.UserID, backorderID, $"Items from order {orderID} added to backorder {backorderID}");

                    MySqlCommand DeleteOrderItems = new MySqlCommand(SQLCommands.DELETETXNITEM + $"({DeleteString}) AND txnID = {txnID}", dbCon.Connection);
                    DeleteOrderItems.ExecuteNonQuery();
                    DeleteOrderItems.Dispose();

                    new Audit("Backordered items deleted", user.UserID, orderID, $"Backordered Items from order {orderID} were deleted from order'");

                    MySqlCommand backorderNotes = new MySqlCommand($"Update txn SET note = IFNULL(CONCAT(note, ', {DeleteString}'), " +
                        $"'Backorder Items: {DeleteString}') where txnID = {txnID}", dbCon.Connection);
                    backorderNotes.ExecuteNonQuery();
                    backorderNotes.Dispose();
                    success = true;
                }
            }
            else
            {
                if (canCreateBackOrder)
                    MessageBox.Show($"Insufficient warehouse inventory to finish Backorder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("You don't have permission to create a Backorder!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return success;
        }
    }
}