namespace IntegrationEventLogEF;

public static class IntegrationLogExtensions
{
    public static void UseIntegrationEventLogs(this ModelBuilder builder)
    {
        builder.Entity<IntegrationEventLogEntry>(entityTypeBuilder =>
        {
            entityTypeBuilder.ToTable("IntegrationEventLog");

            entityTypeBuilder.HasKey(e => e.EventId);
        });
    }
}