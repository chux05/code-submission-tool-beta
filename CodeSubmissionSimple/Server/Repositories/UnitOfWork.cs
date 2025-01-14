﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Server.Data;
using CodeSubmissionSimple.Server.IRepositories;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private ISubmissionRepository _submissions;
        private IGenericRepository<Question> _questions;
        private ICandidateRepo _candidates;
        private IGenericRepository<TestStatus> _testStatuses;
        private IGenericRepository<User> _users;
        private IGenericRepository<AppUser> _appusers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ISubmissionRepository Submissions => _submissions ??= new SubmissionRepository(_context);

        public IGenericRepository<Question> Questions => _questions ??= new GenericRepository<Question>(_context);

        public ICandidateRepo Candidates => _candidates ??= new CandidateRepo(_context);

        public IGenericRepository<TestStatus> TestStatuses => _testStatuses ??= new GenericRepository<TestStatus>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<AppUser> AppUsers => _appusers ??= new GenericRepository<AppUser>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
