﻿using System;
using System.Linq;
using Abc.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.FluentValidate(validator, entity);
            }
        }
    }
}