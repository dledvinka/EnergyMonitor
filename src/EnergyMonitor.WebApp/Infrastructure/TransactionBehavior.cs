using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnergyMonitor.WebApp.Data;
using MediatR;

namespace EnergyMonitor.WebApp.Infrastructure
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly EnergyMonitorContext _dbContext;

        public TransactionBehavior(EnergyMonitorContext dbContext) => _dbContext = dbContext;

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await _dbContext.BeginTransactionAsync();
                var response = await next();
                await _dbContext.CommitTransactionAsync();
                return response;
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}
