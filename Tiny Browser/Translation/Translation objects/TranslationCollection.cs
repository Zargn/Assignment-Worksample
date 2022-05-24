namespace Tiny_Browser.Translation.Translation_objects;

public class TranslationCollection
{
    public List<ITagHandler> TagHandlers = new();
    
    public TranslationCollection()
    {
        TagHandlers.Add(new title());
    }
}