using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace ClientLight.Services
{
    using ClientLight.Helpers;

    public static class ThemeSelectorService
    {
        private const string SettingsKey = "RequestedTheme";

        public static event EventHandler<ElementTheme> OnThemeChanged = delegate { };

        public static bool IsLightThemeEnabled => Theme == ElementTheme.Light;

        public static ElementTheme Theme { get; set; }

        public static async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync();
        }

        public static async Task SwitchThemeAsync()
        {
            if (Theme == ElementTheme.Dark)
            {
                await SetThemeAsync(ElementTheme.Light);
            }
            else
            {
                await SetThemeAsync(ElementTheme.Dark);
            }
        }

        public static Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;
            SetRequestedTheme();
            return SaveThemeInSettingsAsync(Theme);
        }

        public static void SetRequestedTheme()
        {
            if (!(Window.Current.Content is FrameworkElement frameworkElement)) return;
            frameworkElement.RequestedTheme = Theme;
            OnThemeChanged(null, Theme);
        }

        private static async Task<ElementTheme> LoadThemeFromSettingsAsync()
        {
            ElementTheme cacheTheme = ElementTheme.Light;
            var themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);
            if (string.IsNullOrEmpty(themeName))
            {
                cacheTheme = Application.Current.RequestedTheme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
            }
            else
            {
                Enum.TryParse<ElementTheme>(themeName, out cacheTheme);
            }
            return cacheTheme;
        }

        private static Task SaveThemeInSettingsAsync(ElementTheme theme)
        {
                return ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString());
        }
    }
}
