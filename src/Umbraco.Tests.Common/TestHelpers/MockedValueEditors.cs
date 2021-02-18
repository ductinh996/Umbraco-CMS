// Copyright (c) Umbraco.
// See LICENSE for more details.

using Moq;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Core.Serialization;

namespace Umbraco.Cms.Tests.Common.TestHelpers
{
    public class MockedValueEditors
    {
        public static DataValueEditor CreateDataValueEditor(string name)
        {
            var valueType = ValueTypes.IsValue(name) ? name : ValueTypes.String;

            return new DataValueEditor(
                Mock.Of<IDataTypeService>(),
                Mock.Of<ILocalizationService>(),
                Mock.Of<ILocalizedTextService>(),
                Mock.Of<IShortStringHelper>(),
                new JsonNetSerializer(),
                new DataEditorAttribute(name, name, name)
                {
                    ValueType = valueType
                });
        }
    }
}
