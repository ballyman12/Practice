using Practice.BusinessLogic.Implement;
using Practice.BusinessLogic.Interface;
using Practice.Repository.Implement;
using Practice.Repository.Interface;
using StructureMap;


namespace Practice.IoC
{
    public class SimpleIoCRegistry : Registry
    {
        public SimpleIoCRegistry()
        {
            For<IItemRepository>().Use<ItemRepository>();
            For<IItemBusinessLogic>().Use<ItemBusinessLogic>();
        }
    }
}
