using FM.DATA;
using System.Collections.Generic;

namespace FM.SERVICES.Interfaces
{
    public interface IHomeGroupService
    {
        IEnumerable<HomeGroup> GetHomeGroups();
        HomeGroup GetHomeGroup(long id);
        HomeGroup InsertHomeGroup(HomeGroup HomeGroup);
        HomeGroup UpdateHomeGroup(HomeGroup HomeGroup);
        bool DeleteHomeGroup(long id);
    }
}
