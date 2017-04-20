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

        [StringLength(125, ErrorMessage = "Headline may have a maximum of 125 characters.")]
        public string Headline { get; set; }

        [Display(Name = "Article Content")]
        public string Content { get; set; }

        public byte[] ArticlePhoto { get; set; }        

        public string Teaser { get { return UseTeaser(); } }
       
        public string UseTeaser()
        {
            return Content.ArticleShortener(100);
        }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public ApplicationUser Author { get; set; }

        public IList<Comment> ArticleCommentsList { get; set; } 

        public void AddCommentToList(Comment comment)
        {                
            ArticleCommentsList.Add(comment);
        }

            

            

       

    }
}
