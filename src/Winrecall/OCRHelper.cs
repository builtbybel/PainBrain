using Tesseract;
using System;
using System.IO;
using System.Threading.Tasks;

public class OcrHelper
{
    private string tessdataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");  // Path to the tessdata folder
  //  private string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OCRData.txt");  // Path to store OCR logs

    /// <summary>
    /// Extracts text from the given image file using Tesseract OCR asynchronously.
    /// </summary>
    public async Task<string> ExtractTextFromImageAsync(string imagePath)
    {
        // Set the Tesseract model and language
        string language = "eng+deu"; 

        return await Task.Run(() =>
        {
            try
            {
                using (var engine = new TesseractEngine(tessdataFolder, language, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        var result = engine.Process(img, Tesseract.PageSegMode.Auto);
                        string extractedText = result.GetText();

                        // Log the extracted text to a log file
                       // File.AppendAllText(logFilePath, $"[OCR] {DateTime.Now}: {extractedText}\n");

                        return extractedText;  // Return the extracted text
                    }
                }
            }
            catch (Exception ex)
            {
              //  File.AppendAllText(logFilePath, $"[ERROR] {DateTime.Now}: {ex.Message}\n");
                return string.Empty;  // Return empty string if there's an error
            }
        });
    }
}
