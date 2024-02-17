using System.ComponentModel.DataAnnotations;

namespace Color_Selection_API.Model
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string colorName {  get; set; }
        public int colorCode { get; set; }
        public string colorHexaCode { get; set; } 



    }
}
