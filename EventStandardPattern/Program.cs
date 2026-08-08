class Program
{
    static void Main(string[] args)
    {
        PriceEvent();
    }

    static void PriceEvent()
    {
        // Initializing both the Publisher and Subscriber
        var crypto = new Crypto("BTC");
        var portfolio = new Portfolio("Crypto Portfolio");

        // PortofolioTracking Method is subscribing to PriceChanged Event
        crypto.PriceChanged += portfolio.PortfolioTracking;

        Console.WriteLine("Tracking...");

        // Change the Price properties to trigger the event
        crypto.Price = 500;
        crypto.Price = 550;
        crypto.Price = 520;
    }
}

// kind of container of the data sent to subsriber
class PriceChangedEventArgs : EventArgs
{
    public string Symbol { get; }
    public decimal OldPrice { get; }
    public decimal NewPrice { get; }
    public decimal PercentChanged =>
        OldPrice == 0 ? 0 : Math.Abs((NewPrice - OldPrice) / OldPrice * 100);

    public DateTime Timestamp { get; }

    public PriceChangedEventArgs(
        string symbol,
        decimal oldPrice,
        decimal newPrice)
    {
        Symbol = symbol;
        OldPrice = oldPrice;
        NewPrice = newPrice;
        Timestamp = DateTime.Now;
    }
}

class Crypto
{
    private decimal _price;

    public string Symbol { get; }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                decimal oldPrice = _price;
                _price = value;

                OnPriceChanged(
                    new PriceChangedEventArgs(
                        Symbol,
                        oldPrice,
                        _price));
            }
        }
    }

    public event EventHandler<PriceChangedEventArgs>? PriceChanged;

    public Crypto(string symbol)
    {
        Symbol = symbol;
    }

    protected virtual void OnPriceChanged(
        PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
}

class Portfolio
{
    public string Name { get; }

    public Portfolio(string name)
    {
        Name = name;
    }

    public void PortfolioTracking(
        object? sender,
        PriceChangedEventArgs e)
    {
        var direction = e.NewPrice > e.OldPrice
            ? "↑"
            : "↓";

        Console.WriteLine($"Portfolio: {Name}");
        Console.WriteLine($"Crypto   : {e.Symbol}");
        Console.WriteLine(
            $"Price    : {direction} ${e.OldPrice:F2} → " +
            $"${e.NewPrice:F2} ({e.PercentChanged:F2}%)");
        Console.WriteLine(
            $"Time     : {e.Timestamp:dd-MM-yyyy HH:mm:ss}");
        Console.WriteLine();
    }
}