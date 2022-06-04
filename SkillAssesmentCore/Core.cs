using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SkillAssesmentCore
{
    public class Core
    {
        public delegate void AddNewItemDelegate();
        public static event AddNewItemDelegate AddNewItemEvent;


        public ObservableCollection<Discticts> Discticts { get; set; }

        public ObservableCollection<Institution> Institutions { get; set; }

        public ObservableCollection<Posts> Posts { get; set; }

        public ObservableCollection<Subjects> Subjects { get; set; }

        public ObservableCollection<Categories> Categories { get; set; }

        public ObservableCollection<Teachers> Teachers { get; set; }

        public ObservableCollection<Users> Users { get; set; }

        public ObservableCollection<Role> Roles { get; set; }

        public ObservableCollection<Discticts> GetDiscticts()
        {
            return Discticts = new ObservableCollection<Discticts>(DBContext.localConnection.Discticts.ToList());
        }

        public void AddDisctics(string name)
        {

            Discticts discticts = new Discticts()
            {
                name = name
            };

            if (GetDiscticts().FirstOrDefault(i => i.name == discticts.name) == null)
            {
                DBContext.localConnection.Discticts.Add(discticts);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.localConnection.SaveChanges();
        }

        public void RemoveDisctics(Discticts disctict)
        {
            Discticts discticts;
            using (var context = new Entities1())
            {
                discticts = context.Discticts.Where(d => d.name == disctict.name).FirstOrDefault();
            }
            if (discticts != null)
            {
                using (var context = new Entities1())
                {
                    context.Discticts.Attach(discticts);
                    context.Discticts.Remove(discticts);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Institution> GetInstitutions()
        {
            return Institutions = new ObservableCollection<Institution>(DBContext.localConnection.Institution.ToList());
        }

        public void AddInstitution(Institution institution)
        {
            if (GetInstitutions().FirstOrDefault(i => i.name == institution.name) == null)
            {
                DBContext.localConnection.Institution.Add(institution);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.localConnection.SaveChanges();
        }

        public void RemoveInstitutions(Institution institution)
        {
            Institution tempInstitution;
            using (var context = new Entities1())
            {
                tempInstitution = context.Institution.Where(d => d.name == institution.name).FirstOrDefault();
            }
            if (tempInstitution != null)
            {
                using (var context = new Entities1())
                {
                    context.Institution.Attach(tempInstitution);
                    context.Institution.Remove(tempInstitution);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Institution> GetInstitutionsOrderDistrict(Discticts discticts)
        {
            var institutions = new ObservableCollection<Institution>(DBContext.localConnection.Institution.ToList()).Where(x => x.disctrict_id == discticts.disctrict_id);
            return Institutions = new ObservableCollection<Institution>(institutions);
        }

        public ObservableCollection<Posts> GetPosts()
        {
            return Posts = new ObservableCollection<Posts>(DBContext.localConnection.Posts);
        }

        public void AddPosts(string name)
        {
            Posts post = new Posts()
            {
                name = name
            };
            if (GetPosts().FirstOrDefault(i => i.name == post.name) == null)
            {
                DBContext.localConnection.Posts.Add(post);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.localConnection.SaveChanges();
        }

        public void RemovePosts(Posts post)
        {
            Posts tempPost;
            using (var context = new Entities1())
            {
                tempPost = context.Posts.Where(d => d.name == post.name).FirstOrDefault();
            }
            if (tempPost != null)
            {
                using (var context = new Entities1())
                {
                    context.Posts.Attach(tempPost);
                    context.Posts.Remove(tempPost);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Subjects> GetSubjects()
        {
            return Subjects = new ObservableCollection<Subjects>(DBContext.localConnection.Subjects);
        }

        public void AddSubject(string name)
        {
            Subjects subject = new Subjects()
            {
                name = name
            };
            if (GetSubjects().FirstOrDefault(i => i.name == subject.name) == null)
            {
                DBContext.localConnection.Subjects.Add(subject);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.localConnection.SaveChanges();
        }


        public void RemoveSubject(Subjects subject)
        {
            Subjects tempSubject;
            using (var context = new Entities1())
            {
                tempSubject = context.Subjects.Where(d => d.name == subject.name).FirstOrDefault();
            }
            if (tempSubject != null)
            {
                using (var context = new Entities1())
                {
                    context.Subjects.Attach(tempSubject);
                    context.Subjects.Remove(tempSubject);
                    context.SaveChanges();
                }
            }
        }


        public ObservableCollection<Categories> GetCategories()
        {
            return Categories = new ObservableCollection<Categories>(DBContext.localConnection.Categories);
        }

        public void AddCategory(string name)
        {
            Categories category = new Categories()
            {
                name = name
            };
            if (GetCategories().FirstOrDefault(i => i.name == category.name) == null)
            {
                DBContext.localConnection.Categories.Add(category);
            }
            else
            {
                throw new IdenticalException("Данная запись уже существует в БД");
            }
            DBContext.localConnection.SaveChanges();
        }

        public void RemoveCategory(Categories category)
        {
            Categories tempCategory;
            using (var context = new Entities1())
            {
                tempCategory = context.Categories.Where(d => d.name == category.name).FirstOrDefault();
            }
            if (tempCategory != null)
            {
                using (var context = new Entities1())
                {
                    context.Categories.Attach(tempCategory);
                    context.Categories.Remove(tempCategory);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Teachers> GetTeachers()
        {
            return Teachers = new ObservableCollection<Teachers>(DBContext.localConnection.Teachers);
        }

        public bool AddTeachers(Teachers teacher)
        {
            if (teacher != null)
            {

                if (DBContext.localConnection.Teachers.Where(x => x.teacher_id == teacher.teacher_id).Count() == 0)
                {
                    DBContext.localConnection.Teachers.Add(teacher);
                    AddNewItemEvent?.Invoke();
                }
                else
                {
                    DBContext.localConnection.Teachers.SingleOrDefault(x => x.teacher_id == teacher.teacher_id);
                }
                DBContext.localConnection.SaveChanges();
                return true;
            }
            return false;
        }

        public void RemoveTeachers(Teachers teacher)
        {
            Teachers tempTeacher;
            using (var context = new Entities1())
            {
                tempTeacher = context.Teachers.Where(d => d.teacher_id == teacher.teacher_id).FirstOrDefault();
            }
            if (tempTeacher != null)
            {
                using (var context = new Entities1())
                {
                    context.Teachers.Attach(tempTeacher);
                    context.Teachers.Remove(tempTeacher);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Users> GetUsers()
        {
            return Users = new ObservableCollection<Users>(DBContext.localConnection.Users);
        }

        public bool AddUsers(Users user)
        {
            if (user != null)
            {

                if(DBContext.localConnection.Users.Where(x => x.user_id == user.user_id).Count() == 0)
                {
                    DBContext.localConnection.Users.Add(user);
                    AddNewItemEvent?.Invoke();
                }
                else
                {
                    DBContext.localConnection.Users.SingleOrDefault(x => x.user_id == user.user_id);
                }
                DBContext.localConnection.SaveChanges();
                return true;
            }
            return false;
        }

        public void RemoveUsers(Users user)
        {
            Users tempUser;
            using (var context = new Entities1())
            {
                tempUser = context.Users.Where(d => d.user_id == user.user_id).FirstOrDefault();
            }
            if (tempUser != null)
            {
                using (var context = new Entities1())
                {
                    context.Users.Attach(tempUser);
                    context.Users.Remove(tempUser);
                    context.SaveChanges();
                }
            }
        }

        public ObservableCollection<Role> GetRoles()
        {
            return Roles = new ObservableCollection<Role>(DBContext.localConnection.Role);
        }

        public bool IsUserCorrect(string login, string password)
        {
            return GetUser(login, password) != null;
        }

        public Users GetUser(string login, string password)
        {
            return GetUsers().Where(user => user.login == login && user.password == password).FirstOrDefault();
        }

        public bool TryLogin(string login, string password)
        {
            return GetUsers().Where(user => user.login == login && user.password == password).Count() == 1;
        }

        public List<ValidationResult> ValidateTeacher(Teachers teacher)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(teacher);
            Validator.TryValidateObject(teacher, context, results, true);
            return results;
        }

        public List<ValidationResult> ValidateUser(Users user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            Validator.TryValidateObject(user, context, results, true);
            return results;
        }

        public string GetFullUserName()
        {
            return $"{CurrentUser.User.surname} {CurrentUser.User.name} {CurrentUser.User.patronymic} {CurrentUser.User.Role.name}";
        }

        public string GetFullUserName(Users user)
        {
            return $"{user.surname} {user.name} {user.patronymic}";
        }


        public string GetFullNameTeacher(Teachers teachers)
        {
            return $"{teachers.surname} {teachers.name} {teachers.patronymic}";
        }

    }
}
