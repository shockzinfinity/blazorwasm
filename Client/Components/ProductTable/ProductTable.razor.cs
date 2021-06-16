using blazorwasm.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorwasm.Client.Components.ProductTable
{
  public partial class ProductTable
  {
    [Parameter] public List<Product> Products { get; set; }
  }
}
