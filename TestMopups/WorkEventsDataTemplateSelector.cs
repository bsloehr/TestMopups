using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMopups
{
    public class WorkEventsDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _workEventCell = new(typeof(WorkEventCell));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is WorkEventViewModel)
            {
                return _workEventCell;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
