using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ILogger <CustomerService> logger)
        {
            this.logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookModal request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();
            if (request.UserId==1)
            {
                output.FirstName = "Reza";
                output.LastName = "Six";
            }
            if (request.UserId == 2)
            {
                output.FirstName = "Ahmad";
                output.LastName = "Naghi";
            }

            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(
            NewCustomerRequest request
            , IServerStreamWriter<CustomerModel> responseStream
            , ServerCallContext context)
        {

            List<CustomerModel> data = new List<CustomerModel>()
            {
                new CustomerModel
                {
                    FirstName = "Reza",
                    LastName = "Shesh",
                    Age = 32,
                    EmailAddress = "Reza@",
                    IsActive = true
                },
                 new CustomerModel
                {
                    FirstName = "Ali",
                    LastName = "Ahmadi",
                    Age = 22,
                    EmailAddress = "Ali@",
                    IsActive = false
                },
                  new CustomerModel
                {
                    FirstName = "mamad",
                    LastName = "mamadi",
                    Age = 44,
                    EmailAddress = "mamad@",
                    IsActive = false
                }
            };

            foreach (var item in data)
            {
               await responseStream.WriteAsync(item);
            }


        }

    }
}
