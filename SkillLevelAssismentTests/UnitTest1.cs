using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SkillAssesmentCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkillLevelAssismentTests
{

    [TestClass]
    public class UnitTest1
    {
        Core core = new Core();


        [TestMethod]
        public void TestAuth()
        {
            string correctLogin = "admin";
            string correctPassword = "admin";
            string incorrectPassword = "qq";
            string incorrectLogin = "adm";
            Assert.IsTrue(core.IsUserCorrect(correctLogin, correctPassword)); 

            Assert.IsFalse(core.IsUserCorrect(correctLogin, incorrectPassword)); // incorrect data

            Assert.IsFalse(core.IsUserCorrect(incorrectLogin, incorrectPassword));

            Assert.IsFalse(core.IsUserCorrect(incorrectLogin, correctPassword));
        }

        [TestMethod]
        public void CorrectSavingAndDeletingTeacher()
        {
            Teachers teacher = new Teachers {
                name = "test",
                surname = "test",
                categories_id = 1,
                subject_id = 1,
                disctict_id = 1,
                post_id = 4,
                institution_id = 1
            };

            Assert.IsNotNull(teacher);

            {
                core.AddTeachers(teacher);
                ObservableCollection<Teachers> teachers = core.GetTeachers();
                Assert.IsTrue(teachers.Contains(teacher));
            }

            {
                core.RemoveTeachers(teacher);
                ObservableCollection<Teachers> teachers = core.GetTeachers();
                Assert.IsFalse(teachers.Contains(teacher));
            }
        }

        [TestMethod]
        public void CorrectSavingAndDeletingPost()
        {

            Posts post = new Posts
            {
                name = "test"
            };

            Assert.IsNotNull(post);

            {
                core.AddPosts(post.name);
                ObservableCollection<Posts> posts = core.GetPosts();
                Assert.IsTrue(posts.Where(x => x.name == post.name).Count() == 1);
            }


            {
                core.RemovePosts(post);
                ObservableCollection<Posts> posts = core.GetPosts();
                Assert.IsFalse(posts.Contains(post));
            }
        }

        [TestMethod]
        public void CorrectSavingAndDeletingSubject()
        {

            Subjects subject= new Subjects
            {
                name = "test"
            };

            Assert.IsNotNull(subject);

            {
                core.AddSubject(subject.name);
                ObservableCollection<Subjects> subjects = core.GetSubjects();
                Assert.IsTrue(subjects.Where(x => x.name == subject.name).Count() == 1);
            }

            {
                core.RemoveSubject(subject);
                ObservableCollection<Subjects> subjects = core.GetSubjects();
                Assert.IsFalse(subjects.Contains(subject));
            }
        }

        [TestMethod]
        public void CorrectSavingAndDeletingDistricts()
        {

            Discticts disctict = new Discticts
            {
                name = "test"
            };

            Assert.IsNotNull(disctict);

            {
                core.AddDisctics(disctict.name);
                ObservableCollection<Discticts> discticts = core.GetDiscticts();
                Assert.IsTrue(discticts.Where(x => x.name == disctict.name).Count() == 1);
            }

            {
                core.RemoveDisctics(disctict);
                ObservableCollection<Discticts> discticts = core.GetDiscticts();
                Assert.IsFalse(discticts.Contains(disctict));
            }
        }

        [TestMethod]
        public void CorrectSavingAndDeletingInstitutions()
        {

            Institution institution = new Institution
            {
                name = "test",
                disctrict_id = 5
            };

            Assert.IsNotNull(institution);

            {
                core.AddInstitution(institution);
                ObservableCollection<Institution> institutions = core.GetInstitutions();
                Assert.IsTrue(institutions.Where(x => x.name == institution.name).Count() == 1);
            }

            {
                core.RemoveInstitutions(institution);
                ObservableCollection<Institution> institutions = core.GetInstitutions();
                Assert.IsFalse(institutions.Contains(institution));
            }
        }

        [TestMethod]
        public void CorrectSavingAndDeletingCategories()
        {

            Categories category = new Categories
            {
                name = "test"
            };

            Assert.IsNotNull(category);

            {
                core.AddCategory(category.name);
                ObservableCollection<Categories> categories = core.GetCategories();
                Assert.IsTrue(categories.Where(x => x.name == category.name).Count() == 1);
            }

            {
                core.RemoveCategory(category);
                ObservableCollection<Categories> categories = core.GetCategories();
                Assert.IsFalse(categories.Contains(category));
            }
        }
        [TestMethod]
        public void CorrectSavingAndDeletingUsers()
        {
            Users user = new Users
            {
                login = "login",
                password = "password",
                name = "name",
                surname = "surname",
                patronymic = "patronymic",
                role_id = 1
            };

            Assert.IsNotNull(user);

            {
                core.AddUsers(user);
                ObservableCollection<Users> users = core.GetUsers();
                Assert.IsTrue(users.Contains(user));
            }

            {
                core.RemoveUsers(user);
                ObservableCollection<Users> users = core.GetUsers();
                Assert.IsFalse(users.Contains(user));
            }
        }

        public void TestingGetFullUserName()
        {
            Users user = new Users
            {
                login = "login",
                password = "password",
                name = "name",
                surname = "surname",
                patronymic = "patronymic",
                role_id = 1
            };

            Assert.IsNotNull(user);

            Assert.AreEqual(core.GetFullUserName(user), "surname name patronymic");
        }


        [TestMethod]
        public void TestingGetFullTeacherName()
        {
            Teachers teacher = new Teachers
            {
                name = "name",
                surname = "surname",
                patronymic = "patronymic",
                categories_id = 1,
                subject_id = 1,
                disctict_id = 1,
                post_id = 4,
                institution_id = 1
            };

            Assert.IsNotNull(teacher);


            Assert.AreEqual(core.GetFullNameTeacher(teacher), "surname name patronymic");

        }
    }
}
