namespace SolforbTestTask.Data.Models;

//http://193.32.203.182:8081/Directories/Resource/List

/// <summary>
/// Ресурс
/// </summary>
public class Resource
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
