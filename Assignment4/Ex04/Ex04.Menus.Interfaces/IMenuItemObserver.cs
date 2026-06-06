using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuItemObserver
    {
        void Execute(MenuItem i_MenuItem);
    }
}
