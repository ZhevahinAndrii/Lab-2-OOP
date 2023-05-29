using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PaperWork
    {
        public string Course = null;
        public string Group = null;
        public string Auditory = null;
        public string Surname = null;
        public string Name = null;
        public string PhoneNumber = null;

        public PaperWork()
        {
            
        }
        public PaperWork(List<string> data)
        {
            Course = data[0];
            Group = data[1];
            Auditory = data[2];
            Surname = data[3];
            Name = data[4];
            PhoneNumber = data[5];
        }
        //public override bool Equals(object obj)
        //{
        //    if (obj is PaperWork paperwork) {
        //        if (Course == paperwork.Course && Group == paperwork.Group &&
        //            Surname == paperwork.Surname && Auditory == paperwork.Auditory
        //            && Name == paperwork.Name && PhoneNumber == paperwork.PhoneNumber) return true;
        //        return false;
        //    }
        //    return false;
            
        //}
        public IStrategy Algo { get; set; }
        public List<PaperWork> Algorithm(PaperWork parameters,string path)
        {
            return Algo.Algorithm(parameters,path);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
