using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Common.SwaggerFilters
{
    public class SwaggerFilterForSendingMessage : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.RelativePath.StartsWith("Info"))
                {
                    swaggerDoc.Paths.Remove("/" + apiDescription.RelativePath.TrimEnd('/'));
                }
            }
            foreach (var key in swaggerDoc.Components.Schemas.Keys)
            {
                if (key.Contains("Info") || key.Contains("Statistics"))
                {
                    swaggerDoc.Components.Schemas.Remove(key);
                }
            }
        }
    }
}
