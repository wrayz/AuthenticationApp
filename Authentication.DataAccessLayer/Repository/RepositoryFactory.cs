using System;
using Authentication.Domain.Interfaces;

namespace Authentication.DataAccessLayer.Repository
{
    public static class GenericRepositoryFactory
    {
        public static IRepository<T> CreateInstance<T>() where T : class
        {
            IRepository<T> repository;

            var name = typeof(T).Name;

            switch (name)
            {
                case "User":
                    repository = new AuthRepository() as IRepository<T>;
                    break;
                default:
                    throw new Exception($"尚未定義{name}Repository");
            }

            return repository;
        }
    }
}
