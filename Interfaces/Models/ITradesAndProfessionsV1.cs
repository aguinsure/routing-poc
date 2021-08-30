namespace Interfaces.Models
{
    public interface ITradesAndProfessionsV1 : IProductRequest
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TPV1SpecificAnswer { get; set; }
    }
}