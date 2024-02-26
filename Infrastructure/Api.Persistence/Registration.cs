using Api.Application.Interfaces.Repositories;
using Api.Persistence.Context;
using Api.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Api.Persistence
{
    public static class Registration
    {

        //Extension metotlar, genellikle static metotlar olarak tanımlanır çünkü:

        //Erişim Kolaylığı: Extension metotlar, tanımlandıkları sınıfa ait nesneler üzerinde çağrılır, ancak bu metotlar static olarak tanımlandığından,
        //*******nesne oluşturmadan******* doğrudan sınıf üzerinden çağrılabilirler.Bu, erişimin kolay ve doğrudan olmasını sağlar.

        //Tanımlama Kolaylığı: Bir nesnenin üzerine eklenecek olan metotun nesneye ait bir özelliği değiştirmesi veya nesne içindeki verilere ulaşması gerekmez.
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        }
    }
}

//Extension method (uzantı yöntemi), C# ve diğer .NET dillerinde, mevcut bir sınıfa veya tipe yeni bir metot eklemek için kullanılan bir programlama tekniktir.
//Uzantı yöntemleri, mevcut bir tür üzerine yazılmış normal bir statik metot gibidir,
//ancak bu metotları tanımlamak için orijinal türün kodunu değiştirmenize veya yeni bir tür türetmenize gerek yoktur.
//Bu, özellikle framework veya kütüphane sınıfları üzerinde metotlar eklemek için kullanışlıdır.