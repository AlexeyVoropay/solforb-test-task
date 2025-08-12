namespace SolforbTestTask.Data.Models;

/// <summary>
/// Единица измерения
/// </summary>
public class MeasureUnit
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
    /// Состояние (1 - "В работе", 2 - "В архиве")
    /// </summary>
    public int Condition { get; set; }
}
