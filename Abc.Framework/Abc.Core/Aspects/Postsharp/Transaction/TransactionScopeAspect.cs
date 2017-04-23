using System;
using System.Transactions;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp.Transaction
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        public TransactionScopeAspect()
        {

        }
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        private TransactionScopeOption _option;

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
    }
}
