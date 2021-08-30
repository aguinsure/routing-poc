namespace Interfaces.Models
{
    public class ProductRequest : IPropertyOwnersV1, IPropertyOwnersV2, ITradesAndProfessionsV1, IProductRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TPV1SpecificAnswer { get; set; }
        public string POV2SpecificAnswer { get; set; }
        public string POV1SpecificAnswer { get; set; }
    }
}