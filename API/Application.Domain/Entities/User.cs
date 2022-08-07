using Application.Domain.Common;

namespace Application.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Username {get;set;} = "";
        public byte[]? PasswordHash {get;set;}
        public byte[]? PasswordSalt {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string KnownAs {get;set;} = "";
        public DateTime LastActive {get;set;} = DateTime.Now;
        public string Gender{get;set;} = "";
        public string Introduction {get;set;} = "";
         public string LookingFor{get;set;} = "";
        public string Interests {get;set;} = "";
        public string City {get;set;} = "";
        public string Country {get;set;} = "";
        public IList<Photo>? Photos {get;set;}
    }
}