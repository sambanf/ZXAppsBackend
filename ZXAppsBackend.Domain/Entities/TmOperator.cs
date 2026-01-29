namespace ZXAppsBackend.Domain.Entities;

public class TmOperator
{
    public int OperatorPk { get; set; }
    public string NoOperator { get; set; } = string.Empty;
    public string NIP { get; set; } = string.Empty;
    public string Nama { get; set; } = string.Empty;
    public int StatusFk { get; set; }
}
