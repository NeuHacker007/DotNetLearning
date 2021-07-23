using System.Collections.Generic;
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

        public override async Task GetAllCustomers(
            AllCustomerModel request,
            IServerStreamWriter<CustomerDataModel> responseStream,
            ServerCallContext context
            )
        {
            var allCustomers = new List<CustomerDataModel>() {
                new CustomerDataModel() {

                    FirstName = "Eva 1",
                    LastName = "Zhang"
                },
                 new CustomerDataModel() {

                    FirstName = "Reachel Zhao",
                    LastName = "Zhang"
                },
                 new CustomerDataModel() {

                    FirstName = "Eric",
                    LastName = "Li"
                },
                 new CustomerDataModel() {

                    FirstName = "addam",
                    LastName = "A"
                },
            };
            foreach (var item in allCustomers)
            {
                await responseStream.WriteAsync(item);
            }
        }
    }
}