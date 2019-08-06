using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace DetoHelpersNetCore.Select2.Data
{
    [HtmlTargetElement("datepicker-jscss")]
    public class DatepickerJsCss : TagHelper
    {
        private readonly IStringLocalizer _localizer;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(context == null || output == null) throw new ArgumentNullException();
            Contract.EndContractBlock();

            var sb = new StringBuilder();

            AppendScript(sb, "https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.js");
            var localizationUrl = _localizer["LocalizationUrl"];
            if(!string.IsNullOrEmpty(localizationUrl))
            {
                AppendScript(sb, localizationUrl);
            }
            AppendScript(sb, "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js");

            sb.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.css\"/>");

            output.Content.AppendHtml(sb.ToString());

        }


        public DatepickerJsCss(IStringLocalizer<Datepicker> localizer)
        {
            if(localizer == null) throw new ArgumentNullException();
            Contract.EndContractBlock();

            _localizer = localizer;
        }


        private void AppendScript(StringBuilder sb, string src)
        {
            Contract.Requires(sb != null && !string.IsNullOrEmpty(src));

            sb.AppendLine($"<script type=\"text/javascript\" src=\"{src}\"></script>");
        }
    }
}