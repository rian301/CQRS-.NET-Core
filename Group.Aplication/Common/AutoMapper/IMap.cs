using AutoMapper;

namespace Adm.Aplication.Common.AutoMapper
{
    public interface IMap<T>
    {
        void Mapping(Profile profile);
    }
}
