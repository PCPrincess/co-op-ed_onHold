﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Title { get; set; }        

        [Required]
        [MinLength(2)]
        [MaxLength(600)]
        public string CommentContent { get; set; }

        public int ArticleId { get; set; }

        public int ApplicationUserId { get; set; } 

        public List<Comment> UserCommentList { get; set; }
       
        public void AddCommentToList(Comment comment)
        {
            UserCommentList.Add(comment);
        }

        public int Rating { get; set; }        

    }
}
