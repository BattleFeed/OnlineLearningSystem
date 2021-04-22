using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearningSystem.Models
{
    public class UserScoreHistory
    {
        public string UserId { get; set; }
        public int SectionID { get; set; }
        public int HighScore { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Section Section { get; set; }
    }
}
