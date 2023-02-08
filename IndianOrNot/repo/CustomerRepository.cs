using System;
using IndianOrNot.model;

namespace IndianOrNot.repo
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly Dictionary<Guid, Company> _companies = new();

        public void Create(Company company)
        {
            if (company is null)
            {
                return;
            }

            _companies[company.Id] = company;
        }

        public Company? GetById(Guid id)
        {
            if (_companies.ContainsKey(id))
                return _companies[id];
            else return null;
        }

        public List<Company> GetAll()
        {
            return _companies.Values.ToList();
        }

        public void Update(Company Company)
        {
            var existingCompany = GetById(Company.Id);
            if (existingCompany is null)
            {
                return;
            }
            _companies[Company.Id] = Company;
        }

        public void Delete(Guid id)
        {
            _companies.Remove(id);
        }
    }


}

