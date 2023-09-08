using StringConverter.Models.Domain;

namespace StringConverter.Data.Interfaces
{
    public interface IStringConverterRepository
    {
        TblConvertString Add(TblConvertString add);
        TblConvertString Delete(TblConvertString Guid);
        TblConvertString Get(int id);
        IEnumerable<TblConvertString> GetAll();
        Task<IEnumerable<TblConvertString>> GetAllAsync(FormattableString query);
        TblConvertString Update(TblConvertString update);
    }
}