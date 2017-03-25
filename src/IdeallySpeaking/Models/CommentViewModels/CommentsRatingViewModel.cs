using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.CommentViewModels
{
    public class CommentsRatingViewModel
    {
        
        public class CommentsRating
        {
            public int Rating { get; private set; }

            public CommentsRating()
            {
                var rating = 0;
                Rating = rating;
            }

            public void RatingUp()
            {
                Rating += 1; 
            }

            public void RatingDown()
            {
                Rating -= 1;
            }

            public int GetRating
            {
                get { return Rating; }
            }

            public static implicit operator int(CommentsRating v)
            {
                throw new NotImplementedException();
            }
        } 
        
    }
}
