using EFDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp
{
    public class InitialData
    {    // Initializare Manager
        static public  List<LogAmin> amin;
        static public List<LogAmin> amins {get
        {
                amin = new List<LogAmin>
        {
            new LogAmin{Login="manager",Password="1"}
        };
   
                return amin;
            } }
        // Initializare Studenti
        static public Dictionary<string, Student> st1;

        static public List<Student> students = new List<Student> {
                    new Student { Age = 23, FirstName = "Victor",LastName="Madan",Email="madan-victor@bk.ru",About="Student - anul 3, Facultatea de Matematica si Informatica",Telefon=069353658},
                    new Student {Age=25,FirstName="Ron",LastName="Wesley",Email="ronwesl@mail.ru",About="Student - anul 1, Facultatea de Marketing",Telefon=06087632},
                    new Student {Age=18,FirstName="Draco",LastName="Malfoy",Email="malfoy@mail.ru",About="Student - anul 2, Facultatea de Litere",Telefon=07643343},
                    new Student{Age =22,FirstName="Nevill",LastName="Longobottom",Email="nevill@mail.ru",About="Student - anul 4, Facultatea de Drept",Telefon=06080777},
                    new Student {Age=21,FirstName="Harry",LastName="Potter",Email="potter@mail.ru",About="Student - anul 2, Facultatea de Jurnalistica",Telefon=06033777},
                    new Student {Age=19,FirstName="Hermiona",LastName="Granger",Email="granger@mail.ru",About="Student - anul 1, Facultatea de Business si Administrare",Telefon=0643434},
                    new Student {Age=22,FirstName="Gina",LastName="WesleyG",Email="wesley@mail.ru",About="Student - anul 3, Facultatea de Istorie",Telefon=067324312}
                };
        static public Dictionary<string, Student> studs
        {
            get
            {


                st1 = new Dictionary<string, Student>();

                foreach (var el in students)
                {
                    st1.Add(el.LastName, el);
                }


                return st1;
            }
        }


        // Loghin si parola pentru intrare ca student
        static public List<LogStudent> lg1;
        static public List<LogStudent> logStudents
        {
            get
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
            }
        }


        // Initializare Cursuri

        static public List<Curs> cursuri = new List<Curs>
            {
                new Curs {Name="Java",Profesor="Elena McGonnagall",About="Java este un limbaj de programare care se utilizează pentru producerea şi dezvoltarea unui număr mare de aplicaţii software şi pentru implementarea acestora în cele mai diferite medii multiplatformă."},
                new Curs {Name="Merceologie",Profesor="Dubceac Anatolii",About="Disciplină al cărei obiect îl constituie studierea proprietăților fizice și chimice ale mărfurilor în vederea stabilirii calității lor și a condițiilor de păstrare" },
                new Curs {Name="Chimia",Profesor="Vdovcenco Natalia",About="Chimia reprezintă una dintre ramurile științelor naturale al cărei obiect de studiu îl constituie compoziția, structura, proprietățile și schimbarea materiei"},
                new Curs {Name="Business",Profesor="Rubeus Hagrid",About="Afacerea este activitatea de a-și câștiga existența sau de a câștiga bani prin producerea sau cumpărarea și vânzarea de produse (cum ar fi bunuri și servicii)."},
                new Curs {Name="Dreptul_Penal",Profesor="Liupus Liupin",About="Dreptul penal reprezintă instrumentul prin care se apără cele mai importante valori sociale împotriva faptelor periculoase."}
            };


        static public Dictionary<string, Curs> cs1;
        static public Dictionary<string, Curs> curs
        {
            get
            {
                cs1 = new Dictionary<string, Curs>();
                foreach (var el in cursuri)
                {
                    cs1.Add(el.Name, el);
                }


                return cs1;
            }
        }
        // Loghin si parola pentru intrare ca admin
        public static List<LogCurs> admins;
        public static List<LogCurs> logAdmins
        {
            get
            {
                admins = new List<LogCurs>
            {
                new LogCurs {Login="Chimia",Password="Severus",Curs=curs["Chimia"]},
                new LogCurs {Login="Java",Password="Java123",Curs=curs["Java"]},
                    new LogCurs {Login="Merceologie",Password="Albus",Curs=curs["Merceologie"]},
                    new LogCurs {Login="Business",Password="Rubeus",Curs=curs["Business"]},
                    new LogCurs {Login="Dreptul_Penal",Password="Liupus",Curs=curs["Dreptul_Penal"]},

            };

                return admins;
            }
        }

        // Initializare Note
        static public List<Note> notes;
        static public List<Note> nots
        {
            get
            {
                notes = new List<Note>
            {
                new Note {Nota=8,Curs=curs["Chimia"],Student=studs["Madan"]},
                new Note {Nota=9,Curs=curs["Merceologie"],Student=studs["Madan"]},
                new Note {Nota=10,Curs=curs["Business"],Student=studs["Madan"]},
                new Note {Nota=7,Curs=curs["Java"],Student=studs["Madan"]},
                new Note {Nota=5,Curs=curs["Dreptul_Penal"],Student=studs["Madan"]},

                new Note {Nota=8,Curs=curs["Chimia"],Student=studs["Malfoy"]},
                new Note {Nota=3,Curs=curs["Merceologie"],Student=studs["Malfoy"]},
                new Note {Nota=4,Curs=curs["Business"],Student=studs["Malfoy"]},
                new Note {Nota=10,Curs=curs["Java"],Student=studs["Malfoy"]},
                new Note {Nota=10,Curs=curs["Dreptul_Penal"],Student=studs["Malfoy"]},

                 new Note {Nota=2,Curs=curs["Chimia"],Student=studs["Wesley"]},
                new Note {Nota=3,Curs=curs["Merceologie"],Student=studs["Wesley"]},
                new Note {Nota=10,Curs=curs["Business"],Student=studs["Wesley"]},
                new Note {Nota=1,Curs=curs["Java"],Student=studs["Wesley"]},
                new Note {Nota=3,Curs=curs["Dreptul_Penal"],Student=studs["Wesley"]},

                 new Note {Nota=5,Curs=curs["Chimia"],Student=studs["WesleyG"]},
                new Note {Nota=10,Curs=curs["Merceologie"],Student=studs["WesleyG"]},
                new Note {Nota=10,Curs=curs["Business"],Student=studs["WesleyG"]},
                new Note {Nota=9,Curs=curs["Java"],Student=studs["WesleyG"]},
                new Note {Nota=7,Curs=curs["Dreptul_Penal"],Student=studs["WesleyG"]},

                 new Note {Nota=2,Curs=curs["Chimia"],Student=studs["Potter"]},
                new Note {Nota=5,Curs=curs["Merceologie"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Business"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Java"],Student=studs["Potter"]},
                new Note {Nota=10,Curs=curs["Dreptul_Penal"],Student=studs["Potter"]},

                 new Note {Nota=10,Curs=curs["Chimia"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Merceologie"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Business"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Java"],Student=studs["Granger"]},
                new Note {Nota=10,Curs=curs["Dreptul_Penal"],Student=studs["Granger"]},

                 new Note {Nota=2,Curs=curs["Chimia"],Student=studs["Longobottom"]},
                new Note {Nota=7,Curs=curs["Merceologie"],Student=studs["Longobottom"]},
                new Note {Nota=6,Curs=curs["Business"],Student=studs["Longobottom"]},
                new Note {Nota=5,Curs=curs["Java"],Student=studs["Longobottom"]},
                new Note {Nota=5,Curs=curs["Dreptul_Penal"],Student=studs["Longobottom"]},

            };


                return notes;
            }
        }



        // Initializare in BD
        public static void Initialize(ApplicationContext context)
        {
            if (!context.LogAmins.Any())
            {
                context.LogAmins.AddRange(amins);
            }
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
