dotnet ef dbcontext scaffold "Server=tcp:YOUR_SERVER;Database=YOUR_DATABASE;User ID=YOUR_USER;Password=YOUR_PASSWORD;" Microsoft.EntityFrameworkCore.SqlServer -c AppDbContext -f -o Models

pause