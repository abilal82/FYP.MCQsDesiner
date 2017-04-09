using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class ExamQuestion
    {
        public ExamQuestion()
        {
            MultipleChoices = new HashSet<MultipleChoice>();
        }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string CorrectAnswer { get; set; }

        public virtual ICollection<MultipleChoice> MultipleChoices { get; set; }
    }
}
