using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {

        private EmployeeContext _db;
        private IEmployeeStorage _storage;

        public EmployeeController(IEmployeeStorage storage)
        {
            _storage = storage;
        }
        //test:
        // 1. whether returns to Employees
        // 2. whether employee is deleted
        public ActionResult DeleteEmployee(int id)
        {
            _storage.DeleteEmployee(id);
            return RedirectToAction("Employees");

        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }

    public class RedirectResult : ActionResult { }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}