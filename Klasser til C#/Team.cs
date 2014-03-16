using System;


namespace Timeregistreringssystem
{
    class Team
    {
        public Team(int id, String beskrivelse, int teamlederId, String teamleder)
        {
            Id = id;
            Beskrivelse = beskrivelse;
            TeamlederId = teamlederId;
            Teamleder = teamleder;   
        }

        public int Id { get; set; }
        public String Beskrivelse { get; set; }
        public int TeamlederId { get; set; }
        public String Teamleder { get; set; }   
    }
}
