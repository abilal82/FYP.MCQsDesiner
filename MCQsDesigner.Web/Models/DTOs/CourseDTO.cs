namespace MCQsDesigner.Web.Models.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }

        public byte CreditHour { get; set; }

        public string CourseCode { get; set; }

        public string CourseOutLine { get; set; }
    }
}