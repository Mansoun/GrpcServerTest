// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Http.Json;
using System.Text;

Console.WriteLine("Hello, World!");
List<long> result = new List<long>();
for (int i = 0; i < 10; i++)
{
    Task.Delay(10000);
    var url = "http://localhost:5262/product/getall";

    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
    var watch1 = System.Diagnostics.Stopwatch.StartNew();

    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var resultspi = streamReader.ReadToEnd();
    }
    watch1.Stop();
    result.Add(watch1.ElapsedMilliseconds);
    Console.WriteLine(httpResponse.StatusCode);
}


using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("http://localhost:5262/");
    var response = client.PostAsJsonAsync("product/SaveRecords", result).Result;
    if (response.IsSuccessStatusCode)
    {
        Console.Write("Success");
    }
    else
        Console.Write("Error");
}



