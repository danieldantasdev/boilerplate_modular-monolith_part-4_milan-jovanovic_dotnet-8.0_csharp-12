﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Modules.Users.Application.Abstractions.Data;
using Modules.Users.Domain.Followers;
using Modules.Users.Domain.Users;

namespace Modules.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    public DbSet<Follower> Followers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }
}