using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher betul = new Teacher(mediator) { Name = "Betül" };

            Student ibrahim = new Student(mediator) { Name = "İbrahim" };
            Student emir = new Student(mediator) { Name = "Emir" };
            Student hasan = new Student(mediator) { Name = "Hasan" };

            mediator.Teacher = betul;

            List<Student> students = new List<Student> { ibrahim, emir, hasan };

            mediator.Students = students;

            betul.SendNewImageUrl("slide1.jpg");
            betul.RecieveQuestion("Is it true?", ibrahim);

            Console.ReadLine();

        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"Teacher recieved question from {student.Name}.\n{question}");
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question: {0}, {1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }
        public void RecieveImage(string url)
        {
            Console.WriteLine("Student recieved image {0}", url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void RecieveAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}