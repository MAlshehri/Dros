using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace Dros.Models
{
    public class Material : RealmObject
    {
        [PrimaryKey]
        [Required]
        [MapTo("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Indexed]
        [Required]
        [MapTo("title")]
        public string Title { get; set; } = "";

        [MapTo("body")]
        public string Body { get; set; }

        [MapTo("language")]
        public string Language { get; set; }

        [MapTo("authors")]
        [Backlink(nameof(Author.Materials))]
        public IQueryable<Author> Authors { get; }

        [MapTo("tags")]
        [Backlink(nameof(Tag.Materials))]
        public IQueryable<Tag> Tags { get; }

        [MapTo("urls")]
        public IList<Url> Urls { get; }
    }
}