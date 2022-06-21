namespace apiweb_project.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int UserId { get; set; }
    public double? TotalPrice { get; set; }
    public int? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public virtual List<Product> Products {get; set;}

}