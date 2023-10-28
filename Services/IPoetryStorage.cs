using HelloNetMauiBlazorHybridApp.Models;
namespace HelloNetMauiBlazorHybridApp.Services;

public interface IPoetryStorage{
   Task InitializeAsync(); 
    Task SavePoetryAsync(Poetry poetry);
    Task<Poetry> GetPoetryAsync(int id);
    Task<IEnumerable<Poetry>> SearchByNameAsync(string name);

    Task<IEnumerable<Poetry>> GetAllPoetriesAsync();//获得全部诗歌
    Task<IEnumerable<Poetry>> Delete(int index);
}
