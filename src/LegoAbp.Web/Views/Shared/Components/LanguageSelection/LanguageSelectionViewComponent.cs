using Abp.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LegoAbp.Web.Views.Shared.Components.LanguageSelection
{
    public class LanguageSelectionViewComponent : ViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public LanguageSelectionViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages(),
                CurrentUrl = Request.Path
            };
            await Task.CompletedTask;
            return View(model);
        }
    }
}
