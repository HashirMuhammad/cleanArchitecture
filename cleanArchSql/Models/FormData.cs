using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cleanArchSql.Models
{
    public class FormData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Active { get; set; }
        public string PageType { get; set; }

        public ICollection<AssignedUser> AssignedUsers { get; set; }
        public string PageDesignFile { get; set; }
    }

    public class AssignedUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        // Foreign key to FormData
        public int FormDataId { get; set; }
    }

    /*public class UserName
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

    }*/
}

//using System.ComponentModel.DataAnnotations.Schema;
/*using System.ComponentModel.DataAnnotations;

namespace cleanArchSql.Models
{
    public class FormData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Active { get; set; }
        public string PageType { get; set; }
        public string PageDesignFile { get; set; }
    }

    public class AssignedUser
    {
        [Key]
        public int Id { get; set; }
        public int FormDataId { get; set; }
        public FormData FormData { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
    }
    public class PageInputDto
    {
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Active { get; set; }
        public string PageType { get; set; }
        public string PageDesignFile { get; set; }
        public List<int> UserIdList { get; set; }
    }*/

    /*public class UserName
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

    }*/
//}

