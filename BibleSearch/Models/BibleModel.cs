using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibleSearch.Models
{
    // Model is called in the views, this is the attributes to be searched for
    public class BibleModel
    {
        public BibleModel()
        {

        }

        [Required]
        [DisplayName("Testament")]
        [StringLength(200, MinimumLength = 1)]
        public string Testament { get; set; }

        [Required]
        [DisplayName("Book")]
        [StringLength(200, MinimumLength = 1)]
        public string Book { get; set; }

        [Required]
        [DisplayName("Chapter")]
        [StringLength(200, MinimumLength = 1)]
        public string Chapter { get; set; }

        [Required]
        [DisplayName("Verse")]
        [StringLength(200, MinimumLength = 1)]
        public string Verse { get; set; }

        [Required]
        [DisplayName("Verse Text")]
        [StringLength(200, MinimumLength = 1)]
        public string Text { get; set; }

        public BibleModel(string testament, string book, string chapter, string verse, string text)
        {
            this.Testament = testament;
            this.Book = book;
            this.Chapter = chapter;
            this.Verse = verse;
            this.Text = text;
        }
    }
}
