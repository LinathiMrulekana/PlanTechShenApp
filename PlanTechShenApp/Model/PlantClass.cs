using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.Model
{
    internal class PlantClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Waterlevel { get; set; }

        public DateTime CheckDate { get; set; }
    }
}
