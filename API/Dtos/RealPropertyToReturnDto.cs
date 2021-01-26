namespace API.Dtos
{
    public class RealPropertyToReturnDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
    }
}