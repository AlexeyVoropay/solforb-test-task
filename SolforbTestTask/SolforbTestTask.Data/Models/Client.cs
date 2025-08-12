namespace SolforbTestTask.Data.Models;

/// <summary>
/// Клиент
/// </summary>
public class Client
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Состояние (1 - "В работе", 2 - "В архиве")
    /// </summary>
    public int Condition { get; set; }
}