using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;

namespace ISDP_AlexanderK.entity
{
    internal class Audit
    {
        private DateTime auditDateTime;
        private string action;
        private string userID;
        private string transactionID;
        private string description;

        public string Action { get => action; set => action = value; }
        public string UserID { get => userID; set => userID = value; }
        public string TransactionID { get => transactionID; set => transactionID = value; }
        public string Description { get => description; set => description = value; }
        public DateTime AuditDateTime { get => auditDateTime; set => auditDateTime = value; }

        public Audit(string action, string userID, string transactionID, string description)
        {
            this.action = action;
            this.userID = userID;
            this.transactionID = transactionID;

            this.description = description;
            auditDateTime = DateTime.Now;

            Send();
        }

        public void Send()
        {
            DBConnection dbCon = new DBConnection();

            if (dbCon.IsConnect())
            {
                string transactionIDstr = transactionID != ""? $", transactionID = {transactionID}" : "";
                string descriptionstr = description != ""? $", description = \"{description}\"" : "";

                MySqlCommand addCommand = new MySqlCommand("INSERT INTO audit SET auditDateTime = '" + auditDateTime.ToString("yyyy-MM-dd HH:mm:ss") + $"', action = '{action}', " +
                    $"userID = '{userID}' {transactionIDstr} {descriptionstr}", dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();
                dbCon.Close();
            }
        }
    }
}