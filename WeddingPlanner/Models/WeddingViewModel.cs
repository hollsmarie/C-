using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
  public class WeddingViewModel : BaseEntity
  {
    [Required]
    public string WedderOne { get; set; }

    [Required]
    public string WedderTwo { get; set; }

    [Required]
    [PastDate]
    public DateTime WeddingDate { get; set; }

    [Required]
    public string Address { get; set; }
  }
}