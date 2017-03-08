using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ApplicationUserViewModels
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }

        public string Url { get; set; }

        public IFormFile Avatar { get; set; }

        public List<Badge> BadgeList { get; set; }

    }
}


