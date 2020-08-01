namespace EntityframeworkCoreDemo
{
    public interface IEmployeeRepo
    {
        Employee Create(
            string firstname,
            string lastname,
            string address,
            string homephone,
            string cellphone);

        Employee Update(Employee employee);
        void Delete(Employee employee);
    }
}