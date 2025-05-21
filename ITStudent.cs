using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day5Bai01 //// Bai 2
{
    internal class ITStudent:Student
    {
        public ITStudent() : base()
        {

        }
        public ITStudent(int id, string name, string @class, string gender, float score) : base(id, name, @class, gender, score)
        {

        }
        ///////// ghi de ham SetScore
        protected override void SetScore(List<float> scores)
        {
            if (scores == null || scores.Count == 0)
            {
                return;
            }
            float scoreTB = scores.Average();
            if (scoreTB < 5.5f)
            {
                Console.WriteLine("Sinh viên co ID: {0}. Ten la: {1}. Co diem: {2} thap hon 6", _id, _name, scoreTB);
            }
            _score = scoreTB;
        }
    }
}
