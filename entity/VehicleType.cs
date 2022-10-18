namespace ISDP_AlexanderK
{
    public class VehicleType
    {
        public string VehicleTypeID { get; set; }
        public string Description { get; set; }
        public double WeightLimit { get; set; }

        public VehicleType() { }
        public VehicleType(string vehicleTypeID, string description, double weightLimit)
        {
            VehicleTypeID = vehicleTypeID;
            Description = description;
            WeightLimit = weightLimit;
        }
    }
}