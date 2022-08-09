// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

#region Test
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
#endregion

var channelNew = GrpcChannel.ForAddress("http://localhost:5210");
var Server = new ProductsService.ProductsServiceClient(channelNew);
List<long> taketimes = new List<long>();
for (int i = 0; i < 10; i++)
{
    Task.Delay(10000);
    var watch1 = System.Diagnostics.Stopwatch.StartNew();
    var requestssss = Server.GetAll(new Empty());
    watch1.Stop();
    taketimes.Add(watch1.ElapsedMilliseconds);
    var insertdata = Server.PostTimeAsync(new InsertTest { Time = watch1.ElapsedMilliseconds });
}
Console.ReadLine();








