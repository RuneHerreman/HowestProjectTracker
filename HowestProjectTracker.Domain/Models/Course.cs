using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HowestProjectTracker.Domain.Models;

[Table("courses")]
public partial class Course
{
    [Key]
    [Column("courseid")]
    public int CourseId { get; set; }

    [Column("coursename")]
    [StringLength(30)]
    public string? CourseName { get; set; }

    [Column("fee")]
    public int? Fee { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();
}
