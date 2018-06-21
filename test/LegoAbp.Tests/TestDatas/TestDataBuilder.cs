using LegoAbp.EntityFrameworkCore;

namespace LegoAbp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly LegoAbpDbContext _context;

        public TestDataBuilder(LegoAbpDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}