
using System;
using System.ComponentModel.DataAnnotations;

namespace DataFile.Models
{
    public class NeuralNetworkType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code{ get; set; }

        [Required]
        public string Name { get; set; }
    }
}
