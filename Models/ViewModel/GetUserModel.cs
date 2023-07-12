using StringConverter.Models.Domain;

namespace StringConverter.Models.ViewModel
{
    public class GetUserModel
    {
        public IQueryable<User> Users { get; set; }
    }
}
