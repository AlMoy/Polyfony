﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
    {
    public class Person
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
        private List<OrderPerson> orderPersons;
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
        [Display(Name ="Nom")]
        [DataType(DataType.Text)]
        public string LastName
            {
            get { return lastName; }
            set { lastName = value; }
            }

        [Required]
        [Column("pe_firstName")]
        [Display(Name = "Prénom")]
        [DataType(DataType.Text)]
        public string FirstName
            {
            get { return firstName; }
            set { firstName = value; }
            }

        [Required]
        [Column("pe_address")]
        [Display(Name = "Adresse")]
        [DataType(DataType.Text)]
        public string Address
            {
            get { return address; }
            set { address = value; }
            }

        [Required]
        [Column("pe_Mail")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Mail
            {
            get { return mail; }
            set { mail = value; }
            }

        [Required]
        [Column("pe_telephoneNumber")]
        [Display(Name = "N° de téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber
            {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
            }

        [Required]
        [Column("pe_birthDate")]
        //[Range(typeof(DateTime), "01/01/1900", "31/12/2020")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate
            {
            get { return birthDate; }
            set { birthDate = value; }
            }

        [Required]
        [Column("pe_login")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        [MinLength(4)]
        [MaxLength(10)]
        public string Login
            {
            get { return login; }
            set { login = value; }
            }

        [Required]
        [Column("pe_password")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Le mot de passe doit avoir 8 cractères miniment")]
        [MaxLength(200)]
        public string PassWord
            {
            get { return passWord; }
            set { passWord = value; }
            }

        [Display(Name = "Rôle")]
        public virtual Role Role
            {
            get { return role; }
            set { role = value; }
            }

        public List<OrderPerson> OrderPersons
        {
            get { return orderPersons; }
            set { orderPersons = value; }
            }
        #endregion

        #region Constructors
        public Person()
            {
            this.orderPersons = new List<OrderPerson>();
            }
        #endregion
        }
    }
