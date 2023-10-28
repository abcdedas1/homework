using System.Data;
namespace HelloNetMauiBlazorHybridApp.Pages
{
    public partial class FetchData
    {
        private async Task InitializeAsync() =>
            await _poetryStorage.InitializeAsync();
        private string _name;

        private string _content;
        private string _query;
        private async Task SaveAsync()
        {
            var poetry = new Models.Poetry
                { Name = _name, Content = _content };
            await _poetryStorage.SavePoetryAsync(poetry);
        }

        private async Task Get()
        {
            _poetries = await _poetryStorage.GetAllPoetriesAsync();
        }
        
        private IEnumerable<Models.Poetry> _poetries = new List<Models.Poetry>();
       
        private async Task QueryAsync()
        {
            _poetries = await _poetryStorage.SearchByNameAsync(_query);//???有问
        }
        private async Task ReturnQuery()
        {
            _poetries = await _poetryStorage.SearchByNameAsync("");//???有问
            _query = "";
        }

        private async Task delete(int a)
        {
            _poetries = await _poetryStorage.Delete(a);
            _query = "";
        }
    }
}
