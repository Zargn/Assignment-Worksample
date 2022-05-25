﻿using System.Text;
using Tiny_Browser.Translation.Translation_objects;
using TinyHtmlReader;

namespace Tiny_Browser.Ui;

public class LoadedWebpage
{
    public List<HtmlHyperlink> Links = new();
    public string Title;

    public LoadedWebpage(List<TinyBrowserHtmlObject> htmlElements)
    {
        int linkId = 0;
        
        var outputString = new StringBuilder();
        
        foreach (var htmlElement in htmlElements)
        {
            htmlElement.OnDraw();
            // Console.WriteLine(htmlElement);
            if (htmlElement is HtmlHyperlink)
            {
                Links.Add(htmlElement as HtmlHyperlink);
            }
            
            // if (htmlElement is HtmlHyperlink)
            //     outputString.Append($"\n[{linkId++}]{htmlElement}");
            // else
            //     outputString.Append($"\n{htmlElement}");
        }
        
        Console.WriteLine(outputString);
    }
}