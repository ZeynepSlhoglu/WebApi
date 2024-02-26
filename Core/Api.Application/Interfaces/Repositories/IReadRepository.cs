using Api.Domain.Comman;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

        Task<IList<T>> GetAllByPackingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null); 
    }
}


/*
Task<IList<T>> ifadesi => asenkron bir metodu temsil eder ve geri dönüş değerinin IList<T> türünde bir Task olacağını belirtir.
Expression<Func<T, bool>> predicate = null parametresi => bir filtreleme ifadesini temsil eder. Varsayılan değeri null'dir, yani filtreleme kullanılmayabilir.
Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null parametresi => ilişkili verilerin sorgu sonuçlarına dahil edilmesini sağlar. Bu parametre de varsayılan olarak null olabilir.
Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null parametresi => sıralama ifadesini temsil eder. Varsayılan değeri null'dir.
bool enableTracking = false parametresi => Entity Framework gibi ORM (Object-Relational Mapping) araçlarında izleme (tracking) kullanılıp kullanılmayacağını belirler. Varsayılan olarak izleme kapalıdır (false)
 */