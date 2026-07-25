namespace SmartPOS.Infrastructure.Services;

using SmartPOS.Contracts.Services;
using SmartPOS.Core.Enums;

/// <summary>
/// A headless implementation of <see cref="ILanguageService" /> that tracks the active language without interacting with a user interface.
/// </summary>
public sealed class NullLanguageService : ILanguageService
{
    private AppLanguage _currentLanguage = AppLanguage.Arabic;

    /// <inheritdoc />
    public AppLanguage CurrentLanguage => _currentLanguage;

    /// <inheritdoc />
    public void ApplyLanguage(AppLanguage language)
    {
        if (_currentLanguage == language)
        {
            return;
        }

        _currentLanguage = language;
        LanguageChanged?.Invoke(this, language);
    }

    /// <inheritdoc />
    public AppLanguage Toggle()
    {
        var next = _currentLanguage == AppLanguage.Arabic ? AppLanguage.English : AppLanguage.Arabic;
        ApplyLanguage(next);
        return next;
    }

    /// <inheritdoc />
    public event EventHandler<AppLanguage>? LanguageChanged;
}
