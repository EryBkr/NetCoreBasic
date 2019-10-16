using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCore.Models;

namespace TrainingCore.TagHelpers
{
    [HtmlTargetElement("customer-list")]
    public class CustomerListTagHelper:TagHelper
    {
        private List<Customer> _customers;
        public CustomerListTagHelper()
        {
            _customers = new List<Customer>()
            {
                new Customer{Name="Eray",City="İstanbul"},
                new Customer{Name="Berkay",City="İstanbul"},
                new Customer{Name="James",City="New York"}
            };
          
        }

        private const string ListCountAttributeName = "count";
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }

     
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var query = _customers.Take(ListCount);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in query)
            {
                stringBuilder.AppendFormat("<h2><a href='/customer/detail/{0}'>{1}</a></h2>",item.Id,item.Name);
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }


    }
}
