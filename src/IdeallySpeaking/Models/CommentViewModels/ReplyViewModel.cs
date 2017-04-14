using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.CommentViewModels
{    
    public class ReplyViewModel : Comment
    {
        [MinLength(2)]
        [MaxLength(600)]
        public Comment Reply { get; set; }
        //Action Method - Determination of 'Reply' versus 'Comment' can be set via controller based on LINK use.

        
    }
}
