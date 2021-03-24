using EFDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp
{
    public class InitialData
    {
        // Initializare Studenti
        static public Dictionary<string,Student> st1;
    
        static public List<Student> students = new List<Student> {
                    new Student { Age = 23, FirstName = "Victor",LastName="Madan",Email="madan@mail.ru",About="Imi place sa am bani",Telefon=06080777},
                    new Student {Age=25,FirstName="Ron",LastName="Wesley",Email="ronwesl@mail.ru",About="Is stingaci, mii rusine de mine",Telefon=06087632},
                    new Student {Age=18,FirstName="Draco",LastName="Malfoy",Email="malfoy@mail.ru",About="Ma tin cel mai pizdos",Telefon=07643343},
                    new Student{Age =22,FirstName="Nevill",LastName="Longobottom",Email="nevill@mail.ru",About="Daca te socoti de a pula fa cunostinta cu mine",Telefon=06080777},
                    new Student {Age=21,FirstName="Harry",LastName="Potter",Email="potter@mail.ru",About="Is individual ca port ochelari ",Telefon=06033777},
                    new Student {Age=13,FirstName="Hermiona",LastName="Granger",Email="granger@mail.ru",About="Is botan multilaterala, daca ti -i somn vorbeste cu mine deodata te adorm",Telefon=0643434},
                    new Student {Age=12,FirstName="Gina",LastName="WesleyG",Email="sex@mail.ru",About="Am par rud, peste tot!!!!",Telefon=032432}
                };
        static public Dictionary<string,Student> studs { get {

             
                st1 = new Dictionary<string, Student>();
                
                     foreach (var el in students)
                {
                    st1.Add(el.LastName, el);
                }


                return st1; } }


        // Loghin si parola pentru intrare ca student
        static public List<LogStudent> lg1;
        static public List<LogStudent> logStudents { get
            {
                lg1 = new List<LogStudent>
                {
                    new LogStudent{Login="Victor",Password="Madan",Student=studs["Madan"]},
                    new LogStudent{Login="Ron",Password="Wesley",Student=studs["Wesley"]},
                    new LogStudent{Login="Draco",Password="Malfoy",Student=studs["Malfoy"]},
                    new LogStudent{Login="Nevill",Password="Longobottom",Student=studs["Longobottom"]},
                    new LogStudent{Login="Harry",Password="Potter",Student=studs["Potter"]},
                    new LogStudent{Login="Hermiona",Password="Granger",Student=studs["Granger"]},
                    new LogStudent{Login="Gina",Password="WesleyG",Student=studs["WesleyG"]},
                };

                return lg1;
            } }


        // Initializare Cursuri

        static public List<Curs> cursuri = new List<Curs>
            {
                new Curs {Name="Charming",Profesor="Pizda McGonnagall",About="Te inveti a encanta obiecte schimbindu-i proprietatile"},
                new Curs {Name="Transfiguration",Profesor="Albus Dambldor",About="Arta de a deveni ce vrai" },
                new Curs {Name="Alchemy",Profesor="Severus Snape",About="Compozitia !!!Berei!! nu va o invat , Sorry"},
                new Curs {Name="Care_Magical_Animals",Profesor="Rubeus Hagrid",About="Ranitul la vaci, curatitul la porci, pe scurt forte de munca nu ajung!!!"},
                new Curs {Name="Defense_Black_Powers",Profesor="Liupus Liupin",About="Maninci pizdon de la toti?, si n-ai bani pentru un winchester, vino la noi (30 de metode de a masacra un ambal),alta oferta cautam ambali care doresc sa isi dedice viata stiintei subexperimentali in biologie  "}
            };


        static public Dictionary<string,Curs> cs1;
        static public Dictionary<string,Curs> curs { get
            {
                cs1 = new Dictionary<string, Curs>();
                foreach (var el in cursuri)
                {
                    cs1.Add(el.Name, el);
                }


                return cs1;
            } }
        // Loghin si parola pentru intrare ca admin
        public static List<LogCurs> admins;
        public static List<LogCurs> logAdmins
        {
            get
            {
                admins = new List<LogCurs>
            {
                new LogCurs {Login="Alchemy",Password="Severus",Curs=curs["Alchemy"]},
                new LogCurs {Login="Charming",Password="Pizda",Curs=curs["Charming"]},
                    new LogCurs {Login="Transfiguration",Password="Albus",Curs=curs["Transfiguration"]},
                    new LogCurs {Login="Care_Magical_Animals",Password="Rubeus",Curs=curs["Care_Magical_Animals"]},
                    new LogCurs {Login="Defense_Black_Powers",Password="Liupus",Curs=curs["Defense_Black_Powers"]},

            };

                return admins;
            }
        }

        // Initializare Note
        static public List<Note> notes;
        static public List<Note> nots { get
            {
                notes = new List<Note>
            {
                new Note {Nota=8,Curs=curs["Alchemy"],Student=studs["Madan"]},
                new Note {Nota=9,Curs=curs["Transfiguration"],Student=studs["Madan"]},
                new Note {Nota=10,Curs=curs["Care_Magical_Animals"],Student=studs["Madan"]},
                new Note {Nota=7,Curs=curs["Charming"],Student=studs["Madan"]},
                new Note {Nota=5,Curs=curs["Defense_Black_Powers"],Student=studs["Madan"]},

                new Note {Nota=8,Curs=curs["Alchemy"],Student=studs["Malfoy"]},
                new Note {Nota=3,Curs=curs["Transfiguration"],Student=studs["Malfoy"]},
                new Note {Nota=4,Curs=curs["Care_Magical_Animals"],Student=studs["Malfoy"]},
                new Note {Nota=10,Curs=curs["Charming"],Student=studs["Malfoy"]},
                new Note {Nota=10,Curs=curs["Defense_Black_Powers"],Student=studs["Malfoy"]},

                 new Note {Nota=2,Curs=curs["Alchemy"],Student=studs["Wesley"]},
                new Note {Nota=3,Curs=curs["Transfiguration"],Student=studs["Wesley"]},
                new Note {Nota=10,Curs=curs["Care_Magical_Animals"],Student=studs["Wesley"]},
                new Note {Nota=1,Curs=curs["Charming"],Student=studs["Wesley"]},
                new Note {Nota=3,Curs=curs["Defense_Black_Powers"],Student=studs["Wesley"]},

                 new Note {Nota=5,Curs=curs["Alchemy"],Student=studs["WesleyG"]},
                new Note {Nota=10,Curs=curs["Transfiguration"],Student=studs["WesleyG"]},
                new Note {Nota=10,Curs=curs["Care_Magical_Animals"],Student=studs["WesleyG"]},
                new Note {Nota=9,Curs=curs["Charming"],Student=studs["WesleyG"]},
                new Note {Nota=7,Curs=curs["Defense_Black_Powers"],Student=studs["WesleyG"]},

                 new Note {Nota=2,Curs=curs["Alchemy"],Student=studs["Potter"]},
                new Note {Nota=5,Curs=curs["Transfiguration"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Care_Magical_Animals"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Charming"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Defense_Black_Powers"],Student=studs["Potter"]},

                 new Note {Nota=10,Curs=curs["Alchemy"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Transfiguration"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Care_Magical_Animals"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Charming"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Defense_Black_Powers"],Student=studs["Granger"]},

                 new Note {Nota=2,Curs=curs["Alchemy"],Student=studs["Longobottom"]},
                new Note {Nota=7,Curs=curs["Transfiguration"],Student=studs["Longobottom"]},
                new Note {Nota=6,Curs=curs["Care_Magical_Animals"],Student=studs["Longobottom"]},
                new Note {Nota=5,Curs=curs["Charming"],Student=studs["Longobottom"]},
                new Note {Nota=5,Curs=curs["Defense_Black_Powers"],Student=studs["Longobottom"]},

            };


                return notes;
            } 
        }
      


        // Initializare in BD
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(students);
            }
            if (!context.Cursuri.Any())
            {
                context.Cursuri.AddRange(cursuri);
            }
            if (!context.Notes.Any())
            {
                context.Notes.AddRange(nots);
            }
            if (!context.LogCurs.Any())
            {
                context.LogCurs.AddRange(logAdmins);
            }
            if (!context.LogStudents.Any())
            {
                context.LogStudents.AddRange(logStudents);
            }
            context.SaveChanges();
        }
    }
}
