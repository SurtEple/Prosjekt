using System;


namespace Timeregistreringssystem
{
    class Team
    {
        public Team()
        {
            TeamLeder = null;
            Beskrivelse = null;
        }

        public Team(int id, int teamlederId, String teamLeder, String beskrivelse)
        {
            Id = id;
            TeamLederId = teamlederId;
            TeamLeder = teamLeder;
            Beskrivelse = beskrivelse;
        }
        public int Id { get; set; }
        public int TeamLederId { get; set; }
        public String TeamLeder { get; set; }
        public String Beskrivelse { get; set; }
    }
}
