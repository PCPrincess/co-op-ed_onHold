using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.CommentViewModels
{
    public class ReplyViewModel
    {
        public Comment Reply { get; set; }
        //Action Method - Determination of 'Reply' versus 'Comment' can be set via controller based on LINK use.
    }
}
