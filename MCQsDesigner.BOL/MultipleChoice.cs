using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public  class MultipleChoice
    {
        public int MCId { get; set; }
        public string  Choices { get; set; }
        public bool  CorrectAnswer { get; set; }
        public  ExamQuestion ExamQuestion { get; set; }
    }
}
