using System.ComponentModel.DataAnnotations;

 namespace myDiary.Models

 {
    public class DiaryEntry {

        //[Key]
        public int Id { get; set; }

        [Required] //this entry cannot be null, can use ? for required too
        public string? Title { get; set; }
        [Required]
        public string? Content {get; set;}

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
 }
