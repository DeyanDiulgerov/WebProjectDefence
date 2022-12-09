using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data;

namespace WebProject.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static GameStoreDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<GameStoreDbContext>()
                    .UseInMemoryDatabase("GameStoreInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new GameStoreDbContext(dbContextOptions, false);
            }
        }
    }
}
