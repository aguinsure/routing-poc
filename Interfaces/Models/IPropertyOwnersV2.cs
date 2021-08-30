namespace Interfaces.Models
{
    public interface IPropertyOwnersV2 : IProductRequest
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string POV2SpecificAnswer { get; set; }
    }
}