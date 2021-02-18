﻿using System.Collections.Generic;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Core.PropertyEditors;
using Umbraco.Extensions;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// Represents the configuration editor for the datetime value editor.
    /// </summary>
    public class DateTimeConfigurationEditor : ConfigurationEditor<DateTimeConfiguration>
    {
        public override IDictionary<string, object> ToValueEditor(object configuration)
        {
            var d = base.ToValueEditor(configuration);

            var format = d["format"].ToString();

            d["pickTime"] = format.ContainsAny(new string[] { "H", "m", "s" });

            return d;
        }

        public DateTimeConfigurationEditor(IIOHelper ioHelper) : base(ioHelper)
        {
        }
    }
}
