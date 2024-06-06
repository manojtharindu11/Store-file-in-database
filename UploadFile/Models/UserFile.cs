using System.ComponentModel.DataAnnotations;

namespace UploadFile.Models
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; } // Binary data for the file
    }
}
