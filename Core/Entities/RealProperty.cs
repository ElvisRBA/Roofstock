namespace Core.Entities
{
    public class RealProperty : BaseEntity
    {
        public RealProperty()
        {
        }

        public RealProperty(RealProperty realProperty)
        {
            Address = realProperty.Address;
            YearBuilt = realProperty.YearBuilt;
            ListPrice = realProperty.ListPrice;
            MonthlyRent = realProperty.MonthlyRent;
        }
        public string Address { get; set; }
        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
    }
}