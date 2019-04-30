// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using EnterpriseBot2.ServiceClients;
using Microsoft.Bot.Builder;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseBot2.Middleware
{
    public class SetLocaleMiddleware : IMiddleware
    {
        private readonly string defaultLocale;
        static CultureInfo currentLang = new CultureInfo("en-US");

        public SetLocaleMiddleware(string defaultDefaultLocale)
        {
            defaultLocale = defaultDefaultLocale;
            currentLang = new CultureInfo(defaultLocale);
        }

        public async Task OnTurnAsync(ITurnContext context, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {

            ////method 1 - Locale
            //var cultureInfo = !string.IsNullOrWhiteSpace(context.Activity.Locale) ? new CultureInfo(context.Activity.Locale) : new CultureInfo(defaultLocale);
            //CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture = cultureInfo;

            ////end

            //start of 2 & 3
            CultureInfo cultureInfo = currentLang;

            //method 2 - Language Detection of text analytics
            if (!string.IsNullOrWhiteSpace(context.Activity.Text))
            {
                var language = await LanguageDetectionService.DetectAsync(context.Activity.Text);
                cultureInfo = new CultureInfo(language);
            }

            //////method 3 - switching by keyword
            //if (!string.IsNullOrWhiteSpace(context.Activity.Text) && (
            //    context.Activity.Text == "en" || context.Activity.Text == "zh" || context.Activity.Text == "de" || context.Activity.Text == "es"
            //     || context.Activity.Text == "it" || context.Activity.Text == "fr"))
            //{
            //    switch (context.Activity.Text.ToLower())
            //    {
            //        case "en":
            //            cultureInfo = new CultureInfo("en-US");
            //            break;
            //        case "zh":
            //            cultureInfo = new CultureInfo("zh");
            //            break;
            //        case "de":
            //            cultureInfo = new CultureInfo("de-de");
            //            break;
            //        case "es":
            //            cultureInfo = new CultureInfo("es-es");
            //            break;
            //        case "it":
            //            cultureInfo = new CultureInfo("it-it");
            //            break;
            //        case "fr":
            //            cultureInfo = new CultureInfo("it-it");
            //            break;
            //        default:
            //            cultureInfo = new CultureInfo("en-US");
            //            break;
            //    }
            //}
            ////end of method 3

            context.Activity.Locale = cultureInfo.Name;
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture = currentLang = cultureInfo;
            //end of 2 & 3
            await next(cancellationToken).ConfigureAwait(false);
        }
    }
}
