using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Các dịch vụ khác như DbContext, Swagger, v.v.
builder.Services.AddDbContext<BanMoHinh>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Cấu hình JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });


// Cấu hình Authorization (Phân quyền)
builder.Services.AddAuthorization(options =>
{
    // Chính sách dành cho Quản trị viên (Admin)
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("1"));

    // Chính sách dành cho Khách hàng (Customer)
    options.AddPolicy("CustomerPolicy", policy => policy.RequireRole("0", "1") );
});



// Đăng ký các Repository và Service thông qua Extension Method
builder.Services.AddScoped<ICTDonHangService, CTDonHangService>();
builder.Services.AddScoped<ICTDonHangRepository, CTDonHangRepository>();

builder.Services.AddScoped<ICTDonNhapService, CTDonNhapService>();
builder.Services.AddScoped<ICTDonNhapRepository, CTDonNhapRepository>();

builder.Services.AddScoped<IDonHangService, DonHangService>();
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>();

builder.Services.AddScoped<IDonNhapService, DonNhapService>();
builder.Services.AddScoped<IDonNhapRepository, DonNhapRepository>();

builder.Services.AddScoped<IKhachHangService, KhachHangService>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();

builder.Services.AddScoped<IKhoService, KhoService>();
builder.Services.AddScoped<IKhoRepository, KhoRepository>();

builder.Services.AddScoped<ILoaiService, LoaiService>();
builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();

builder.Services.AddScoped<INCCService, NCCService>();
builder.Services.AddScoped<INCCRepository, NCCRepository>();

builder.Services.AddScoped<INguoiDungService, NguoiDungService>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

builder.Services.AddScoped<ISanPhamService, SanPhamService>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();

builder.Services.AddScoped<IThanhToanService, ThanhToanService>();
builder.Services.AddScoped<IThanhToanRepository, ThanhToanRepository>();


// Add services to the container
builder.Services.AddControllers();


// Swagger/OpenAPI
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter the token in the format: Bearer {your_token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Logging configuration
builder.Logging.AddConsole();

var app = builder.Build();



// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
