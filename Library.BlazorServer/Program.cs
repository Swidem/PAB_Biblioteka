using FluentValidation.AspNetCore;
using FluentValidation;
using Library.BlazorServer.Data;
using Library.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Library.Application.Validators;
using Library.SharedKernel.Dto;
using Library.Application.Services;
using Library.Domain.Contracts;
using Library.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Rejestracja automappera w kontenerze IoC
builder.Services.AddAutoMapper(typeof(Program));

// Rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState)
builder.Services.AddFluentValidationAutoValidation();

// Rejestracja kontekstu bazy w kontenerze IoC
var sqliteConnectionString = "Data Source=Library.db";
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite(sqliteConnectionString));

// Rejestracja walidatorów
builder.Services.AddScoped<IValidator<CreateBookDto>, RegisterCreateBookDtoValidator>();
builder.Services.AddScoped<IValidator<CreateClientDto>, RegisterCreateClientDtoValidator>();
builder.Services.AddScoped<IValidator<CreateEmployeeDto>, RegisterCreateEmployeeDtoValidator>();
builder.Services.AddScoped<IValidator<CreateLoanDto>, RegisterCreateLoanDtoValidator>();

// Rejestracja jednostki pracy i repozytoriów
builder.Services.AddScoped<ILibraryUnitOfWork, LibraryUnitOfWork>();
// Rejestracja repozytoriów w kontenerze IoC
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

// Rejestracja seeder
builder.Services.AddScoped<DataSeeder>();

// Rejestracja serwisu produktów
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILoanService, LoanService>();

// Dodaj us³ugi dla kontrolerów
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Seeding data
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}

app.Run();