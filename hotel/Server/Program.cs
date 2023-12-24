using System.Text;
using Hotel.Server.Data;
using Hotel.Server.Services.EmployeeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Hotel.Server.Services.RoomtypeService;
using Hotel.Server.Services.DepartmentService;
using Hotel.Server.Services.BookingService;
using Hotel.Server.Services.PayMent;
using Hotel.Server.Services.RoomImg;
using Hotel.Server.Services;
using Hotel.Server.Services.Rooms;
using Hotel.Server.Services.Stripe;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text;
using Hotel.Server.Data;
using Hotel.Server.Services.EmployeeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Hotel.Server.Services.RoomtypeService;
using Hotel.Server.Services.DepartmentService;
using Hotel.Server.Services.BookingService;
using Hotel.Server.Services.PayMent;
using Hotel.Server.Services.RoomImg;
using Hotel.Server.Services;
using Hotel.Server.Services.VNPAY;
using Hotel.Server.SignalR;
using Microsoft.AspNetCore.ResponseCompression;
using Hotel.Server.Hubs;
using System.Text.Json.Serialization;
using Hotel.Server.Services.Rooms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<MyDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// VNPAY
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true) // Cho phep tat ca cac origin
               .AllowAnyHeader();
    });
});
// EndVNPAY
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});
//builder.Services.AddSignalRCore();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Employee3
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//RoomType
builder.Services.AddScoped<IRoomTypeService, RoomtypeService>();

//Room
builder.Services.AddHttpClient<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomService, RoomService>();

//Department
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

//RoomType
builder.Services.AddScoped<IRoomTypeService, RoomtypeService>();

//Department
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

//Booking
builder.Services.AddHttpClient<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingService, BookingService>();

//Payment
builder.Services.AddHttpClient<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

//Guest
builder.Services.AddHttpClient<IGuestService, GuestService>();
builder.Services.AddScoped<IGuestService, GuestService>();

//Roomimg
builder.Services.AddHttpClient<IRoomImgService, RoomImgService>();
builder.Services.AddScoped<IRoomImgService, RoomImgService>();

//Room
builder.Services.AddHttpClient<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomService, RoomService>();

//Room
builder.Services.AddHttpClient<IStripePaymentService, StripePaymentService>();
builder.Services.AddScoped<IStripePaymentService, StripePaymentService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["JwtIssuer"],
                ValidAudience = builder.Configuration["JwtAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]!))
            };
        });
builder.Services.AddSwaggerGen();

//Booking
builder.Services.AddHttpClient<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingService, BookingService>();

//Payment
builder.Services.AddHttpClient<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

//Guest
builder.Services.AddHttpClient<IGuestService, GuestService>();
builder.Services.AddScoped<IGuestService, GuestService>();

//Roomimg
builder.Services.AddHttpClient<IRoomImgService, RoomImgService>();
builder.Services.AddScoped<IRoomImgService, RoomImgService>();

//VNPAY
builder.Services.AddScoped<IVnPayService, VnPayService>();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["JwtIssuer"],
                ValidAudience = builder.Configuration["JwtAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]!))
            };
        });
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for Employeeion scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseCors("AllowOrigin");

// VNPAY
app.UseCors("AllowOrigin");
// End VNPAY

//app.UseSignalR(routes =>
//{
//    routes.MapHub<SignalrHub>("/signalr");
//});
app.UseResponseCompression();
//app.MapBlazorHub();
//app.MapHub<ChatHub>("/chathub");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SignalrHub>("/paymentHub");
    endpoints.MapHub<ChatHub>("/chathub");
    // Other endpoints...
});


app.Run();
