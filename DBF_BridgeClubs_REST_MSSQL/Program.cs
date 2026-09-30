using DBF_BridgeClubs_Lib.Interfaces;
using DBF_BridgeClubs_Lib.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

IMainClubRepository mainClubRepo = new MainClubRepository();
IMemberClubRepository memberClubRepo = new MemberClubRepository();
IMemberRepository memberRepo = new MemberRepository();
IResultRepository resultRepo = new ResultRepository();
IRoundRepository roundRepo = new RoundRepository();
ISectionPlayerRepository sectionPlayer = new SectionPlayerRepository();
ISectionRepository sectionRepo = new SectionRepository();
ISubClubRepository subClubRepo = new SubClubRepository();
ITournamentRepository tournamentRepo = new TournamentRepository();

builder.Services.AddCors(options =>
{
	options.AddPolicy("allowGet",
		builder =>
			builder.AllowAnyOrigin()
			.WithMethods("GET")
			.AllowAnyHeader());
	options.AddPolicy("allowAnything", // similar to * in Azure
		builder =>
			builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());
});

builder.Services.AddSingleton<IMainClubRepository>(mainClubRepo);
builder.Services.AddSingleton<IMemberClubRepository>(memberClubRepo);
builder.Services.AddSingleton<IMemberRepository>(memberRepo);
builder.Services.AddSingleton<IResultRepository>(resultRepo);
builder.Services.AddSingleton<IRoundRepository>(roundRepo);
builder.Services.AddSingleton<ISectionPlayerRepository>(sectionPlayer);
builder.Services.AddSingleton<ISectionRepository>(sectionRepo);
builder.Services.AddSingleton<ISubClubRepository>(subClubRepo);
builder.Services.AddSingleton<ITournamentRepository>(tournamentRepo);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseCors("allowGet");

app.MapControllers();

app.Run();
