using System.ComponentModel.DataAnnotations.Schema;
using Application.Domain.Common;

namespace Application.Domain.Entities
{
    [Table("Photos")]
    public class Photo : BaseAuditableEntity
    {
        public string Url {get;set;} = "";
        public bool IsMain {get;set;}
        public string PublicId {get;set;} = "";
        public int UserId {get;set;}
    }
}