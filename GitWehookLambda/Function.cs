using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GitWehookLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(Stream stream, ILambdaContext context)
        {
            Console.WriteLine("serialzing...with reader");

            var input = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                 input =  reader.ReadToEnd();
            }

            dynamic pullRequest = JsonConvert.DeserializeObject(input);

            var title = pullRequest?.pull_request?.title;

            Console.WriteLine($"title of the PR is {title}");
            return new APIGatewayProxyResponse
                   {
                       Body = title,
                       Headers = new Dictionary<string, string>
                                 {
                                     {
                                         "key", "value"
                                     }
                                 },
                       IsBase64Encoded = false,
                       StatusCode = 200
                   };
        }
    }
}
