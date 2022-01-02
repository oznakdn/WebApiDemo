using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Entities;

namespace WebApiDemo.UI.Repositories
{
    public class WebApiDemoRepo
    {
        public HttpClient _client;
        public HttpResponseMessage _response;

        public WebApiDemoRepo()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5164");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public async Task<List<Product>>Getlist()
        {
            _response = await _client.GetAsync($"/api/products");

            var json = await _response.Content.ReadAsStringAsync();
            var listProduct = JsonConvert.DeserializeObject<List<Product>>(json);
            return listProduct;
        }

        public async Task<Product> Get(int id)
        {

            _response = await _client.GetAsync($"api/products/{id}");

            var json = await _response.Content.ReadAsStringAsync();
            var Product = JsonConvert.DeserializeObject<Product>(json);
            return Product;
        }


        public void Add(Product product)
        {
            var result = JsonConvert.SerializeObject(product);
            var buffer = Encoding.UTF8.GetBytes(result);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync("api/products", byteContent);
        }

        public void Delete(int id)
        {
            _client.DeleteAsync($"api/products/{id}");
        }

        

        public void Update(Product product, int id)
        {
            var result = JsonConvert.SerializeObject(product);
            var buffer = Encoding.UTF8.GetBytes(result);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"api/products/{id}", byteContent);
        }
    }
}
