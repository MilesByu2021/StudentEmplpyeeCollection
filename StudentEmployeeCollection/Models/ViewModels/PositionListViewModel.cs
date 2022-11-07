using System;
using System.Collections.Generic;

namespace StudentEmployeeCollection.Models.ViewModels
{
    public class PositionListViewModel
    {
        public PositionListViewModel(string group, Position position)
        {
            Group = group;
            Positions = new List<Position>()
            {
                position
            };
        }

        public string Group { get; set; }
        public List<Position> Positions { get; set; }
    }
}
