namespace RepositoryNetAPI.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstNames {  get; set; }
        public string? LastName { get; set;}
        public string? Alias { get; set; }
        public int? IsAdmin { get; set; }
        public int? MainRoleId {  get; set; }
        public int? IsActive { get; set;}
        public int? ContactInformationId { get; set; }
    }
}
