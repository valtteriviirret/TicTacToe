using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// The type of value of a cell where the game is currently
    /// </summary>
    public enum Mark
    {
        /// <summary>
        /// Unclicked cell
        /// </summary>
        Free,
        /// <summary>
        /// Cell = 0
        /// </summary>
        Zero,
        /// <summary>
        /// Cell = X
        /// </summary>
        Cross
    }
}
