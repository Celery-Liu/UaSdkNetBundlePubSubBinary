using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace ConsoleClient
{
    partial class Client
    {
        ClientState FileLoad()
        {
            return ClientState.Connected;
        }

    }
}
