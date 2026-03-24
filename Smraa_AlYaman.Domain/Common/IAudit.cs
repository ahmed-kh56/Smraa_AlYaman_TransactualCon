namespace Smraa_AlYaman.Domain.Common
{
    public interface IAudit<IdType>
    {
        Guid AuditId { get; }
        IdType EntityId { get; }






        DateTime From { get; }
        DateTime ChangedAt { get; }
        bool IsRecovered { get; }



    }
}
