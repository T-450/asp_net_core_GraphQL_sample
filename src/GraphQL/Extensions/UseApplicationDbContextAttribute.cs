namespace ConferencePlanner.GraphQL
{
    using Data;
    using HotChocolate.Data;

    public class UseApplicationDbContextAttribute : UseDbContextAttribute
    {
        public UseApplicationDbContextAttribute() : base(typeof(ApplicationDbContext)) { }
    }
}
