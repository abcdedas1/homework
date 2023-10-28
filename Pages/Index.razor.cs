
namespace HelloNetMauiBlazorHybridApp.Pages
{
    public partial class Index
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
            _name = "";
            _content = "";
        }
        
        private async Task QueryAsync()
        {
            _poetries = await _poetryStorage.SearchByNameAsync(_query);//???有问
        }
        private IEnumerable<Models.Poetry> _poetries = new List<Models.Poetry>();
        

    }
}
