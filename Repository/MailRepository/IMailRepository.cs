using System;
using Core.RepositoryBase;
using Model.Models;

namespace Repository.MailRepository
{
    public interface IMailRepository : IRepository<MailTo, Guid>
    {
    }
}
