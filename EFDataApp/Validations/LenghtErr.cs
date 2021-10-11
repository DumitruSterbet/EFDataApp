using EFDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Validations
{
    public class LenghtErr
    {
        public string errMess = "Introdu cel putin 4 simboluri";
        public string errMessAge = "Virsta nu poate fi mai mica de 18 ani";
        public string errMessEm = "Adresa email trebuie sa contina @";
        public bool ifNull(Object input)
        {
            if (input.ToString().Length<4)
                return true;
            return false;

        }

        public string nullValidation(Object obj)
        {
            string k = "";
            if (obj is Student)
            {
                Student client = (Student)obj;
                if (ifNull(client.FirstName))
                    k = k + "1";
                if (ifNull(client.LastName))
                    k = k + "2";
                if (ifNull(client.Telefon))
                    k = k + "3";
                if (client.Age <18)
                    k = k + "4";
                if (ifNull(client.About))
                    k = k + "5";
                if (ifNull(client.Email))
                    k = k + "6";
                if (!client.Email.Contains("@"))
                    k = k + "7";
            }
            if (obj is LogStudent)
            {
                LogStudent client = (LogStudent)obj;
                if (ifNull(client.Login))
                    k = k + "1";
                if (ifNull(client.Password))
                    k = k + "2";

            }
            if (obj is Curs)
            {
                Curs client = (Curs)obj;
                if (ifNull(client.Name))
                    k = k + "1";
                if (ifNull(client.Profesor))
                    k = k + "2";
                if (ifNull(client.About))
                    k = k + "3";
            }
            if (obj is LogCurs)
            {
                LogCurs client = (LogCurs)obj;
                if (ifNull(client.Login))
                    k = k + "1";
                if (ifNull(client.Password))
                    k = k + "2";

            }
            if (obj is LogAmin)
            {
                LogAmin client = (LogAmin)obj;
                if (ifNull(client.Login))
                    k = k + "1";
                if (ifNull(client.Password))
                    k = k + "2";
            }

            return k;
        }
    }
}
