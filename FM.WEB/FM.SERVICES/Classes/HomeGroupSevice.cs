using System;
using System.Collections.Generic;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;

namespace FM.SERVICES.Classes
{
    public class HomeGroupSevice : IHomeGroupService
    {
        private readonly IHomeGroupRepository _groupRepository;
        public HomeGroupSevice(IHomeGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public bool DeleteHomeGroup(long id)
        {
            try
            {
                HomeGroup HomeGroup = GetHomeGroup(id);
                _groupRepository.Remove(HomeGroup);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public HomeGroup GetHomeGroup(long id)
        {
            return _groupRepository.Get(id);
        }

        public IEnumerable<HomeGroup> GetHomeGroups()
        {
            return _groupRepository.GetAll();
        }

        public HomeGroup InsertHomeGroup(HomeGroup HomeGroup)
        {
            try
            {
                return _groupRepository.Insert(HomeGroup);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public HomeGroup UpdateHomeGroup(HomeGroup HomeGroup)
        {
            try
            {
                return _groupRepository.Update(HomeGroup);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
