namespace SelectAllEmployes
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            
            // 1300+ Records in Profiler, every 4 or smth is select so around 300 maybe
            EmployeePrint(context);

            // Around 180 Records in the Profiler, 36 selects only
            EmployeePrintWithInclude(context);

            // Again 1300+ Records :)
            string city = "Sofia";
            SelectTown(context, city);

            // And the winer issssss : 1 query :)
            SelectTownFaster(context, city);
        }

        private static void SelectTownFaster(TelerikAcademyEntities context, string city)
        {
            var towns = context.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == city).ToList();

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }
        }

        private static void SelectTown(TelerikAcademyEntities context, string city)
        {
            var towns = context.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == city);

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }
        }

        private static void EmployeePrintWithInclude(TelerikAcademyEntities context)
        {
            foreach (var employee in context.Employees.Include("Department").Include("Address"))
            {
                Console.WriteLine("Employy: {0} {1} {2}, {3}, {4}", employee.FirstName, employee.MiddleName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
        }

        private static void EmployeePrint(TelerikAcademyEntities context)
        {
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Employy: {0} {1} {2}, {3}, {4}", employee.FirstName, employee.MiddleName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
        }
    }
}
