using System.Net.Http.Json;
using System.Web;

public class ChosenFunctionAppCalls
{
    private static string functionApp = "chosenfunctionapp";
    public static async Task<string> CallFirstFunction(string yourName)
    {
        const string functionName = "firstfunction";
        const string key = "9o7I4iVhnZxh8ID_a40irBaM97NadICnLr7JBdOZWEcFAzFuyTf6AQ";
        yourName = HttpUtility.UrlEncode(yourName);
        
        var url = $"https://{functionApp}.azurewebsites.net/api/{functionName}?code={key}==&name={yourName}";
        Console.WriteLine($"Encoded URL: {url}");
        
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        
        if (!response.IsSuccessStatusCode) return "Request Failed";
        
        string responseContent = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(responseContent);

        return responseContent;
    }
    
    public static async Task<List<DatabaseField>> CallDatabaseFunction()
    {
        const string key = "7Yf1DWftjuwfreuVbS-mTQyOOoo7gWb0IMwFaqL0pOdTAzFulQ7Xxg==";
        const string functionName = "databasefunction";
        
        var url = $"https://{functionApp}.azurewebsites.net/api/{functionName}?code={key}";
        Console.WriteLine($"Encoded URL: {url}");
        
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        var data = await response.Content.ReadFromJsonAsync<List<DatabaseField>>();

        return response.IsSuccessStatusCode ? data : new List<DatabaseField>();
    }
    
    // var connectionString = "Server=tcp:xchosen.database.windows.net,1433;Initial Catalog=blazorDatabase;Persist Security Info=False;User ID=CloudSA326ab916;Password=Matabase@1324;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

}

public class DatabaseField
{
    public int Id { get; set; }
    public string Name { get; set; }
}