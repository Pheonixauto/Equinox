using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department
{
    public class DepartmentCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

    }
}
