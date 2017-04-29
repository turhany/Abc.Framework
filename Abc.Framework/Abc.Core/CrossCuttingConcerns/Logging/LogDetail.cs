
using System.Collections.Generic;
using FluentNHibernate.Testing.Values;

namespace Abc.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
