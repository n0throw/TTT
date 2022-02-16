using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using TicTacToeMVVM.Properties;

namespace TicTacToeMVVM;

public partial class App : Application
{
	private static readonly List<CultureInfo> languages = new();

	public static List<CultureInfo> Languages
	{
		get => languages;
	}

	public static event EventHandler LanguageChanged;

	public static CultureInfo Language
	{
		get => Thread.CurrentThread.CurrentUICulture;
		set
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			if (value == Thread.CurrentThread.CurrentUICulture)
				return;

			Thread.CurrentThread.CurrentUICulture = value;

			ResourceDictionary dict = new();
			dict.Source = value.Name switch
			{
				"ru-RU" => new Uri(string.Format("Resources/LanguageRes.{0}.xaml", value.Name), UriKind.Relative),
				_ => new Uri("Resources/LanguageRes.xaml", UriKind.Relative),
			};


			Current.Resources.MergedDictionaries.Clear();
			Current.Resources.MergedDictionaries.Add(dict);

			LanguageChanged(Current, new EventArgs());
		}
	}

	public App()
	{
		languages.Clear();
		languages.Add(new CultureInfo("en-US"));
		languages.Add(new CultureInfo("ru-RU"));

		LanguageChanged += App_LanguageChanged;

		Language = ApplicationSettings.Default.DefaultLanguage;
	}

	private void App_LanguageChanged(object? sender, EventArgs e)
	{
		ApplicationSettings.Default.DefaultLanguage = Language;
		ApplicationSettings.Default.Save();
	}
}
