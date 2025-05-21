using System.Reflection;
using System.Security.Claims;
using System.Xml.Linq;

namespace Day5Bai01
{
    internal class Student //// Bai 1
    {
        protected int _id {  get; } // b. readOnly chi get ko cho set
        protected String _name;
        protected String Name
        {
            get 
            { 
                return _name; 
            }
            private set 
            { 
                _name = value;
            }
        }
        String _class;
        protected String Class
        {
            get
            {
                return _class;
            }
            private set
            {
                _class = value;
            }
        }
        String _gender;
        protected String Gender
        {
            get
            {
                return _gender;
            }
            private set
            {
                _gender = value;
            }
        }
        protected float _score;
        protected float Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;
            }
        }
        // a. Ham khoi tao
        public Student()
        {
            _id = 0;
            _name = "";
            _class = "";
            _gender = "";
            _score = 0f;
        }
        public Student(int id, string name, string @class, string gender, float score)
        {
            _id = id;
            _name = name;
            _class = @class;
            _gender = gender;
            _score = score;
        }
        ////////////////////////////////////////////////////////
        // d. phuong thuc sua doi thong tin sinh vien
        public void EditName(string name)
        {
            _name = name;
        }
        public void EditClass(string @class)
        {
            _class = @class;
        }
        public void EditGender(string @gender)
        {
            _gender = @gender;
        }
        public void EditScore(float score)
        {
            _score = score;
        }
        ////////////////////////////////////////////////////////
        
        // Ham check so luong sv nhap vao
        protected int CheckInt(string context)
        {
            bool checker = false;
            int number = 0;
            do
            {
                Console.Write(context);
                checker = int.TryParse(Console.ReadLine(), out number);
            } while (!checker);

            return number;
        }
        // in thong tin cua 1 Student
        protected void PrintInfoStudent()
        {
            Console.WriteLine("ID: {0}. Name: {1}. Class: {2}. Gender: {3}. Score: {4}", _id, _name, _class,_gender, _score);
        }
        // e. Ham SetScore
        protected virtual void SetScore(List<float> scores)
        {
            if (scores == null || scores.Count ==0)
            {
                return;
            }
            float scoreTB = scores.Average();
            if (scoreTB < 6)
            {
                Console.WriteLine("Sinh viên co ID: {0}. Ten la: {1}. Co diem: {2} thap hon 6",_id,_name,scoreTB);
            }
            _score = scoreTB;
        }
        protected void CanhBao()
        {
            if (_score < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SINH VIEN NAY DIEM DUOI TRUNG BINH");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("SINH VIEN DAT DIEM");
            }
            Console.ResetColor();
            Console.WriteLine("--------------------------");
        }
        // SET DIEM KO CANH BAO
        protected void AddScore(List<float> scores)
        {
            if (scores == null || scores.Count == 0)
            {
                return;
            }
            float scoreTB = scores.Average();
            _score = scoreTB;
        }
        static void Main(string[] args)
        {
            //C. Tao DS 5 SV
            List<Student> students = new List<Student>
            {
                new Student(1,"An","A1","Nam",9),
                new Student(2,"Linh","A1","Nam",6),
                new Student(3,"Huy","A1","Nam",5),
                new Student(4,"Linh","A1","Nam",7),
                new Student(5,"Trang","A1","Nam",3),
            };
            //////////////////////////////////////////
            // in ra DS SV ban dau
            Console.WriteLine("DANH SACH SV MOI NHAP");
            foreach (var student in students)
            {
                student.PrintInfoStudent();
                if (student._score < 6)
                {
                    student.CanhBao();
                }
            }
            Console.WriteLine("*******************");
            //////////////////////////////////////////
            Student svtemp = new Student(6, "Quan", "A2", "Nam", 100f);
            students.Add(svtemp);
            svtemp.SetScore(new List<float> { 9, 5, 6, 9, 9 });
            // Them diem toan cao cap va in danh sach
            Console.WriteLine("DANH SACH SV DIEM TOAN CAO CAP");
            foreach (var student in students)
            {
                Random rd = new Random();               
                student.AddScore(new List<float> { rd.Next(10), rd.Next(20), rd.Next(20) });
                student.PrintInfoStudent();
                student.CanhBao();
            }
            Console.WriteLine("*******************");
            // Them diem triet
            Console.WriteLine("DANH SACH SV DIEM TRIET HOC");
            foreach (var student in students)
            {
                Random rd = new Random();
                student.AddScore(new List<float> { rd.Next(10), rd.Next(20), rd.Next(20) });
                student.PrintInfoStudent();
                student.CanhBao();
            }
            Console.WriteLine("*******************");
        }
    }
}
