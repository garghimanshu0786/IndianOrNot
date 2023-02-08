using System;
using IndianOrNot.model;

namespace IndianOrNot.repo
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        void Delete(Guid id);
        List<Company> GetAll();
        Company? GetById(Guid id);
        void Update(Company company);
    }
}

