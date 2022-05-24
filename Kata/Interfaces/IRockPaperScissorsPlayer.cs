using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Interfaces
{
    public interface IRockPaperScissorsPlayer
    {
        // Your name as displayed in match results.
        string Name { get; }

        // Used by playground to notify you that a new match will start.
        void SetNewMatch(string opponentName);

        // Used by playground to get your game shape (values: "R", "P" or "S").
        string GetShape();

        // Used by playground to inform you about the shape your opponent played in the game. 
        void SetOpponentShape(string shape);
    }
}
