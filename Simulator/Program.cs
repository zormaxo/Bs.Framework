using Bs.Business;
using Bs.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Simulator
{
    internal static class Program
    {
        private static int count;

        private static void Main()
        {
            try
            {
                Thread thread = new Thread(Test);
                thread.Start();

                //for (int i = 0; i < 100; i++)
                //{
                //    Thread thread = new Thread(Test);
                //    thread.Start();
                //    Console.WriteLine(i);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        public static void Test()
        {


            var stu1Add = new StudentAddress
            {
                //Student = stu1,
                Address1 = "Turkiye"
            };

            var stu1 = new Student
            {
                StudentName = "Emre",
                StudentAddresses = new List<StudentAddress> { stu1Add }
            };

            var insert = new OStudentInsert(stu1, stu1Add);
            Student inserted = insert.Execute().Data;

            var stu2 = new Student
            {
                Guid = inserted.Guid
            };

            var delete = new OStudentDelete(stu2);
            delete.Execute();
            Console.WriteLine("count: " + count);
        }
    }
}