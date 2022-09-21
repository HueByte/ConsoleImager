using SkiaSharp;

HttpClient client = new();

var imageUrl = args[0];
int width = args.Length != 0 ? Convert.ToInt32(args[1]) : 100;
int height = Convert.ToInt32(width * 0.5);

var imageBytes = await client.GetByteArrayAsync(imageUrl);
var bitmap = SKBitmap.Decode(imageBytes);

SKBitmap resizedImage = new(width, height);
bitmap.ScalePixels(resizedImage, SKFilterQuality.Low);

for (int h = 0; h < resizedImage.Height; h++)
{
    string line = "";
    for (int w = 0; w < resizedImage.Width; w++)
    {
        var pixel = resizedImage.GetPixel(w, h);
        line += GetPrinter(new SKColor(pixel.Red, pixel.Green, pixel.Blue));
    }
    Console.WriteLine(line);
    await Task.Delay(15);
}

static string GetPrinter(SKColor color)
{
    var result = $"\u001b[38;2;{color.Red};{color.Green};{color.Blue}m█";
    return result;
}