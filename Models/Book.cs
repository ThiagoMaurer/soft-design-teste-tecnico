﻿namespace SoftDesignTesteTecnico.Models; 

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsRented { get; set; }
}
