using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowestProjectTracker.Domain.Models;

[Table("students_courses")]
public partial class StudentsCourse
{
    [Key]
    [Column("studentid")]
    public int StudentId { get; set; }

    [Key]
    [Column("courseid")]
    public int CourseId { get; set; }

    [Column("deleted")]
    public bool? Deleted { get; set; }

    [ForeignKey("Courseid")]
    [InverseProperty("StudentsCourses")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("Studentid")]
    [InverseProperty("StudentsCourses")]
    public virtual Student Student { get; set; } = null!;
}
