namespace GithubExplorer.Interfaces;



/// <summary>
/// Indicates a class is displayable and able to be used as a page in the ui.
/// </summary>
public interface IDisplayable
{
    /// <summary>
    /// Draw this object to the ui.
    /// </summary>
    public void Draw();
}