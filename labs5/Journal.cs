using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Journal
    {
        private List<JournalEntry> data = [];

        public List<JournalEntry>  Data
        {
            get { return data; }
        }

        public Journal(string typeEvent, params StudentCollection[] colls)
        {
            foreach (StudentCollection collection in colls)
            {
                switch (typeEvent)
                {
                    case "Count":
                        {
                            collection.StudentsCountChanged += HandleStudentsCountChanged;
                            break;
                        }
                    case "Reference":
                        {
                            collection.StudentReferenceChanged += HandleStudentReferenceChanged;
                            break;
                        }
                    case "All":
                        {
                            collection.StudentsCountChanged += HandleStudentsCountChanged;
                            collection.StudentReferenceChanged += HandleStudentReferenceChanged;
                            break;
                        }
                }
            }
            //if (typeEvent == "Count")
            //{
            //    collection.StudentsCountChanged += HandleStudentsCountChanged;
            //}
            //if (typeEvent == "Reference")
            //{
            //    collection.StudentReferenceChanged += HandleStudentReferenceChanged;
            //}
            //if (typeEvent == "All")
            //{
            //    collection.StudentsCountChanged += HandleStudentsCountChanged;
            //    collection.StudentReferenceChanged += HandleStudentReferenceChanged;
            //}
        }


        public override string ToString()
        {
            return String.Join('\n', Data);
        }

        public void HandleStudentsCountChanged(object source, StudentListHandlerEventArgs args)
        {
            JournalEntry journalEntry = new
                (args.TitleOfCollection, 
                args.TypeOfChanges, 
                args.ChangedStudent);

            data.Add(journalEntry);
        }

        public void HandleStudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            JournalEntry journalEntry = new
                (args.TitleOfCollection,
                args.TypeOfChanges,
                args.ChangedStudent);

            data.Add(journalEntry);
        }

    }

    class JournalEntry
    {
        public string TitleOfCollection { get; set; }
        public string TypeOfChanges { get; set; }

        public Student ChangedStudent { get; set; }

        public JournalEntry()
        {
            this.TitleOfCollection = "TitleOfCollection";
            this.TypeOfChanges = "TypeOfChanges";
            this.ChangedStudent = new Student();
        }

        public JournalEntry
            (string title, string type, Student student)
        {
            this.TitleOfCollection = title;
            this.TypeOfChanges = type;
            this.ChangedStudent = student;
        }

        public override string ToString()
        {
            string str;
            str = $"TitleOfCollection: {this.TitleOfCollection}\n" +
                $"TypeOfChanges: {this.TypeOfChanges}\n" +
                $"ChangedStudent: {this.ChangedStudent.ToShortString()}\n";
            return str;
        }
    }
}
