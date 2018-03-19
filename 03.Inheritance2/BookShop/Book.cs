using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get => this.author;
        protected set
        {
            if (value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1 && char.IsDigit(value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    public string Title
    {
        get => this.title;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get => this.price;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Type: {this.GetType().Name}");
        result.AppendLine($"Title: {this.Title}");
        result.AppendLine($"Author: {this.Author}");
        result.AppendLine($"Price: {this.Price:f2}");

        return result.ToString();
    }
}