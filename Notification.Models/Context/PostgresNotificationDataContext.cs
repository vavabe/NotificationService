using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Models.Context
{
    public class PostgresNotificationDataContext : DbContext
    {
        public PostgresNotificationDataContext(DbContextOptions<PostgresNotificationDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
