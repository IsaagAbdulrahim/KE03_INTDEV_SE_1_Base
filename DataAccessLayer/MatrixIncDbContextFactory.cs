using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer
{
    public class MatrixIncDbContextFactory : IDesignTimeDbContextFactory<MatrixIncDbContext>
    {
        public MatrixIncDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MatrixIncDbContext>();
            optionsBuilder.UseSqlite("Data Source=MatrixInc.db");

            return new MatrixIncDbContext(optionsBuilder.Options);
        }
    }
}
