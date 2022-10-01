using SkiaSharp;

HttpClient client = new();

var imageUrl = args.Length != 0 ? args[0] : "https://preview.redd.it/653ztm9yjtg31.jpg?auto=webp&s=da7aeb94db7f956bea0f2a4b1543af4714cbadc4";
var imageBytes = await client.GetByteArrayAsync(imageUrl);
var bitmap = SKBitmap.Decode(imageBytes);

var ratio = (double)bitmap.Width / bitmap.Height;
int width = !(args.Length <= 1) ? Convert.ToInt32(args[1]) : 100;
int height = !(args.Length <= 2) ? Convert.ToInt32(args[2]) : (int)(width / ratio);

SKBitmap resizedImage = new(width, height);
bitmap.ScalePixels(resizedImage, GetFilterQuality(width));

ParallelOptions options = new()
{
    MaxDegreeOfParallelism = Environment.ProcessorCount
};

string[,] outputArr = new string[resizedImage.Height, resizedImage.Width + 1];
Parallel.For(0, resizedImage.Height, options, (heightIndex) =>
{
    for (int widthIndex = 0; widthIndex < resizedImage.Width; widthIndex++)
    {
        outputArr[heightIndex, widthIndex] = GetPrinter(resizedImage.GetPixel(widthIndex, heightIndex));
    }

    outputArr[heightIndex, resizedImage.Width] = Environment.NewLine;
});

string output = "";
for (int h = 0; h < outputArr.GetLength(0); h++)
{
    output = "";
    for (int w = 0; w < outputArr.GetLength(1); w++)
    {
        output += outputArr[h, w];
    }

    Console.Write(output);
}

static string GetPrinter(SKColor color)
{
    var result = $"\u001b[38;2;{color.Red};{color.Green};{color.Blue}m█";
    return result;
}

static SKFilterQuality GetFilterQuality(int width)
{
    if (width <= 100) return SKFilterQuality.Low;
    else if (width <= 500) return SKFilterQuality.Medium;
    else if (width <= 1500) return SKFilterQuality.High;
    else return SKFilterQuality.Low;
}