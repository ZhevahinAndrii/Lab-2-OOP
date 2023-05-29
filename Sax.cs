using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    internal class Sax:IStrategy
    {
        private List<PaperWork> information=new List<PaperWork>();
        private XmlReader reader;
        public Sax(string path)
        {
            reader=XmlReader.Create(path);
        }
        public List<PaperWork> Algorithm(PaperWork student,string path)
        {
            information.Clear();
            List<PaperWork> res=new List<PaperWork>();
            PaperWork stud = null;
            string _course = null;
            string _group = null;
            while (reader.Read())
            {
                if (reader.Name == "speciality")
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "COURSE")
                        {
                            _course= reader.Value;
                        }
                    }
                }
                if (reader.Name == "group")
                {
                    while(reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "GROUP")
                        {
                            _group=reader.Value;
                        }
                    }
                }
                if (reader.Name == "student")
                {  
                    stud = new PaperWork();
                    stud.Course = _course;
                    stud.Group = _group;
                    if (reader.HasAttributes)
                    {
                        while(reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "AUDITORY")
                            {
                                stud.Auditory = reader.Value;
                            }
                            if (reader.Name == "SURNAME")
                            {
                                stud.Surname = reader.Value;
                            }
                            if(reader.Name=="NAME")
                            {
                                stud.Name = reader.Value;
                            }
                            if (reader.Name == "PHONENUMBER")
                            {
                                stud.PhoneNumber= reader.Value;
                            }
                        }
                    }
                    if (stud.Surname != null) res.Add(stud);
                }
            }
            information = Filter(res, student);
            return information;
        }
        public List<PaperWork> Filter(List<PaperWork> allStudents,PaperWork param)
        {
            List<PaperWork> result = new List<PaperWork>();
            if (allStudents != null)
            {
                foreach(PaperWork student in allStudents)
                {
                    try
                    {
                        if(
                            (student.Course==param.Course||param.Course==null)&&
                            (student.Group==param.Group||param.Group==null)&&
                            (student.Auditory==param.Auditory||param.Auditory==null)&&
                            (student.Surname==param.Surname||param.Surname==null)&&
                            (student.Name==param.Name||param.Name==null)&&
                            (student.PhoneNumber==param.PhoneNumber||param.PhoneNumber==null)
                            )
                        {
                            result.Add(student);
                        }
                    }
                    catch { }
                }
            }
            return result;
        }
    }
}
