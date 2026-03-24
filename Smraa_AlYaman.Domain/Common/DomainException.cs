namespace Smraa_AlYaman.Domain.Common;

public class DomainException :Exception
{
    public DomainException(string massage,string code = "DomainError"): base(massage)
    {
        Code = code;
    }
    public string Code { get; internal set; }
    public static DomainException AlreadyDeletedEntity = new DomainException("This entity is already deleted", "AlreadyDeletedEntity");
    public static DomainException AlreadyRecoveredAudit = new DomainException("This Audit is already Recoverd", "AlreadyRecoveredAudit");

}
