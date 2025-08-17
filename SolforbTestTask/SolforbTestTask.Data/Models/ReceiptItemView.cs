namespace SolforbTestTask.Data.Models;

public class ReceiptItemView
{
    public Resource Resource { get; set; } = null!;
    public MeasureUnit MeasureUnit { get; set; } = null!;
    public int Quantity { get; set; }
}
