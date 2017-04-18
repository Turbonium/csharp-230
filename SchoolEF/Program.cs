using System;
using System.Linq;

namespace SchoolEF
{
    class Program
    {
        static void Main()
        {
            // Database accessor. This opens the database automatically
            var school = new SchoolEntities();

            // This accesses the ClassMaster table
            foreach (var user in school.Users)
            {
                foreach (var classMaster in school.ClassMasters)
                {
                    Console.WriteLine(
                            "Username: {0}\nClassId: {1}\nClassName: {2}\nClassDescription: {3}\nClassPrice: {4}\n", 
                    user.UserName,
                    classMaster.ClassId,
                    classMaster.ClassName,
                    classMaster.ClassDescription,
                    classMaster.ClassPrice)
                    ;

                }
            }

            Console.Write("Done.");
            Console.ReadLine();
        }
    }
}
//var query = // your query here...
//    .GroupBy(x => x.Id)
//    .Select(g => g.First());