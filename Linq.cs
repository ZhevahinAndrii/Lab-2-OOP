using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    internal class Linq:IStrategy
    {
        List<PaperWork> information = new List<PaperWork>();
        XDocument doc = new XDocument();
        public Linq(string path)
        {
            doc=XDocument.Load(path);
        }
        public List<PaperWork> Algorithm(PaperWork student,string path)
        {
            List<XElement> match=(from val in doc.Descendants("student")
                                  where
                                  ((student.Course==null||student.Course==val.Parent.Parent.Attribute("COURSE").Value)&&
                                  (student.Group==null||student.Group==val.Parent.Attribute("GROUP").Value) &&
                                     (student.Auditory == null || student.Auditory == val.Attribute("AUDITORY").Value) &&
                                     (student.Surname == null || student.Surname == val.Attribute("SURNAME").Value) &&
                                     (student.Name == null ||student.Name == val.Attribute("NAME").Value) &&
                                     (student.PhoneNumber == null || student.PhoneNumber == val.Attribute("PHONENUMBER").Value))
                                  select val).ToList();
            foreach(XElement obj in match)
            {
                PaperWork paperwork=new PaperWork();
                paperwork.Course = obj.Parent.Parent.Attribute("COURSE").Value;
                paperwork.Group = obj.Parent.Attribute("GROUP").Value;
                paperwork.Auditory = obj.Attribute("AUDITORY").Value;
                paperwork.Surname = obj.Attribute("SURNAME").Value;
                paperwork.Name = obj.Attribute("NAME").Value;
                paperwork.PhoneNumber = obj.Attribute("PHONENUMBER").Value;
                information.Add(paperwork);
            }
            return information;
        }
    }
}
