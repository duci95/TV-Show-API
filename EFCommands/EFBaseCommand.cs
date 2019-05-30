using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.UserCommands
{
    public abstract class EFBaseCommand
    {
        protected TVShowsContext Context { get; }
        //zasto nije public
        protected EFBaseCommand(TVShowsContext context) => Context = context;
        //objasniti
    }
}
