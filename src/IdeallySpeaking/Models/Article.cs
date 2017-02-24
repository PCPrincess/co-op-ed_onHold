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
        
        public string Teaser
        {
            get { return Content.ArticleShortener(100); }
        }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        public ApplicationUser Author { get; set; }

        public class ArticleCommentsList
        {
            public ArticleCommentsList(Article article)
            {
                this.ArticleCommentsListId = article.ArticleId;
            }

            public void AddCommentToList(Comment comment)
            {                
                ArtCommList.Add(comment);
            }

            public int ArticleCommentsListId { get; set; }

            public IList<Comment> ArtCommList { get; set; }

        }

    }
}
