using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Entities
{
    public class Person : EntityBase
    {
        #region Attributs
        private long id;
        private string lastName;
        private string firstName;
        private string address;
        private string mail;
        private string telephoneNumber;
        private DateTime birthDate;
        private string login;
        private string passWord;
        private Role role;
        private List<Order> orders;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pe_id")]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        [Column("pe_lastName")]
        [DataType(DataType.Text)]
        public string LastName
            {
            get { return lastName; }
            set { lastName = value; }
            }

        [Required]
        [Column("pe_firstName")]
        [DataType(DataType.Text)]
        public string FirstName
            {
            get { return firstName; }
            set { firstName = value; }
            }

        [Required]
        [Column("pe_address")]
        [DataType(DataType.Text)]
        public string Address
            {
            get { return address; }
            set { address = value; }
            }

        [Required]
        [Column("pe_Mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail
            {
            get { return mail; }
            set { mail = value; }
            }

        [Required]
        [Column("pe_telephoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber
            {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
            }

        [Required]
        [Column("pe_birthDate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate
            {
            get { return birthDate; }
            set { birthDate = value; }
            }

        [Required]
        [Column("pe_login")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(10)]
        public string Login
            {
            get { return login; }
            set { login = value; }
            }

        [Required]
        [Column("pe_password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [MaxLength(200)]
        public string PassWord
            {
            get { return passWord; }
            set { passWord = value; }
            }

        public Role Role
            {
            get { return role; }
            set { role = value; }
            }

        public List<Order> Orders
            {
            get { return orders; }
            set { orders = value; }
            }
        #endregion

        #region Constructors
        public Person()
            {
            this.orders = new List<Order>();
            }
        #endregion
        }
    }
