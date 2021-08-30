namespace Interfaces.Models
{
    public interface IPropertyOwnersV1 : IProductRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string POV1SpecificAnswer { get; set; }
    }
}