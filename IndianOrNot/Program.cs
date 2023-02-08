using IndianOrNot.model;
using IndianOrNot.repo;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();
        builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.


        app.MapGet("/companies", ([FromServices] ICompanyRepository repository) =>
        {
            var company = repository.GetAll();
            return company is not null ? Results.Ok(company) : Results.NotFound();
        });

        app.MapGet("/company/{id}", ([FromServices] ICompanyRepository repo, Guid id) =>
        {
            var company = repo.GetById(id);
            return company is not null ? Results.Ok(company) : Results.NotFound();
        });

        app.MapDelete("/company/{id}", ([FromServices] ICompanyRepository repo, Guid id) =>
        {
            repo.Delete(id);
            return Results.Ok();
        });

        app.MapPost("/company", ([FromServices] ICompanyRepository repo, Company company) =>
        {
            repo.Create(company);
            return Results.Created($"/companies/{company.Id}", company);
        });

        app.MapPut("/company/{id}", ([FromServices] ICompanyRepository repo, Guid id, Company updatedCompany) =>
        {
            var Company = repo.GetById(id);
            if (Company is null)
            {
                return Results.NotFound();
            }
            repo.Update(updatedCompany);
            return Results.Ok(updatedCompany);
        });




        app.MapPost("/category", ([FromServices] ICategoryRepository repo, Category category) =>
        {
            repo.Create(category);
            return Results.Created($"/companies/{category.Id}", category);
        });


        app.Run();
    }
}