namespace Day5Bai01
{
    internal class Student
    {
        public int Id {  get; } // b. readOnly chi get ko cho set
        private String Name { get; set; }
        String Class { get; set; }
        String Gender {  get; set; }
        float Score {  get; set; }  
        // a. Ham khoi tao
        public Student()
        {

        }
        public Student(int id, string name, string @class, string gender, float score)
        {
            Id = id;
            Name = name;
            Class = @class;
            Gender = gender;
            Score = score;
        }
        ////////////////////////////////////////////////////////
        // d. phuong thuc sua doi thong tin sinh vien
        public void EditName(string name)
        {
            Name = name;
        }
        public void EditClass(string @class)
        {
            Class = @class;
        }
        public void EditGender(string @gender)
        {
            Gender = @gender;
        }
        public void EditScore(float score)
        {
            Score = score;
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
            Console.WriteLine("ID: {0}. Name: {1}. Class: {2}. Gender: {3}. Score: {4}", Id, Name, Class,Gender, Score);
        }
        // e. Ham SetScore
        protected void SetScore(List<float> scores)
        {
            if (scores == null || scores.Count ==0)
            {
                return;
            }
            float scoreTB = scores.Average();
            if (scoreTB < 6)
            {
                Console.WriteLine("Sinh viên co ID: {0}. Ten la: {1}. Co diem: {2} thap hon 6",Id,Name,scoreTB);
            }
            Score = scoreTB;
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
            // in ra DS SV
            foreach (var student in students)
            {
                student.PrintInfoStudent();
            }
            //////////////////////////////////////////
            Student svtemp = new Student(6, "Quan", "A2", "Nam", 100f);
            students.Add(svtemp);
            svtemp.SetScore(new List<float> { 9, 5, 6, 9, 9 });
        }
    }
}
