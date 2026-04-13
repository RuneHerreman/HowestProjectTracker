var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HowestProjectTracker_Api>("howestprojecttracker");

builder.Build().Run();
