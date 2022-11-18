using System.Text.Json;
using API.RequestHelpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class HttpExtentions
{
  public static void AddPaginationHeader(this HttpResponse response, MetaData metaData)
  {
    //var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    response.Headers.Add("Pagination", JsonConvert.SerializeObject(metaData));
    //response.Headers.Add("Pagination", JsonConvert.JsonSerializerOptions(metaData,options));
    response.Headers.Add("Access-Control-Expose-Headers","Pagination");

  }

}