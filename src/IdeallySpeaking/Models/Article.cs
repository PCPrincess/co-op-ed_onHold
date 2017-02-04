using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Headline { get; set; }

        [Display(Name = "Article Content")]
        public string Content { get; set; }

        [RegularExpression(@"^(\w+)\s\.]{1,100}$")] 
        public string Teaser
        {
            get { return Content; }
        }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<Comment> CommentList { get; set; }

        public int AuthorUserId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}
