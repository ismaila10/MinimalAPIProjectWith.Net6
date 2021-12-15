using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIProjectWith.Net6.Models;
using MinimalAPIProjectWith.Net6.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IJobService, JobService>();

var app = builder.Build();

app.UseSwagger();
app.UseAuthorization();
app.UseAuthentication();

app.MapGet("/", () => "Hello World!");

app.MapPost("/create",
    (Job job, IJobService service) => CreateJob(job, service));

app.MapGet("/get",
    (int id, IJobService service) => GetJobById(id, service));

app.MapGet("/list",
    (IJobService service) => GetJobs(service));

app.MapPut("/edit",
    (Job job, IJobService service) => UpdateJob(job, service));

app.MapDelete("/delete",
    (int id, IJobService service) => DeleteJobById(id, service));

IResult CreateJob(Job job, IJobService service)
{
    return Results.Ok(service.CreateJob(job));
}

IResult GetJobById(int id, IJobService service)
{
    return Results.Ok(service.GetJobById(id));
}

IResult GetJobs(IJobService service)
{
    return Results.Ok(service.GetJobs());
}

IResult UpdateJob(Job job, IJobService service)
{
    var newJob = service.GetJobById(job.Id);

    if (newJob is null) Results.NotFound("Job not found");

    return Results.Ok(newJob);
}

IResult DeleteJobById(int id, IJobService service)
{
    var result = service.DeleteJobById(id);

    if (!result) Results.BadRequest("Something went wrong");

    return Results.Ok(result);
}

app.UseSwaggerUI();

app.Run();
