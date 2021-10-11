using EFDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Validations.Students
{
    public class NullErr
    {
        public string errMess = "Cimpul nu poate fi vid";
        public bool ifNull(Object input)
        {
            if (input == null)
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
                if (client.Telefon == 0)
                    k = k + "3";
                if (client.Age == 0)
                    k = k + "4";
                if (ifNull(client.About))
                    k = k + "5";
                if (ifNull(client.Email))
                    k = k + "6";
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
