namespace Domain.Entities;

public class AuditLog : Entity
{
    public Guid RecordId { get; set; }
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public string OriginalValue { get; set; }
    public string UpdatedValue { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}

