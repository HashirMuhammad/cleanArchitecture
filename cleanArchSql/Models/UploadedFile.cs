namespace cleanArchSql.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FilePath { get; set; } // If you want to save the file path in the database
    }
}
