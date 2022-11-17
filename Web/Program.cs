using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using TP.Core.Interfaces.Repositories;
using TP.Core.Interfaces.Services;
using TP.Core.Services;
using TP.Infrastructure.Data;
using TP.Infrastructure.Data.Configuration;
using TP.Infrastructure.Data.Repositories;
using TP.Infrastructure.Services;
using Web.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TaskProjectConnectionProduction")
        ));
}
else
{
    // Add DbContext
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TaskProjectConnection")
        ));
}

builder.Services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();

builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    });


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:Authentication:ClientId");
    googleOptions.ClientSecret = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:Authentication:ClientSecret");
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


builder.Services.AddScoped<IImportantTaskRepository, ImportantTaskRepositoryEFSQL>();
builder.Services.AddScoped<IUrgentTaskRepository, UrgentTaskRepositoryEFSQL>();
builder.Services.AddScoped<IUserService, UserManagerService>();
builder.Services.AddScoped<IImportantTaskService, ImportantTaskService>();
builder.Services.AddScoped<IUrgentTaskService, UrgentTaskService>();

// Add Email
builder.Services.Configure<SmtpConfiguration>(options =>
{
    options.HostAddress = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:Address");
    options.HostPort = Convert.ToInt32(builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:Port"));
    options.HostUsername = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:Account");
    options.HostPassword = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:Password");
    options.SenderEmail = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:SenderEmail");
    options.SenderName = builder.Configuration.GetValue<string>("ExternalProviders:Gmail:SMTP:SenderName");
});
builder.Services.AddTransient<IEmailSender, EmailServiceMailKit>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
