using Api.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Api.Persistence.Configurations
{
    //BrandConfiguration sınıfı, Brand sınıfını bir veritabanı tablosuyla eşleştirmek üzere yapılandırma sağlar.
    //IEntityTypeConfiguration<Brand> arabirimini uygulayan BrandConfiguration sınıfının Configure yöntemi,
    //EntityTypeBuilder<Brand> nesnesini parametre olarak alır.Bu nesne, Brand sınıfının veritabanı tablosu ile ilişkilendirilmesini sağlar.
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(256);

            Faker faker = new("tr");

            Brand Brand1 = new() 
            { 
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate= DateTime.Now,  
                IsDeleted = false,  
            };

            Brand Brand2 = new()
            {
                Id = 2,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            Brand Brand3 = new()
            {
                Id = 3,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };

            //builder.HasData() yöntemi, Entity Framework Core (EF Core) Fluent API kullanılarak bir veritabanı tablosuna başlangıç verilerini eklemek için kullanılır.
            //Bu yöntem, bir veya birden fazla varlık örneğini belirli bir tabloya eklemek için kullanılır ve genellikle veritabanı ilk oluşturulduğunda veya bir güncelleme yapıldığında kullanılır.
            builder.HasData(Brand1,Brand2,Brand3);
        }
    }
}


//Fluent API (Akıcı Arabirim), bir yazılım arayüzünün tasarlanmasında kullanılan bir programlama yaklaşımıdır.
//Entity Framework Core (EF Core) içinde Fluent API, ilişkisel veritabanı modellerinin ve yapılandırmalarının tanımlanması için kullanılır.
//Bu API, özellikle ORM (Object-Relational Mapping) araçlarıyla çalışan veritabanı işlemlerini daha esnek ve açık bir şekilde yapmanıza olanak tanır.
//Entity Framework Core'da Fluent API, ilişkisel veritabanlarındaki tabloların, sütunların ve ilişkilerin nasıl oluşturulacağını ve yapılandırılacağını belirleme sürecini sağlar.
//Fluent API, veritabanı ile uygulama arasında daha fazla kontrol ve özelleştirme sağlamak için kullanılır.