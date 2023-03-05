using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Установка Quary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> Set<T>() where T : class;
        /// <summary>
        /// Добавления сушности асинхронно
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        /// <summary>
        /// Сохранение в БД
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Выполненеи транзакции
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task InvokeTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);
        /// <summary>
        /// Выполненеи транзакции с шаблоном
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> InvokeTransactionAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
    }
}
