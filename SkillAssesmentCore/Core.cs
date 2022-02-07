using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAssesmentCore
{
    public class Core
    {
        public ObservableCollection<Discticts> Discticts { get; set; }

        public ObservableCollection<Institution> Institutions { get; set; }

        public ObservableCollection<Discticts> GetDiscticts()
        {
            return Discticts = new ObservableCollection<Discticts>(DBContext.connection.Discticts.ToList());
        }

        public void AddDisctics(string name)
        {
            Discticts discticts = new Discticts();
            discticts.name = name;
            if(GetDiscticts().FirstOrDefault(i => i.name == discticts.name) == null)
            {
                DBContext.connection.Discticts.Add(discticts);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.connection.SaveChanges();
        }

        public void RemoveDisctics(Discticts disctict)
        {
            Discticts discticts;
            using(var context = new Entities())
            {
                discticts = context.Discticts.Where(d => d.name == disctict.name).FirstOrDefault();
            }
            if(discticts != null)
            {
                using (var context = new Entities())
                {
                    context.Discticts.Attach(discticts);
                    context.Discticts.Remove(discticts);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Institution> GetInstitutions()
        {
            return Institutions = new ObservableCollection<Institution>(DBContext.connection.Institution.ToList());
        }
    }
}
