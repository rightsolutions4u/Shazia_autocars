using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class AutosFeatures
    {
        [Key]
        public int AuFeId { get; set; }
        [StringLength(70)]
        [Display(Name = "Features")]
        public string AuDesc { get; set; }
        //Foreign Key
        public int FEATID { get; set; }
        //Foreign Key
        public int AutoId { get; set; }
        //Navigation Property
        //public AutosVehicle AutosVehicle { get; set; }
        public Vehiclefeatures Vehiclefeatures { get; set; }
    }

    //public int Central { get; set; }
    //public int FourWheel{get; set;}
    //public int cruise { get; set; }
    //public int StartStop { get; set; }
    //public int ELWin { get; set; }
    //public int ABS { get; set; }
    //public int ESP { get; set; }
    //public int RoofRack { get; set; }
    //public int TowingDev { get; set; }
    //public int LEDXenon { get; set; }
    //public int LeatherInt { get; set; }
    //public int HeatedSeats { get; set; }
    //public int Navigation { get; set; }
    //public int AppleCarPlay { get; set; }
    //public int BlueTooth { get; set; }
    //public int AndroidAuto { get; set; }
    //public int MirrorLink { get; set; }
    //public int PremAudioSys { get; set; }
    //public int TV { get; set; }
    //public int VoiceControl { get; set; }
    //public int HeadUpDisplay { get; set; }
    //public int VirtualCockPit { get; set; }
    //public int AirCondition { get; set; }
    //public int AutoAirConditioning { get; set; }
    //public int ParkingAssit { get; set; }
    //public int PanoramicRoof { get; set; }
    //public int ElSeats { get; set; }
}
