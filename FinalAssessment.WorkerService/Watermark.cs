using System.Drawing;


namespace FinalAssessment.WorkerService
{
 
    public class Watermark : BackgroundService
    {
 
        //image watermarking process.
        //it gets original image path and answers both watermarked image and its path
        public static Tuple<byte[], string> watermarked(string sourceImage)
        {


#pragma warning disable CA1416 // Validate platform compatibility
            Image img = Image.FromFile(sourceImage, true);
#pragma warning restore CA1416 // Validate platform compatibility


#pragma warning disable CA1416 // Validate platform compatibility
            int width = img.Width;
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            int height = img.Height;
#pragma warning restore CA1416 // Validate platform compatibility
            int font_size = (width > height ? height : width) / 9;


            Point text_starting_point = new Point(height / 3, (width / 4));

#pragma warning disable CA1416 // Validate platform compatibility
            Font text_font = new Font("Times New Roman", font_size, FontStyle.Bold, GraphicsUnit.Pixel);
#pragma warning restore CA1416 // Validate platform compatibility


            Color color = Color.FromArgb(255, Color.Gray);
#pragma warning disable CA1416 // Validate platform compatibility
            SolidBrush brush = new SolidBrush(color);
#pragma warning restore CA1416 // Validate platform compatibility


#pragma warning disable CA1416 // Validate platform compatibility
            Graphics graphics = Graphics.FromImage(img);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            graphics.DrawString("www.mysite.com", text_font, brush, text_starting_point);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            graphics.Dispose();
#pragma warning restore CA1416 // Validate platform compatibility



#pragma warning disable CA1416 // Validate platform compatibility
            string watermarked_path = "c:/" + Guid.NewGuid().ToString() + ".jpg";
            img.Save(watermarked_path);
#pragma warning restore CA1416 // Validate platform compatibility

#pragma warning disable CA1416 // Validate platform compatibility
            img.Dispose();
#pragma warning restore CA1416 // Validate platform compatibility

            return Tuple.Create(System.IO.File.ReadAllBytes(watermarked_path), watermarked_path);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }


    }
}
