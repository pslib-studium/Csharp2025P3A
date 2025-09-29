using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02manyToMany.Models
{
    internal enum RoleKind
    {
        Unknown = 0,
        Actor = 1,
        Director,
        Producer,
        Writer,
        Cinematographer,
        Editor,
        Composer,
        CostumeDesigner,
        ProductionDesigner
    }
}
