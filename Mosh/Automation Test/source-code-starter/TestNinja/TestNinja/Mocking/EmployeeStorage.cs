/**
* @Project Name: $projectname$ ： EmployeeStorage
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/15/2018 3:45:49 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/15/2018 3:45:49 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/

namespace TestNinja.Mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployee(int id);
    }

    class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
