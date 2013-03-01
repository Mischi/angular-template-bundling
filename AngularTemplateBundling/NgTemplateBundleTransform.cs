using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace AngularTemplateBundling
{
    public class NgTemplateBundleTransform : IBundleTransform
    {
        private readonly string ngapp;
        private readonly StringBuilder bundledTemplates = new StringBuilder();

        public NgTemplateBundleTransform(string ngapp)
        {
            this.ngapp = ngapp;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            response.Cacheability = HttpCacheability.Public;
            bundledTemplates.Append("angular.module('" + ngapp + "').run(['$templateCache',function(t){");

            if (BundleTable.EnableOptimizations)
            {
                foreach (var file in response.Files)
                {
                    AppendTemplate(file);
                }
            }

            bundledTemplates.Append("}]);");

            response.Content = bundledTemplates.ToString();
            response.ContentType = "application/javascript";
        }

        private void AppendTemplate(FileInfo file)
        {
            using (var reader = file.OpenText())
            {
                var tmplName = Path.Combine(file.Directory.Name, file.Name).Replace("\\", "/");
                var tmpl = reader.ReadToEnd()
                                    .Replace("\r", "").Replace("\n", "") //replace newline
                                    .Replace("\t", ""); //replace tabs

                bundledTemplates.Append(string.Format("t.put('{0}','{1}');", tmplName, tmpl));
            }
        }
    }
}
