using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
    class Questionairre
    {
        private Int64 id_number;
        private List<string> question_list = new List<string>();

        public Int64 idNumber { get { return id_number; } set { id_number = value; } }
        public List<string> questionList { get { return question_list; } set { question_list = value; } }

        public Questionairre(Int64 id, List<string> questions)
        {
            this.id_number = id;
            this.question_list = questions;
        }
    }
}
