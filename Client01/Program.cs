// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;


//var input = new HelloRequest { Name = "Reza" };
//var channel = GrpcChannel.ForAddress("http://localhost:5210");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(input);



//var channel = GrpcChannel.ForAddress("http://localhost:5210");
//var customerclient = new Customer.CustomerClient(channel);

//var request = new CustomerLookModal { UserId = 22 };


//var customer = await customerclient.GetCustomerInfoAsync(request);
//Console.WriteLine($"{customer.LastName}  {customer.LastName}"); 


//using (var call  = customerclient.GetNewCustomers(new NewCustomerRequest()))
//{
//    while (await call.ResponseStream.MoveNext())
//    {
//        var cust = call.ResponseStream.Current;
//        Console.WriteLine($"{cust.FirstName} - fmly:  {cust.LastName}");

//    }
//}





var channelNew = GrpcChannel.ForAddress("http://localhost:5210");
var sss = new ProductsService.ProductsServiceClient(channelNew);

var requestsss =  sss.GetAll(new Empty());






