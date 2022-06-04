using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillAssesmentCore;

namespace SkillLevelAssismentConsole
{
    class Program
    {
        public static Core core = new Core();
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение SkillLevelAssisment!");
            Console.WriteLine("Выберите из пункта меню желаемое действие:");

            GetMenu();

 

        }

        static void GetMenu()
        {
            Console.WriteLine("1. Просмотреть список районов");
            Console.WriteLine("2. Просмотреть список учителей");
            Console.WriteLine("3. Просмотреть список учреждений");
            Console.WriteLine("4. Просмотреть список категорий");
            Console.WriteLine("5. Просмотреть список должностей");
            Console.WriteLine("6. Просмотреть список предметов");

            string n = Console.ReadLine();

            switch (n)
            {
                case "1":
                    ShowDistricts();
                    break;
                case "2":
                    ShowTeachers();
                    break;
                case "3":
                    ShowInstitutuons();
                    break;
                case "4":
                    ShowCategories();
                    break;
                case "5":
                    ShowPosts();
                    break;
                case "6":
                    ShowSubjects();
                    break;
                default:
                    GetMenu();
                    break;
            }
        }

        static void ShowDistricts()
        {
            var districts = core.GetDiscticts();
            var cnt = 0;
            foreach (var d in districts)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Название {d.name}");
            }
        }

        static void ShowTeachers()
        {
            var teachers = core.GetTeachers();
            var cnt = 0;
            foreach (var t in teachers)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Фамилия: {t.surname} | Имя: {t.name} | Отчество: {t.patronymic} | Категория: {t.Categories.name} |" +
                    $" Район: {t.Discticts.name} | Учреждение: {t.Institution.name} | Должность: {t.Posts.name} | Предмет: {t.Subjects.name}");
                Console.WriteLine();
            }
        }

        static void ShowInstitutuons()
        {
            var institutions = core.GetInstitutions();
            var cnt = 0;
            foreach (var i in institutions)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Название {i.name} | Район {core.GetDiscticts().Where(x => x.disctrict_id == i.disctrict_id).FirstOrDefault().name}");
            }
        }



        static void ShowCategories()
        {
            var categories = core.GetCategories();
            var cnt = 0;
            foreach (var c in categories)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Название {c.name}");
            }
        }

        static void ShowPosts()
        {
            var posts = core.GetPosts();
            var cnt = 0;
            foreach (var p in posts)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Название {p.name}");
            }
        }

        static void ShowSubjects()
        {
            var subjects = core.GetSubjects();
            var cnt = 0;
            foreach (var s in subjects)
            {
                cnt++;
                Console.WriteLine($"{cnt}. Название {s.name}");
            }
        }
    }
}
