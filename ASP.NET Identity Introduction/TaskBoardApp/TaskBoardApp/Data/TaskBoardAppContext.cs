using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppContext : IdentityDbContext
    {
        public TaskBoardAppContext(DbContextOptions<TaskBoardAppContext> options)
            : base(options)
        {
        }

        private IdentityUser TestUser { get; set; }

        private Board OpenBoard { get; set; }

        private Board InProgressBoard { get; set; }

        private Board DoneBoard { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            builder.Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder.Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                    CreatedOn = DateTime.Now.AddDays(-100),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id,
                }, new Task()
                {
                    Id = 2,
                    Title = "Test2",
                    Description = "Test2",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
					BoardId = InProgressBoard.Id,
                }, new Task()
                {
                    Id = 3,
                    Title = "Test3",
                    Description = "Test3",
                    CreatedOn = DateTime.Now.AddDays(-300),
                    OwnerId = TestUser.Id,
					BoardId = DoneBoard.Id,
                }, new Task()
                {
                    Id = 4,
                    Title = "Test4",
                    Description = "Test4",
                    CreatedOn = DateTime.Now.AddYears(-3),
                    OwnerId = TestUser.Id,
					BoardId = DoneBoard.Id,
                });


            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.TestUser = new IdentityUser()
            {
                UserName = "testuser@gmail.com",
                NormalizedUserName = "TESTUSER@GMAIL.COM"
            };

            this.TestUser.PasswordHash = hasher.HashPassword(TestUser, "pass123");
        }
    }
}