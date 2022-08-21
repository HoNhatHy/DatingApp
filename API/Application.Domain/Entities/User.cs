using Application.Domain.Common;

namespace Application.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Username {get;set;} = "";
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt {get;set;}
        public List<Photo> Photos {get;set;} = new List<Photo>();
    }
}