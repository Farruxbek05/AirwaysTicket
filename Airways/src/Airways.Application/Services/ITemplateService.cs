namespace Airways.Application.Services
{
    public interface ITemplateService
    {
        Task<string> GetTemplateAsync(string templateName);

        string ReplaceInTemplate(string input, IDictionary<string, string> replaceWords);
    }
}
