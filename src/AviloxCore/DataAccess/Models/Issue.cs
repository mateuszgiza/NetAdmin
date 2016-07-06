using AviloxCore.DataAccess.Enums;

namespace AviloxCore.DataAccess.Models
{
    public class Issue : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public IssueTypeEnum IssueType { get; set; }
    }
}