using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace AngularTemplateBundling
{
    public class NgTemplateBundle : Bundle
    {
        public NgTemplateBundle(string virtualPath, string ngapp)
            : base(virtualPath, new NgTemplateBundleTransform(ngapp))
        { }
    }
}
