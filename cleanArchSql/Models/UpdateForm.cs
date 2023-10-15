namespace cleanArchSql.Models
{
    public class UpdateForm
    {
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Active { get; set; }
        public string PageType { get; set; }

        public List<AssignedUser> AssignedUsers { get; set; }
        public string PageDesignFile { get; set; }
    }
}
