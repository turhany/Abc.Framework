
namespace Abc.Core.Utilities.Search
{
    public class SearchFilter
    {
        public string PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }
}
