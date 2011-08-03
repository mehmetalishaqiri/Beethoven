using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Beethoven.Plugins.Widgets;
namespace Beethoven.Plugins.HtmlHelpers
{
    public static class DashboardHelper
    {
        public static MvcHtmlString Dashboard(this HtmlHelper helper, IEnumerable<Widget> widgets, int columns)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<div id=\"columns\">");

            for (int i = 0; i < columns; i++)
            {
                builder.AppendFormat("<ul id=\"column{0}\" data-id=\"{0}\" class=\"column\">", i);

                if (widgets != null)
                {
                    foreach (var item in widgets.Where(w => w.Column == i).OrderBy(w => w.Position))
                    {
                        builder.Append(System.Web.Mvc.Html.PartialExtensions.Partial(helper, "_WidgetContainer", item));

                        /*builder.AppendFormat("<li class=\"widget\" id=\"{0}\" data-column=\"{1}\" data-position=\"{2}\">", item.Name, i, item.Column);
                        
                        //HEADER
                        builder.Append("<div class=\"widget-head ui-widget-header\">");
                        builder.AppendFormat("<h3>{0}</h3>", item.Name); //Should be changed to title
                        builder.Append("</div>");

                        //BODY
                        builder.AppendFormat("<div class=\"widget-content ui-widget-content\" style=\"display:{0}\">", item.Collapsed ? "none" : "block");
                        builder.Append(System.Web.Mvc.Html.ChildActionExtensions.Action(helper, "Index", item.Name));
                        builder.Append("</div>");

                        builder.Append("</li>");*/
                    }
                }

                builder.Append("</ul>");
            }

            builder.Append("</div>");

            return new MvcHtmlString(builder.ToString());
        }
    }
}
