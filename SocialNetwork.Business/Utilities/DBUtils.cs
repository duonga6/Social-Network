using Microsoft.Extensions.Logging;
using SocialNetwork.Common;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.Business.Utilities
{
    public static class DBUtils
    {
        private static readonly ILogger _logger = StaticLogger.GetLogger(typeof(DBUtils));

        public static async Task ExecuteWithTransactionAsync(IUnitOfWork unitOfWork, Action action, bool throwIfError = true)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(action);

            try
            {
                await unitOfWork.BeginTransactionAsync();
                action();
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error message: {ErrorMessage}", ex.Message);
                
                try
                {
                    await unitOfWork.RollbackAsync();
                }
                catch (Exception rollbackEx)
                {
                    _logger.LogError(rollbackEx, "Additional error during transaction rollback: {ErrorMessage}", rollbackEx.Message);
                }

                if (throwIfError)
                {
                    throw;
                }
            }
        }

        public static async Task ExecuteWithTransactionAsync(IUnitOfWork unitOfWork, Func<Task> asyncAction, bool throwIfError = true)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(asyncAction);

            try
            {
                await unitOfWork.BeginTransactionAsync();
                await asyncAction();
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error message: {ErrorMessage}", ex.Message);

                try
                {
                    await unitOfWork.RollbackAsync();
                }
                catch (Exception rollbackEx)
                {
                    _logger.LogError(rollbackEx, "Additional error during transaction rollback: {ErrorMessage}", rollbackEx.Message);
                }

                if (throwIfError)
                {
                    throw;
                }
            }
        }

        public static async Task<T> ExecuteWithTransactionAsync<T>(IUnitOfWork unitOfWork, Func<Task<T>> asyncAction, bool throwIfError = true)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(asyncAction);

            try
            {
                await unitOfWork.BeginTransactionAsync();
                var result = await asyncAction();
                await unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error message: {ErrorMessage}", ex.Message);

                try
                {
                    await unitOfWork.RollbackAsync();
                }
                catch (Exception rollbackEx)
                {
                    _logger.LogError(rollbackEx, "Additional error during transaction rollback: {ErrorMessage}", rollbackEx.Message);
                }

                if (throwIfError)
                {
                    throw;
                }

                return default!;
            }
        }
    }
}
