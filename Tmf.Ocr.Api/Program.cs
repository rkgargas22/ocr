using FluentValidation;
using Tmf.Logs;
using Tmf.Ocr.Api.Middleware;
using Tmf.Ocr.Api.Validations;
using Tmf.Ocr.Core.Options;
using Tmf.Ocr.Core.RequestModels;
using Tmf.Ocr.Infrastructure.HttpServices;
using Tmf.Ocr.Infrastructure.Interfaces;
using Tmf.Ocr.Infrastructure.Services;
using Tmf.Ocr.Manager.Interfaces;
using Tmf.Ocr.Manager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.Configure<OcrOptions>(builder.Configuration.GetSection(OcrOptions.Ocr));
builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHttpServices, HttpServices>();

builder.Services.AddScoped<IOcrRepository, OcrRepository>();

builder.Services.AddScoped<IOcrManager, OcrManager>();

builder.Services.AddScoped<IValidator<AadharExtractRequest>, AadharExtractValidator>();
builder.Services.AddScoped<IValidator<DataAadhar>, DataAadharValidator>();

builder.Services.AddScoped<IValidator<DrivingLicenseExtractRequest>, DrivingLicenseExtractValidator>();
builder.Services.AddScoped<IValidator<DataDL>, DataDLValidator>();

builder.Services.AddScoped<IValidator<VoterIdExtractionRequest>, VoterIdExtractValidator>();
builder.Services.AddScoped<IValidator<DataVoterId>, DataVoterIdValidator>();

builder.Services.AddScoped<IValidator<ValidateDocumentRequest>, ValidationDocumentValidator>();
builder.Services.AddScoped<IValidator<Data>, DataValidator>();
builder.Services.AddScoped<IValidator<AdvancedFeatures>, AdvanceFeatureValidator>();

builder.Services.AddScoped<IValidator<TaskDetailRequest>, TaskDetailValidator>();

builder.Services.AddScoped<IValidator<DocumentMaskingRequest>, DocumentMaskingValidator>();
builder.Services.AddScoped<IValidator<DataMasking>, DataMaskingValidator>();

builder.Services.AddSingleton<ILog, Log>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
