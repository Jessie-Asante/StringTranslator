using StringConverter.Models.Domain;

namespace StringConverter.Models.ViewModel
{
    public class GetViewModel
    {
        public IQueryable<TblConvertString> TblConvertStrings { get;set; }
    }
}
