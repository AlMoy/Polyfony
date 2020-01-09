using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class Person : EntityBase<Person>
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
            set { lastName = value; OnPropertyChanged("LastName"); }
            }

        [Required]
        [Column("pe_firstName")]
        [DataType(DataType.Text)]
        public string FirstName
            {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
            }

        [Required]
        [Column("pe_address")]
        [DataType(DataType.Text)]
        public string Address
            {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
            }

        [Required]
        [Column("pe_Mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail
            {
            get { return mail; }
            set { mail = value; OnPropertyChanged("Mail"); }
            }

        [Required]
        [Column("pe_telephoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber
            {
            get { return telephoneNumber; }
            set { telephoneNumber = value; OnPropertyChanged("TelephoneNumber"); }
            }

        [Required]
        [Column("pe_birthDate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate
            {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChanged("BirthDate"); }
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
            set { passWord = value; OnPropertyChanged("Password"); }
            }

        public Role Role
            {
            get { return role; }
            set { role = value; OnPropertyChanged("Role"); }
            }

        public List<Order> Orders
            {
            get { return orders; }
            set { orders = value; OnPropertyChanged("Orders"); }
            }
        #endregion

        #region Constructors
        public Person()
            {
            this.orders = new List<Order>();
            }
        #endregion

        #region Functions
        public override Person Copy()
            {
            Person person = new Person();
            person.Id = this.Id;
            person.LastName = this.LastName;
            person.FirstName = this.FirstName;
            person.Address = this.Address;
            person.Mail = this.Mail;
            person.TelephoneNumber = this.TelephoneNumber;
            person.BirthDate = this.BirthDate;
            person.Login = this.Login;
            person.PassWord = this.PassWord;
            person.Role = this.Role;
            person.Orders = this.Orders;

            return person;
            }

        public override void CopyFrom(Person obj)
            {
            this.Id = obj.Id;
            this.LastName = obj.LastName;
            this.FirstName = obj.FirstName;
            this.Address = obj.Address;
            this.Mail = obj.Mail;
            this.TelephoneNumber = obj.TelephoneNumber;
            this.BirthDate = obj.BirthDate;
            this.Login = obj.Login;
            this.PassWord = obj.PassWord;
            this.Role = obj.Role;
            this.Orders = obj.Orders;
            }
        #endregion
        }
    }
