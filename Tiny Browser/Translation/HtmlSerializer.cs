namespace Tiny_Browser.Translation;

public class HtmlSerializer
{
    public HtmlSerializer(List<ITagHandler> tagHandlers)
    {
        foreach (var tagHandler in tagHandlers)
        {
            this.tagHandlers.Add(tagHandler.Tag, tagHandler);
        }
    }
    
    
    
    // public async Task<List<HtmlObjectBase>> ConvertHtmlToObjects(string htmlString)
    // {
    //     
    // }
    
    

    private Dictionary<string, ITagHandler> tagHandlers = new ();
    
    

    public IEnumerable<HtmlObjectBase> ExtractHtmlObjects(string htmlString)
    {
        for (int i = 0; i < htmlString.Length; i++)
        {
            if (htmlString[i] != '<') continue;
            
            // Check tag type
            var searchIndex = i + 1;
            var tag = GetTag(htmlString, searchIndex, out int endIndex);
            // Console.WriteLine(tag);
            searchIndex = endIndex;

            if (tagHandlers.TryGetValue(tag, out ITagHandler tagHandler))
            {
                var endOfSectionIndex = GetIndexAtEndOfTagSection(htmlString, searchIndex, tagHandler.EndTag);
                yield return tagHandler.GetObjectFromString(htmlString.Substring(i, endOfSectionIndex - i));
                i = endOfSectionIndex;
            }
            else
            {
                i = GetIndexAtEndOfTagBlock(htmlString, searchIndex);
            }
        }
    }
    

    /// <summary>
    /// Gets the html tag at the startindex.
    /// </summary>
    /// <param name="htmlString"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private string GetTag(string htmlString, int startIndex, out int endIndex)
    {
        for (int i = startIndex; i < htmlString.Length; i++)
        {
            char c = htmlString[i];

            if (c != ' ' && c != '>')
                continue;

            endIndex = i;
            return htmlString.Substring(startIndex, endIndex - startIndex);
        }

        throw new Exception($"Unexpected end to tag block! Did the string get cut early? StartIndex:{startIndex}");
    }
    
    
    /// <summary>
    /// Returns a string where the current tag block ends.
    /// </summary>
    /// <param name="htmlString"></param>
    /// <param name="startIndex"></param>
    /// <returns></returns>
    private int GetIndexAtEndOfTagBlock(string htmlString, int startIndex)
    {
        for (int i = startIndex; i < htmlString.Length; i++)
        {
            if (htmlString[i] == '>')
                return i + 1;
        }

        return htmlString.Length;
    }

    
    /// <summary>
    /// Returns the end index of the selected tag.
    /// </summary>
    /// <param name="htmlString"></param>
    /// <param name="startIndex"></param>
    /// <param name="endTag"></param>
    /// <returns></returns>
    /// <exception cref="Exception">if the html file doesn't contain the endTag provided</exception>
    private int GetIndexAtEndOfTagSection(string htmlString, int startIndex, string endTag)
    {
        var result = htmlString.IndexOf(endTag, startIndex, StringComparison.Ordinal);
        if (result == -1)
            throw new Exception(
                $"A end tag matching [{endTag}] was not found! Are your html incomplete or is your translator tags miss configured?");

        // Indexof returns the start of the word, so we add the words length to get the position at the end.
        return result + endTag.Length;
    }
}