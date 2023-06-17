﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerStatsNew.Models
{
    public class LeagueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string LogoURL { get; set; }
        public string CountryName { get; set; }

        [ForeignKey("Name")]
        public CountryModel Country { get; set; }
    }
}