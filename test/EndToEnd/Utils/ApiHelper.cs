using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace EndToEnd.Utils;

public class ApiHelper
{
    private readonly RestClient _client;
    private readonly Uri _uri;
    
    public ApiHelper(Uri uri)
    {
        _client = new RestClient();
        _uri = uri;
    }

    public async Task<string> Insert<TEntity>(TEntity entity) where TEntity : Entity
    {
        var request = new RestRequest(_uri)
            .AddJsonBody(entity);

        var response = await _client.PostAsync(request);
        return response.Content!;
    }
    
    public async Task Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
    {
        foreach (var entity in entities)
        {
            await Insert(entity);
        }
    }

    public async Task Reset<TEntity>() where TEntity : Entity
    {
        var ids = await GetAll<TEntity>();
        await Delete(ids);
    }

    public async Task Delete(IEnumerable<Guid> ids)
    {
        foreach (var id in ids)
        {
            var request = new RestRequest($"{_uri}?id={id}");
            await _client.DeleteAsync(request);
        }
    }

    private async Task<IEnumerable<Guid>> GetAll<TEntity>() where TEntity : Entity
    {
        var request = new RestRequest(_uri);
        var response = await _client.GetAsync(request);
        var entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(response.Content);
        return entities.Select(x => x.Id);
    }
}