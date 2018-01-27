using System;
using System.Collections.Generic;
using Realms;

namespace Dros.Models
{
    public class Author : RealmObject
    {
        [Required]
        [PrimaryKey]
        [MapTo("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Indexed]
        [MapTo("name")]
        public string Name { get; set; } = "";

        [MapTo("materials")]
        public IList<Material> Materials { get; }
    }
}