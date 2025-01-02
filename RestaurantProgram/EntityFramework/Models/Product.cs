namespace RestaurantProgram.EntityFramework.Models;

/// <summary>
/// Описание таблицы продуктов
/// </summary>
public class Product
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Сomposition { get; init; }
    public decimal? Price { get; init; }
    public int MenuId { get; init; }
    public virtual Menu Menu { get; init; }
}