﻿using System;
using AutoMapper;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Mapping;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Services;
using Umbraco.Web.Models.ContentEditing;

namespace Umbraco.Web.Models.Mapping
{
    internal class DataTypeModelMapper : MapperConfiguration
    {
        public override void ConfigureMappings(IConfiguration config, ApplicationContext applicationContext)
        {
            var lazyDataTypeService = new Lazy<IDataTypeService>(() => applicationContext.Services.DataTypeService);

            config.CreateMap<PropertyEditor, PropertyEditorBasic>()
                  .ForMember(basic => basic.EditorId, expression => expression.MapFrom(editor => editor.Id));

            config.CreateMap<PreValueField, PreValueFieldDisplay>();

            config.CreateMap<IDataTypeDefinition, DataTypeDisplay>()
                  .ForMember(display => display.AvailableEditors, expression => expression.ResolveUsing<AvailablePropertyEditorsResolver>())
                  .ForMember(display => display.PreValues, expression => expression.ResolveUsing(
                      new PreValueDisplayResolver(lazyDataTypeService)))
                  .ForMember(display => display.SelectedEditor, expression => expression.MapFrom(definition => definition.ControlId));
        }
    }
}