using PrBx8.solution.services.impl;

namespace PrBx8.solution.services;

public interface IService <T>
{   
    public void Save(T entity);
    public void Delete(long id);
    public T Get(long id);
    public List<T> GetAll();
    public List<T> GetAll(ClientService.SortField sortField, ClientService.SortOrder sortOrder);
    public List<T> FindAll(List<string> query);
}