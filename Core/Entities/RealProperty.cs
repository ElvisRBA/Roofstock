namespace Core.Entities
{
    public class RealProperty : BaseEntity
    {
        public string Address { get; set; }
        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
    }
}