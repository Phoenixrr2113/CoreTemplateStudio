﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

using CoreTemplateStudio.Api.Extensions.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Templates.Api.Resources;
using Microsoft.Templates.Core;
using Microsoft.Templates.Core.Gen;

namespace Microsoft.Templates.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateGenContextFilter]
    public class ServiceController : Controller
    {
        [HttpGet]
        public ActionResult<List<TemplateInfo>> GetServiceForFrameworks(string projectType, string frontEndFramework, string backEndFramework)
        {
            if (frontEndFramework == null && backEndFramework == null)
            {
                return BadRequest(new { message = StringRes.BadReqNoBackendOrFrontend });
            }

            var platform = GenContext.CurrentPlatform;
            var services = GenContext.ToolBox.Repo.GetTemplatesInfo(
                                                                TemplateType.Service,
                                                                platform,
                                                                projectType,
                                                                frontEndFramework,
                                                                backEndFramework);

            return services.ToList();
        }
    }
}