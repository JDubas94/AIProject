using DataFile.Models;
using Microsoft.AspNetCore.Identity;
using MyProject.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class NeuralNetworkModel 
    {
        [Key]
        public Guid Id { get; set; }
        //public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        //public NeuralNetworkType TypeNN { get; set; }
        [Required]
        public Guid TypeId { get; set; }

        [NotMapped]
        public StreamFileUploadLocalService DataFile { get; set; }

        [Required]
        [Range(10, 90, ErrorMessage = "Invalid percentage of test data")]
        public uint PersentageTestSet { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Invalid number of epochs")]
        public uint Epochs { get; set; }

        //[Required]
        [Range(1, 1000000, ErrorMessage = "Invalid number of cycles")]
        public uint Cycles { get; set; }

        //[Required]
        [Range(1, 1000000, ErrorMessage = "Invalid number of rules")]
        public uint Rules { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Invalid gradient step value")]
        public double GradientStep { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Invalid threshold error value")]
        public double ThresholdError { get; set; }

        //[Required]
        [Range(1, 1000000, ErrorMessage = "Invalid number of layers")]
        public uint Layers { get; set; }

        //[Required]
        [Range(1, 1000000, ErrorMessage = "Invalid number of newrons layers")]
        public uint NewronsInLayer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}
