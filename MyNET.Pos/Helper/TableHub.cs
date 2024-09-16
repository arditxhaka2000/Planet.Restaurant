using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos.Helper
{
    public class TableHub: Hub
    {
        public void UpdateTable(string tableId, string color)
        {
            Clients.All.updateTableColor(tableId, color);
        }
    }
}
