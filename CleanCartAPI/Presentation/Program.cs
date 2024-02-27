
using Application.Implementations;
using Application.Interfaces;
using Infrastructure.KafkaProducers;
using Infrastructure.Repositories;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();

            builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();
            builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("Kafka"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
