using WebErebor.Application;
using BuisnessLogic.Repositories;
using WebErebor.Repositories;
using BuisnessLogic.Services;
using BuisnessLogic.Observer;
using WebErebor.Observer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<ILectorRepository, LectorRepository>();

builder.Services.AddScoped<AttendanceReportService, AttendanceReportService>();

builder.Services.AddScoped<EmailAttendanceObserverImpl>();
builder.Services.AddScoped<SmsAttendanceObserverImpl>();
builder.Services.AddScoped<AttendanceObserverService>(a => new AttendanceObserverService(
	a.GetRequiredService<IAttendanceRepository>(), new List<IAttendanceObserver> {
		a.GetRequiredService<SmsAttendanceObserverImpl>(),
		a.GetRequiredService<EmailAttendanceObserverImpl>(),
	}));

var app = builder.Build();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
