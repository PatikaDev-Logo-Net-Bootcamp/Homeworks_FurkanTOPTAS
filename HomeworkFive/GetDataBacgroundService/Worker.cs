using First.App.Business.Abstract;
using First.App.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetDataBacgroundService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient httpClient;
        private readonly IPostService _postService;

        public Worker(ILogger<Worker> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }
        
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            httpClient.Dispose();
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Post>>(response);
                    foreach (var item in posts)
                    {
                        _postService.AddPost(item);//Error 
                    } 

                }
                else
                {
                    _logger.LogError("Error while getting data from jsonplaceholder.typicode.com/posts");
                }
                await Task.Delay(1000, stoppingToken);

            }
        }
    }
}
