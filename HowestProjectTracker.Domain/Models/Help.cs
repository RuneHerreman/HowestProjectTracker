using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowestProjectTracker.Domain.Models;

[Table("help")]
public partial class Help
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }
}
