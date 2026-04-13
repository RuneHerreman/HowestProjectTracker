using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowestProjectTracker.Domain.Models;

[Table("students")]
public partial class Student
{
    [Key]
    [Column("studentid")]
    public int StudentId { get; set; }

    [Column("firstname")]
    [StringLength(30)]
    public string? FirstName { get; set; }

    [Column("lastname")]
    [StringLength(30)]
    public string? LastName { get; set; }

    [Column("birthdate")]
    public DateOnly? BirthDate { get; set; }

    [Column("gender")]
    [StringLength(1)]
    public string? Gender { get; set; }

    [Column("paid")]
    public int? Paid { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("penalty")]
    public int? Penalty { get; set; }

    [Column("deleted")]
    public bool? Deleted { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();
}
