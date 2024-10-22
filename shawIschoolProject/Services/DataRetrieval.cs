using System.Net.Http.Headers;

namespace shawIschoolProject.Services
{
    public class DataRetrieval
    {
        public async Task<string> GetData(string endpoint) {


            //task v thread - 
            //task has async/await and a return value, can cancel a task
            //thread - no direct way to return from a thread, thread can do multiple things at once
            
            //using - at the end of it, it is automatically disposed
            using(var client = new HttpClient())
            {
                //we need to set up our http client
                //request/response
                client.BaseAddress = new Uri("http://ischool.gccis.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    //go get it
                    var data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "httpRequest " + msg;
                }
                catch(Exception e) {
                    var msg = e.Message;
                    return "Ex: " + msg;
                }


            }


        }


    }
}
