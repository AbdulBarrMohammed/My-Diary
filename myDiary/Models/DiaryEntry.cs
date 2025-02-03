using System.ComponentModel.DataAnnotations;

 namespace myDiary.Models

 {
    public class DiaryEntry {

        //[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Title must be between 3 and 100 characters")]
        public string? Title { get; set; }
        [Required] //this entry cannot be null, can use ? for required too
        public string? Content {get; set;}

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
 }
