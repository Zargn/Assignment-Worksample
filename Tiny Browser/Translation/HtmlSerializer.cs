namespace Tiny_Browser.Translation;

public class HtmlSerializer
{
    // public HtmlSerializer(list)
    // {
    //     
    // }
    
    
    
    public static async Task<List<HtmlObject>> ConvertHtmlToObjects(string htmlString)
    {
        throw new NotImplementedException();
    }
    
    

    private Dictionary<string, Action> tagAction = new ();
    
    

    private IEnumerable<HtmlObject> ExtractHtmlObjects(string htmlString)
    {
        for (int i = 0; i < htmlString.Length; i++)
        {
            if (htmlString[i] == '<')
            {
                // Check tag type
                i++;
                string tag = GetTag(htmlString, i, out int endIndex);
                i = endIndex;

                if (tagAction.TryGetValue(tag, out Action action))
                {
                    
                }
                else
                {
                    i = GetIndexAtEndOfTagBlock(htmlString, i);
                }


                // Compare if tag type is know

                // if known do appropriate action


                // yield return ReadSection(ref htmlString, i, out int endIndex);
                // i = endIndex;
            }
        }

        throw new NotImplementedException();
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
            if (htmlString[i] is not ' ' or '>')
                continue;

            endIndex = i;
            return htmlString.Substring(startIndex, endIndex - startIndex);
        }

        throw new Exception("Unexpected end to tag block! Did the string get cut early?");
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
}