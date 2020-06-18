﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Core.Strings;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.Security;

namespace Umbraco.Web.BackOffice.Filters
{
    /// <summary>
    /// Validates the incoming <see cref="MemberSave"/> model
    /// </summary>
    internal sealed class MemberSaveValidationAttribute : TypeFilterAttribute
    {
        public MemberSaveValidationAttribute() : base(typeof(MemberSaveValidationFilter))
        {

        }

        private sealed class MemberSaveValidationFilter : IActionFilter
        {
            private readonly ILogger _logger;
            private readonly IWebSecurity _webSecurity;
            private readonly ILocalizedTextService _textService;
            private readonly IMemberTypeService _memberTypeService;
            private readonly IMemberService _memberService;
            private readonly IShortStringHelper _shortStringHelper;

            public MemberSaveValidationFilter(ILogger logger, IWebSecurity webSecurity, ILocalizedTextService textService, IMemberTypeService memberTypeService, IMemberService memberService, IShortStringHelper shortStringHelper)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _webSecurity = webSecurity ?? throw new ArgumentNullException(nameof(webSecurity));
                _textService = textService ?? throw new ArgumentNullException(nameof(textService));
                _memberTypeService = memberTypeService ?? throw new ArgumentNullException(nameof(memberTypeService));
                _memberService = memberService  ?? throw new ArgumentNullException(nameof(memberService));
                _shortStringHelper = shortStringHelper ?? throw new ArgumentNullException(nameof(shortStringHelper));
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var model = (MemberSave)context.ActionArguments["contentItem"];
                var contentItemValidator = new MemberSaveModelValidator(_logger, _webSecurity, _textService, _memberTypeService, _memberService, _shortStringHelper);
                //now do each validation step
                if (contentItemValidator.ValidateExistingContent(model, context))
                    if (contentItemValidator.ValidateProperties(model, model, context))
                        contentItemValidator.ValidatePropertiesData(model, model, model.PropertyCollectionDto, context.ModelState);
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
            }

        }
    }
}
