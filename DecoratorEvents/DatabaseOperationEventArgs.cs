using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorEvents
{
    public class DatabaseOperationEventArgs : EventArgs
    {
        public string OperationName { get; set; }

        public string EntityType { get; set; }

        public int AffectedEntityId { get; set; }
    }
}
