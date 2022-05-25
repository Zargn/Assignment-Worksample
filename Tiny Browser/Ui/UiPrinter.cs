using Tiny_Browser.Translation.Translation_objects;
using TinyHtmlReader;

namespace Tiny_Browser.Ui;

public class UiPrinter
{
    public void PrintWebpage(List<HtmlObjectBase> htmlElements)
    {
        foreach (var htmlElement in htmlElements)
        {
            Console.WriteLine(htmlElement);
            
            if (htmlElement is HtmlTitle)
                Console.WriteLine("YAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYAYA");
            if (htmlElement is HtmlHyperlink)
                Console.WriteLine("LINKLINKLINKLINK");
        }
    }
}