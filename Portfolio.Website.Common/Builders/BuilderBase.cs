using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Common
{
    public abstract class BuilderBase<TResult> where TResult : new()
    {
        protected BuilderBase(TResult @default = default)
        {
            this.Result = @default ?? new TResult();
        }

        public TResult Result { get; }
    }
}
