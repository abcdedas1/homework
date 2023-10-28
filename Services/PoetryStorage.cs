using HelloNetMauiBlazorHybridApp.Models;
using SQLite;

namespace HelloNetMauiBlazorHybridApp.Services;

public class PoetryStorage : IPoetryStorage
{
    public const string DbName = "poetrydb.sqlite3";

    public static readonly string PoetryDbPath =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData), DbName);

    private SQLiteAsyncConnection _connection;

    private SQLiteAsyncConnection Connection =>
        _connection ??= new SQLiteAsyncConnection(PoetryDbPath);

    public async Task InitializeAsync() =>
        await Connection.CreateTableAsync<Poetry>();

    public async Task SavePoetryAsync(Poetry poetry) =>
        await Connection.InsertAsync(poetry);

    public async Task<Poetry> GetPoetryAsync(int id) =>
        await Connection.Table<Poetry>().Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Poetry>> SearchByNameAsync(string name) =>
        await Connection.Table<Poetry>()
            .Where(p => p.Name.Contains(name))
            .ToListAsync();

    public async Task<IEnumerable<Poetry>> GetAllPoetriesAsync() => await Connection.Table<Poetry>().ToListAsync();

    public async Task<IEnumerable<Poetry>> Delete(int index)
    {
        var poetries = await Connection.Table<Poetry>().ToListAsync();

       
            var poetryToDelete = poetries[index];
            await Connection.DeleteAsync(poetryToDelete);
        

        return await Connection.Table<Poetry>().ToListAsync();
    }


}

