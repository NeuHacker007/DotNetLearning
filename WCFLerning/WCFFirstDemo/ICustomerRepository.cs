using System.Data;

namespace WCFFirstDemo
{
    interface ICustomerRepository
    {
        DataSet GetCustNameAutoComplete();
    }
}
