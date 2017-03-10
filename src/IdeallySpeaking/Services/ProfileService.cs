using IdeallySpeaking.Models;
using IdeallySpeaking.Models.ApplicationUserViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Services
{
    public class ProfileService
    {
        private readonly ProfileViewModel _profileViewModel;

        public ProfileService(ProfileViewModel profileViewModel)
        {
            _profileViewModel = profileViewModel;
        }

        public string GetUserName()
        {
            return _profileViewModel.UserName;
        }

        public DateTime GetJoinDate()
        {
            return _profileViewModel.JoinDate;
        }

        public string GetUrl()
        {
            return _profileViewModel.Url;
        }

        public IFormFile GetAvatar()
        {
            return _profileViewModel.Avatar;
        }

        public List<Badge> GetBadges()
        {
            return _profileViewModel.BadgeList;
        }
    }
}
