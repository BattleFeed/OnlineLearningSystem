using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public int Score { get; set; }
    }

    public class RankingViewModel
    { 
        public ICollection<UserViewModel> Users { get; set; }
        public int CurrentUserScore { get; set; }
        public string CurrentUserName { get; set; }
    }
}
