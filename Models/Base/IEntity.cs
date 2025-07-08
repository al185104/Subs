using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Models.Base;

public interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}
