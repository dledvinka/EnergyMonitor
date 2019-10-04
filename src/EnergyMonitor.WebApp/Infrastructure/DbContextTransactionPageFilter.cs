using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMonitor.WebApp.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EnergyMonitor.WebApp.Infrastructure
{
    public class DbContextTransactionPageFilter : IAsyncPageFilter
    {
        private readonly EnergyMonitorContext _dbContext;

        public DbContextTransactionPageFilter(EnergyMonitorContext dbContext) => _dbContext = dbContext;

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            try
            {
                await _dbContext.BeginTransactionAsync();

                var actionExecuted = await next();
                if (actionExecuted.Exception != null && !actionExecuted.ExceptionHandled)
                {
                    _dbContext.RollbackTransaction();

                }
                else
                {
                    await _dbContext.CommitTransactionAsync();

                }
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}
