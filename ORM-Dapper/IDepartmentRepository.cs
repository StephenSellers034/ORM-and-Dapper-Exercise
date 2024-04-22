using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
        public IEnumerable<Department> GetAllDepartments(); //Stubbed out method
        public void InsertDepartment(string newDepartmentName);
    }
}

