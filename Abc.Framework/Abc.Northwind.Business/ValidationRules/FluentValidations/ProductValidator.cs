using Abc.Northwind.Entities.Concrete;
using FluentValidation;

namespace Abc.Northwind.Business.ValidationRules.FluentValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(0).When(p => p.CategoryId == 1);
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.UnitsInStock).GreaterThan((short)0);

            //Custom validation rule tanımlaması
            //RuleFor(p => p.ProductName).Must(StartWithA);
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
