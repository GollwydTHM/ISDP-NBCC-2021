namespace ISDP_AlexanderK.entity
{
    internal class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        public Supplier() { }
        public Supplier(int supplierID, string supplierName)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
        }
    }
}