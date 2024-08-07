using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreed {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColor {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet
    {
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreed breed {get; set;}
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColor color {get; set;}
        public DateTime? checkedInAt {get; set;}
        [ForeignKey("petOwner")]
        public int petOwnerid {get; set;}
        public PetOwner petOwner {get; set;}

        

    }
}
