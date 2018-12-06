using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECOM.Infra.Data.Contexto
{
    public class ContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public DbContext Context
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                {
                     HttpContext.Current.Items[ContextKey] = new EcomContext();
                }
                return (EcomContext) HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
