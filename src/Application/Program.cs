using AutoMapper;
using CrossCutting.DependencyInjection;
using CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureContext.ConfigureDependenciesService(builder.Services);
ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesService(builder.Services);

var mapperConfiguration = new AutoMapper.MapperConfiguration(
    cfg => cfg.AddProfile(
        new PessoaProfile()
    )
);

IMapper mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
