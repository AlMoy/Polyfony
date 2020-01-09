using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Entities
{
    public class Role : EntityBase
    {
        #region Attributs
        private long id;
        private string name;
        private List<Person> people;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ro_id")]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        [Column("ro_name")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name
            {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
                }
            }

        public List<Person> People
            {
            get { return people; }
            set { people = value; }
            }
        #endregion

        #region Constructors
        public Role()
            {
            this.people = new List<Person>();
            }
        #endregion

        #region Functions

        public override object Copy()
        {
            Role role = new Role();
            role.Id = this.Id;
            role.Name = this.Name;

            return role;
        }

        public override void CopyFrom(object obj)
        {
            Role role = obj as Role;
            this.Id = role.Id;
            this.Name = role.Name;
        }
        #endregion
    }


}
