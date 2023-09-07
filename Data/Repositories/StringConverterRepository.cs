using StringConverter.Data.Interfaces;
using StringConverter.Models.Domain;

namespace StringConverter.Data.Repositories
{
    public class StringConverterRepository:IStringConverterRepository
    {
        private readonly StringConverterDbContext _context;
        public StringConverterRepository(StringConverterDbContext context)=> _context = context;

        public TblConvertString Add(TblConvertString add)
        {
            _context.TblConvertStrings.Add(add);
            _context.SaveChanges();
            return add;
        }

        public TblConvertString? Delete(TblConvertString Guid)
        {
            TblConvertString del = _context.TblConvertStrings.Find(Guid);
            if (del != null)
            {
                _context.TblConvertStrings.Remove(del);
                _context.SaveChanges();
            }
            return del;
        }
        
        public IEnumerable<TblConvertString> GetAll()
        {
            return _context.TblConvertStrings;
        }

        public TblConvertString Get (int id)
        {
            return _context.TblConvertStrings.Find(id);
        }

        public TblConvertString Update(TblConvertString update)
        {
            var translate = _context.TblConvertStrings.Attach(update);
            translate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }
    }
}
