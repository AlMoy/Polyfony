using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class Role : EntityBase<Role>
    {
        #region Attributs
        private long id;
        private string name;
        private List<Person> people;
        #endregion

        #region Properties
        [PrimaryKey]
        [Column("ro_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [NotNull]
        [Column("ro_name")]
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        [Ignore]
        public List<Person> People
        {
            get { return people; }
            set { people = value; OnPropertyChanged("People"); }
        }
        #endregion

        #region Constructors
        public Role()
        {
            this.people = new List<Person>();
        }
        #endregion

        #region Functions
        public override Role Copy()
        {
            Role role = new Role();
            role.Id = this.Id;
            role.Name = this.Name;
            role.People = this.People;

            return role;
        }

        public override void CopyFrom(Role obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.People = obj.People;
        }
        #endregion
    }
}