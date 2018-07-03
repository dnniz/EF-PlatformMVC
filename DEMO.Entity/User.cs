using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Entity
{
    [Table("User")]
    public class User : BaseEntity
    {
        public int UserId { get; set; }

        [MaxLength(120)]
        public string Email { get; set; }

        //[Required]
        [MaxLength(120)]
        public string Password { get; set; }

        //[Required]
        [MaxLength(180)]
        public string UserName { get; set; }

        [MaxLength(8)]
        public string DNI { get; set; }

        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string MobilePhone { get; set; }

        [NotMapped]
        public string strEmail
        {
            get
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    return Email;
                }
                else
                {
                    return "(Sin correo)";
                }
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    return string.Format("{0} {1}", FirstName, LastName);
                }
                else
                {
                    return "(Sin nombre)";
                }
            }
        }
        [NotMapped]
        public string strDNI
        {
            get
            {
                if (!string.IsNullOrEmpty(DNI))
                {
                    return DNI;
                }
                else
                {
                    return "(Sin DNI)";
                }
            }
        }
    }
}
