using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
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
        private int roleId;
        private List<OrderPerson> orderPerson;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        [Column("pe_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }



        [NotNull]
        [Column("pe_lastName")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        [NotNull]
        [Column("pe_firstName")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        [NotNull]
        [Column("pe_address")]
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        [Unique]
        [NotNull]
        [Column("pe_Mail")]
        public string Mail
        {
            get { return mail; }
            set { mail = value; OnPropertyChanged("Mail"); }
        }

        [Unique]
        [NotNull]
        [Column("pe_telephoneNumber")]
        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; OnPropertyChanged("TelephoneNumber"); }
        }

        [NotNull]
        [Column("pe_birthDate")]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChanged("BirthDate"); }
        }

        [Unique]
        [NotNull]
        [Column("pe_login")]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [NotNull]
        [Column("pe_password")]
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; OnPropertyChanged("Password"); }
        }

        [ManyToOne("RoleId")]
        public Role Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged("Role"); }
        }

        [ForeignKey(typeof(Role))]
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        [ManyToOne]
        public List<OrderPerson> OrderPerson
        {
            get { return orderPerson; }
            set { orderPerson = value; OnPropertyChanged("Orders"); }
        }
        #endregion

        #region Constructors
        public Person()
        {
            this.orderPerson = new List<OrderPerson>();
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
            person.RoleId = this.RoleId;
            person.OrderPerson = this.OrderPerson;

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
            this.RoleId = obj.RoleId;
            this.OrderPerson = obj.OrderPerson;
        }
        #endregion
    }
}