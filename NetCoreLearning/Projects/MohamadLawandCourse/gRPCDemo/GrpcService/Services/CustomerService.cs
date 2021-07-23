using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerDataModel> GetCustomerInfo(CustomerFindModel request, ServerCallContext context)
        {
            var model = new CustomerDataModel();
            if (request.UserId == 1)
            {
                model.FirstName = "Ivan";
                model.LastName = "Zhang";
            }
            else if (request.UserId == 2)
            {
                model.FirstName = "Eva";
                model.LastName = "Zhang";
            }
            else if (request.UserId == 3)
            {
                model.FirstName = "Guopin";
                model.LastName = "Zhao";
            }
            else
            {
                model.FirstName = "Yina";
                model.LastName = "Zhang";
            }

            return Task.FromResult(model);
        }
    }
}