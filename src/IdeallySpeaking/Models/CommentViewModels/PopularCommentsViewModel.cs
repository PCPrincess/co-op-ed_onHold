using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.CommentViewModels
{
    public class PopularCommentsViewModel
    {
        //public int Rating { get; set; }
        //Create Partial View in Views/Comments - PopularCommentsPartial
        //Partial Will Render in Home/Index.cshtml

        public class CommentsRating
        {
            public CommentsRating(Comment comment)
            {
                comment.Rating = 0;   
            }

            public void RatingUp(Comment comment)
            {
                comment.Rating += 1; 
            }

            public void RatingDown(Comment comment)
            {
                comment.Rating -= 1;
            }

        } 
        
    }
}
