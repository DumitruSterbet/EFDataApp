using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Validations
{
    public class NoteErr
    {
        public string errNote = "Inrodu nota intre 1-10";

        public string noteValid(int input)
        {
            string k = "";
            if (input < 1 || input > 10)
                k = k + "1";
            return k;

        }
    }
}
