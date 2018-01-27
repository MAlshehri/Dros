using System;
using System.Linq;
using Realms;

namespace Dros.Models
{
    public class Url : RealmObject
    {
        [Required]
        [PrimaryKey]
        [MapTo("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MapTo("material")]
        [Backlink(nameof(Material.Urls))]
        public IQueryable<Material> Materials { get; }

        [MapTo("order")]
        public int Order { get; set; } = 0;

        [Required]
        [MapTo("link")]
        public string Link { get; set; } = "";

        [MapTo("contentLength")]
        public long ContentLength { get; set; } = 0;
    }
}